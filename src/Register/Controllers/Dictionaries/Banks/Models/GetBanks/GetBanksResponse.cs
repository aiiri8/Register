using System;
using System.Collections.Immutable;

namespace Register.Controllers.Dictionaries.Banks.Models.GetBanks;

public record GetBanksResponse(
    ImmutableArray<BankResponse> BankResponses);
    
public record BankResponse(
    long Id,
    string BankName
);