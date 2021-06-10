using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Web_QLNS.Models
{
    public partial class TaiKhoan
    {
        [Required(ErrorMessage = "Không được để trống!")]
        public int Idnv { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Không được để trống!")]
        public string Pass { get; set; }
        public bool? Type { get; set; }

        public virtual NhanVien IdnvNavigation { get; set; }
    }
}
