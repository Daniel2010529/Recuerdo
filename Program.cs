var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
	app.Use(async (context, next) =>
	{
		await next();
		if (context.Request.Path == "/" || context.Request.Path == "/index.html")
		{
			context.Response.Headers.CacheControl = "no-store, no-cache, must-revalidate";
		}
	});
}
app.UseDefaultFiles();
app.UseStaticFiles();
app.Run();
