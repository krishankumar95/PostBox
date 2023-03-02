using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PostBox.Common.DataAccess.DAL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PostBox.Integration.Sample.API.Controllers
{
   

    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        IPostboxMessageRepository messageRepository;
        public ValuesController(IPostboxMessageRepository repo)
        {
            messageRepository = repo;
        }

        // GET: api/values
        [HttpGet()]
        public ActionResult GetAllFromRepo()
        {
            var msgs = messageRepository.GetAllMessages();
            List<string> decoded = new List<string>();
            foreach(var msg in msgs)
            {
                var str = Encoding.UTF8.GetString(msg.MessageBody);
                decoded.Add(str);
            }
            return Ok(decoded);
        }
    }
}

