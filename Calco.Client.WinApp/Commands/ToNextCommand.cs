using Calco.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calco.Client.WinApp.Commands
{
    public class ToNextCommand : ICommand
    {
        private Board _board;
        private LinkedListNode<Square> _squares;
        private CommandManager _manager;
        private FrmSudoku _frmSudoku;

        public ToNextCommand(Board board, LinkedListNode<Square> squares, CommandManager manager, FrmSudoku frmSudoku)
        {
            _board = board;
            _squares = squares;
            _manager = manager;
            _frmSudoku = frmSudoku;
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
                _manager.Invoke(new ToPreviousCommand(_board, squareNext, _manager, _frmSudoku));
            }
            else
            {
                squareNext.Value.Val = squareNext.Value.AllowedValues[squareNext.Value.Idx];
                _frmSudoku.WriteSquare(squareNext);
                _manager.Invoke(new ToNextCommand(_board, squareNext, _manager, _frmSudoku));
            }
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
