using Register.Controllers.Dictionaries.Banks.Models.GetBanks;
using Register.Domain.Features.GetBank;
using Register.Domain.Models;

namespace Register.Controllers.Dictionaries.Banks.Mappings;

public static class GetBankMapping
{
    public static BankResponse MapToResponse (
        this GetBankResult result)
    {
        return result.Bank.MapToResponse();
    }

   public static BankResponse MapToResponse(
        this Bank bank)
    {
        return new BankResponse(
            (bank.Id ?? 0),
            bank.BankName);
    }
}