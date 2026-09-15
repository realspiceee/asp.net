using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace aspnetWebApp.Pages;

public class IndexModel : PageModel
{
    [BindProperty]
    public string Name { get; set; }
    
    [BindProperty]
    public string Phone { get; set; }
    
    [BindProperty]
    public string Email { get; set; }

    [BindProperty]
    public string City { get; set; } // НОВОЕ

    [BindProperty]
    public string Speciality { get; set; }
    
    [BindProperty]
    public string MainLanguage { get; set; } // НОВОЕ

    [BindProperty]
    public string StudyFormat { get; set; } // НОВОЕ

    [BindProperty]
    public string Course { get; set; }
    
    [BindProperty]
    public string BirthDate { get; set; }
    
    [BindProperty]
    public string[] Technologies { get; set; } = Array.Empty<string>();

    [BindProperty]
    public string AboutMe { get; set; } // НОВОЕ

    public string Message { get; set; }

    public void OnGet()
    {
    }

    public IActionResult OnPost() {
        string technologies = Technologies.Length > 0
            ? string.Join(", ", Technologies)
            : "Не выбраны";

        string aboutMeText = !string.IsNullOrWhiteSpace(AboutMe) 
            ? AboutMe 
            : "Не указана";

        string message = $"Анкета студента\n\n" +
                $"Имя: {Name}\n" + 
                $"Телефон: {Phone}\n" +
                $"Email: {Email}\n" +
                $"Город: {City}\n" + // НОВОЕ
                $"Специальность: {Speciality}\n" +
                $"Основной язык: {MainLanguage}\n" + // НОВОЕ
                $"Формат обучения: {StudyFormat}\n" + // НОВОЕ
                $"Курс: {Course}\n" +
                $"Дата рождения: {BirthDate}\n" +
                $"Технологии: {technologies}\n" +
                $"О себе: {aboutMeText}"; // НОВОЕ

        return Content(message);
    }
}
