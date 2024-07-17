using Register.Controllers.Wards.Models.GetWards;
using Register.Domain.Features.GetWard;
using Register.Domain.Models;

namespace Register.Controllers.Wards.Mappings;

public static class GetWardMapping
{
    public static WardResponse MapToResponse (
        this GetWardResult result)
    {
        return result.Ward.MapToResponse();
    }

   public static WardResponse MapToResponse(
        this Ward ward)
    {
        return new WardResponse(
            (ward.Id ?? 0),
            ward.FirstName,
            ward.LastName,
            ward.Patronymic,
            ward.Birthday,
            ward.Snils);
    }
}