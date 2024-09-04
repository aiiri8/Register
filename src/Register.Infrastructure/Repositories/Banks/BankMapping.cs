using Register.Database.Models;
using Register.Domain.Models;

namespace Register.Infrastructure.Repositories.Banks;

public static class BankMapping
{
    public static Bank MapToModel(
        this BankDto dto)
    {
        return new Bank
        (
            dto.Id,
            dto.BankName
        );
    }
    
    public static BankDto MapToDto(
        this string model)
    {
        return new BankDto()
        {
            BankName = model
        };
    }
}