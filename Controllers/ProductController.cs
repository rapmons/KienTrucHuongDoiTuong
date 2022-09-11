using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductManager.Models;
using ProductManager.Services;

namespace ProductManager.Controllers
{
public class ProductController : Controller
{
//   private readonly datacontext _context;
//     public ProductController(datacontext context)
//     {
//        _context=context;
//     }
//         public IActionResult Index()
//         {
//             var Products= _context.Product.ToList();
//             // var categories= new List<String>()
//             // {
//             //     "SmartPhone",
//             //     "TV"
//             // };
//             // ViewBag.categories=categories;
//           //  ViewData["Categories"]=categories;
//             return View(Products);
//         }
 private readonly IProductService _productService;

        public ProductController(IProductService iProductService)
        {
            // Products= new List<Product>()
            // {
            //     new Product(){Id=1,Name="Iphone 10",Price=500,Quantity=30,Option="hehe"},
            //     new Product(){Id=2,Name="Iphone 11",Price=500,Quantity=30,Option="hehe"},
            //     new Product(){Id=3,Name="Iphone 12",Price=500,Quantity=30,Option="hehe"}
            // };
            _productService = iProductService;
        }
        public IActionResult Index()
        {
            var products = _productService.GetProducts();
            return View(products);
        }
        public IActionResult Create()
        {
            var categories = _productService.GetCategories();
            return View(categories);
        }

        public IActionResult Update(int Id)
        {
            var product = _productService.GetProductById(Id);
            if (product == null) return RedirectToAction("Create");
            var categories = _productService.GetCategories();
            ViewBag.Product = product;
            return View(categories);
        }

        public IActionResult Save(Product product)
        {
            List<Product> listProduct = _productService.GetProducts();
            var check = 0;
            foreach(var product1 in listProduct)
            {
                if(product1.Id == product.Id)
                {
                    check = 1;
                    break;
                }
            }
            if (check == 0)
            {
                _productService.CreateProduct(product);
            }
            else
            {
                _productService.UpdateProduct(product);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            _productService.DeleteProduct(Id);
            return RedirectToAction("Index");
        }
    }
}