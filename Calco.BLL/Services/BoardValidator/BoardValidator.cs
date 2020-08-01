using Calco.BLL.Models;
using System.Collections.Generic;
using static Calco.Common.Constants;

namespace Calco.BLL.Services.BoardValidator
{
    public abstract class BoardValidator : IBoardValidator
    {
        protected internal List<int?> Values;

        public BoardValidator(List<int?> values)  
        { 
            Values = values;
        }

        public abstract string IsValid();
    }
}
