using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebBanDienThoatBTL.Models
{
    [MetadataTypeAttribute(typeof(DonHangMetadata))]
    public partial class DonHang
    {
        internal sealed class DonHangMetadata
        {
            [Display(Name = "Mã Đơn Hàng")] //Thuộc tính display hiện tiếng việt
            [Required(ErrorMessage = "{0} Bạn chưa nhập mã!")] //Kiểm tra rỗng
            public int MaDonHang { get; set; }
            [Display(Name = "Tình Trạng")] //Thuộc tính display hiện tiếng việt
            public string DaThanhToan { get; set; }
            [Display(Name = "Tình Trạng Giao Hàng")] //Thuộc tính display hiện tiếng việt
            public string TinhTrangGiaoHang { get; set; }
            [Display(Name = "Ngày Đặt")] //Thuộc tính display hiện tiếng việt
            public Nullable<System.DateTime> NgayDat { get; set; }
            [Display(Name = "Ngày Giao")] //Thuộc tính display hiện tiếng việt
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
            [DataType(DataType.Date)]
            public Nullable<System.DateTime> NgayGiao { get; set; }
            [Display(Name = "Tên Khách Hàng")] //Thuộc tính display hiện tiếng việt
            public Nullable<int> MaKH { get; set; }
            [Display(Name = "Địa Chỉ")] //Thuộc tính display hiện tiếng việt
            public string DiaChi { get; set; }
            [Display(Name = "Số Điện Thoại")] //Thuộc tính display hiện tiếng việt
            public string DienThoai { get; set; }
        }
    }
}