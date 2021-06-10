using System;
using System.Collections.Generic;

#nullable disable

namespace Web_QLNS.Models
{
    public partial class ChamCong
    {
        public DateTime Ngay { get; set; }
        public int Idnv { get; set; }
        public bool? TrangThai { get; set; }

        public virtual NhanVien IdnvNavigation { get; set; }
    }
}
