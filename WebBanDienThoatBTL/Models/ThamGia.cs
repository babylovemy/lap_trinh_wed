//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebBanDienThoatBTL.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ThamGia
    {
        public int MaDT { get; set; }
        public int MaNSX { get; set; }
        public string VaiTro { get; set; }
        public string ViTri { get; set; }
    
        public virtual DienThoai DienThoai { get; set; }
    }
}
