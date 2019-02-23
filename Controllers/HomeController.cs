using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ApplicationsFromCitizens.Models;
using ApplicationsFromCitizens.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System;
using Helpers;

namespace ApplicationsFromCitizens.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApplicationFormProvider _tProvider;
        private readonly SendMail _sendMail;
        
        public HomeController(IApplicationFormProvider applicationFormProvider, SendMail sendMail)
        {
            _sendMail = sendMail;
            _tProvider = applicationFormProvider;
        }

        public IActionResult Index()
        {
            return View(_tProvider.GetApplicationFormViewModel());
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Index(ApplicationFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    return View("TreatmentCheck", _tProvider.GetApplicationFormViewModel(model.ApplicationForm));
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }
            }
            model = _tProvider.GetApplicationFormViewModel();
            model.ListError = ModelState.GetAllErrors();
            return View(model);
        }

        [HttpGet]
        public ActionResult TreatmentCheck(ApplicationFormViewModel model)
        {
            return View(model);
        }

        [HttpPost]
        public ActionResult TreatmentCheck(ApplicationFormViewModel m, string btnSubmit)
        {
            switch (btnSubmit)
            {
                case "SendTreatment":
                    try
                    {
                        var getAnswer = "в электронном форме";
                        if (m.ApplicationForm.GetAnswerListId == 2)
                        { getAnswer = "в письменной форме"; }

                        var sub = "Обращение из личного кабинета";
                        var email = "Office@mp-ges.ru";
                        var bodyMail =
                            $" <b>ФИО отправителя:</b> {m.ApplicationForm.FamilyName} {m.ApplicationForm.Name} {m.ApplicationForm.MiddleName} <br>" +
                            $" <b>Способ получения ответа:</b> {getAnswer} <br>" +
                            $" <b>Адресной электронной почты:</b> {m.ApplicationForm.Email} <br>" +
                            $" <b>Телефон или сотовый:</b> {m.ApplicationForm.Mobile} <br>" +
                            $" <b>Текст обращения:</b> {m.ApplicationForm.Message}";
                        _sendMail.SendCustom(sub, bodyMail, email);

                        return RedirectToAction("Result");
                    }
                    catch
                    {
                    }
                    return View();

                case "EditTreatment":
                    return View("Index", _tProvider.GetApplicationFormViewModel(m.ApplicationForm));

                default:
                    return View();
            }
        }

        public ActionResult Result()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Описания приложения";

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
