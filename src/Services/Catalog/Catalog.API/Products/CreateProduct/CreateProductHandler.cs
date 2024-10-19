

namespace Catalog.API.Products.CreateProduct
{
    /*
      In ASP.NET Core, a record is a feature introduced in C# 9.01
      .Records are a reference type, similar to classes, but they have value semantics, meaning they are immutable and can be compared by value2
  .   This makes them particularly useful for modeling data3
  .
      public record Person(string FirstName, string LastName);
      In this example, the Person record has two properties: FirstName and LastName4
  .   Records are great for creating data transfer objects (DTOs) and for ensuring that your data models are immutable and easily comparable5
  .
      */

    public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price)
        : ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);

    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x=> x.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required.");
            RuleFor(x => x.ImageFile).NotEmpty().WithMessage("ImageFile is required.");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0.");
        }
    }

    internal class CreateProductCommandHandler(IDocumentSession session)
        : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {

            //  Create Product entity from Command Object
            //  Save the database
            //  Return Create ProductResult result
            var product = new Product
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price


            };

            // Save to Database

            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);

             //return result

            return new CreateProductResult(product.Id);
        }
    }
}
