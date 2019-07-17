using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Abp.Application.Services.Dto;
using Abp.Runtime.Session;
using Abp.AutoMapper;
using blogger.Blogs.Dtos;
using Microsoft.EntityFrameworkCore;

namespace blogger.Blogs
{
    [AbpAuthorize]
    public class BlogAppService : bloggerAppServiceBase, IBlogAppService
    {
        private readonly IBlogManager _blogManager;
        private readonly IRepository<Blog, Guid> _blogRepository;
        public BlogAppService(
            IBlogManager blogManager,
            IRepository<Blog, Guid> blogRepository)
        {
            _blogManager = blogManager;
            _blogRepository = blogRepository;
        }
        public async Task<ListResultDto<BlogListDto>> GetListAsync(GetBlogListInput input)
        {
            var blogs = await _blogRepository
            .GetAll()
            .WhereIf(!input.IncludeCanceledBlogs, e => !e.IsCancelled)
            .Take(64)
            .ToListAsync();
            return new ListResultDto<BlogListDto>(blogs.MapTo<List<BlogListDto>>());
        }
        public async Task CreateAsync(CreateBlogInput input)
        {
            var @blog = Blog.Create(AbpSession.GetTenantId(), input.Title, input.Content, input.Date, input.AuthorId, input.CategoryId, input.Image);
            await _blogManager.CreateAsync(@blog);
        }
        public async Task CancelAsync(EntityDto<Guid> input)
        {
            var @blog = await _blogManager.GetAsync(input.Id);
            _blogManager.Cancel(@blog);
        }
    }
}