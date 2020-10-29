using System.Collections.Generic;

namespace Calco.BLL.Services
{
    public interface ISudokuValidator
    {
        string Validate(List<int?> values);
    }
}
