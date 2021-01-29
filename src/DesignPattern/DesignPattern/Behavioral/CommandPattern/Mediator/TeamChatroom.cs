using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.Behavioral.CommandPattern.Mediator
{
    public class TeamChatroom : Chatroom
    {
        private List<TeamMember> members = new List<TeamMember>();

        // References
        // just set up/register connection between mediator and colleague 
        public override void Register(TeamMember member)
        {
            member.SetChatroom(this);
            this.members.Add(member);
        }

        // Sending this message for each members
        public override void Send(string from, string message)
        {
            this.members.ForEach(m => m.Receive(from, message));
        }

        // Register team members at once
        public void RegisterMembers(params TeamMember[] teamMembers)
        {
            foreach (var member in teamMembers)
            {
                this.Register(member);
            }
        }

        public override void SendTo<T>(string from, string message)
        {
            this.members.OfType<T>().ToList().ForEach(m => m.Receive(from, message));
        }
    }
}
