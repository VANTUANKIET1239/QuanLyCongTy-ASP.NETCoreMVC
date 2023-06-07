using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DBBL.Models;

public partial class NhanVien
{
    public string IdNv { get; set; } = null!;
    public string TenNv { get; set; } = null!;
    public string SđtNv { get; set; } = null!;

    public string EmailNv { get; set; } = null!;

    public string IdCt { get; set; } = null!;

    public string Mk { get; set; } = null!;

    public bool? Trangthai { get; set; }

<<<<<<< Updated upstream
=======
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
>>>>>>> Stashed changes
}
