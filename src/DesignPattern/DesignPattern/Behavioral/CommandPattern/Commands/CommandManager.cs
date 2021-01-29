using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Behavioral.CommandPattern.Commands
{
    public class CommandManager
    {
        private readonly Stack<ICommand> _commands = new Stack<ICommand>();

        public void Invoke(ICommand command)
        {
            if (command.CanExecute())
            {
                _commands.Push(command);
                command.Execute();
            }
        }

        public void Undo()
        {
            while (_commands.Count > 0)
            {
                ICommand command = _commands.Pop();
                command.Undo();
            }
        }
    }
}
