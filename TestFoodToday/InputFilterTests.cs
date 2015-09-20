using FoodTodayBase;
using FoodTodayImplementation;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFoodToday
{
	[TestFixture]
	public class InputFilterTests
	{

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void CreateFilterNoFileReader()
		{
			InputFilter filter = new InputFilter(null);
		}
	}
}
