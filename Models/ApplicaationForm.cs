using System.ComponentModel.DataAnnotations;

namespace ApplicationsFromCitizens.Models
{
    public class GetAnswer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ApplicationForm
    {
        [Required(ErrorMessage = "Укажите способ получения ответа")]
        [Display(Name = "Получить ответ")]
        public int GetAnswerListId { get; set; }

        [Required(ErrorMessage = "Введите адрес электронной почты")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Не корректный адрес электронной почты")]
        [Display(Name = "Адрес электронной почты")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите Фамилию")]
        [Display(Name = "Фамилия")]
        public string FamilyName { get; set; }

        [Required(ErrorMessage = "Введите Имя")]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Display(Name = "Отчество (при наличие)")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Введите номер телефона")]
        [Display(Name = "Номер телефона")]
        public string Mobile { get; set; }

        [Display(Name = "Социальное положение")]
        public int SocialStatusId { get; set; }


        [Required(ErrorMessage = "Введите Текст обращения")]
        [Display(Name = "Текст обращения")]
        public string Message { get; set; }

        [Display(Name = "Прикрепить файл")]
        public string Attachment { get; set; }
    }
}
