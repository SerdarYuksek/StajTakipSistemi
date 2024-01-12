using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{    
	//StajBilgi Crud işlemlerinin Yazılması(IGenericDaldan miras alındı)

    public interface IStajBilgiDal : IGenericDal<StajBilgi>
	{
	}
}
