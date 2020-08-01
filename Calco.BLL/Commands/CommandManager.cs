﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Calco.BLL.Commands
{
    public class CommandManager
    {
        private Stack<ICommand> commands = new Stack<ICommand>();
        public void Invoke(ICommand command)
        {
            if (command.CanExecute())
            {
                commands.Push(command);
                command.Execute();
            }
        }

        public void Undo()
        {
            while (commands.Count > 0)
            { 
                var command = commands.Pop();
                command.Undo();
            }
        }
    }
}
