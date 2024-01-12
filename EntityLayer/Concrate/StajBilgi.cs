using System.ComponentModel.DataAnnotations;


namespace EntityLayer.Concrate
{
    //StajBilgi ile İlgili entitylerin yazılması

    public class StajBilgi
    {
        [Key]
        public int StajBilgiID { get; set; }
        public string AdUnvan { get; set; }
        public string Adres { get; set; }
        public string Alanı { get; set; }
        public string YetkiliAd { get; set; }
        public string TelNo { get; set; }
        public string Mail { get; set; }
        public string FaksNo { get; set; }
        public string WebSite { get; set; }
        public DateTime Başlamatrh { get; set; }
        public DateTime Bitistrh { get; set; }
        public string StajTürü { get; set; }
        public int stajsayi { get; set; }
        public bool ResmiTatil { get; set; }
        public bool CmtDahil { get; set; }
        public bool Egitim { get; set; }
        public int KabulGün { get; set; }
        public bool Onay { get; set; }
        public bool Kabul { get; set; }
        public bool KatkıPayıOnay { get; set; }
        public string? RedSebep { get; set; }
        public int StudentID { get; set; } 
        public Student student { get; set; }
        public List<Dosya> dosyas { get; set; }

    }
}
