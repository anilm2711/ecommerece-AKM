
namespace Basket.API.Basket.DeleteBasket
{

    //public record DeleteBasketRequest(string UserName);
    public record DeleteBasketResonse(bool IsSuccess);
    public class DeleteBasketEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/basket/{UserName}", async (string UserName, ISender sender) =>
            {
                var result = await sender.Send(new DeleteBasketCommand(UserName));

                var respone=result.Adapt<DeleteBasketResonse>();
                return Results.Ok(respone);

            }).WithName("DeleteBasket")
                .Produces<DeleteBasketResonse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Delete Basket")
                .WithDescription("Delete Basket"); 
        }
    }
}
