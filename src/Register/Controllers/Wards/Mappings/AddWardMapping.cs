using Register.Controllers.Wards.Models;
using Register.Domain.Models;

namespace Register.Controllers.Wards.Mappings;

public static class AddWardMapping
{
    public static Ward MapToModel(
        this AddWardRequest request)
    {
        return new Ward(
            null,
            request.FirstName,
            request.LastName,
            request.Patronymic,
            request.Birthday.Date,
            request.Snils);
    }
}