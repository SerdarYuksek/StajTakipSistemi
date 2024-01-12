using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
	// Ek ve sadece personel ile ilgili servicelerin tanımlanması
	public class EfPersonalRepository : GenericRepository<Personal>, IPersonalDal
	{
	}
}
