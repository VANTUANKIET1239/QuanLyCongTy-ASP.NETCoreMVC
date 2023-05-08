using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DBBL.Models;

public partial class CongTy
{
    public string IdCt { get; set; } = null!;
    public string TenCt { get; set; } = null!;
    public string TenNql { get; set; } = null!;
    public string SđtNql { get; set; } = null!;
    public string EmailNql { get; set; } = null!;
    public string Mk { get; set; } = null!;
}
