using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace blogger.Blogs.Dtos
{
    [AutoMapFrom(typeof(Category))]
    public class CategoryListDto : EntityDto<int>
    {
        public string Title { get; set; }
    }
}