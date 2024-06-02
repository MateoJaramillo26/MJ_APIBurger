using System;
using System.Collections.Generic;

namespace MJ_APIBurger.Data.Models;

public partial class MJBurger
{
    public int MJBurgerId { get; set; }

    public string MJName { get; set; } = null!;

    public bool MJWithCheese { get; set; }

    public decimal MJPrecio { get; set; }

    public virtual ICollection<MJPromo> MJPromos { get; set; } = new List<MJPromo>();
}
