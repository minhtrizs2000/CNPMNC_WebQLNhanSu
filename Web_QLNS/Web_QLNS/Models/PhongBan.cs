using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Web_QLNS.Models
{
    public partial class PhongBan
    {
        public PhongBan()
        {
            NhanViens = new HashSet<NhanVien>();
        }

        [Display(Name = "ID Phòng ban")]
        public int Idpb { get; set; }
        [Display(Name = "Tên phòng ban")]
        public string TenPb { get; set; }

        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
