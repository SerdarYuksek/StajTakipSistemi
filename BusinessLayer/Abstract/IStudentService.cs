using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    //Öğrenci ile ilgili serviceler (Generic serviceden implement edilmiştir)
    public interface IStudentService : IGenericService<Student>
    {

    }
}
