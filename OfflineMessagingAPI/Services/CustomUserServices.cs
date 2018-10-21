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
        private readonly OfflineMessagingDbContext _offlineMessagingDbContext;

        public CustomUserServices(OfflineMessagingDbContext offlineMessagingDbContext)
        {
            _offlineMessagingDbContext = offlineMessagingDbContext;
        }

        public CustomUser CreateCustomUser(CustomUser customUser)
        {
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

        public CustomUser IsOnline(string userName)
        {
            var userDb = _offlineMessagingDbContext.CustomUsers.Where(x => x.UserName == userName && x.IsOnline).FirstOrDefault();

            return userDb;
        }

        public CustomUser IsOnline(CustomUser customUser)
        {
            throw new NotImplementedException();
        }

        public CustomUser LoginCustomUser(LoginInfo loginInfo)
        {
            var customUser =  _offlineMessagingDbContext.CustomUsers.Where(x => (x.Email == loginInfo.UserNameOrEmail || x.UserName == loginInfo.UserNameOrEmail) && x.Password == loginInfo.Md5Password && x.IsActive == true).FirstOrDefault();


            customUser.IsOnline = true;
            _offlineMessagingDbContext.CustomUsers.Update(customUser);
            _offlineMessagingDbContext.SaveChanges();

            return customUser;
        }

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
                return false;
            }
        }
    }
}
