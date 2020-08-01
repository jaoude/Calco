using Calco.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calco.BLL.Commands
{
    public class ToNextCommand : ICommand
    {
        private Board _board;
        private LinkedListNode<Square> _squares;
        private CommandManager _manager;
        public ToNextCommand(Board board, LinkedListNode<Square> squares, CommandManager manager)
        {
            _board = board;
            _squares = squares;
            _manager = manager;
        }

        public bool CanExecute() => true;

        public void Execute()
        {
            if (_squares == _board.LinkedSquares.Last)
            {
                return;
            }

            var squareNext = _squares.Next;

            squareNext.Value.Idx = 0;
            _board.GetAllowedValues(squareNext.Value);
            if (!squareNext.Value.AllowedValues.Any())
            {
                _manager.Invoke(new ToPreviousCommand(_board, squareNext, _manager));
            }
            else
            {
                squareNext.Value.Val = squareNext.Value.AllowedValues[squareNext.Value.Idx];
                _manager.Invoke(new ToNextCommand(_board, squareNext, _manager));
            }
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
