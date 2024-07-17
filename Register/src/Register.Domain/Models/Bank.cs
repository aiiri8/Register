using System;

namespace Register.Domain.Models;

public record Bank(
    long? Id,
    string BankName);