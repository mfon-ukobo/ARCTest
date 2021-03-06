using System.Reflection;

using Infrastructure;

using Newtonsoft.Json.Converters;

using WemaClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
	.AddNewtonsoftJson(options =>
	{
		options.SerializerSettings.Converters.Add(new StringEnumConverter());
	});

builder.Services.AddSwaggerGenNewtonsoftSupport();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
	options.DescribeAllParametersInCamelCase();

	var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
	options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddHttpClient<IWemaApiClient, WemaApiClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
