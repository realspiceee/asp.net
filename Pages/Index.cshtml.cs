using System;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using aspnetWebApp.Models;

namespace aspnetWebApp.Pages;

public class IndexModel : PageModel
{
    [BindProperty]
    public string Name { get; set; } = "";
    
    [BindProperty]
    public string Phone { get; set; } = "";
    
    [BindProperty]
    public string Email { get; set; } = "";

    [BindProperty]
    public string City { get; set; }  = "";

    [BindProperty]
    public string Speciality { get; set; } = "";
    
    [BindProperty]
    public string MainLanguage { get; set; }  = "";

    [BindProperty]
    public string StudyFormat { get; set; }  = "";

    [BindProperty]
    public string Course { get; set; } = "";
    
    [BindProperty]
    public string BirthDate { get; set; } = "";
    
    [BindProperty]
    public string[] Technologies { get; set; } = Array.Empty<string>();

    [BindProperty]
    public string AboutMe { get; set; }  = "";
    public string Message { get; set; }

    public static List<Student> Students { get; set; } = new();

    public void OnGet() {}

    public IActionResult OnPost() {
        string technologies = Technologies.Length > 0
            ? string.Join(", ", Technologies)
            : "Не выбраны";

        string aboutMeText = !string.IsNullOrWhiteSpace(AboutMe) 
            ? AboutMe 
            : "Не указана";

        // string message = $"Анкета студента\n\n" +
        //         $"Имя: {Name}\n" + 
        //         $"Телефон: {Phone}\n" +
        //         $"Email: {Email}\n" +
        //         $"Город: {City}\n" + 
        //         $"Специальность: {Speciality}\n" +
        //         $"Основной язык: {MainLanguage}\n" +  
        //         $"Формат обучения: {StudyFormat}\n" +  
        //         $"Курс: {Course}\n" +
        //         $"Дата рождения: {BirthDate}\n" +
        //         $"Технологии: {technologies}\n" +
        //         $"О себе: {aboutMeText}"; 

        var student = new Student {
            Id = Students.Count + 1,
            Name = Name,
            Phone = Phone,
            Email = Email,
            City = City,
            Speciality = Speciality,
            MainLanguage = MainLanguage,
            StudyFormat = StudyFormat,
            Course = Course,
            BirthDate = BirthDate,
            Technologies = Technologies,
            AboutMe = AboutMe
        };

        Students.Add(student);

        // return Content(JsonSerializer.Serialize(student),
        // "application/json");

        return new JsonResult(student);
    }

    public IActionResult OnPostDelete(int Id){
        var student = Students.FirstOrDefault(x => x.Id == Id);
        if (student == null) {
            return new JsonResult(new {
                success = false,
                message = "Студент не найден"
            });
        }
        Students.Remove(student);
        return new JsonResult(new {
            success = true
        });
    }
}
