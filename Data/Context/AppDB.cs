using BlogAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI.Data.Context
{
    public class AppDB : DbContext
    {
        public AppDB(DbContextOptions<AppDB> options) : base(options) {}

        public DbSet<BlogPost> Posts { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Comment> Comments { get; set; }

        // many-to-many
        public DbSet<PostsTopics> PostsTopics { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostsTopics>().HasKey(pt => new { pt.PostId, pt.TopicId });
            modelBuilder.Entity<PostsTopics>().HasOne(pt => pt.Post).WithMany(p => p.PostsTopics).HasForeignKey(p => p.PostId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PostsTopics>().HasOne(pt => pt.Topic).WithMany(p => p.PostsTopics).HasForeignKey(t => t.TopicId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
