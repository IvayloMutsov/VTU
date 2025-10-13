using Microsoft.AspNetCore.Mvc;
using AppDbContext.Data;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;


namespace MovieRentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DirectorController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public DirectorController(ApplicationDbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<IActionResult> GetDirectors()
        {
            var directors = await context.Directors.Where(x => x.IsDeleted == false).ToListAsync();
            if (directors != null)
            {
                return Ok(directors);
            }
            else
            {
                return NotFound();
            }
        } 

        [HttpGet("id")]
        public async Task<IActionResult> GetDirectorByID(int id)
        {
            var directors = await context.Directors.ToListAsync();
            var director = directors.Find(x => x.ID == id);
            if (director != null)
            {
                return Ok(director);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("name")]
        public async Task<IActionResult> GetDirectorByName(string name)
        {
            var directors = await context.Directors.ToListAsync();
            var directorByName = directors.First(x => x.Name == name);
            if (directorByName != null)
            {
                return Ok(directorByName);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddDirector(string name, int age)
        {
            using (context)
            {
                Director director = new Director { Name = name, Age = age };
                await context.Directors.AddAsync(director);
                await context.SaveChangesAsync();
                return Ok(director);
            }
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateDirector(int id, string name)
        {
            var directors = await context.Directors.ToListAsync();
            var director = directors.Find(x => x.ID == id);
            if (director != null)
            {
                director.Name = name;
                director.DateLastModified = DateTime.Now;
                context.Directors.Update(director);
                await context.SaveChangesAsync();
                return Ok(director);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("delete")]
        public async Task<IActionResult> DeleteDirector(int id)
        {
            var directors = await context.Directors.ToListAsync();
            var directorDelete = directors.Find(x => x.ID == id);
            if (directorDelete == null)
            {
                return NotFound();
            }
            else
            {
                SoftDelete del = new SoftDelete { EntityID = id, Name = directorDelete.Name, IsDeleted = true };
                directorDelete.IsDeleted = true;
                directorDelete.DateLastModified = DateTime.Now;
                await context.SoftDelete.AddAsync(del);
                context.Directors.Update(directorDelete);
                await context.SaveChangesAsync();
                return Ok();
            }
        }
    }
}
