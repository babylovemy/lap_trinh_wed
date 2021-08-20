using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBanDienThoatBTL.Models
{
    [MetadataTypeAttribute(typeof(NhaSanXuatMetaData))]
    public partial class NhaSanXuat
    {
        internal sealed class NhaSanXuatMetaData
        {
            [Display(Name = "Mã Nhà Sản Xuất")] //Thuộc tính display hiện tiếng việt
            [Required(ErrorMessage = "{0} Bạn chưa nhập mã!")] //Kiểm tra rỗng
            public int MaNSX { get; set; }
            [Display(Name = "Tên Nhà Sản Xuất")] //Thuộc tính display hiện tiếng việt
            [Required(ErrorMessage = "{0} Bạn chưa nhập tên!")] //Kiểm tra rỗng
            public string TenNSX { get; set; }
            [Display(Name = "Xuất Xứ")] //Thuộc tính display hiện tiếng việt
            [Required(ErrorMessage = "{0} Bạn chưa nhập địa chỉ!")] //Kiểm tra rỗng
            public string DiaChi { get; set; }
            [Display(Name = "Điện Thoại Hỗ Trợ")] //Thuộc tính display hiện tiếng việt
            [Required(ErrorMessage = "{0} Bạn chưa nhập số điện thoại!")] //Kiểm tra rỗng
            public string DienThoai { get; set; }
        }
    }
}