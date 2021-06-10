using System;
using System.Collections.Generic;

#nullable disable

namespace Web_QLNS.Models
{
    public partial class LoaiKhenThuong
    {
        public LoaiKhenThuong()
        {
            KhenThuongs = new HashSet<KhenThuong>();
        }

        public int IdloaiKt { get; set; }
        public string TenKt { get; set; }
        public int? GiaTri { get; set; }

        public virtual ICollection<KhenThuong> KhenThuongs { get; set; }
    }
}
