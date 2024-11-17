


namespace Basket.API.Basket.StoreBasket
{
    public record StoreBasketCommand(ShoppingCart Cart):ICommand<StoreBaseketResult>;

    public record StoreBaseketResult(string UserName);

    public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand>
    {
       public StoreBasketCommandValidator()
        {
            RuleFor(x => x.Cart).NotNull().WithMessage("Cart cannot be null");
            RuleFor(x => x.Cart.UserName).NotEmpty().WithMessage("User Name is required");
        }
    }
    public class StoreBasketCommandHandler :
        ICommandHandler<StoreBasketCommand, StoreBaseketResult>
    {
        public async Task<StoreBaseketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
        {
           ShoppingCart cart = command.Cart;

            // Store basket in a Database
            //Update cache
            return new StoreBaseketResult("swn");

        }
    }
}
