
namespace Basket.API.Basket.DeleteBasket
{

    public record DeleteBasketCommand(string UserName):ICommand<DeleteBasketResult>;

    public record DeleteBasketResult(bool IsSucess);

    public class DeleteBasketCommandValidator:AbstractValidator<DeleteBasketCommand>
    {
        public DeleteBasketCommandValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("User Name is required.");
        }
    }
    public class DeleteBasketCommandHandler : ICommandHandler<DeleteBasketCommand, DeleteBasketResult>
    {
        public async Task<DeleteBasketResult> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
        {
            //Delete basket from Database and cache
            //Session.Delete<Product>(command.Id);

            return new DeleteBasketResult(true);
        }
    }

}
