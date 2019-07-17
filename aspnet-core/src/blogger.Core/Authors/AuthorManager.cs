using System;
using System.Threading.Tasks;

using Abp.Events.Bus;
using Abp.Domain.Repositories;
using Abp.UI;


namespace blogger.Authors
{
    public class AuthorManager : IAuthorManager
    {
        public IEventBus EventBus { get; set; }
        private readonly IRepository<Author, long> _authorRepository;

        public AuthorManager(
            IRepository<Author, long> authorRepository
        )
        {
            _authorRepository = authorRepository;
        }
        public async Task<Author> GetAsync(long id)
        {
            var @author = await _authorRepository.FirstOrDefaultAsync(id);
            if (@author == null)
            {
                throw new UserFriendlyException("Could not found the author, maybe it's deleted!");
            }
            return @author;
        }

        public async Task CreateAsync(Author @author)
        {
            await _authorRepository.InsertAsync(@author);
        }
        public void Deactivate(Author @author)
        {
            @author.Deactivate();
        }
    }
}