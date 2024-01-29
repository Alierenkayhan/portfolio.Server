var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

//DB ConnectionStrings
builder.Services.Configure<DatabaseSettings>(
                builder.Configuration.GetSection("ConnectionStrings"));

#region Scoped
builder.Services.AddScoped<IRepository<About>, AboutService>();
builder.Services.AddScoped<IRepository<Recommendation>, RecommendationService>();
builder.Services.AddScoped<IRepository<ContentFile>, ContentFileService>();
builder.Services.AddScoped<IRepository<Hobbies>, HobbiesService>();
builder.Services.AddScoped<IRepository<MiniBio>, MiniBioService>();
builder.Services.AddScoped<IRepository<Skills>, SkillsService>();
builder.Services.AddScoped<IRepository<Socials>, SocialsService>();
builder.Services.AddScoped<IRepository<Education>, EducationService>();
builder.Services.AddScoped<IRepository<Voluntarily>, VoluntarilyService>();
builder.Services.AddScoped<IRepository<WorkExperience>, WorkExperienceService>();
#endregion


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<SecurityMiddleware>();

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
