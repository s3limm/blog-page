﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Blog_Page.Models
{
    public class UpdateBlogModel : BaseModel
    {
        public int? ID { get; set; }

        [Required(ErrorMessage = "Blog adı boş geçilemez")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Blog açıklaması boş geçilemez")]
        public string Description { get; set; }

        [Required(ErrorMessage = "İçerik boş geçilemez")]
        public string Content { get; set; }
        //public IFormFile FileData { get; set; }

        //Relational Properties

        [Required(ErrorMessage = "Kategori boş geçilemez")]

        public int CategoryID { get; set; }
        public List<SelectListItem>? Categories { get; set; }
    }
}
