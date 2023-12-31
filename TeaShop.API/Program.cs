using TeaShop.API.ValidationRules;
using TeaShop.BusinessLayer.Abstract;
using TeaShop.BusinessLayer.Concrete;
using TeaShop.DataAccessLayer.Abstract;
using TeaShop.DataAccessLayer.Concrete;
using TeaShop.DataAccessLayer.EntityFramework;
using TeaShop.EntityLayer.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IAboutDAL, EFAboutDAL>();
builder.Services.AddScoped<IAboutService, AboutManager>();

builder.Services.AddScoped<IContactDAL, EFContactDAL>();
builder.Services.AddScoped<IContactService, ContactManager>();

builder.Services.AddScoped<IDrinkDAL, EFDrinkDAL>();
builder.Services.AddScoped<IDrinkService, DrinkManager>();

builder.Services.AddScoped<IMapDAL, EFMapDAL>();
builder.Services.AddScoped<IMapService, MapManager>();

builder.Services.AddScoped<IMessageDAL, EFMessageDAL>();
builder.Services.AddScoped<IMessageService, MessageManager>();

builder.Services.AddScoped<IQuestionDAL, EFQuestionDAL>();
builder.Services.AddScoped<IQuestionService, QuestionManager>();

builder.Services.AddScoped<ISocialMediaDAL, EFSocialMediaDAL>();
builder.Services.AddScoped<ISocialMediaService, SocialMediaManager>();

builder.Services.AddScoped<ISubscribeDAL, EFSubscribeDAL>();
builder.Services.AddScoped<ISubscribeService, SubscribeManager>();

builder.Services.AddScoped<ITestimonialDAL, EFTestimonialDAL>();
builder.Services.AddScoped<ITestimonialService, TestimonialManager>();

builder.Services.AddScoped<IStatisticsDAL, EFStatisticsDAL>();
builder.Services.AddScoped<IStatisticsService, StatisticsManager>();

builder.Services.AddScoped<IBannerDAL, EFBannerDAL>();
builder.Services.AddScoped<IBannerService, BannerManager>();

builder.Services.AddScoped<IShopDAL, EFShopDAL>();
builder.Services.AddScoped<IShopService, ShopManager>();

builder.Services.AddDbContext<TeaContext>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<TeaContext>().AddErrorDescriber<CustomIdentityValidator>();

builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.UseCors("AllowAllOrigins");

app.Run();