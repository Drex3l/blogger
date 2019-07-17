using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using blogger.Blogs.Dtos;

namespace blogger.Blogs
{
    public interface IBlogAppService : IApplicationService
    {
        Task<ListResultDto<BlogListDto>> GetListAsync(GetBlogListInput input);
        Task CreateAsync(CreateBlogInput input);
        Task CancelAsync(EntityDto<Guid> input);
    }
}