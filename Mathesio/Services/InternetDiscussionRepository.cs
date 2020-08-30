using System;
using System.Collections.Generic;
using System.Linq;
using InternetDiscussion.DbContexts;
using InternetDiscussion.Entities;

namespace InternetDiscussion.Services
{
    public class InternetDiscussionRepository : IInternetDiscussionRepository
    {

        private readonly InternetDiscussionContext _context;

        public InternetDiscussionRepository(InternetDiscussionContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void AddAuthor(Author author)
        {
            if (author == null)
            {
                throw new ArgumentNullException(nameof(author));
            }

            _context.Authors.Add(author);
        }

        public void AddReply(int authorId, int topicId, Reply reply)
        {
            throw new NotImplementedException();
        }

        public void AddReply(int topicId, Reply reply)
        {
            throw new NotImplementedException();
        }

        public void AddTopic(int authorId, Topic topic)
        {
            if (topic == null)
            {
                throw new ArgumentNullException(nameof(topic));
            }
            topic.AuthorId = authorId;
            _context.Topics.Add(topic);
        }

        public bool AuthorExists(int authorId)
        {
            return _context.Authors.Any(a => a.Id == authorId);
        }

        public Author GetAuthor(int authorId)
        {
            return _context.Authors.FirstOrDefault(a => a.Id == authorId);
        }

        public IEnumerable<Author> GetAuthors()
        {
            return _context.Authors.ToList<Author>();
        }

        public IEnumerable<Reply> GetRepliesOfAuthor(int authorId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reply> GetRepliesOfTopic(int topicId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Topic> GetTopics(int authorId)
        {
            return _context.Topics
                        .Where(c => c.AuthorId == authorId)
                        .OrderBy(c => c.Id).ToList();
        }


        public Topic GetTopic(int authorId, int topicId)
        {
            return _context.Topics
              .Where(c => c.AuthorId == authorId && c.Id == topicId).FirstOrDefault();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
