using MediatR;

namespace Bookeasy.Application.Customers.Queries.GetCustomerDetail
{
    public class GetCustomerDetailQuery : IRequest<CustomerDetailVm>
    {
        public string Id { get; set; }
    }
}
