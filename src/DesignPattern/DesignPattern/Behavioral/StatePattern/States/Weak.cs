using DesignPatterns.Behavioral.StatePattern.AbstractState;
using DesignPatterns.Behavioral.StatePattern.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Behavioral.StatePattern.States
{
    public class Weak : IHealth
    {
        void IHealth.DoBattle(Warrior w)
        {
            //warrior can transition to another state based on the outcome
            w.SetHealth(new Strong());
        }
    }
}
