using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace Helpers
{
    public static class ModelStateExtensions
    {
        public static IEnumerable<string> GetAllErrors(this ModelStateDictionary modelState)
        {
            var em = modelState.Values.SelectMany(ms => ms.Errors).Select(e => e.ErrorMessage);
            return em.IsNullOrEmpty() ? null : em;
        }
    }
}