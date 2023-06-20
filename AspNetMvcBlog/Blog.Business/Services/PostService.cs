﻿using Azure;
using Blog.Data;
using Blog.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Blog.Business.Services.Abstract;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Blog.Business.Services
{
    public class PostService : IPostService
    {
        private readonly AppDbContext _db;

        public PostService(AppDbContext db)
        {
            // Post koleksiyonunu başlatma veya veritabanından veri çekme işlemleri burada yapılabilir
            _db = db;
        }

        public List<PostDto> GetAll()
        {
            return _db.Posts.Include(p => p.Categories).Include(p => p.User).ToList().PostListToDtoList();
                
        }

        public PostDto GetById(int id)
        {
            return _db.Posts
                .Include(p => p.Categories)
                .Include(p => p.User)
                .Where(p => p.Id == id)
                .FirstOrDefault().PostToDto();
        }

        public void Insert(PostDto post)
        {
            _db.Posts.Add(post.DtoToPost());
            _db.SaveChanges();
        }

        public void Update(PostDto post)
        {
            var oldPost = _db.Posts.FirstOrDefault(p => p.Id == post.Id);
            if (oldPost != null)
            {
                _db.Entry(oldPost).CurrentValues.SetValues(post);
                _db.SaveChanges();
            }
        }

        public void DeleteById(int id)
        {
            var post = _db.Posts.SingleOrDefault(p => p.Id == id);
            if (post != null)
            {
                _db.Posts.Remove(post);
                _db.SaveChanges();
            }
        }

    }
}