using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OfflineMessagingAPI.Helpers;
using OfflineMessagingAPI.Models;
using OfflineMessagingAPI.Services;

namespace OfflineMessagingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagingController : ControllerBase
    {
        private readonly ICustomUserServices _customUserServices;

        #region Constructer
        public MessagingController(ICustomUserServices customUserServices)
        {
            _customUserServices = customUserServices;
        } 
        #endregion

        //// POST api/messsaging/CreateCustomUser 
        [HttpPost]
        [Route("CreateCustomUser")]
        public ActionResult<CustomUser> CreateCustomUser(CustomUser customUser)
        {
            var createdCustomUser = _customUserServices.CreateCustomUser(customUser);

            if(createdCustomUser == null)
            {
                return NotFound();
            }

            return createdCustomUser;
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult<CustomUser> LoginCustomUser(LoginInfo loginInfo)
        {
            var customUser = _customUserServices.LoginCustomUser(loginInfo);

            if(customUser == null)
            {
                return NotFound();
            }

            return customUser;
        }


        [HttpPost]
        [Route("SendMessage")]
        public bool SendMessage(MessageInfo messageInfo)
        {
            bool IsSendMessage = _customUserServices.SendMessage(messageInfo);

            return IsSendMessage;
        }

        // GET api/messaging/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/messaging
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/messaging/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/messaging/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
