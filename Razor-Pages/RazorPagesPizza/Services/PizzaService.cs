using RazorPagesPizza.Models;

namespace RazorPagesPizza.Services;

public static class PizzaService
{
	private static List<Pizza> Pizzas { get; }
	static int _nextId = 7;
	
	static PizzaService()
	{
		Pizzas = new List<Pizza>
		{
			new() { Id = 1, Name = "Pepperoni", Price = 8.99M },
			new() { Id = 2, Name = "Hawaiian", Price  = 9.99M },
			new() { Id = 3, Name = "Veggie", Price = 7.99M },
			new() { Id = 4, Name = "Meat Lovers", Price = 10.99M },
			new() { Id = 5, Name = "Supreme", Price = 11.99M },
			new() { Id = 6, Name = "BBQ Chicken", Price = 12.99M },
		};
	}
	
	public static List<Pizza> GetAll() => Pizzas;
	
	public static Pizza? Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id);
	
	public static void Add(Pizza pizzaModel)
	{
		pizzaModel.Id = _nextId;
		Pizzas.Add(pizzaModel);
		_nextId++;
	}
	
	public static void Delete(int id) => Pizzas.Remove(Get(id) ?? throw new ArgumentException($"No pizzaModel with id {id}"));

	public static void Update( Pizza pizza )
	{
		int index = Pizzas?.FindIndex(p => p.Id == pizza.Id) ?? throw new ArgumentException($"No pizzaModel with id {pizza.Id}");
		Pizzas[index] = pizza;
	}
	

}