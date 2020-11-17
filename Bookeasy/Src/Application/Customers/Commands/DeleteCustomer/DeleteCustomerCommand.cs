using MediatR;

namespace Bookeasy.Application.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand : IRequest
    {
        public string Id { get; set; }
    }
}
