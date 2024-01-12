using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrate
{
	//Personel ile İlgili entitylerin yazılması
	public class Personal
	{
		[Key]
		public int KullaniciID { get; set; }
		public string AdSoyad { get; set; }
		public string TCNO { get; set; }
		public bool Cinsiyet { get; set; }
		public string Image { get; set; }
		public string Mail { get; set; }
		public string Password { get; set; }
		public string RePassword { get; set; }
		public string Rol { get; set; }
		public string PersonalNo { get; set; }
        public string Unvan { get; set; }
	}
}
