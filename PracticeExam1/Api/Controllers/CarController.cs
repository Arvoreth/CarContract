using Microsoft.AspNetCore.Mvc;
using PracticeExam1.Domain.Models;
using PracticeExam1.Domain.Repositories;

namespace PracticeExam1.Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class CarController : ControllerBase
{
    private readonly ICarRepository _car;
    private readonly ICustomerRepository _customer;
    private readonly IContractRepository _contract;

    public CarController(ICarRepository car, ICustomerRepository customer, IContractRepository contract)
    {
        _car = car;
        _customer = customer;
        _contract = contract;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Car>>> GetAll()
    {
        var cars = await _car.FindAllAsync();
            
        return Ok(cars);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Car>> Get(int id)
    {
        var car = await _car.FindByIdAsync(id);

        if (car == null)
            return NotFound();

        return Ok(car);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<Car>> Post(Car car)
    {
        var newCar = await _car.AddAsync(car);

        return CreatedAtAction(nameof(Get), new { id = newCar.Id }, newCar);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Car>> Put(int id, Car car)
    {
        var existingCar = await _car.FindByIdAsync(id);

        if (existingCar == null)
            return NotFound();

        car.Id = existingCar.Id;

        return Ok(await _car.UpdateAsync(car));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id)
    {
        var existingCar = await _car.FindByIdAsync(id);

        if (existingCar == null)
            return NotFound();

        await _car.DeleteAsync(existingCar);

        return Ok();
    }
}
