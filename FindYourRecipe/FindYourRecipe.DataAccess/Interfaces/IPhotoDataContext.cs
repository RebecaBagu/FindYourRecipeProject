using System;
namespace FindYourRecipe.DataAccess.Interfaces
{
	public interface IPhotoDataContext
	{
		public Photo GetById(int id);
		public void Detele(int id);
		public Photo Update(int photoId, string link);
	}
}

