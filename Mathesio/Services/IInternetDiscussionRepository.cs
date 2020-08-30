using System.Collections.Generic;
using InternetDiscussion.Entities;

namespace InternetDiscussion.Services
{
    public interface IInternetDiscussionRepository
    {
        Author GetAuthor(int authorId);
        IEnumerable<Author> GetAuthors();
        bool AuthorExists(int authorId);
        void AddAuthor(Author author);
        Topic GetTopic(int authorId, int topicId);
        IEnumerable<Topic> GetTopics(int authorId);
        void AddTopic(int authorId, Topic topic);
        IEnumerable<Reply> GetRepliesOfAuthor(int authorId);
        IEnumerable<Reply> GetRepliesOfTopic(int topicId);
        void AddReply(int authorId, int topicId, Reply reply);
        void AddReply(int topicId, Reply reply);
        bool Save();
    }
}
