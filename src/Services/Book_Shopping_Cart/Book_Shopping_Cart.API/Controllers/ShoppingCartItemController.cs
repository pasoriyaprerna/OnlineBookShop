using Book_Shopping_Cart.API.Entities;
using Book_Shopping_Cart.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Book_Shopping_Cart.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartItemController : ControllerBase
    {
        private readonly IShoppingCartRepository _repository;

        public ShoppingCartItemController(IShoppingCartRepository ShoppingCartrepository)
        {
            _repository = ShoppingCartrepository ?? throw new ArgumentNullException(nameof(ShoppingCartrepository));
           
        }

        [HttpGet("{userName}", Name = "GetCart")]
        [ProducesResponseType(typeof(BookShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<BookShoppingCart>> GetCart(string userName)
        {
            var cart = await _repository.GetCart(userName);
            return Ok(cart ?? new BookShoppingCart(userName));
        }

        [HttpPost]
        [ProducesResponseType(typeof(BookShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<BookShoppingCart>> UpdateCart([FromBody] BookShoppingCart cart)
        {
            return Ok(await _repository.UpdateCart(cart));
        }

        [HttpDelete("{userName}", Name = "DeleteCart")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteCart(string userName)
        {
            await _repository.DeleteCart(userName);
            return Ok();
        }
    }
}
