using System;

namespace Register.Controllers.Wards.Models;

public record AddWardRequest(
    string FirstName,
    string LastName,
    string Patronymic,
    DateTime Birthday,
    string Snils);