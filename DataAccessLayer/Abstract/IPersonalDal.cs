using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    //Personel Crud işlemlerinin Yazılması(IGenericDaldan miras alındı)
    public interface IPersonalDal : IGenericDal<Personal>
	{
	}
}
