using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bookeasy.Application.Customers.Commands.CreateCustomer;
using Bookeasy.Application.Customers.Commands.DeleteCustomer;
using Bookeasy.Application.Customers.Commands.UpdateCustomer;
using Bookeasy.Application.Customers.Queries.GetCustomerDetail;
using Bookeasy.Application.Customers.Queries.GetCustomersList;
using System.Threading.Tasks;

namespace Bookeasy.WebUI.Controllers
{
    [Authorize]
    public class CustomersController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<CustomersListVm>> GetAll()
        {
            var vm = await Mediator.Send(new GetCustomersListQuery());

            return Ok(vm);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CustomerDetailVm>> Get(string id)
        {
            var vm = await Mediator.Send(new GetCustomerDetailQuery { Id = id });

            return Ok(vm);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody]CreateCustomerCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody]UpdateCustomerCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string id)
        {
            await Mediator.Send(new DeleteCustomerCommand { Id = id });

            return NoContent();
        }
    }
}