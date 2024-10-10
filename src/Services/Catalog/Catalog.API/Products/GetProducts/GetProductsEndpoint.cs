﻿
namespace Catalog.API.Products.GetProducts
{
    public record GetProductsResponnse(IEnumerable<Product> Products);
    public class GetProductsEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async (ISender sender) =>
            {
                var result = await sender.Send(new GetProductsQuery());
                var response = result.Adapt<GetProductsResponnse>();
                return Results.Ok(response);
            })
             .WithName("GetProducts")
             .Produces<GetProductsResponnse>(StatusCodes.Status200OK)
             .ProducesProblem(StatusCodes.Status400BadRequest)
             .WithSummary("Get Products")
             .WithDescription("Get Products");
        }
    }
}
