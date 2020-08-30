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
    [Route("api/authors/{authorId}/topics")]
    public class TopicsForAuthorController : ControllerBase
    {
        private readonly IInternetDiscussionRepository _internetDiscussionRepository;
        private readonly IMapper _mapper;

        public TopicsForAuthorController(IInternetDiscussionRepository internetDiscussionRepository,
            IMapper mapper)
        {
            _internetDiscussionRepository = internetDiscussionRepository ??
                throw new ArgumentNullException(nameof(internetDiscussionRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult<IEnumerable<TopicLookupDto>> GetTopicsForAuthor(int authorId)
        {
            if (!_internetDiscussionRepository.AuthorExists(authorId))
            {
                Logger.GetLogger().LogNonExistingAuthor(authorId);
                return NotFound();
            }

            var topicsForAuthorFromRepository = _internetDiscussionRepository.GetTopics(authorId);
            return Ok(_mapper.Map<IEnumerable<TopicLookupDto>>(topicsForAuthorFromRepository));
        }

        [HttpPost]
        public ActionResult<TopicDto> CreateTopicForAuthor(
            int authorId, TopicForCreationDto topic)
        {
            if (!_internetDiscussionRepository.AuthorExists(authorId))
            {
                Logger.GetLogger().LogNonExistingAuthor(authorId);
                return NotFound();
            }

            var topicEntity = _mapper.Map<Entities.Topic>(topic);
            _internetDiscussionRepository.AddTopic(authorId, topicEntity);
            _internetDiscussionRepository.Save();

            var topicToReturn = _mapper.Map<TopicDto>(topicEntity);
            return CreatedAtRoute("GetTopicForAuthor",
                new { authorId = authorId, topicId = topicToReturn.Id },
                topicToReturn);
        }

        [HttpGet("{topicId}", Name = "GetTopicForAuthor")]
        public ActionResult<TopicDto> GetTopicForAuthor(int authorId, int topicId)
        {
            if (!_internetDiscussionRepository.AuthorExists(authorId))
            {
                Logger.GetLogger().LogNonExistingAuthor(authorId);
                return NotFound();
            }

            var topicForAuthorFromRepository = _internetDiscussionRepository.GetTopic(authorId, topicId);

            if (topicForAuthorFromRepository == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<TopicDto>(topicForAuthorFromRepository));
        }

    }
}