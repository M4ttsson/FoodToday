using FoodTodayInterface;
using System;
using System.Collections.Generic;

namespace FoodTodayBase
{
	public class Dinner
	{
		private IDinnerRepository repo;
		private IInputFilter filter;
		private List<Ingredient> ingredients = new List<Ingredient>();

		public string Description { get; private set; }

		public Dinner(IDinnerRepository repo, IInputFilter filter)
		{
			CheckIfValidParameters(repo, filter);

			this.repo = repo;
			this.filter = filter;
		}

		private static void CheckIfValidParameters(IDinnerRepository repo, IInputFilter filter)
		{
			if (repo == null)
				throw new ArgumentNullException("Needs a valid dinner repository");
			if (filter == null)
				throw new ArgumentNullException("Needs a valid input filter");
		}

		public void AddIngredient(Ingredient ingredient)
		{
			if (ingredient == null)
				throw new ArgumentNullException("Not a valid ingredient");

			ingredients.Add(ingredient);
		}

		public IEnumerable<Ingredient> GetAllIngredients()
		{
			return ingredients;
		}

		public void RemoveIngredient(Ingredient ingToRemove)
		{
			ingredients.Remove(ingToRemove);
		}

		public void SetDescription(string description)
		{
			description = filter.RemoveFoulLanguage(description);
			Description = description;
		}
	}
}