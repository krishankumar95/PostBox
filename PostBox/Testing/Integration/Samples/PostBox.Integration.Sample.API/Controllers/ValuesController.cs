using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PostBox.Common.DataAccess.DAL;
using PostBox.Outbound.Relayer.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PostBox.Integration.Sample.API.Controllers
{
   

    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        IPostboxMessageRepository messageRepository;
        IPostboxOutboundRelayer outboundRelayer;
        public ValuesController(IPostboxMessageRepository repo, IPostboxOutboundRelayer relayer)
        {
            messageRepository = repo;
            outboundRelayer = relayer;
        }

        // GET: api/values
        [HttpGet()]
        public async Task<ActionResult> GetAllFromRepo()
        {
            var msgs = messageRepository.GetAllMessages();
            List<string> decoded = new List<string>();
            foreach(var msg in msgs)
            {
                var str = Encoding.UTF8.GetString(msg.MessageBody);
                decoded.Add(str);
            }
            await outboundRelayer.ExecuteAsync();
            return Ok(decoded);
        }
    }
}

