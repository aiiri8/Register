using System;
using System.Collections.Immutable;

namespace Register.Controllers.Wards.Models.GetWards;

public record GetWardsResponse(
    ImmutableArray<WardResponse> WardResponses);
    
public record WardResponse(
    long Id,
    string FirstName,
    string LastName,
    string Patronymic,
    DateTime Birthday,
    string Snils
);