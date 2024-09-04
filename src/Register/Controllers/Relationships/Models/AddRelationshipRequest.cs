using System;

namespace Register.Controllers.Relationships.Models;

public record AddRelationshipRequest(
    long WardId,
    long DaysInMonth,
    DateTime EndingDate);