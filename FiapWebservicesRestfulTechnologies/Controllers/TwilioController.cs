using FiapWebservicesRestfulTechnologies.Model;
using FiapWebservicesRestfulTechnologies.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace FiapWebservicesRestfulTechnologies.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Authorize("Bearer")]
    [Route("api/v1/[controller]")]
    public class TwilioController : ControllerBase
    {
       
        [HttpPost]
        [ProducesResponseType((200))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Route("sms")]
        public IActionResult SendSms()
        {
            var accountSid = "AC390f0cfe0707a069223009ca9b53fa9b";
            var authToken = "dfd29d7e65108b7b0040cbd1202c80fd";
            TwilioClient.Init(accountSid, authToken);

            var messageOptions = new CreateMessageOptions(new PhoneNumber("+5511981825396"));
            messageOptions.MessagingServiceSid = "MG6f11e1fdfda3c2fb2ddc7e96b9d99b17";
            messageOptions.Body = "Olá Marco, trabalho CANVAS entregue. Agora vamos terminar o de WEBSERVICES.";

            var message = MessageResource.Create(messageOptions);
            Console.WriteLine(message.Body);

            return Ok(message.Body);
        }

    }
}
