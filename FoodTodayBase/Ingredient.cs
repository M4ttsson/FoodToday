using System;

namespace FoodTodayBase
{
	public class Ingredient
	{
		public string Name { get; set; }

		public Ingredient()
		{
		}

		public Ingredient(string name)
		{
			Name = name;
		}



		public override bool Equals(object obj)
		{
			if (obj is Ingredient)
				return Name.Equals(((Ingredient)obj).Name);
			else
				throw new ArgumentException("Cannot only compare ingredients, objekt not of typ ingredient");
		}
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public override string ToString()
		{
			return Name;
		}

	}
}