using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // Dependency chain - bagimlilik zinciri
        // IProductService productService = new ProductManager(new EfProductDal()); 
        // yukaridaki bagimliligi yapmak yerine dependency injection yapildi
        // bu islemde -> loose coupling - gevsek baglilik
       
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // get --> sunucudaki verilere erismek
        [HttpGet("getall")]

        // neden IActionResult ???
        // bir metotta birden fazla actionresult tipi mumkunse kullanilir
        // ActionResult turleri cesitli http durum kodlarini temsil eder
        public IActionResult GetAll()
        {
            var result = _productService.GetAll();
            if (result.Success)
            {
                // ok --> http 200 status dondurur -->hersey basarili demek
                return Ok(result);

            }
            // badrequest --> http 400 dondurur --> istemci hatasi
            return BadRequest(result);
        }

        // post --> sunucuya veri gondermek
        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int categoryId)
        {
            var result = _productService.GetAllByCategoryId(categoryId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        //[HttpGet("details")]
        //public IActionResult GetProductDetail()
        //{
        //    var result = _productService.GetProductDetails();
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}

        [HttpGet("getbystock")]
        public IActionResult GetProductByStock(decimal min, decimal max)
        {
            var result = _productService.GetProductByStock(min,max);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("transaction")]
        public IActionResult TransactionTest(Product product)
        {
            var result = _productService.TransactionalOperation(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
     
    }
}
