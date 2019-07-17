using System;
using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace blogger.Blogs.Dtos
{
    [AutoMapFrom(typeof(Category))]
    public class CategoryDetailOutput : EntityDto<long>
    {
        public string Title { get; set; }
        public ICollection<Blog> Blogs { get; set; }
    }
}