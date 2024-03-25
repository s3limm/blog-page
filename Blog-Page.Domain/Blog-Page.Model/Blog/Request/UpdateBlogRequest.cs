﻿using System;
using Microsoft.AspNetCore.Http;

namespace Blog_Page.Model.Blog.Request
{
	public class UpdateBlogRequest
	{
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public int CategoryID { get; set; }
    }
}

