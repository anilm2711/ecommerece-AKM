
using Basket.API.Basket.GetBasket;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Basket.API.Basket.StoreBasket
{

    public record StoreBasketRequest(ShoppingCart Cart);
    public record StoreBasketResponse(string UserName);
    public class StoreBasketEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/basket", async (StoreBasketRequest request, ISender sender) =>
            {
                var command = request.Adapt<StoreBasketCommand>();
                var result = await sender.Send(command);
                var respone = result.Adapt<StoreBasketResponse>();
                return Results.Created($"/basket/{respone.UserName}", request);
            }).WithName("StoreBasket")
                .Produces<StoreBasketRequest>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Store BasketE")
                .WithDescription("Store Basket");
        }
    }
}
