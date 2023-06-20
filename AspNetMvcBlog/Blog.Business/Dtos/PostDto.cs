﻿using Blog.Data.Entity.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Data.Entity;

public class PostDto : AuditEntity
{
	[Key]
	public int Id { get; set; }

	
	public int UserId { get; set; }
	public User User { get; set; }


	[Required]
	[Column(TypeName = "nvarchar(200)")]
	public string? Title { get; set; }

	[Required]
	[Column(TypeName = "ntext")]
	public string? Content { get; set; }

	// Navigation Properties
	public List<CategoryDto> Categories { get; set; }
}