using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OfflineMessagingAPI.DataContext;
using OfflineMessagingAPI.Helpers;
using OfflineMessagingAPI.Models;

namespace OfflineMessagingAPI.Services
{
    public class CustomUserServices : ICustomUserServices
    {
        #region Fields
        private readonly OfflineMessagingDbContext _offlineMessagingDbContext;
        #endregion

        #region Constructor
        public CustomUserServices(OfflineMessagingDbContext offlineMessagingDbContext)
        {
            _offlineMessagingDbContext = offlineMessagingDbContext;
        }
        #endregion

        #region CreateCustomUser
        public CustomUser CreateCustomUser(CustomUser customUser)
        {
            try
            {
                var userControl = _offlineMessagingDbContext.CustomUsers.Where(x => x.UserName == customUser.UserName || x.Email == customUser.Email).FirstOrDefault();

                if (userControl != null)
                {
                    return null;
                }

                CustomUser addCustomUser = new CustomUser();
                addCustomUser.FirstName = customUser.FirstName;
                addCustomUser.LastName = customUser.LastName;
                addCustomUser.UserName = customUser.UserName;
                addCustomUser.Email = customUser.Email;
                addCustomUser.Password = customUser.Password;
                addCustomUser.IsActive = customUser.IsActive;
                addCustomUser.LastLoginTime = customUser.LastLoginTime;
                addCustomUser.UploadDate = customUser.UploadDate;

                _offlineMessagingDbContext.CustomUsers.Add(addCustomUser);
                _offlineMessagingDbContext.SaveChanges();

                return addCustomUser;
            }
            catch (Exception ex)
            {
                PublicLogs publicLog = new PublicLogs();
                publicLog.LogContent = ex.ToString();
                publicLog.LogTime = DateTime.Now;
                InsertPublicLog(publicLog);
                return null;
            }
        } 
        #endregion

        #region GetAllChats
        public List<List<Messages>> GetAllChats(int customUserId)
        {
            try
            {
                List<Chats> chatsInfo = _offlineMessagingDbContext.Chats.Where(x => x.SenderId == customUserId || x.ReceiverId == customUserId).ToList();
                UsersAllChats usersAllChats = new UsersAllChats();

                if (chatsInfo != null)
                {
                    foreach (var chatInfo in chatsInfo)
                    {
                        List<Messages> messages = _offlineMessagingDbContext.Messages.Where(x => x.Chat.Id == chatInfo.Id && ((chatInfo.SenderId == customUserId && x.UploadDate >= chatInfo.SenderDeleteTime) || (chatInfo.ReceiverId == customUserId && x.UploadDate >= chatInfo.ReceiverDeleteTime))).ToList();
                        usersAllChats.AllChats.Add(messages);
                    }
                }

                return usersAllChats.AllChats;
            }
            catch (Exception ex)
            {
                PublicLogs publicLog = new PublicLogs();
                publicLog.LogContent = ex.ToString();
                publicLog.LogTime = DateTime.Now;
                InsertPublicLog(publicLog);
                return null;
            }
        } 
        #endregion

        #region InsertActivityLog
        public ActivityLogs InsertActivityLog(ActivityLogs activityLog)
        {
            try
            {
                _offlineMessagingDbContext.ActivityLogs.Add(activityLog);
                _offlineMessagingDbContext.SaveChanges();
                return activityLog;
            }
            catch (Exception ex)
            {
                PublicLogs publicLog = new PublicLogs();
                publicLog.LogContent = ex.ToString();
                publicLog.LogTime = DateTime.Now;
                InsertPublicLog(publicLog);
                return null;
            }
        } 
        #endregion

        #region InsertPublicLog
        public void InsertPublicLog(PublicLogs publicLog)
        {
            _offlineMessagingDbContext.PublicLogs.Add(publicLog);
            _offlineMessagingDbContext.SaveChanges();
        } 
        #endregion

        #region IsOnline
        public CustomUser IsOnline(string userName)
        {
            try
            {
                var userDb = _offlineMessagingDbContext.CustomUsers.Where(x => x.UserName == userName && x.IsOnline).FirstOrDefault();

                return userDb;
            }
            catch (Exception ex)
            {
                PublicLogs publicLog = new PublicLogs();
                publicLog.LogContent = ex.ToString();
                publicLog.LogTime = DateTime.Now;
                InsertPublicLog(publicLog);
                return null;
            }
        } 
        #endregion

        #region LoginCustomUser
        public CustomUser LoginCustomUser(LoginInfo loginInfo)
        {
            try
            {
                var customUser = _offlineMessagingDbContext.CustomUsers.Where(x => (x.Email == loginInfo.UserNameOrEmail || x.UserName == loginInfo.UserNameOrEmail) && x.Password == loginInfo.Md5Password && x.IsActive == true).FirstOrDefault();


                customUser.IsOnline = true;
                _offlineMessagingDbContext.CustomUsers.Update(customUser);
                _offlineMessagingDbContext.SaveChanges();

                return customUser;
            }
            catch (Exception ex)
            {
                PublicLogs publicLog = new PublicLogs();
                publicLog.LogContent = ex.ToString();
                publicLog.LogTime = DateTime.Now;
                InsertPublicLog(publicLog);
                return null;
            }
        } 
        #endregion

        #region SendMessage
        public bool SendMessage(MessageInfo messageInfo)
        {
            try
            {
                var senderUser = IsOnline(messageInfo.SenderUserName);
                var receiverUser = _offlineMessagingDbContext.CustomUsers.Where(x => x.UserName == messageInfo.ReceiverUserName).FirstOrDefault();

                if (senderUser != null && receiverUser != null)
                {
                    Chats chat = new Chats();

                    var dbChat = _offlineMessagingDbContext.Chats.Where(x => (x.SenderId == senderUser.ID || x.SenderId == receiverUser.ID) && (x.ReceiverId == receiverUser.ID || x.ReceiverId == senderUser.ID)).FirstOrDefault();
                    if (dbChat == null)
                    {
                        chat.SenderId = senderUser.ID;
                        chat.ReceiverId = receiverUser.ID;
                        chat.SenderDeleteTime = DateTime.Now;
                        chat.ReceiverDeleteTime = DateTime.Now;
                        _offlineMessagingDbContext.Chats.Add(chat);
                        _offlineMessagingDbContext.SaveChanges();
                    }

                    Messages message = new Messages();
                    message.SenderId = senderUser.ID;
                    message.ReceiverId = receiverUser.ID;
                    message.MessageContent = messageInfo.MessageContent;
                    message.UploadDate = DateTime.Now;
                    message.Chat = dbChat != null ? dbChat : chat;

                    _offlineMessagingDbContext.Messages.Add(message);
                    _offlineMessagingDbContext.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                PublicLogs publicLog = new PublicLogs();
                publicLog.LogContent = ex.ToString();
                publicLog.LogTime = DateTime.Now;
                InsertPublicLog(publicLog);
                return false;
            }
        }
        #endregion

        #region BlockUser
        public void BlockUser(BlockUser blockUser)
        {
                _offlineMessagingDbContext.BlockUser.Add(blockUser);
                _offlineMessagingDbContext.SaveChanges();
        }
        #endregion
    }
}
