using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Register.Domain.Features.AddWard;
using Register.Domain.Features.GetWard;
using Register.Domain.Features.GetWards;
using Register.Domain.Models;
using Register.Domain.Repositories;

namespace Register.Domain.Services.WardService;

public class WardService(IWardRepository wardRepository) : IWardService
{
    private readonly IWardRepository _wardRepository = wardRepository;

    public async Task<AddWardResult> AddWardAsync(
        Ward command,
        CancellationToken cancellationToken)
    {
        var result = await _wardRepository.Add(command, cancellationToken);
        return new AddWardResult(result);
    }
    
    public async Task<AddWardResult> UpdateWardAsync(
        long id,
        Ward command,
        CancellationToken cancellationToken)
    {
        var result = await _wardRepository.Update(id, command, cancellationToken);
        return new AddWardResult(result);
    }

    public async Task<GetWardResult> GetWardAsync(
        long id,
        CancellationToken cancellationToken)
    {
        var result = await _wardRepository.Get(id, cancellationToken);
        return new GetWardResult(result);
    }
    
    public async Task<GetWardsResult> GetWardsAsync(
        GetWardsQuery query,
        CancellationToken cancellationToken)
    {
        var skip = (query.PageNumber - 1) * query.PageSize;
        var take = query.PageSize;
        var result = await _wardRepository.Get(skip, take, cancellationToken);
        return new GetWardsResult(result);
    }
    
    public async Task<GetWardsResult> GetWardsAsync(
        string query,
        CancellationToken cancellationToken)
    {
        var result = await _wardRepository.Get(query, cancellationToken);
        return new GetWardsResult(result);
    }
}