﻿

namespace Basket.API.Basket.GetBasket
{
    public record GetBasketQuery(string UserName) : IQuery<GetBasketResult>;

    public record GetBasketResult(ShoppingCart Cart);
    public class  GetBaskeQuerytHandler : IQueryHandler<GetBasketQuery, GetBasketResult>
    {
        public async Task<GetBasketResult> Handle(GetBasketQuery query, CancellationToken cancellationToken)
        {
            //To do : get basket from Database
            //var basket=await _repositoyry.GetBasket(request.UserName)
            return  new GetBasketResult(new ShoppingCart("swn"));
        }
    }
}
