using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Application.Services.Dto;
using Abp.Runtime.Session;
using Abp.Linq.Extensions;
using blogger.Authors.Dtos;
using Abp.AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace blogger.Authors
{
    [AbpAuthorize]
    public class AuthorAppService : bloggerAppServiceBase, IAuthorAppService
    {
        private readonly IAuthorManager _authorManager;
        private readonly IRepository<Author, long> _authorsRepository;
        public AuthorAppService(
            IAuthorManager authorManager,
            IRepository<Author, long> authorsRepository)
        {
            _authorManager = authorManager;
            _authorsRepository = authorsRepository;
        }

        public async Task<ListResultDto<AuthorListDto>> GetListAsync(GetAuthorListInput input)
        {
            var authors = await _authorsRepository
                .GetAll()
                .WhereIf(!input.IncludeInactiveAccounts, e => !e.IsDeactivated)
                .Take(64)
                .ToListAsync();

            return new ListResultDto<AuthorListDto>(authors.MapTo<List<AuthorListDto>>());
        }
        public async Task CreateAsync(CreateAuthorInput input)
        {
            var @author = Author.Create(AbpSession.GetTenantId(), input.FirstName, input.LastName, input.Email);
            await _authorManager.CreateAsync(@author);
        }
        public async Task DeativateAsync(EntityDto<long> input)
        {
            var @author = await _authorManager.GetAsync(input.Id);
            _authorManager.Deactivate(@author);
        }
    }
}