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

    public ContractController(IContractRepository contract, ICarRepository car, ICustomerRepository customer)
    {
        _contract = contract;
        _car = car;
        _customer = customer;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Contract>>> GetAll()
    {
        var contracts = await _contract.FindAllAsync();
        
        return Ok(contracts);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Contract>> Get(int id)
    {
        var contract = await _contract.FindByIdAsync(id);
        if (contract == null)
        {
            return NotFound();
        }
        return Ok(contract);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Contract>> Post(Contract contract)
    {
        var customer = await _customer.FindByIdAsync(contract.CustomerId);

        if (customer == null)
            return BadRequest("Customer not found");

        /*
        var car = await _contract.FindByIdAsync(contract.CarId);

        if (car == null)
            return BadRequest("Car not found");
        */

        var createdContract = await _contract.AddAsync(contract);

        return CreatedAtAction(nameof(Get), new {id = createdContract.Id}, createdContract);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id)
    {
        var contract = await _contract.FindByIdAsync(id);

        if (contract == null)
            return NotFound();
        
        await _contract.DeleteAsync(contract);

        return Ok();
    }
}