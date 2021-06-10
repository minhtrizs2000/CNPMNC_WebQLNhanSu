using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Web_QLNS.Models
{
    public partial class HopDongLaoDong
    {
        [Display(Name = "Mã hợp đồng")]
        public int Idnv { get; set; }
        [Display(Name = "Lương cơ bản")]
        public int LuongCb { get; set; }
        [Display(Name = "Ngày ký hợp đồng")]
        public DateTime NgayKy { get; set; }

        public virtual NhanVien IdnvNavigation { get; set; }
    }
}
