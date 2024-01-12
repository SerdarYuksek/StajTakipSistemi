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
    //Staj Bilgileri ile ilgili servicelerin içlerinin doldurulması ( IStajBilgiService interfacesi implement edilmiştir)
    public class StajBilgiManager : IStajBilgiService
    {
        IStajBilgiDal _stajBilgiDal;
        public StajBilgiManager(IStajBilgiDal stajBilgiDal)
        {
            _stajBilgiDal = stajBilgiDal;
        }
        public StajBilgi TGetById(int id)
        {
            return _stajBilgiDal.GetById(id);
        }

        public List<StajBilgi> GetList()
        {
            return _stajBilgiDal.GetListAll();
        }

        public void TAdd(StajBilgi t)
        {
            _stajBilgiDal.Insert(t);
        }

        public void TDelete(StajBilgi t)
        {
            _stajBilgiDal.Delete(t);
        }

        public void TUpdate(StajBilgi t)
        {
            _stajBilgiDal.Update(t);
        }
    }
}
