using System;
using System.Collections.Generic;

#nullable disable

namespace Web_QLNS.Models
{
    public partial class LoaiKyLuat
    {
        public LoaiKyLuat()
        {
            KyLuats = new HashSet<KyLuat>();
        }

        public int IdloaiKl { get; set; }
        public string TenKl { get; set; }
        public int? GiaTri { get; set; }

        public virtual ICollection<KyLuat> KyLuats { get; set; }
    }
}
