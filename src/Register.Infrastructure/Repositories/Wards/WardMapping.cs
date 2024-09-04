using Register.Database.Models;
using Register.Domain.Models;

namespace Register.Infrastructure.Repositories.Wards;

public static class WardMapping
{
    public static Ward MapToModel(
        this WardDto dto)
    {
        return new Ward
        (
            dto.Id,
            dto.FirstName,
            dto.LastName,
            dto.Patronymic,
            dto.Birthday,
            dto.Snils
        );
    }
    
    public static WardDto MapToDto(
        this Ward model)
    {
        return new WardDto()
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Patronymic = model.Patronymic,
            Birthday = model.Birthday,
            Snils = model.Snils
        };
    }
}