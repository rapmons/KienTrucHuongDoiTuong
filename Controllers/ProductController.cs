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
  private readonly datacontext _context;
    public ProductController(datacontext context)
    {
       _context=context;
    }
        public IActionResult Index()
        {
            var Products= _context.Product.ToList();
            // var categories= new List<String>()
            // {
            //     "SmartPhone",
            //     "TV"
            // };
            // ViewBag.categories=categories;
          //  ViewData["Categories"]=categories;
            return View(Products);
        }
    }
}