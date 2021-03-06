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
    
    public partial class DienThoai
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DienThoai()
        {
            this.ChiTietDonHangs = new HashSet<ChiTietDonHang>();
            this.ThamGias = new HashSet<ThamGia>();
        }
    
        public int MaDT { get; set; }
        public string TenDT { get; set; }
        public Nullable<decimal> GiaBan { get; set; }
        public string Mota { get; set; }
        public string AnhBia { get; set; }
        public Nullable<System.DateTime> NgayCapNhap { get; set; }
        public Nullable<int> SoLuongTon { get; set; }
        public Nullable<int> MaNSX { get; set; }
        public Nullable<int> MaLDT { get; set; }
        public Nullable<int> Moi { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public virtual LoaiDienThoai LoaiDienThoai { get; set; }
        public virtual NhaSanXuat NhaSanXuat { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThamGia> ThamGias { get; set; }
    }
}
