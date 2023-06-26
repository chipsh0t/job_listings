using JobListingsWeb.Middleware.Contracts;

namespace JobListingsWeb.Middleware
{
	public class RequestLoggingMiddleware: IRequestLoggingMiddleware
	{
		private readonly RequestDelegate? _next;

		public RequestLoggingMiddleware() { }

		public RequestLoggingMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			string requestPath = context.Request.Path;
			string requestMethod = context.Request.Method;

			if (requestPath=="/Jobs/CreateJobListing")
			{
				Console.WriteLine($"Request received for {requestPath} [{requestMethod}]");
			}

			if (_next is not null) await _next(context);
		}
	}
}
