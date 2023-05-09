using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DBBL.Models;

public partial class SanPham
{
    [Display(Name = "ID Sản Phẩm")]
    public string IdSp { get; set; } = null!;
   
    public string IdCt { get; set; } = null!;
    [Display(Name = "Tên Sản Phẩm")]
    public string TenSp { get; set; } = null!;
    [Display(Name = "Số Lượng Hiện Tại")]
    public string SlHt { get; set; } = null!;
    [Display(Name = "Giới Hạn")]
    public string GioiHan { get; set; } = null!;

    public bool? Trangthai { get; set; }
}
