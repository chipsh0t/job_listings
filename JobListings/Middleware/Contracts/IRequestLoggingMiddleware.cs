namespace JobListingsWeb.Middleware.Contracts
{
	public interface IRequestLoggingMiddleware
	{
		public Task InvokeAsync(HttpContext context);
	}
}
