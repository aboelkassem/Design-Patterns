using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Behavioral.Mediator
{
    public abstract class Chatroom
    {
        public abstract void Register(TeamMember member);
        public abstract void Send(string from, string message);
        // Send message to the specific objects like sending to only developers, only testers
        public abstract void SendTo<T>(string from, string message) where T : TeamMember;
    }
}
