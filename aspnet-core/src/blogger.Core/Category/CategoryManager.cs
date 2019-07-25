using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Events.Bus;
using Abp.UI;

using blogger.Authors;

namespace blogger.Blogs
{
    public class CategoryManager : ICategoryManager
    {
        public IEventBus EventBus { get; set; }
        private readonly IRepository<Category,int> _blogCategoryRepository;

        public CategoryManager(
            IRepository<Category,int> blogCategoryRepository
        )
        {
            _blogCategoryRepository = blogCategoryRepository;
        }

        public async Task<Category> GetAsync(int id)
        {
            var @categories = await _blogCategoryRepository.FirstOrDefaultAsync(id);
            if (@categories == null)
            {
                throw new UserFriendlyException("Could not found the category, maybe it's deleted!");
            }

            return @categories;
        }

        public async Task CreateAsync(Category @category)
        {
            await _blogCategoryRepository.InsertAsync(@category);
        }
        public async Task DeleteAsync(Category @category)
        {
             await _blogCategoryRepository.DeleteAsync(@category);
        }
    }
}