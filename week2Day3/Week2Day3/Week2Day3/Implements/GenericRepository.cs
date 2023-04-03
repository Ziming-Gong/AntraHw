using System;
using Week2Day3;
using Week2Day3.Constracts;

namespace Week2Day3.Implements
{
	public class GenericRepository<T>  : IRepository<T>  where T : Entity
	{



		public GenericRepository()
		{

		}

        public void Add(T obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public  void Remove(T obj)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}

