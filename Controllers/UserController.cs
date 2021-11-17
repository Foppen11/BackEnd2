using Inlamning2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Inlamning2.Controllers
{
    public class UserController : Controller
    {
        public static int LastLoggedInId;

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult FailedLogin()
        {
            return View();
        }

        public async Task<ActionResult> VerifyLogin(User user)
        {
            var checkEmail = user.Email;
            var checkPassword = user.Password;

            if(checkEmail == null || checkPassword == null)
            {
                return RedirectToAction(nameof(Login));
            }
            
            var http = new HttpClient();
            var users = await http.GetFromJsonAsync<List<User>>("https://localhost:44347/api/Users");

            foreach (var account in users)
            {
                if(account.Email == checkEmail)
                {
                    if(account.Password == checkPassword)
                    {
                        //return logged in
                        LastLoggedInId = account.Id;
                        return View(account);
                    }
                    else
                    {
                        //return password incorrect
                        return RedirectToAction(nameof(FailedLogin));
                    }
                }
            }
            return RedirectToAction(nameof(FailedLogin));
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult FailedRegister()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> VerifyRegister(User user)
        {
            
            var checkEmail = user.Email;
            var checkPassword = user.Password;

            if (checkEmail == null || checkPassword == null || user.FirstName == null || user.LastName == null)
            {
                return RedirectToAction(nameof(FailedRegister));
            }

            Regex emailRegex = new(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match emailMatch = emailRegex.Match(checkEmail);

            Regex passwordRegex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$");
            Match passwordMatch = passwordRegex.Match(checkPassword);

            if(emailMatch.Success && passwordMatch.Success)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        var http = new HttpClient();
                        var users = await http.GetFromJsonAsync<List<User>>("https://localhost:44347/api/Users");
                        foreach (var account in users)
                        {
                            if (account.Email == user.Email)
                            {
                                //return account with email exist
                                return RedirectToAction(nameof(FailedRegister));
                            }
                        }

                        var client = new HttpClient();
                        await client.PostAsJsonAsync("https://localhost:44347/api/Users", user);

                        return View();
                    }
                    catch
                    {
                        return RedirectToAction(nameof(FailedRegister));

                    }
                }
                else
                {
                    return RedirectToAction(nameof(FailedRegister));

                }
            }

            return RedirectToAction(nameof(FailedRegister));

        }
    }
}
