using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DBBL.Models;

public partial class NhanVien
{
    [Display(Name = "ID Nhân Viên")]
    public string IdNv { get; set; } = null!;
    [Display(Name = "Họ Tên")]
    public string TenNv { get; set; } = null!;
    [Display(Name = "Số Điện Thoại")]
    public string SđtNv { get; set; } = null!;
    [Display(Name = "Email")]
    public string EmailNv { get; set; } = null!;

    public string IdCt { get; set; } = null!;
    [Display(Name = "Mật Khẩu")]
    [MinLength(6,ErrorMessage = "Mật khẩu phải dài hơn 6 kí tự")]
    public string Mk { get; set; } = null!;

    public bool? Trangthai { get; set; }
}
