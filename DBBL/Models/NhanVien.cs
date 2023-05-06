using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DBBL.Models;

public partial class NhanVien
{
    public string IdNv { get; set; } = null!;
    [Display(Name = "Tên Nhân Viên")]
    public string TenNv { get; set; } = null!;
    [Display(Name = "Số Điện Thoại")]
    public string SđtNv { get; set; } = null!;

    [Display(Name = "Email")]
    public string EmailNv { get; set; } = null!;

    public string IdCt { get; set; } = null!;

    [Display(Name = "Mật Khẩu")]
    public string Mk { get; set; } = null!;

    public bool? Trangthai { get; set; }

    public NhanVien()
    {
        IdNv = "";
        TenNv = "";
        SđtNv = "";
        EmailNv = "";
        IdCt = "";
        Mk = "";
        Trangthai = true;
    }
}
