using System;
using System.Collections.Generic;
using System.Text;

namespace Calco.BLL.Commands
{
    public interface ICommand
    {
        void Execute();
        bool CanExecute();
        void Undo();
    }
}
