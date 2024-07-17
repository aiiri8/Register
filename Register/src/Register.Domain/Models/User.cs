namespace Register.Domain.Models;

public record User(
    long Id,
    long Email,
    string Password,
    string Name,
    string Surname,
    UserRole Role);