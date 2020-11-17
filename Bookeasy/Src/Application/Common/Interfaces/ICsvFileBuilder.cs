using System.Collections.Generic;
using Bookeasy.Application.Products.Queries.GetProductsFile;

namespace Bookeasy.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildProductsFile(IEnumerable<ProductRecordDto> records);
    }
}
