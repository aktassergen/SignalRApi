using SignalR.BL.Abstract;
using SignalR.BL.Concrete;
using SignalR.DAL.Abstract;
using SignalR.DAL.Concrete;
using SignalR.DAL.EntityFrameWork;
using SignalRApi.Hubs;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader()//herhangibi ba�l��a izin versin
        .AllowAnyMethod()//herhangibi metoda izin versin
        .SetIsOriginAllowed((host) => true)//herhangibi kayna�a izin versin
        .AllowCredentials();//herhangibi Kimli�e izin versin
	});
});
builder.Services.AddSignalR();

builder.Services.AddDbContext<SignalRContext>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());//otomapper icin kullan�lan recister y�ntem

builder.Services.AddScoped<IAboutService,AboutManager>();//servisi g�rd���nde manageri �a��r
builder.Services.AddScoped<IAboutDal,EfAboutDal>();

builder.Services.AddScoped<IBookingService, BookingManager>();
builder.Services.AddScoped<IBookingDal, EfBookingDal>();

builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();

builder.Services.AddScoped<IContantService, ContantManager>();
builder.Services.AddScoped<IContantDal, EfContantDal>();

builder.Services.AddScoped<IDiscountService, DiscountManager>();
builder.Services.AddScoped<IDiscountDal, EfDiscountDal>();

builder.Services.AddScoped<IFeatureService, FeatureManager>();
builder.Services.AddScoped<IFeatureDal, EfFeatureDal>();

builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<IProductDal, EfProductDal>();

builder.Services.AddScoped<ISosialMediaService, SosialMediaManager>();
builder.Services.AddScoped<ISosialMediaDal, EfSosialMediaDal>();

builder.Services.AddScoped<ITestimonialService, TestimonialManager>();
builder.Services.AddScoped<ITestimonialDal, EfTestimonialDal>();

builder.Services.AddControllers();
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
app.UseCors("CorsPolicy");//yukardaki kullanm�� oldu�um keyi �a��rm�� oldum

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHub<SignalRHub>("/signalrhub");

app.Run();

//diyelim ki bir yere istekte bulunulacak localhost://1234/swagger/category/index bu porttan sonra istekte bulunmak istedi�im yer neresi
//localhost://1234/signalrhub yukardaki yaz��um maphub ile buraya istekte bulunuyorum
