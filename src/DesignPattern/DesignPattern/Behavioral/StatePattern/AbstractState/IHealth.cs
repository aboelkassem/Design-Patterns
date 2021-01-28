using DesignPatterns.Behavioral.StatePattern.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Behavioral.StatePattern.AbstractState
{
    public interface IHealth
    {
        void DoBattle(Warrior w);
    }
}
