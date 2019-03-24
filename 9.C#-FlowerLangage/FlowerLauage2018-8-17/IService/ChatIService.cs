using FlowerLauage2018_8_17.Entity;
using FlowerLauage2018_8_17.Fuctions;
using FlowerLauage2018_8_17.Service.ModelService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlowerLauage2018_8_17.IService
{
    public class ChatIService
    {
        public static ChatService Chat
        {
            get { return new ChatService(); }
        }

        public static FlowerChatService FlowerChat
        {
            get { return new FlowerChatService(); }
        }
    }
}