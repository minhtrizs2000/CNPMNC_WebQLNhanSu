using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Web_QLNS.Models
{
    public partial class ChucVu
    {
        public ChucVu()
        {
            NhanViens = new HashSet<NhanVien>();
        }

        [Display(Name = "ID Chức vụ")]
        public int Idcv { get; set; }
        [Display(Name = "Chức vụ")]
        public string TenCv { get; set; }
        [Display(Name = "Hệ số")]
        public double? HeSo { get; set; }

        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
