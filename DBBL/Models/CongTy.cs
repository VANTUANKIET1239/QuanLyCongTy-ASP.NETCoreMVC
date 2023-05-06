using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DBBL.Models;

public partial class CongTy
{
    public string IdCt { get; set; } = null!;
    [Display(Name = "Tên Công Ty")]
    public string TenCt { get; set; } = null!;
    [Display(Name = "Họ Tên")]
    public string TenNql { get; set; } = null!;
    [Display(Name = "Số Điện Thoại")]
    public string SđtNql { get; set; } = null!;
    [Display(Name = "Email")]
    public string EmailNql { get; set; } = null!;
    [Display(Name = "Mật Khẩu")]
    public string Mk { get; set; } = null!;
}
