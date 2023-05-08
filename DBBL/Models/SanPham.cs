using System;
using System.Collections.Generic;

namespace DBBL.Models;

public partial class SanPham
{
    public string IdSp { get; set; } = null!;

    public string IdCt { get; set; } = null!;

    public string TenSp { get; set; } = null!;

    public string SlHt { get; set; } = null!;

    public string GioiHan { get; set; } = null!;

    public bool? Trangthai { get; set; }
}
