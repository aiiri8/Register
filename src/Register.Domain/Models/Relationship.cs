using System;

namespace Register.Domain.Models;

public record Relationship(
    long? Id,
    long GuardianId,
    long WardId,
    long DaysInMonth,
    DateTime EndingDate);