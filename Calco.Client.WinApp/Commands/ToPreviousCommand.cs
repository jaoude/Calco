using Calco.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calco.Client.WinApp.Commands
{
    public class ToPreviousCommand : ICommand
    {
        private Board _board;
        private LinkedListNode<Square> _squares;
        private CommandManager _manager;
        private FrmSudoku _frmSudoku;

        public ToPreviousCommand(Board board, LinkedListNode<Square> squares, CommandManager manager, FrmSudoku frmSudoku)
        {
            _board = board;
            _squares = squares;
            _manager = manager;
            _frmSudoku = frmSudoku;
        }

        public bool CanExecute() => true;

        public void Execute()
        {
            _squares = _squares.Previous;
            _squares.Value.Idx = _squares.Value.Idx + 1;
            if (_squares.Value.Idx >= _squares.Value.AllowedValues.Count)
            {
                _squares.Value.Val = null;
                _frmSudoku.WriteSquare(_squares);
                _manager.Invoke(new ToPreviousCommand(_board, _squares, _manager, _frmSudoku));
            }
            else
            {
                _squares.Value.Val = _squares.Value.AllowedValues[_squares.Value.Idx];
                _frmSudoku.WriteSquare(_squares);
                _manager.Invoke(new ToNextCommand(_board, _squares, _manager, _frmSudoku));
            }
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
