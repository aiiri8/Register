using System.Collections.Immutable;
using Register.Domain.Models;

namespace Register.Domain.Features.GetBanks;

public record GetBanksResult(
    ImmutableHashSet<Bank> Banks);