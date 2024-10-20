﻿namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductRequest(string Name, List<string> Category, string Description, string ImageFile, decimal Price);
    public record CreateProductResponse(Guid Id);
    public class CreateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/products",
                async (CreateProductRequest request, ISender sender) =>
                {
                    //We met incoming request to create Product Command Object
                    var command = request.Adapt<CreateProductCommand>();

                    // Send it using the MediatR and MediatR will trigger our Handler Class
                    var result = await sender.Send(command);

                    //And After that we will get back to response and adapt result back to the CreateProductResponse 
                    

                    var response = result.Adapt<CreateProductResponse>();

                    // and return this response to the Client Application

                    return Results.Created($"/products/{response.Id}", response);
                })
            .WithName("CreateProduct")
            .Produces<CreateProductResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Create Product")
            .WithDescription("Create Product");
        }
    }
}
