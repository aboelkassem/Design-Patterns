using DesignPatterns.Behavioral.StatePattern.AbstractState;
using DesignPatterns.Behavioral.StatePattern.States;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Behavioral.StatePattern.Context
{
    public class Warrior
    {
        private IHealth health = new Normal();  //start as normal health

        public void Battle()
        {
            health.DoBattle(this);  //calls the health to exhibit the behavior
        }

        public void SetHealth(IHealth health)
        {
            this.health = health;
        }

        public void ShowHealth()
        {
            Console.WriteLine("Warrior is now: " + health.GetType().Name);
        }
    }
}
