using System;
using System.Collections.Generic;

namespace MJ_APIBurger.Data.Models;

public partial class Promo
{
    public int PromoId { get; set; }

    public string? PromoDescripcion { get; set; }

    public DateTime FechaPromocion { get; set; }

    public int BurgerId { get; set; }

    public virtual Burger Burger { get; set; } = null!;
}
