using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
	//Crud işlemlerinin içlerinin doldurulup generic halde yazılması
	public class GenericRepository<T> : IGenericDal<T> where T : class
	{
		DataContext dc = new DataContext();
		DbSet<T> data;

        public GenericRepository()
        {
			data = dc.Set<T>();
        }
        public void Delete(T t)
		{
			data.Remove(t);
			dc.SaveChanges();
		}

		public T GetById(int id)
		{
			return data.Find(id);
		}

		public List<T> GetListAll()
		{
			return data.ToList();
		}

		public void Insert(T t)
		{
			data.Add(t);
			dc.SaveChanges();
		}

		public void Update(T t)
		{
			data.Update(t);
			dc.SaveChanges();
		}

	}
}
