using System.Collections.Immutable;
using Register.Domain.Models;

namespace Register.Domain.Features.GetGuardians;

public record GetGuardiansResult(
    ImmutableHashSet<Guardian> Guardians);