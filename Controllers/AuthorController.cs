using ApiAuthor.Contexts;
using ApiAuthor.Entities;
using ApiAuthor.Filters;
using ApiAuthor.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAuthor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {

        private readonly ApiDBContext Context;
        private readonly ILogger<AuthorController> Logger;
        private readonly IService Service;
        private readonly ServiceTrasient ServiceTrasient;
        private readonly ServiceScoped ServiceScoped;
        private readonly ServiceSingleton ServiceSingleton;

        public AuthorController(ApiDBContext context, ILogger<AuthorController> logger, IService service, ServiceTrasient serviceTrasient, ServiceScoped serviceScoped, ServiceSingleton serviceSingleton)
        {
            Context = context;
            Logger = logger;
            Service = service;
            ServiceTrasient = serviceTrasient;
            ServiceScoped = serviceScoped;
            ServiceSingleton = serviceSingleton;
        }

        [HttpGet("Guid")]
        [ServiceFilter(typeof(MyActionFilter))]
        public ActionResult GetGuid()
        {
            return Ok(new
            {
                ControllerTrasient = ServiceTrasient.Guid,
                ServiceTrasient = Service.GetTrasient(),
                ControllerScoped = ServiceScoped.Guid,
                ServiceScoped = Service.GetScoped(),
                ControllerSingleton = ServiceSingleton.Guid,
                ServiceSingleton = Service.GetSingleton(),
            });
        }

        [HttpGet]
        [HttpGet("Listado")]
        [HttpGet("/Listado")]
        [ServiceFilter(typeof(MyActionFilter))]
        public async Task<ActionResult<List<Author>>> Get()
        {
            throw new NotImplementedException();
            Logger.LogInformation("Get List Author");
            return await  Context.Authors.Include(a => a.Books).ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Author>> GetById(int id)
        {
            Author author =  await Context.Authors.FirstOrDefaultAsync(a => a.Id == id);
            if (author is null)
            {
                return NotFound();
            }
            return author;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Author author)
        {
            bool existNameAuthor = await Context.Authors.AnyAsync(a => a.Name == author.Name);
            if (existNameAuthor)
            {
                return BadRequest($"The Author's name {author.Name} alreasy exist");
            }

            Context.Add(author);
            await Context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, Author author)
        {
            if (id != author.Id)
            {
                return BadRequest("El id del autor no coincide con el id de la URL");
            }
            bool exist = await Context.Authors.AnyAsync(a => a.Id == id);
            if (!exist)
            {
                return BadRequest("El id del autor no existe");
            }

            Context.Update(author);
            await Context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Remove(int id)
        {
            bool exist = await Context.Authors.AnyAsync(a => a.Id == id);
            if (!exist)
            {
                return BadRequest("El id del autor no existe");
            }
            Context.Remove(new Author { Id = id } );
            await Context.SaveChangesAsync();
            return Ok();
        }

    }
}
