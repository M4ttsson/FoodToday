using System.Collections.Generic;

namespace FoodTodayInterface
{
	public interface IFileReader
	{
		HashSet<string> ReadFoulLanguageFile();
	}
}