
namespace Catalog.API.Products.DeleteProduct
{
    //public record ProductDeleteRequest(Guid Id);

    public record DeleteProductResponse(bool IsSuccess);
    public class DeleteProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/products/{Id}", async (Guid id, ISender sender) =>
            {
                var resut =await sender.Send(new DeleteProductCommand(id));

                var response= resut.Adapt<DeleteProductResponse>();

                return Results.Ok(response);
            })
                .WithName("DeleteProduct")
                .Produces<DeleteProductResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Delete Product")
                .WithDescription("Delete Product")
                ;
        }
    }
}
