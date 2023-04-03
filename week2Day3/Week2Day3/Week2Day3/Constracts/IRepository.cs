using System;
namespace Week2Day3.Constracts
{
	public interface IRepository <T> where T : Entity
	{
		void Add(T obj);

		void Remove(T obj);

		void Save();

		IEnumerable<T> GetAll();

		T GetById(int id);
	}
}

