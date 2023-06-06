namespace FirstApiProject.DTOs;

public class StudentCreateDto
{
    public IFormFile ProfileImage { get; set; }
    public string FullName { get; set; } = null!;
}
