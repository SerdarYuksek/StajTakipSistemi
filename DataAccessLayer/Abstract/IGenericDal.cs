using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    //Veri Tabanı Crud işlemlerinin generic yazılması
    public interface IGenericDal <T> where T : class
	{
		void Insert(T t);
		void Delete(T t);
		void Update(T t);
		List<T> GetListAll();
		T GetById(int id);
	}
}
