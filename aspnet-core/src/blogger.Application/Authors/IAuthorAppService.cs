using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using blogger.Authors.Dtos;

namespace blogger.Authors
{
    public interface IAuthorAppService : IApplicationService
    {
        Task<ListResultDto<AuthorListDto>> GetListAsync(GetAuthorListInput input);
        Task CreateAsync(CreateAuthorInput input);
        Task DeativateAsync(EntityDto<long> input);
    }
}