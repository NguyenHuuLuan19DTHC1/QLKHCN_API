using System.ComponentModel.DataAnnotations;

namespace QLKHCN_API.Data
{

    public class GiangVien
    {
        [Key]
        [MaxLength(50)]
        public string MaGV { get; set; }
        [MaxLength(100)]
        public string HoTen{ get; set; }
        [MaxLength(100)]
        public string MaDV { get; set; }
       
    }
}
