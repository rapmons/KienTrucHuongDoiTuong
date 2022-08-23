using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductManager.Models;

namespace ProductManager.Controllers
{
public class ProductController : Controller
{
    public List<Product> Products { get; set; }
    public ProductController()
    {
        Products= new List<Product>()
        {
            new Product(){Id=1,Name="Iphone 10",Price=500,Quantity=30,Option="hehe"},
            new Product(){Id=2,Name="Iphone 11",Price=500,Quantity=30,Option="hehe"},
            new Product(){Id=3,Name="Iphone 12",Price=500,Quantity=30,Option="hehe"}
        };
    }
        public IActionResult Index()
        {
            
            return View(Products);
        }
    }
}