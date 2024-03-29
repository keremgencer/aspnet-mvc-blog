﻿using Blog.Business.Dtos;
using Blog.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Blog.Business
{
    public static class DtoConvertions
    {

        //post

        public static PostDto PostToDto(this Post p)
        {
            return new PostDto { Id = p.Id, CategoryDtos = p.Categories.CategoryListToDtoList(), Content = p.Content, CreatedAt = p.CreatedAt, DeletedAt = p.DeletedAt, Title = p.Title, UpdatedAt = p.UpdatedAt, UserId = p.UserId, User = p.User.UserToDto(), PostImageDtos = p.PostImages.PostImageListToDtoList() };
        }

        public static List<PostDto> PostListToDtoList(this List<Post> p)
        {
            List<PostDto> dtos = new List<PostDto>();
            if (p != null)
            {
                foreach (var item in p)
                {
                    dtos.Add(item.PostToDto());
                }
            }
            return dtos;
        }
        public static Post DtoToPost(this PostDto p)
        {
            //var categories = p.Categories.DtoListToCategoryList();

            var postEntity = new Post
            {
                Id = p.Id,
                Title = p.Title,
                Content = p.Content,
                CreatedAt = p.CreatedAt,
                DeletedAt = p.DeletedAt,
                UpdatedAt = p.UpdatedAt,
                UserId = p.UserId,
                //Categories = categories,
            };

            return postEntity;
        }

        public static List<Post> DtoListToPostList(this List<PostDto> p)
        {
            List<Post> dtos = new List<Post>();
            foreach (var item in p)
            {
                dtos.Add(item.DtoToPost());
            }
            return dtos;
        }

        //user

        public static UserDto UserToDto(this User u)
        {
            return u != null ? new UserDto { City = u.City, Email = u.Email, Id = u.Id, Name = u.Name, Password = u.Password, Phone = u.Phone, Roles = u.Roles } : null;
        }

        public static List<UserDto> UserListToDtoList(this List<User> p)
        {
            List<UserDto> dtos = new List<UserDto>();
            foreach (var item in p)
            {
                dtos.Add(item.UserToDto());
            }
            return dtos;
        }
        public static User DtoToUser(this UserDto u)
        {
            return new User {
                City = u.City,
                Email = u.Email,
                Id = u.Id,
                Name = u.Name,
                Password = u.Password,
                Phone = u.Phone
            };
        }

        //category

        public static CategoryDto CategoryToDto(this Category c)
        {
            return new CategoryDto { Description = c.Description, Name = c.Name, Id = c.Id, /*Posts = c.Posts.PostListToDtoList(),*/ Slug = c.Slug };
        }

        public static List<CategoryDto> CategoryListToDtoList(this List<Category> p)
        {
            List<CategoryDto> dtos = new List<CategoryDto>();
            foreach (var item in p)
            {
                dtos.Add(item.CategoryToDto());
            }
            return dtos;
        }

        public static Category DtoToCategory(this CategoryDto c)
        {
            return new Category
            {
                Description = c.Description,
                Name = c.Name,
                Id = c.Id,
                Slug = c.Slug,
            /*Posts = c.Posts.DtoListToPostList()*/
            };
        }

        public static List<Category> DtoListToCategoryList(this List<CategoryDto> p)
        {
            var entities = new List<Category>();
            foreach (var item in p)
            {
                entities.Add(item.DtoToCategory());
            }
            return entities;
        }

        //page


        public static PageDto PageToDto(this Page p)
        {
            return new PageDto { Content = p.Content, CreatedAt = p.CreatedAt, DeletedAt = p.DeletedAt, Id = p.Id, IsActive = p.IsActive, Slug = p.Slug, Title = p.Title, UpdatedAt = p.UpdatedAt };
        }

        public static List<PageDto> PageListToDtoList(this List<Page> p)
        {
            List<PageDto> dtos = new List<PageDto>();
            foreach (var item in p)
            {
                dtos.Add(item.PageToDto());
            }
            return dtos;
        }
        public static Page DtoToPage(this PageDto p)
        {
            return new Page { Content = p.Content, CreatedAt = p.CreatedAt, DeletedAt = p.DeletedAt, Id = p.Id, IsActive = p.IsActive, Slug = p.Slug, Title = p.Title, UpdatedAt = p.UpdatedAt };

        }

        //setting

        public static SettingDto SettingToDto(this Setting s)
        {
            return new SettingDto { Id = s.Id, Name = s.Name, UserId = s.UserId, Value = s.Value };
        }

        public static List<SettingDto> SettingListToDtoList(this List<Setting> s)
        {
            List<SettingDto> dtos = new List<SettingDto>();
            foreach (var item in s)
            {
                dtos.Add(item.SettingToDto());
            }
            return dtos;
        }
        public static Setting DtoToSetting(this SettingDto s)
        {
            return new Setting { Id = s.Id, Name = s.Name, UserId = s.UserId, Value = s.Value };

        }

        //Images

        public static List<PostImageDto> PostImageListToDtoList(this List<PostImage> images)
        {
            if (images == null) return null;
            List<PostImageDto> postImages = new List<PostImageDto>();
            foreach (var i in images) {
                postImages.Add(PostImageToDto(i));
            
            }
            return postImages;
        }

        public static PostImageDto PostImageToDto(this PostImage i)
        {
            if (i == null) return null;
            PostImageDto postImage = new PostImageDto { Id = i.Id, ImagePath = i.ImagePath, PostId = i.PostId };
            return postImage;
        }
    }
}
