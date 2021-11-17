using Inlamning2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Inlamning2.Controllers
{
    public class OrderController : Controller
    {

        // GET: OrderController
        public async Task<ActionResult> Index()
        {
            var http = new HttpClient();
            var orders = await http.GetFromJsonAsync<List<Order>>("https://localhost:44347/api/Orders");
            return View(orders);
        }

        // GET: OrderController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var http = new HttpClient();
            var order = await http.GetFromJsonAsync<Order>("https://localhost:44347/api/Orders/" + id);

            return View(order);
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult NoUser()
        {
            return View();
        }

        public ActionResult SomethingWentWrong()
        {
            return View();
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateOrder()
        {
            var order = new Order();
            if(UserController.LastLoggedInId > 0)
            {
                if (CartController._CartList.Count > 0)
                {
                    order = new Order()
                    {
                        OrderDate = DateTimeOffset.Now,
                        OrderLines = CartController._CartList,
                        UserId = UserController.LastLoggedInId
                    };
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                return RedirectToAction(nameof(NoUser));
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var client = new HttpClient();
                    await client.PostAsJsonAsync("https://localhost:44347/api/Orders", order);
                    CartController._CartList = new List<OrderLine>();

                    return RedirectToAction(nameof(Create));
                }
                catch
                {
                    return RedirectToAction(nameof(SomethingWentWrong));
                }
            }
            else
            {
                return RedirectToAction(nameof(SomethingWentWrong));
            }
        }

        public ActionResult OrderUpdated()
        {
            return View();
        }

        public async Task<ActionResult> UpdateOrder(Order order)
        {
            var tempId = 0;
            var http = new HttpClient();
            var orders = await http.GetFromJsonAsync<List<Order>>("https://localhost:44347/api/Orders");
            foreach(var _order in orders)
            {
                if(_order.OrderId == order.OrderId)
                {
                    if(_order.Status == "recieved")
                    {
                        _order.Status = "sent";

                        if (ModelState.IsValid)
                        {
                            try
                            {
                                var client = new HttpClient();
                                await client.PutAsJsonAsync("https://localhost:44347/api/Orders/" + _order.OrderId, _order);


                                return RedirectToAction(nameof(OrderUpdated));
                            }
                            catch
                            {
                                return RedirectToAction(nameof(SomethingWentWrong));
                            }
                        }
                        else
                        {
                            return RedirectToAction(nameof(SomethingWentWrong));
                        }
                    }
                    if(_order.Status == "sent")
                    {
                        _order.Status = "received";

                        if (ModelState.IsValid)
                        {
                            try
                            {
                                var client = new HttpClient();
                                await client.PutAsJsonAsync("https://localhost:44347/api/Orders/" + _order.OrderId, _order);

                                return RedirectToAction(nameof(OrderUpdated));
                            }
                            catch
                            {
                                return RedirectToAction(nameof(SomethingWentWrong));
                            }
                        }
                        else
                        {
                            return RedirectToAction(nameof(SomethingWentWrong));
                        }
                    }
                }
                tempId++;
            }
            return RedirectToAction(nameof(SomethingWentWrong));
        }

        public async Task<ActionResult> Delete(Order order)
        {
            var tempId = 0;
            var http = new HttpClient();
            var orders = await http.GetFromJsonAsync<List<Order>>("https://localhost:44347/api/Orders");
            foreach (var _order in orders)
            {
                if (_order.OrderId == order.OrderId)
                {
                    _order.Status = "deleted";

                    if (ModelState.IsValid)
                    {
                        try
                        {
                            var client = new HttpClient();
                            await client.PutAsJsonAsync("https://localhost:44347/api/Orders/" + _order.OrderId, _order);

                            return RedirectToAction(nameof(OrderUpdated));
                        }
                        catch
                        {
                            return RedirectToAction(nameof(SomethingWentWrong));
                        }
                    }
                    else
                    {
                        return RedirectToAction(nameof(SomethingWentWrong));
                    }
                }
                tempId++;
            }
            return RedirectToAction(nameof(SomethingWentWrong));
        }


        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
