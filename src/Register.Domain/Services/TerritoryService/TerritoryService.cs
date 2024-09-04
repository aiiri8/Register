using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Register.Domain.Features.AddTerritory;
using Register.Domain.Features.GetTerritories;
using Register.Domain.Features.GetTerritory;
using Register.Domain.Repositories;

namespace Register.Domain.Services.TerritoryService;

public class TerritoryService(ITerritoryRepository territoryRepository) : ITerritoryService
{
    private readonly ITerritoryRepository _territoryRepository = territoryRepository;

    public async Task<AddTerritoryResult> AddTerritoryAsync(
        string command,
        CancellationToken cancellationToken)
    {
        var result = await _territoryRepository.Add(command, cancellationToken);
        return new AddTerritoryResult(result);
    }
    
    public async Task<AddTerritoryResult> UpdateTerritoryAsync(
        long id,
        string command,
        CancellationToken cancellationToken)
    {
        var result = await _territoryRepository.Update(id, command, cancellationToken);
        return new AddTerritoryResult(result);
    }

    public async Task<GetTerritoryResult> GetTerritoryAsync(
        long id,
        CancellationToken cancellationToken)
    {
        var result = await _territoryRepository.Get(id, cancellationToken);
        return new GetTerritoryResult(result);
    }
    
    public async Task<GetTerritoriesResult> GetTerritoriesAsync(
        CancellationToken cancellationToken)
    {
        var result = await _territoryRepository.Get(cancellationToken);
        return new GetTerritoriesResult(result);
    }
}