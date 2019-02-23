
using ApplicationsFromCitizens.Models;

namespace ApplicationsFromCitizens.Interfaces
{
    public interface IApplicationFormProvider
    {
        ApplicationFormViewModel GetApplicationFormViewModel();
        ApplicationFormViewModel GetApplicationFormViewModel(ApplicationForm model);
    }
}
