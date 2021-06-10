using System;
using System.Collections.Generic;

#nullable disable

namespace Web_QLNS.Models
{
    public partial class KyLuat
    {
        public int Idkl { get; set; }
        public int? IdloaiKl { get; set; }
        public DateTime? Ngay { get; set; }
        public int? Idnv { get; set; }

        public virtual LoaiKyLuat IdloaiKlNavigation { get; set; }
        public virtual NhanVien IdnvNavigation { get; set; }
    }
}
