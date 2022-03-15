using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P320.DomainModels.DTOs;
using P320.DomainModels.Entities;
using P320.Repository.DataContext;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace P320.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public StudentsController(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var students = await _dbContext.Students.ToListAsync();

            return Ok(_mapper.Map<List<StudentDto>>(students));
        }

        [HttpGet("{id?}")]
        public async Task<IActionResult> Get([FromRoute] int? id)
        {
            if (id == null)
                return NotFound();

            var student = await _dbContext.Students.FindAsync(id);
            if (student == null)
                return NotFound();

            return Ok(_mapper.Map<StudentDto>(student));
        }
    }
}
