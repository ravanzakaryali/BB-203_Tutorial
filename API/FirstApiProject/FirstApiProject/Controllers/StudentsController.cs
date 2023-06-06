using FirstApiProject.DataContexts;
using FirstApiProject.DTOs;
using FirstApiProject.DTOs.StudentDto;
using FirstApiProject.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstApiProject.Controllers;


[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public StudentsController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            return StatusCode(200, await _dbContext.Students.ToListAsync());
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new
            {
                Message = ex.Message
            });
        }
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        Student? student = await _dbContext.Students.FirstOrDefaultAsync(s => s.Id == id);
        if (student == null)
        {
            return NotFound();
        }
        //return StatusCode(StatusCodes.Status200OK, student);
        return Ok(student);
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromForm] StudentCreateDto student)
    {
        Student newStudent = new Student()
        {
            FullName = student.FullName,
        };
        await _dbContext.Students.AddAsync(newStudent);
        await _dbContext.SaveChangesAsync();
        return StatusCode(StatusCodes.Status201Created);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        Student? student = await _dbContext.Students.FirstOrDefaultAsync(s => s.Id == id);
        if (student == null)
        {
            return NotFound();
        }
        _dbContext.Students.Remove(student);
        await _dbContext.SaveChangesAsync();
        return NoContent();
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] StudentUpdateDto student)
    {
        Student? studentDb = await _dbContext.Students.FirstOrDefaultAsync(s => s.Id == id);
        if (studentDb == null)
        {
            return NotFound();
        }
        studentDb.FullName = student.FullName;
        await _dbContext.SaveChangesAsync();
        return Ok(studentDb);
    }
}
