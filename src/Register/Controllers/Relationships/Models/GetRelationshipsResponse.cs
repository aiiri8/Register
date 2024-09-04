using System;
using System.Collections.Immutable;

namespace Register.Controllers.Relationships.Models;

public record GetRelationshipsResponse(
    ImmutableArray<RelationshipResponse> RelationshipResponses);
    
public record RelationshipResponse(
    long Id,
    long GuardianId,
    long WardId,
    string WardFirstName,
    string WardLastName,
    string WardPatronymic,
    DateTime WardBirthdate,
    string WardSnils,
    long DaysInMonth,
    DateTime EndingDate
);