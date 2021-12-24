using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project1_WebAPI.Data;
using Project1_WebAPI.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project1_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private IAuthor _author;
        private IMapper _mapper;

        public AuthorsController(IAuthor author, IMapper mapper)
        {
            _author = author ?? throw new ArgumentNullException(nameof(author));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        // GET: api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> Get()
        {
            var authors = await _author.GetAll();
            var dtos = _mapper.Map<IEnumerable<AuthorDto>>(authors);
            return Ok(dtos);
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto>> Get(int id)
        {
            var result = await _author.GetById(id.ToString());
            if (result == null)
                return NotFound();

            return Ok(_mapper.Map<AuthorDto>(result));
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<AuthorDto>> Post([FromBody] AuthorForCreateDto authorforCreateDto)
        {
            try
            {
                var author = _mapper.Map<Models.Author>(authorforCreateDto);
                var result = await _author.Insert(author);
                var authorReturn = _mapper.Map<Dtos.AuthorDto>(result);
                return Ok(authorReturn);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult<AuthorDto>> Put(int id, [FromBody] AuthorForCreateDto authorForCreateDto)
        {
            try
            {
                var author = _mapper.Map<Models.Author>(authorForCreateDto);
                var result = await _author.Update(id.ToString(), author);
                var authordto = _mapper.Map<Dtos.AuthorDto>(result);
                return Ok(authordto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _author.Delete(id.ToString());
                return Ok($"Data author {id} berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
