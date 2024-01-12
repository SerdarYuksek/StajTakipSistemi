using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    //Personel ile ilgili servicelerin içlerinin doldurulması ( IPersonalService interfacesi implement edilmiştir)
    public class PersonalManager : IPersonalService
	{
		IPersonalDal _personalDal;
		public PersonalManager(IPersonalDal personalDal)
		{
			_personalDal = personalDal;
		}

		public List<Personal> GetList()
		{
			return _personalDal.GetListAll();
		}

        public void TAdd(Personal t)
        {
            _personalDal.Insert(t);
        }

        public void TDelete(Personal t)
        {
            _personalDal.Delete(t);
        }

        public Personal TGetById(int id)
        {
            return _personalDal.GetById(id);
        }

        public void TUpdate(Personal t)
        {
            _personalDal.Update(t);
        }
    }
}
