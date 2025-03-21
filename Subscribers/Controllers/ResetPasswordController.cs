﻿using System.Reflection.Metadata;
using Microsoft.AspNetCore.Mvc;
using Subscribers.Models;
using System.Net.Mail;
using Microsoft.AspNetCore.Identity;

namespace Subscribers.Controllers
{
    public class ResetPasswordController : Controller
    {
        private readonly Spo2Context _context;
        public ResetPasswordController (Spo2Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(User user)
        {
            var confirEmail = _context.Users.FirstOrDefault(d => d.Email == user.Email);
            if (confirEmail == null) 
            {
                ModelState.AddModelError("Email", "Пользователя с такой почтой не существует");
                return View(user);
            }
            string userEmail = confirEmail.Email;
            string UserPassword = confirEmail.Password;
            string UserFirstName = confirEmail.Firstname;
            string UserSecondName = confirEmail.Secondname;
            string emailSubject = "Восстановление пароля";
            string emailBody = $"<div><h1>Здарваствуйте, {UserSecondName} {UserFirstName}! </h1> </div> <h2>Ваш пароль:</h2><p>{UserPassword}</p>";

            SendPasswordOnEmail emailService = new SendPasswordOnEmail();
            emailService.SendPassword(userEmail, emailSubject, emailBody);
            return RedirectToAction("Index", "Authorization");
        }
    }
}
