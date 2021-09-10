using System;
using System.Collections.Generic;
using System.Linq;
using Custom.AspNet.Filesystem;
using Custom.AspNet.PagePagination;
using Custom.AspNet.PagePagination.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication4.Controllers
{
    public class PaginationController : Controller
    {
        private readonly List<Post> _posts = new()
        {
            new() {Id = 1, Title = "Telegram", Content = "Lorem200"},
            new() {Id = 2, Title = "React", Content = "Lorem200"},
            new() {Id = 3, Title = "Angular", Content = "Lorem200"},
            new() {Id = 4, Title = "Vue", Content = "Lorem200"},
            new() {Id = 5, Title = "DotNet", Content = "Lorem200"},
            new() {Id = 6, Title = "AspNet", Content = "Lorem200"},
        };
        
        [Route("/pagination")]
        [HttpGet]
        public IActionResult Index(int currentPage, int perPage = 5)
        {
            currentPage = Math.Max(currentPage, 1);
            
            var content = _posts.Skip(perPage * (currentPage - 1)).Take(perPage);
            var pagination = new SimplePagination(
                1, currentPage, _posts.Count, perPage
            );
            ViewData["content"] = content;
            
            return View(new SimplePaginationView(
                pagination, "/pagination?currentPage={0}" + $"&perPage={perPage}"
            ));
        }

        public class Post
        {
            public int Id { get; set; }

            public string Title { get; set; }

            public string Content { get; set; }
        }
    }
}