using System.Security.Claims;

namespace AvaliacaoPW.API.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static int GetUserId(this ClaimsPrincipal user)
    {
        return int.Parse(user.FindFirst("UserId").Value);
    }
    public static int GetCompanyName(this ClaimsPrincipal user)
    {
        return int.Parse(user.FindFirst("CompanyName").Value);
    }
}