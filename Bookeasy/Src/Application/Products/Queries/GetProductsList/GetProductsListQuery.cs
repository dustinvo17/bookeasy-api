using MediatR;

namespace Bookeasy.Application.Products.Queries.GetProductsList
{
    public class GetProductsListQuery : IRequest<ProductsListVm>
    {
    }
}
