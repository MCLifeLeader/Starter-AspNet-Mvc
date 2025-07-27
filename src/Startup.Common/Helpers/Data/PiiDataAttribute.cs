using Microsoft.Extensions.Compliance.Classification;

namespace Startup.Common.Helpers.Data;

public class PiiDataAttribute : DataClassificationAttribute
{
    public PiiDataAttribute() : base(DataTaxonomy.Pii)
    {

    }
}