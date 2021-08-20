using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBanDienThoatBTL.Models
{
    [MetadataTypeAttribute(typeof(LoaiDienThoaiMetadata))]
    public partial class LoaiDienThoai
    {
        internal sealed class LoaiDienThoaiMetadata
        {
            [Display(Name = "Mã Loại Điện Thoại")] //Thuộc tính display hiện tiếng việt
            [Required(ErrorMessage = "{0} Bạn chưa nhập mã!")] //Kiểm tra rỗng
            public int MaLDT { get; set; }
            [Display(Name = "Tên Loại Điện Thoại")] //Thuộc tính display hiện tiếng việt
            [Required(ErrorMessage = "{0} Bạn chưa nhập tên!")] //Kiểm tra rỗng
            public string TenLDT { get; set; }
        }
    }
}