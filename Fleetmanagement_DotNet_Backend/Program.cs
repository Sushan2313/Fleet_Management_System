
using Fleetmanagement_new.Service;
using Fleetmanagement_new.Services;
using Fleets.Services;
using FM.Repositories;
using FM.Services;
using Microsoft.EntityFrameworkCore;

namespace Fleetmanagement_new
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<BookingService>();

            builder.Services.AddControllers();




            builder.Services.AddTransient<ICityService, CityService>();
            builder.Services.AddTransient<IStateService, StateService>();
            builder.Services.AddScoped<IHubService, HubService>();
            builder.Services.AddScoped<IAirportService, AirportService>();
            builder.Services.AddScoped<ICarService, CarService>();
            builder.Services.AddScoped<ICarTypeService,CarTypeService>();
           builder.Services.AddScoped<IBookingService,BookingService>();
            builder.Services.AddScoped<IBookingDetailService,BookingDetailService>();
            builder.Services.AddScoped<IAddOnService, AddOnService>();
            builder.Services.AddScoped<IInvoiceDetailService, InvoiceDetailService>();
            builder.Services.AddScoped<IInvoiceService, InvoiceService>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowReactApp",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:3000")
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });


            builder.Services.AddCors(d=>d.AddDefaultPolicy(p=>p.WithOrigins("*").AllowAnyMethod().AllowAnyHeader()));


            builder.Services.AddDbContext<FMContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
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

            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }


            //app.UseRouting();
            app.UseHttpsRedirection();
//app.UseStaticFiles();
            app.UseCors();


            app.UseAuthorization();

            /*  app.UseEndpoints(endpoints =>
              {
                  endpoints.MapControllers(); // Ensure this is included
              });*/
            app.MapControllers();

            app.Run();
        }
    }
}
