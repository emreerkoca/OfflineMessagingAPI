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
        #region Fields
        private readonly ICustomUserServices _customUserServices;
        #endregion

        #region Constructor
        public MessagingController(ICustomUserServices customUserServices)
        {
            _customUserServices = customUserServices;
        }
        #endregion

        #region CreateCustomUser
        //// POST api/messsaging/CreateCustomUser 
        [HttpPost]
        [Route("CreateCustomUser")]
        public ActionResult<CustomUser> CreateCustomUser(CustomUser customUser)
        {
            var createdCustomUser = _customUserServices.CreateCustomUser(customUser);

            if (createdCustomUser == null)
            {
                return NotFound();
            }

            return createdCustomUser;
        }
        #endregion

        #region LoginCustomUser
        [HttpPost]
        [Route("Login")]
        public ActionResult<CustomUser> LoginCustomUser(LoginInfo loginInfo)
        {
            var customUser = _customUserServices.LoginCustomUser(loginInfo);

            if (customUser == null)
            {
                return NotFound();
            }

            return customUser;
        }
        #endregion

        #region SendMessage
        [HttpPost]
        [Route("SendMessage")]
        public bool SendMessage(MessageInfo messageInfo)
        {
            bool IsSendMessage = _customUserServices.SendMessage(messageInfo);

            return IsSendMessage;
        }
        #endregion

        #region InsertActivityLog
        public ActivityLogs InsertActivityLog(ActivityLogs activityLog)
        {
            return _customUserServices.InsertActivityLog(activityLog);
        }
        #endregion

        #region GetAllChats
        [HttpGet]
        [Route("GetAllChats/{customUserId}")]
        public List<List<Messages>> GetAllChats(int customUserId)
        {
            UsersAllChats usersAllChats = new UsersAllChats();
            usersAllChats.AllChats = _customUserServices.GetAllChats(customUserId);

            return usersAllChats.AllChats;
        }
        #endregion

        #region BlockUser
        [HttpGet]

        public void BlockUser(BlockUser blockUser)
        {
            _customUserServices.BlockUser(blockUser);
        }
        #endregion
    }
}
