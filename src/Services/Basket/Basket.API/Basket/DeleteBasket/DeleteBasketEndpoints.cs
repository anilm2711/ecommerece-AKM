﻿
namespace Basket.API.Basket.DeleteBasket
{

    //public record DeleteBasketRequest(string UserName);
    public record DeleteBasketResonse(bool IsSuccess);
    public class DeleteBasketEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/basket{userName}", async (string userName, ISender sender) =>
            {
                var result = await sender.Send(new DeleteBasketCommand(userName));

                var respone=app.Adapt<DeleteBasketResonse>();
                return Results.Ok(respone);

            }).WithName("DeleteBasket")
                .Produces<DeleteBasketResonse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Delete Basket")
                .WithDescription("Delete Basket"); 
        }
    }
}
