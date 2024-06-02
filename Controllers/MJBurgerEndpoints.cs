using Microsoft.EntityFrameworkCore;
using MJ_APIBurger.Data;
using MJ_APIBurger.Data.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace MJ_APIBurger.Controllers;

public static class MJBurgerEndpoints
{
    public static void MapMJBurgerEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/MJBurger").WithTags(nameof(MJBurger));

        group.MapGet("/", async (BurgersPromosContext db) =>
        {
            return await db.Burgers.ToListAsync();
        })
        .WithName("GetAllMJBurgers")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<MJBurger>, NotFound>> (int mjburgerid, BurgersPromosContext db) =>
        {
            return await db.Burgers.AsNoTracking()
                .FirstOrDefaultAsync(model => model.MJBurgerId == mjburgerid)
                is MJBurger model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetMJBurgerById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int mjburgerid, MJBurger mJBurger, BurgersPromosContext db) =>
        {
            var affected = await db.Burgers
                .Where(model => model.MJBurgerId == mjburgerid)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.MJBurgerId, mJBurger.MJBurgerId)
                    .SetProperty(m => m.MJName, mJBurger.MJName)
                    .SetProperty(m => m.MJWithCheese, mJBurger.MJWithCheese)
                    .SetProperty(m => m.MJPrecio, mJBurger.MJPrecio)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateMJBurger")
        .WithOpenApi();

        group.MapPost("/", async (MJBurger mJBurger, BurgersPromosContext db) =>
        {
            db.Burgers.Add(mJBurger);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/MJBurger/{mJBurger.MJBurgerId}",mJBurger);
        })
        .WithName("CreateMJBurger")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int mjburgerid, BurgersPromosContext db) =>
        {
            var affected = await db.Burgers
                .Where(model => model.MJBurgerId == mjburgerid)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteMJBurger")
        .WithOpenApi();
    }
}
