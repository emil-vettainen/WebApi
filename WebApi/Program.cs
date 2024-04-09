using Business.AutoMapper;
using Business.Services;
using Infrastructure.Contexts;
using Infrastructure.Repositories.ContactRepositories;
using Infrastructure.Repositories.CoursesRepositories;
using Infrastructure.Repositories.Subscribers;
using Microsoft.EntityFrameworkCore;
using WebApi.Configurations;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("SQLServer")));
builder.Services.AddScoped<SubscribeRepository>();
builder.Services.AddScoped<SubscribeService>();
builder.Services.AddScoped<ContactRequestRepository>();
builder.Services.AddScoped<ContactRequestService>();


builder.Services.AddDbContext<CosmosDbContext>(x => x.UseCosmos("AccountEndpoint=https://evettainen.documents.azure.com:443/;AccountKey=p7pfxnLGAF3LNixPDdrcXuz58iuWdD0tlDf9YLJswUP530PVVlWTL1MMsz7xML98cWXFghwwhCdBACDbOowCEQ==;", "WebApi"));
builder.Services.AddScoped<CourseRepository>();
builder.Services.AddScoped<CourseService>();



builder.Services.RegisterSwagger();
builder.Services.ReqisterJwt(builder.Configuration);

var app = builder.Build();

app.UseCors(x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

app.UseSwagger();
app.UseSwaggerUI(x => x.SwaggerEndpoint("/swagger/v1/swagger.json", "Silicon Web Api v1"));

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();