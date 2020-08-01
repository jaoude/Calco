using System;
using System.Collections.Generic;
using System.Linq;
using static Calco.Common.Constants;

namespace Calco.BLL.Services.BoardValidator
{
    public class BoardValidatorRow : BoardValidatorArea
    {
        public BoardValidatorRow(List<int?> values) : base(values) { }

        public override string IsValid()
        {
            var duplicate = Squares
                .Where(c => c.Val != null)
                .GroupBy(c => new { c.Val, c.Row })
                .Where(g => g.Count() > 1);

            if (duplicate.Any())
                return DUPLICATES_IN_ROW_ERROR;

            return null;
        }
    }
}
