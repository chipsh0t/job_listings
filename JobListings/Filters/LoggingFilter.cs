using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace JobListingsWeb.Filters
{
	public class LogRequestAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			string requestPath = context.HttpContext.Request.Path;
			string requestMethod = context.HttpContext.Request.Method;

			Console.WriteLine($"Request received for {requestPath} [{requestMethod}]");

			base.OnActionExecuting(context);
		}
	}
}
