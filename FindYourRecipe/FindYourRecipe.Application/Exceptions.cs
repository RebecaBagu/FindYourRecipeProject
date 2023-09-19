using System;
namespace FindYourRecipe.Application
{
	public class NotFoundException :Exception
	{
		public NotFoundException()
		{
		}
		public NotFoundException(int id) :base(String.Format("Id not found "+ id))
		{

		}
	}
}

