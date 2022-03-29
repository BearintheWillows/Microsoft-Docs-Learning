using ContosPizza.Models;
using ContosPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosPizza.Controllers;

[ApiController]
[Route( "[controller]" )]
public class PizzaController : ControllerBase
{
	public PizzaController() { }

	// GET all action
	[HttpGet]
	public ActionResult<List<Pizza>> GetAll() => PizzaService.GetAll();

	// GET by Id Action
	[HttpGet( "{id}" )]
	public ActionResult<Pizza> GetById( int id )
	{
		Pizza? pizza = PizzaService.Get( id );
		return pizza == null ? NotFound() : pizza;
	}

	// POST Action
	[HttpPost]
	public IActionResult Create( Pizza pizza )
	{
		PizzaService.Add( pizza );
		return CreatedAtAction( nameof( Create ), new { id = pizza.Id }, pizza );
	}

	// PUT Action
	[HttpPut( "{id}" )]
	public IActionResult Update( int id, Pizza pizza )
	{
		if ( id != pizza.Id ) return BadRequest();

		var existingPizza = PizzaService.Get( id );

		if ( existingPizza is null ) return NotFound();

		PizzaService.Update( pizza );

		return NoContent();
	}

	// DELETE Action
	[HttpDelete( "{id}" )]
	public IActionResult Delete( int id )
	{
		var pizza = PizzaService.Get( id );

		if ( pizza is null ) return NotFound();

		PizzaService.Delete( id );

		return NoContent();
	}
}