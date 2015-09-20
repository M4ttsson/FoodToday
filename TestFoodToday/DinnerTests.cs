using System;
using NUnit.Framework;
using FoodTodayBase;
using Moq;
using System.Linq;
using System.Collections.Generic;
using FoodTodayInterface;
using FoodTodayImplementation;

namespace TestFoodToday
{
	[TestFixture]
	public class DinnerTests
	{
		Mock<IDinnerRepository> mockRepo;
		Mock<IInputFilter> mockFilter;
		Dinner dinner;

		[SetUp]
		public void SetUp()
		{
			mockRepo = new Mock<IDinnerRepository>();
			mockFilter = new Mock<IInputFilter>();
			dinner = new Dinner(mockRepo.Object, mockFilter.Object);
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void CreateDinnerNoRepo()
		{
			Dinner dinner = new Dinner(null, mockFilter.Object);
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void CreateDinnerNoFilter()
		{
			Dinner dinner = new Dinner(mockRepo.Object, null);
		}

		[Test]
		public void AddIngredient()
		{
			dinner.AddIngredient(new Ingredient());

			Assert.AreEqual(1, CountIngredients());
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void AddNullIngredient()
		{
			dinner.AddIngredient(null);
		}

		[Test]
		public void RemoveIngredient()
		{
			Ingredient ingToRemove = CreatePotato();
			dinner.AddIngredient(ingToRemove);
			dinner.RemoveIngredient(ingToRemove);

			Assert.AreEqual(0, CountIngredients());
		}


		[Test]
		public void RemoveIngredientWithSameName()
		{
			Ingredient firstIngredient = CreatePotato();
			Ingredient secondIngredient = CreatePotato();

			dinner.AddIngredient(firstIngredient);

			dinner.RemoveIngredient(secondIngredient);

			Assert.AreEqual(0, CountIngredients());
		}

		[Test]
		public void SetDescription()
		{
			string testDesc = "Test description";
			mockFilter.Setup(filter => filter.RemoveFoulLanguage(It.IsAny<string>())).Returns(testDesc);

			dinner.SetDescription(testDesc);
			Assert.AreEqual(testDesc, dinner.Description);
		}

		[Test]
		[ExpectedException(typeof(ArgumentException))]
		public void NoFoulLanguageInDescription()
		{
			Mock<IFileReader> reader = new Mock<IFileReader>();
			reader.Setup(read => read.ReadFoulLanguageFile()).Returns(new HashSet<string>() { "foul", "deoderant" });

			InputFilter filter = new InputFilter(reader.Object);
			dinner = new Dinner(mockRepo.Object, filter);
			dinner.SetDescription("foul deoderant and a couple of eggs");
		}

		private static Ingredient CreatePotato()
		{
			return CreateIngredient("Potato");
		}

		private static Ingredient CreateIngredient(string name)
		{
			return new Ingredient(name);
		}

		private int CountIngredients()
		{
			return dinner.GetAllIngredients().Count();
		}
	}
}
