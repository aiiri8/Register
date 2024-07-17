using System;

namespace Register.Controllers.Relationships.Models;

public record UpdateRelationshipRequest(
    long DaysInMonth,
    DateTime EndingDate);