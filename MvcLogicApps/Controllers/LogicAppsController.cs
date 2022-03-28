﻿using Microsoft.AspNetCore.Mvc;
using MvcLogicApps.Models;
using MvcLogicApps.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcLogicApps.Controllers
{
    public class LogicAppsController : Controller
    {
        private ServiceLogicApps service;

        public LogicAppsController(ServiceLogicApps service)
        {
            this.service = service;
        }

        public IActionResult SendMail()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMail(EmailModel model)
        {
            await this.service.SendMailAsync(model.Email
                , model.Subject, model.Body);
            ViewData["MENSAJE"] = "Logic Apps de Mail en proceso!!!!";
            return View();
        }

        public IActionResult SumarNumeros()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SumarNumeros
            (int numero1, int numero2)
        {
            string respuesta =
                await this.service.SumarNumerosAsync(numero1, numero2);
            ViewData["MENSAJE"] = respuesta;
            return View();
        }
    }
}
