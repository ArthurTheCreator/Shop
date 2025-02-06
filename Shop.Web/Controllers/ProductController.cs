using Microsoft.AspNetCore.Mvc;
using Shop.Web.Models;
using Shop.Web.Services.Interfaces;

namespace Shop.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ActionResult<List<OutputProduct>>> Index()
        {
            var result = await _productService.GetAll();

            if (result is null)
                return View("Nenhum Produto Cadastrado!");

            return View(result);
        }
    }
}