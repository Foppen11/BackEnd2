using Inlamning2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inlamning2.Controllers
{
    public class CartController : Controller
    {
        public static List<OrderLine> _CartList = new List<OrderLine>();

        public IActionResult Index()
        {
            if(_CartList.Count > 0)
            {
                return View(_CartList);
            }
            else
            {
                return RedirectToAction(nameof(Empty));
            }
        }

        public ActionResult Empty()
        {
            return View();
        }

        public ActionResult CartSummary()
        {
            TempData["items"] = "new";
            return View();
        }


        public ActionResult AddToCartList(Product _orderLine)
        {
            var tempId = 0;

            if (_CartList.Count > 0)
            {
                foreach(var line in _CartList)
                {
                    if (line.ProductId == _orderLine.Id)
                    {
                        line.ProductId = line.ProductId;
                        line.Quantity = line.Quantity + 1;
                        line.UnitPrice = line.UnitPrice;
                        _CartList.RemoveAt(tempId);
                        _CartList.Insert(tempId, line);
                        CartSummary();
                        return RedirectToAction("Index", "Product");
                    }
                    tempId++;
                }
            }
            OrderLine orderLine = new OrderLine();
            orderLine.ProductId = _orderLine.Id;
            orderLine.Quantity = 1;
            orderLine.UnitPrice = _orderLine.Price;
            _CartList.Add(orderLine);
            CartSummary();
            return RedirectToAction("Index", "Product");
            }
    }
}
