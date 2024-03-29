﻿using ApiAuthor.Contexts;
using ApiAuthor.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiAuthor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {

        private readonly ApiDBContext Context;

        public AuthorController(ApiDBContext context)
        {
            Context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Author>>> Get()
        {
            return await  Context.Authors.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Author>> GetById(int id)
        {
            Author author = await Context.Authors.FirstOrDefaultAsync(a => a.Id == id);
            if (author is null)
            {
                return NotFound();
            }
            return author;
        }

        [HttpGet("{name:string}")]
        public async Task<ActionResult<Author>> GetById([FromRoute] string name)
        {
            Author author = await Context.Authors.FirstOrDefaultAsync(a => a.Name == name);
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
                return BadRequest($"The Author's name {author.Name} already exist");
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
