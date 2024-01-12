using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrate
{
    //Dosya ile İlgili entitylerin yazılması

    public class Dosya
	{
		[Key]
		public int DosyaID { get; set; }
		public string? Akissemasi { get; set; }
		public string? degerledirmedok { get; set; }
		public string? yonerge { get; set; }
		public string? basvuru { get; set; }
		public string? devam { get; set; }
		public string? degerlendirmeform { get; set; }
		public string? raporsablon { get; set; }
        public int? StudentID { get; set; }
        public Student student { get; set; }
        public int? StajId { get; set; }
        public StajBilgi stajBilgi { get; set; }
    }
}
