using System;
using System.Collections.Generic;

#nullable disable

namespace Web_QLNS.Models
{
    public partial class KhenThuong
    {
        public int Idkt { get; set; }
        public int? IdloaiKt { get; set; }
        public DateTime? Ngay { get; set; }
        public int? Idnv { get; set; }

        public virtual LoaiKhenThuong IdloaiKtNavigation { get; set; }
        public virtual NhanVien IdnvNavigation { get; set; }
    }
}
