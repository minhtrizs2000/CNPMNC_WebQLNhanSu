using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Web_QLNS.Models
{
    public partial class NhanVien
    {
        public NhanVien()
        {
            ChamCongs = new HashSet<ChamCong>();
            KhenThuongs = new HashSet<KhenThuong>();
            KyLuats = new HashSet<KyLuat>();
            //HinhAnh = "~/img/145211_facebook_doi_anh_dai_dien_2.jpg";
        }
        [Display(Name = "ID Nhân viên")]
        [Required(ErrorMessage = "Không được bỏ trống, không được trùng lặp")]
        public int Idnv { get; set; }
        [Display(Name = "ID Phòng ban")]
        public int? Idpb { get; set; }
        [Display(Name = "ID Chức vụ")]
        public int? Idcv { get; set; }
        [Display(Name = "Nhân viên")]
        [Required(ErrorMessage = "Không được bỏ trống")]
        public string TenNv { get; set; }
        [Display(Name = "Giới tính")]
        public bool? GioiTinh { get; set; }
        [Display(Name = "CMND")]
        public int? Cmnd { get; set; }
        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }
        [Display(Name = "Điện thoại")]
        public string DienThoai { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Hình ảnh")]
        public string HinhAnh { get; set; }
        [Display(Name = "Tình trạng")]
        public bool? TinhTrang { get; set; }
        [Display(Name = "Ngày sinh")]
        public DateTime? NgaySinh { get; set; }

        public virtual ChucVu IdcvNavigation { get; set; }
        public virtual PhongBan IdpbNavigation { get; set; }
        public virtual HopDongLaoDong HopDongLaoDong { get; set; }
        public virtual TaiKhoan TaiKhoan { get; set; }
        public virtual ICollection<ChamCong> ChamCongs { get; set; }
        public virtual ICollection<KhenThuong> KhenThuongs { get; set; }
        public virtual ICollection<KyLuat> KyLuats { get; set; }
        [NotMapped]
        [Required(ErrorMessage = "Hãy chọn hình")]
        public IFormFile UploadHinh { get; set; }
    }
}
