using System;
using System.Collections.Generic;

namespace MJ_APIBurger.Data.Models;

public partial class MJPromo
{
    public int MJPromoId { get; set; }

    public string? MJPromoDescripcion { get; set; }

    public DateTime MJFechaPromocion { get; set; }

    public int MJBurgerId { get; set; }

    public virtual MJBurger MJBurger { get; set; } = null!;
}
