using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Application.Services.Dto;
using blogger.Blogs.Dtos;
using Abp.AutoMapper;
using Microsoft.EntityFrameworkCore;
namespace blogger.Blogs
{
    [AbpAuthorize]
    public class CategoryAppServices : bloggerAppServiceBase, ICategoryAppService
    {
        private readonly ICategoryManager _categoryManager;
        private readonly IRepository<Category, int> _categoryRepository;
        public CategoryAppServices(
            ICategoryManager categoryManager,
            IRepository<Category, int> categoryRepository)
        {
            _categoryManager = categoryManager;
            _categoryRepository = categoryRepository;
        }
        public async Task<ListResultDto<CategoryListDto>> GetListAsync()
        {
            var categories = await _categoryRepository
            .GetAll()
            .Take(64)
            .ToListAsync();
            return new ListResultDto<CategoryListDto>(categories.MapTo<List<CategoryListDto>>());
        }
        public async Task CreateAsync(CreateCategoryInput input)
        {
            var @category = Category.Create(input.Title);
            await _categoryManager.CreateAsync(@category);
        }
        public async Task DeleteAsync(EntityDto<int> input)
        {
            await _categoryManager.DeleteAsync(
                await _categoryManager.GetAsync(input.Id));
        }
    }
}