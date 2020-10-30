using System.Collections.Generic;

namespace Calco.BLL.Services.Validator
{
    public interface IValidator
    {
        string IsValid(List<int?> values);
    }
}
