using FoodTodayInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTodayImplementation
{
	public class InputFilter : IInputFilter
	{
		private IFileReader fileReader;

		public InputFilter(IFileReader fileReader)
		{
			if (fileReader == null)
				throw new ArgumentNullException("Needs a valid filereader");

			this.fileReader = fileReader;
		}

		public string RemoveFoulLanguage(string input)
		{
			HashSet<string> foulLanguage = fileReader.ReadFoulLanguageFile();
			string[] words = input.Split(' ', ',', '.');

			foreach(string word in words)
			{
				if (foulLanguage.Contains(word))
					throw new ArgumentException("Input contains foul language");
			}
			return input;
		}
	}
}
