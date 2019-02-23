using ApplicationsFromCitizens.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ApplicationsFromCitizens.Interfaces
{
    public class ApplicationFormProvider : IApplicationFormProvider
    {
        List<SelectListItem> _GetAnswerList = new List<SelectListItem>();
        List<SelectListItem> _GetSocialStatusList = new List<SelectListItem>();

        public ApplicationFormProvider()
        {
            var tmp = new List<SelectListItem>();
            tmp.Add(new SelectListItem
            {
                Text = "в электронной форме",
                Value = "1",
                Selected = true
            });
            tmp.Add(new SelectListItem
            {
                Text = "в письменной форме",
                Value = "2"
            });
            _GetAnswerList = tmp;

            var tmp2 = new List<SelectListItem>();
            tmp2.Add(new SelectListItem
            {
                Text = "не указано",
                Value = "1",
                Selected = true
            });
            tmp2.Add(new SelectListItem
            {
                Text = "пенсионер",
                Value = "2"
            });
            tmp2.Add(new SelectListItem
            {
                Text = "инвалид",
                Value = "3"
            });
            tmp2.Add(new SelectListItem
            {
                Text = "ветеран труда",
                Value = "4"
            });

            _GetSocialStatusList = tmp2;

        }
        public ApplicationFormViewModel GetApplicationFormViewModel()
        {
            return new ApplicationFormViewModel()
            {
                GetAnswerList = _GetAnswerList,
                GetSocialStatusList = _GetSocialStatusList,
#if DEBUG
                ApplicationForm = new ApplicationForm() {
                    GetAnswerListId = 1,
                    Attachment = null,
                    Email = "",
                    FamilyName = "",
                    Name = "",
                    Message = "",
                    MiddleName = "",
                    Mobile = "",
                    SocialStatusId = 1
                },
#endif
#if !DEBUG
                ApplicationForm = null,      
#endif
                Title = "Направить электронное обращение",
                MessageSuccess = null,
                ListError = null,
                Info = null
            };
        }

        public ApplicationFormViewModel GetApplicationFormViewModel(ApplicationForm m)
        {
            return new ApplicationFormViewModel()
            {
                GetAnswerList = _GetAnswerList,
                GetSocialStatusList = _GetSocialStatusList,
                ApplicationForm = m,
                Title = "Направить электронное обращение",
                MessageSuccess = null,
                ListError = null,
                Info = null
            };
        }
    }
}