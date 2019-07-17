using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using blogger.Blogs.Dtos;

namespace blogger.Blogs
{
    public interface ICategoryAppService : IApplicationService
    {
        Task<ListResultDto<CategoryListDto>> GetListAsync();
        Task CreateAsync(CreateCategoryInput input);
        Task DeleteAsync(EntityDto<int> input);
    }
}