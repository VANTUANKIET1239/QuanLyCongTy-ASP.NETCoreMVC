using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DBBL.Models;

public partial class SanPham
{
    public string IdSp { get; set; } = null!;

    public string IdCt { get; set; } = null!;

    [Display(Name = "Tên Sản Phẩm")]
    public string TenSp { get; set; } = null!;
    [Display(Name = "Số Lượng Hiện Tại")]
    [MinLength(0,ErrorMessage = "Giá trị Không được âm")]
    public string SlHt { get; set; } = null!;
    [Display(Name = "Giới Hạn Số Lượng")]
    [MinLength(0, ErrorMessage = "Giá trị Không được âm")]
    public string GioiHan { get; set; } = null!;

    public bool? Trangthai { get; set; }

    public SanPham()
    {
        IdSp = "";
        IdCt = "";
        TenSp = "";
        SlHt = "";
        GioiHan = "";
        Trangthai = true;
    }
}
