using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Calco.Common.Constants;

namespace Calco.BLL.Services.BoardValidator
{
    public class BoardValidatorBox : BoardValidatorArea
    {
        public BoardValidatorBox(List<int?> values) : base(values) { }

        public override string IsValid()
        {
            var duplicate = Squares
                .Where(c => c.Val != null)
                .GroupBy(c => new { c.Val, c.Box })
                .Where(g => g.Count() > 1);

            if (duplicate.Any())
                return DUPLICATES_IN_BOX_ERROR;

            return null;
        }
    }
}
