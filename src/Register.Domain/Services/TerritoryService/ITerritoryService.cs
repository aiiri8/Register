using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Register.Domain.Features.AddTerritory;
using Register.Domain.Features.GetTerritories;
using Register.Domain.Features.GetTerritory;

namespace Register.Domain.Services.TerritoryService;

public interface ITerritoryService
{
    Task<AddTerritoryResult> AddTerritoryAsync(
        string command,
        CancellationToken cancellationToken);

    public Task<AddTerritoryResult> UpdateTerritoryAsync(
        long id,
        string command,
        CancellationToken cancellationToken);
    
    public Task<GetTerritoryResult> GetTerritoryAsync(
        long id,
        CancellationToken cancellationToken);
    
    public Task<GetTerritoriesResult> GetTerritoriesAsync(
        CancellationToken cancellationToken);
}