namespace Register.Controllers.Wards.Models.GetWards;

public record GetWardsRequest(
    int PageNumber = 1,
    int PageSize = 10);