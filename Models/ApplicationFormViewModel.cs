using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ApplicationsFromCitizens.Models
{
    public class ApplicationFormViewModel
    {
        public string Title { get; set; }
        public string MessageSuccess { get; set; }
        public IEnumerable<string> ListError { get; set; }
        public string Info { get; set; }
        public ApplicationForm ApplicationForm { get; set; }
        public List<SelectListItem> GetAnswerList { get; set; }
        public List<SelectListItem> GetSocialStatusList { get; set; }
    }
}
