using System.Collections.Generic;
using System.Linq;
using static Calco.Common.Constants;

namespace Calco.BLL.Services.BoardValidator
{
    public class BoardValidatorColumn : BoardValidatorArea
    {
        public BoardValidatorColumn(List<int?> values) : base(values) { }

        public override string IsValid()
        {
            var duplicate = Squares
                .Where(c => c.Val != null)
                .GroupBy(c => new { c.Val, c.Col })
                .Where(g => g.Count() > 1);

            if (duplicate.Any())
                return DUPLICATES_IN_COLUMN_ERROR;

            return null;
        }
    }
}
