using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebBanDienThoatBTL.Models
{
    [MetadataTypeAttribute(typeof(DienThoaiMetadata))]
    public partial class DienThoai
    {
        internal sealed class DienThoaiMetadata
        {
            [Display(Name = "Mã Điện Thoại")] //Thuộc tính display hiện tiếng việt
            [Required(ErrorMessage = "{0} Bạn chưa nhập mã!")] //Kiểm tra rỗng
            public int MaDT { get; set; }
            [Display(Name = "Tên Điện Thoại")] //Thuộc tính display hiện tiếng việt
            [Required(ErrorMessage = "{0} Bạn chưa nhập tên!")] //Kiểm tra rỗng
            public string TenDT { get; set; }
            [Display(Name = "Giá Bán")] //Thuộc tính display hiện tiếng việt
            [Required(ErrorMessage = "{0} Bạn chưa nhập giá!")] //Kiểm tra rỗng
            public Nullable<decimal> GiaBan { get; set; }
            [Display(Name = "Mô tả")] //Thuộc tính display hiện tiếng việt
            [Required(ErrorMessage = "{0} Bạn chưa nhập mô tả!")] //Kiểm tra rỗng
            public string Mota { get; set; }
            [Display(Name = "Ảnh")] //Thuộc tính display hiện tiếng việt
            public string AnhBia { get; set; }
            [Display(Name = "Ngày cập nhập")] //Thuộc tính display hiện tiếng việt
            [Required(ErrorMessage = "{0} Bạn chưa nhập ngày cập nhập!")] //Kiểm tra rỗng
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
            [DataType(DataType.Date)]
            public Nullable<System.DateTime> NgayCapNhap { get; set; }
            [Display(Name = "Số lượng")] //Thuộc tính display hiện tiếng việt
            [Required(ErrorMessage = "{0} Bạn chưa nhập số lượng!")] //Kiểm tra rỗng
            public Nullable<int> SoLuongTon { get; set; }
            [Display(Name = "Loại Thiết Bị")] //Thuộc tính display hiện tiếng việt
            [Required(ErrorMessage = "{0} Bạn chưa nhập loại điện thoại!")] //Kiểm tra rỗng
            public Nullable<int> MaLDT { get; set; }
            [Display(Name = "Nhà sản xuất")] //Thuộc tính display hiện tiếng việt
            [Required(ErrorMessage = "{0} Bạn chưa nhập nhà sản xuất!")] //Kiểm tra rỗng
            public Nullable<int> MaNSX { get; set; }
            [Display(Name = "Tình trạng")] //Thuộc tính display hiện tiếng việt
            [Required(ErrorMessage = "{0} Bạn chưa nhập tình trạng điện thoại!")] //Kiểm tra rỗng
            public Nullable<int> Moi { get; set; }
        }
    }
}