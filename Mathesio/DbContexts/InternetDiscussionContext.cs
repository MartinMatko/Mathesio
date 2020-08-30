using InternetDiscussion.Entities;
using Microsoft.EntityFrameworkCore;

namespace InternetDiscussion.DbContexts
{
    public class InternetDiscussionContext : DbContext
    {
        public InternetDiscussionContext(DbContextOptions<InternetDiscussionContext> options)
           : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Topic> Topics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //dummy data
            modelBuilder.Entity<Author>().HasData(
                new Author()
                {
                    Id = 1,
                    FirstName = "Ned",
                    LastName = "First"
                },
                new Author()
                {
                    Id = 2,
                    FirstName = "Kiefer",
                    LastName = "Second"
                },
                new Author()
                {
                    Id = 3,
                    FirstName = "Stan",
                    LastName = "Third"
                }
                );

            modelBuilder.Entity<Topic>().HasData(
               new Topic
               {
                   Id = 1,
                   AuthorId = 1,
                   Title = "Is Earth flat?",
                   Description = "Of course, no other world was carried through the starry infinity on the backs of four giant elephants, who were themselves perched on the shell of a giant turtle. His name - or her name, according to another school of thought - was Great A'Tuin; he - or, as it might be she - will not take a central role in what follows but it is vital to an understanding of the Disc that he - or she - is there, down below the mines and sea ooze and fake fossil bones put there by a Creator with nothing better to do than upset archaeologists and give them silly ideas."
               },
               new Topic
               {
                   Id = 2,
                   AuthorId = 1,
                   Title = "Your favorite movie?",
                   Description = "Mine is Jurassic Park."
               }
               );

            base.OnModelCreating(modelBuilder);
        }
    }
}
