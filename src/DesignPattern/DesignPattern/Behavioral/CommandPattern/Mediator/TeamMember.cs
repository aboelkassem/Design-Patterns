using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Behavioral.CommandPattern.Mediator
{
    public abstract class TeamMember
    {
        public string Name { get; }
        private Chatroom chatroom;

        public TeamMember(string name)
        {
            this.Name = name;
        }

        // Set Mediator
        internal void SetChatroom(Chatroom chatroom)
        {
            this.chatroom = chatroom;
        }

        // Sending messages to mediator
        public void Send(string message)
        {
            this.chatroom.Send(this.Name, message);
        }
        // Receiving a chat message
        public virtual void Receive(string from, string message)
        {
            Console.WriteLine($"from {from}: '{message}'");
        }

        public void SendTo<T>(string message) where T : TeamMember
        {
            this.chatroom.SendTo<T>(this.Name, message);
        }
    }
}
