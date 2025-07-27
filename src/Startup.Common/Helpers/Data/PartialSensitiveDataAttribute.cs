using Microsoft.Extensions.Compliance.Classification;

namespace Startup.Common.Helpers.Data;

public class PartialSensitiveDataAttribute : DataClassificationAttribute
{
    public PartialSensitiveDataAttribute() : base(DataTaxonomy.PartialSensitiveData)
    {

    }
}