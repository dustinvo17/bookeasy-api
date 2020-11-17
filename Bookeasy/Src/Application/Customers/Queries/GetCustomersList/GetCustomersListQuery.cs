using MediatR;

namespace Bookeasy.Application.Customers.Queries.GetCustomersList
{
    public class GetCustomersListQuery : IRequest<CustomersListVm>
    {
    }
}
