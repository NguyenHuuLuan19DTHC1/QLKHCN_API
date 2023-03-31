using System;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace QLKHCN_API.Data
{
    public class User
    {
        [Key]
        [MaxLength(20)]
        public string username { get; set; }
        [MaxLength(200)]
        public string password { get; set; }
        [MaxLength(200)]
        public string gmail { get; set; }
        [MaxLength(200)]
        public string hoten { get; set; }
        [MaxLength(200)]
        public string socccd { get; set; }
        [MaxLength(200)]
        public string chucvu { get; set; }
        [MaxLength(200)]
        public string chucdanh_hocvi { get; set; }
        public DateTime? ngaysinh { get; set; }
        [MaxLength(1)]
        public string gioitinh { get; set; }
    }
}
