using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Behavioral.CommandPattern.Mediator
{
    public class Developer : TeamMember
    {
        public Developer(string name): base(name)
        {

        }

        public override void Receive(string from, string message)
        {
            Console.Write($"{this.Name} ({nameof(Developer)}) has received: ");
            base.Receive(from, message);
        }
    }

    public class Tester : TeamMember
    {
        public Tester(string name) : base(name)
        {

        }

        public override void Receive(string from, string message)
        {
            Console.Write($"{this.Name} ({nameof(Tester)}) has received: ");
            base.Receive(from, message);
        }
    }
}
