using Microsoft.AspNetCore.Mvc;
using PostBox.Integration.Sample.API.MQ;

namespace PostBox.Integration.Sample.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MqTestingController : ControllerBase
    {
        private readonly RabbitMqPublisher _rabbitMqPublisher;
        public MqTestingController() 
        { 
            _rabbitMqPublisher= new RabbitMqPublisher();
        }
        [HttpGet(Name = "PublishOnRabbitMq")]
        public ActionResult PublishOnRabbitMq(int id)
        {
            _rabbitMqPublisher.SendMessage();
            return Ok();
        }


    }
}
