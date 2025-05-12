using Microsoft.AspNetCore.Mvc;
using PracticeExam1.Domain.Models;
using PracticeExam1.Domain.Repositories;

namespace PracticeExam1.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContractController : ControllerBase
{
    private readonly IContractRepository _contract;
    private readonly ICarRepository _car;
    private readonly ICustomerRepository _customer;

    public ContractController(ICarRepository car, ICustomerRepository customer)
    {
        _car = car;
        _customer = customer;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]

    public async Task<ActionResult<IEnumerable<Contract>>> GetAll()
    {
        var contracts = await _contract.FindAllAsync();

        if (contracts == null)
        {
            return NotFound();
        }

        return Ok(contracts);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<Contract>> GetById(int id)
    {
        var contract = await _contract.FindByIdAsync(id);
        if (contract == null)
        {
            return NotFound();
        }
        return Ok(contract);
    }
}
