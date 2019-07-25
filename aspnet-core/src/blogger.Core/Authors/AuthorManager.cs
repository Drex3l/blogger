using System;
using System.Threading.Tasks;
using System.Linq;
using Abp.Domain.Repositories;
using Abp.Events.Bus;
using Abp.UI;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;

namespace blogger.Authors {
    public class AuthorManager : IAuthorManager {
        public AuthorManager (IEventBus eventBus) {
            this.EventBus = eventBus;

        }
        public IEventBus EventBus { get; set; }
        private readonly IRepository<Author, long> _authorRepository;

        public AuthorManager (
            IRepository<Author, long> authorRepository
        ) {
            _authorRepository = authorRepository;
        }
        public async Task<Author> GetAsync (long id) {
            var @author = await _authorRepository.FirstOrDefaultAsync (id);
            if (@author == null) {
                throw new UserFriendlyException ("Could not find author, maybe it's deleted!");
            }
            return @author;
        }

        public async Task CreateAsync (Author @author) {
            await _authorRepository.InsertAsync (@author);
        }

        public async Task UpdateAsync (Author @author) {
            await _authorRepository.UpdateAsync (@author);
        }
    }
}