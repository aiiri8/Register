using System;

namespace Register.Domain.Models;

public record Ward(
    long? Id,
    string FirstName,
    string LastName,
    string Patronymic,
    DateTime Birthday,
    string Snils);