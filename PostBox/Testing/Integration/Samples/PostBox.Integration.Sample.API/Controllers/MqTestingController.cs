﻿using Microsoft.AspNetCore.Mvc;
using PostBox.Common.Core;
using PostBox.Common.DataAccess.DAL;
using PostBox.Outbound.Ingestion.Interface;

namespace PostBox.Integration.Sample.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MqTestingController : ControllerBase
    {
        private readonly IPostboxOutboundIngestor<WeatherForecast> _rabbitMqPublisher;

        public MqTestingController(IPostboxOutboundIngestor<WeatherForecast> ingestor) 
        {
            _rabbitMqPublisher = ingestor;
        }
        [HttpGet(Name = "PublishOnMq")]
        public async Task<ActionResult> PublishOnMq(int id)
        {
            var entityToPublishTo = "hello";
            var deliveryParams = new DeliveryParameters(MessagingEntityType.Queue, entityToPublishTo);

            var msg = new WeatherForecast { Summary = $"Just a test message{id}" };

            await _rabbitMqPublisher.PublishMessage(msg, deliveryParams);
            return Ok();
        }

       




    }
}
