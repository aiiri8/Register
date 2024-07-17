using System.Collections.Immutable;
using Register.Domain.Models;

namespace Register.Domain.Features.GetWards;

public record GetWardsResult(
    ImmutableHashSet<Ward> Wards);