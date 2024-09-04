using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Register.Domain.Features.AddWard;
using Register.Domain.Features.GetWard;
using Register.Domain.Features.GetWards;
using Register.Domain.Models;

namespace Register.Domain.Services.WardService;

public interface IWardService
{
    Task<AddWardResult> AddWardAsync(
        Ward command,
        CancellationToken cancellationToken);

    public Task<AddWardResult> UpdateWardAsync(
        long id,
        Ward command,
        CancellationToken cancellationToken);
    
    public Task<GetWardResult> GetWardAsync(
        long id,
        CancellationToken cancellationToken);
    
    public Task<GetWardsResult> GetWardsAsync(
        GetWardsQuery query,
        CancellationToken cancellationToken);
    
    public Task<GetWardsResult> GetWardsAsync(
        string query,
        CancellationToken cancellationToken);
}