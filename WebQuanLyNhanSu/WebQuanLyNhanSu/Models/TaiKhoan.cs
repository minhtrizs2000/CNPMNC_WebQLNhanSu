//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebQuanLyNhanSu.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TaiKhoan
    {
        public int IDNV { get; set; }
        public string Pass { get; set; }
        public Nullable<bool> Type { get; set; }
    
        public virtual NhanVien NhanVien { get; set; }
    }
}
