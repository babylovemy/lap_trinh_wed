using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBanDienThoatBTL.Models
{
    [MetadataTypeAttribute(typeof(KhachHangMetadata))]
    public partial class KhachHang
    {
        internal sealed class KhachHangMetadata
        {
            [Display(Name = "Mã Khách Hàng")] //Thuộc tính display hiện tiếng việt
            [Required(ErrorMessage = "{0} Bạn chưa nhập mã!")] //Kiểm tra rỗng
            public int MaKH { get; set; }
            [Display(Name = "Họ Tên")] //Thuộc tính display hiện tiếng việt
            [Required(ErrorMessage = "{0} Bạn chưa nhập họ tên!")] //Kiểm tra rỗng
            public string HoTen { get; set; }
            [Display(Name = "Tài Khoản")] //Thuộc tính display hiện tiếng việt
            [Required(ErrorMessage = "{0} Bạn chưa nhập tên tài khoản!")] //Kiểm tra rỗng
            public string TaiKhoan { get; set; }
            [Display(Name = "Mật Khẩu")] //Thuộc tính display hiện tiếng việt
            [Required(ErrorMessage = "{0} Bạn chưa nhập mật khẩu!")] //Kiểm tra rỗng
            [StringLength(12, MinimumLength = 6, ErrorMessage = "Mật khẩu từ 6-12 ký tự!")]
            public string MatKhau { get; set; }
            [Display(Name = "Email")] //Thuộc tính display hiện tiếng việt
            [Required(ErrorMessage = "{0} Bạn chưa nhập Email!")] //Kiểm tra rỗng
            [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage ="Email không hợp lệ!")]
            public string Email { get; set; }
            [Display(Name = "Địa Chỉ")] //Thuộc tính display hiện tiếng việt
            [Required(ErrorMessage = "{0} Bạn chưa nhập địa chỉ!")] //Kiểm tra rỗng
            public string DiaChi { get; set; }
            [Display(Name = "Số Điện Thoại")] //Thuộc tính display hiện tiếng việt
            [Required(ErrorMessage = "{0} Bạn chưa nhập số điện thoại!")] //Kiểm tra rỗng
            [Range(0, 9999999999, ErrorMessage ="Số điện thoại không hợp lệ!")]
            public string DienThoai { get; set; }
            [Display(Name = "Giới tính")] //Thuộc tính display hiện tiếng việt
            [Required(ErrorMessage = "{0} Bạn chưa nhập giới tính!")] //Kiểm tra rỗng
            public string GioiTinh { get; set; }
            [Display(Name = "Ngày sinh")] //Thuộc tính display hiện tiếng việt
            [Required(ErrorMessage = "{0} Bạn chưa nhập ngày sinh!")] //Kiểm tra rỗng
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
            [DataType(DataType.Date)]
            public Nullable<System.DateTime> NgaySinh { get; set; }
        }
    }
}