
namespace Catalog.API.Products.GetProductByCategory
{
    public record GetProductByCategoryQuery(string Category):IQuery<GetProductbyCategoryResult>;

    public record GetProductbyCategoryResult(IEnumerable<Product> Products);

    public class GetProductByCategoryQueryHandler(IDocumentSession session)
        : IQueryHandler<GetProductByCategoryQuery, GetProductbyCategoryResult>
    {
        public async Task<GetProductbyCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
        {
            var products=await session.Query<Product>()
                .Where(p=>p.Category.Contains(query.Category))
                .ToListAsync(cancellationToken);
            return new GetProductbyCategoryResult(products);
        }
    }
}
