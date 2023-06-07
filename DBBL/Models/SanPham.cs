using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DBBL.Models;

public partial class SanPham
{
    public string IdSp { get; set; } = null!;

    public string IdCt { get; set; } = null!;

    public string TenSp { get; set; } = null!;

    public string SlHt { get; set; } = null!;

    public string GioiHan { get; set; } = null!;

    public bool? Trangthai { get; set; }

<<<<<<< Updated upstream
=======
    public SanPham()
    {
        IdSp = "";
        IdCt = "";
        TenSp = "";
        SlHt = "0";
        GioiHan = "0";
        Trangthai = true;
    }
>>>>>>> Stashed changes
}
