using System.Security.Claims;
using Hangfire.Dashboard;
using Streetcode.DAL.Enums;

namespace Streetcode.BLL.Services.Hangfire;

public class HangfireDashboardAuthorizationFilter : IDashboardAuthorizationFilter
{
	public bool Authorize(DashboardContext context)
	{
		var user = GetUser(context);
		var isAdmin = IsAdmin(user);

		return isAdmin;
	}

	public bool IsAdmin(ClaimsPrincipal user)
	{
		return user.IsInRole(nameof(UserRole.Admin));
	}

	public virtual ClaimsPrincipal GetUser(DashboardContext context)
	{
		return context.GetHttpContext().User;
	}
}