using Microsoft.AspNetCore.Mvc;
using PracticeExam1.Domain.Models;
using PracticeExam1.Domain.Repositories;

namespace PracticeExam1.Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class CustomerController : ControllerBase
{
    private readonly ICustomerRepository _customer;
    private readonly IContractRepository _contract;
    private readonly ICarRepository _car;

    public CustomerController(ICustomerRepository customer, IContractRepository contract, ICarRepository car)
    {
        _customer = customer;
        _contract = contract;
        _car = car;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Customer>>> GetAll()
    {
        var customers = await _customer.FindAllAsync();

        return Ok(customers);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Customer>> Get(int id)
    {
        var customer = await _customer.FindByIdAsync(id);

        if (customer == null)
            return NotFound();

        return Ok(customer);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<Customer>> Post(Customer customer)
    {
        var newCustomer = await _customer.AddAsync(customer);

        return CreatedAtAction(nameof(Get), new {id = newCustomer.Id}, newCustomer);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Customer>> Put(int id, Customer customer)
    {
        var existingCustomer = await _customer.FindByIdAsync(id);

        if (existingCustomer == null)
            return NotFound();

        customer.Id = existingCustomer.Id;

        return Ok(await _customer.UpdateAsync(customer));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Contract>> Delete(int id)
    {
        var existingCustomer = await _customer.FindByIdAsync(id);

        if (existingCustomer == null)
            return NotFound();

        await _customer.DeleteAsync(id);

        return Ok(existingCustomer);
    }
}
