﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bookeasy.Application.Employees.Commands.DeleteEmployee;
using Bookeasy.Application.Employees.Commands.UpsertEmployee;
using Bookeasy.Application.Employees.Queries.GetEmployeeDetail;
using Bookeasy.Application.Employees.Queries.GetEmployeesList;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookeasy.WebUI.Controllers
{
    public class EmployeesController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IList<EmployeeLookupDto>>> GetAll()
        {
            return Ok(await Mediator.Send(new GetEmployeesListQuery()));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<EmployeeDetailVm>> Get(int id)
        {
            return Ok(await Mediator.Send(new GetEmployeeDetailQuery { Id = id }));
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Upsert(UpsertEmployeeCommand command)
        {
            var id = await Mediator.Send(command);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteEmployeeCommand { Id = id });

            return NoContent();
        }
    }
}
