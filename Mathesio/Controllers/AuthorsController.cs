using System;
using System.Collections.Generic;
using AutoMapper;
using InternetDiscussion.Models;
using InternetDiscussion.Services;
using InternetDiscussion.Tools;
using Microsoft.AspNetCore.Mvc;

namespace InternetDiscussion.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorsController : ControllerBase
    {
        private readonly IInternetDiscussionRepository _internetDiscussionRepository;
        private readonly IMapper _mapper;

        public AuthorsController(IInternetDiscussionRepository internetDiscussionRepository,
            IMapper mapper)
        {
            _internetDiscussionRepository = internetDiscussionRepository ??
                throw new ArgumentNullException(nameof(internetDiscussionRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }


        [HttpGet()]
        [HttpHead]
        public ActionResult<IEnumerable<AuthorDto>> GetAuthors()
        {
            var authorsFromRepository = _internetDiscussionRepository.GetAuthors();
            return Ok(_mapper.Map<IEnumerable<AuthorDto>>(authorsFromRepository));
        }

        [HttpGet("{authorId}", Name = "GetAuthor")]
        public IActionResult GetAuthor(int authorId)
        {
            var authorFromRepository = _internetDiscussionRepository.GetAuthor(authorId);

            if (authorFromRepository == null)
            {
                Logger.GetLogger().LogNonExistingAuthor(authorId);
                return NotFound();
            }

            return Ok(_mapper.Map<AuthorDto>(authorFromRepository));
        }

        [HttpPost]
        public ActionResult<AuthorDto> CreateAuthor(AuthorForCreationDto author)
        {
            var authorEntity = _mapper.Map<Entities.Author>(author);
            _internetDiscussionRepository.AddAuthor(authorEntity);
            _internetDiscussionRepository.Save();

            var authorToReturn = _mapper.Map<AuthorDto>(authorEntity);
            return CreatedAtRoute("GetAuthor",
                new { authorId = authorToReturn.Id },
                authorToReturn);
        }
    }
}
