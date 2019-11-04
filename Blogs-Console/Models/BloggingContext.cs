using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using NLog;
namespace BlogsConsole.Models
{
    public class BloggingContext : DbContext
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public BloggingContext() : base("name=BlogContext") { }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        public void DisplayBlog()
        {
            var database = new BloggingContext();
            var query = database.Blogs.OrderBy(b => b.Name);

            Console.WriteLine($"{query.Count()} Blogs returned");
            foreach (var item in query)
            {
                Console.WriteLine(item.Name);
            }
        }
        public void AddBlog()
        {
            Console.Write("Enter new blog");
            var blog = new Blog { Name = Console.ReadLine() };
            var database = new BloggingContext();
        }
        public void CreatePost()
        {
            var database = new BloggingContext();
            var query = database.Blogs.OrderBy(b => b.BlogId);

            Console.WriteLine("Select blog");
            foreach (var item in query)
            {
                Console.WriteLine($"{item.BlogId}) {item.Name}");
                Console.WriteLine("Enter blog ID here");
                int userBlogChosen = int.Parse(Console.ReadLine());

                Post match = new Post();

                if (userBlogChosen == item.BlogId)
                {
                    //add post
                    Console.Write("Enter new post");
                    var post = new Post { Name = Console.ReadLine() };
                    var database = new BloggingContext();
                }
            }
        }
        public void DisplayPost()
        {
            var database = new BloggingContext();
            var query = database.Blogs.OrderBy(b => b.BlogId);
            Console.WriteLine("Enter Blog ID to display");
            Console.WriteLine("(D)isplay all blogs");
            var userSelect = Console.ReadLine().ToUpper();

            foreach (var item in query)
            {
                Console.WriteLine($"{item.BlogId}) Posts from {item.Name}");
            }
            List<Post> LPost;
            if (userSelect == "D")
            {
                //display all post and blogs
                Posts = db.Posts.OrderBy(p => p.Title);
            }
        }
        public void DeletePost()
        {
            //delete post
            Console.WriteLine("What post do you wish to delete?");
            var post = Console.ReadLine();
            var database = new BloggingContext();
            database.Remove(post);

        }
        public void EditPost()
        {
            //edit post
            Console.WriteLine("What post to you wish to edit?");
            var post = Console.ReadLine();
            var database = new BloggingContext();

            Posts newPost = post(database);

        }
    }
}
