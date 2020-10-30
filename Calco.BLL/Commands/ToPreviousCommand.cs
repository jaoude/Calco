using Calco.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calco.BLL.Commands
{
    public class ToPreviousCommand : ICommand
    {
        private SudokuSolver _board;
        private LinkedListNode<Square> _squares;
        private CommandManager _manager;
        
        public ToPreviousCommand(SudokuSolver board, LinkedListNode<Square> squares, CommandManager manager)
        {
            _board = board;
            _squares = squares;
            _manager = manager;
        }

        public bool CanExecute() => true;

        public void Execute()
        {
            _squares = _squares.Previous;
            _squares.Value.Idx = _squares.Value.Idx + 1;
            if (_squares.Value.Idx >= _squares.Value.AllowedValues.Count)
            {
                _squares.Value.Val = null;
                _manager.Invoke(new ToPreviousCommand(_board, _squares, _manager));
            }
            else
            {
                _squares.Value.Val = _squares.Value.AllowedValues[_squares.Value.Idx];
                _manager.Invoke(new ToNextCommand(_board, _squares, _manager));
            }
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
