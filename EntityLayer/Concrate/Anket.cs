using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrate
{
    public class Anket
    {
        [Key]
        public int AnketID { get; set; }
        public string? soru { get; set; }
        public string? cevap { get; set; }
        public string? cevap2 { get; set; }
        public string? cevap3 { get; set; }
        public string? cevap4{ get; set; }
        public string? cevap5 { get; set; }
        public string? cevap6 { get; set; }
        public string? cevap7 { get; set; }
        public string? cevap8 { get; set; }
        public string? cevap9 { get; set; }
        public string? cevap10 { get; set; }
    }
}
