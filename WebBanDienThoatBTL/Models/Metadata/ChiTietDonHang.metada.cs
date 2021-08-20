using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebBanDienThoatBTL.Models
{
    [MetadataTypeAttribute(typeof(ChiTietDonHangMetadata))]
    public partial class ChiTietDonHang
    {
        internal sealed class ChiTietDonHangMetadata
        {
            [Display(Name = "Tên Điện Thoại")] //Thuộc tính display hiện tiếng việt
            public int MaDT { get; set; }
            [Display(Name = "Mã Đơn Hàng")] //Thuộc tính display hiện tiếng việt
            public int MaDonHang { get; set; }
            [Display(Name = "Số Lượng")] //Thuộc tính display hiện tiếng việt
            public Nullable<int> SoLuong { get; set; }
            [Display(Name = "Đơn Giá")] //Thuộc tính display hiện tiếng việt
            public string DonGia { get; set; }
        }
    }
}