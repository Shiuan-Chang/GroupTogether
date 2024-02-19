using GroupTogether.Data;
using Microsoft.EntityFrameworkCore;
namespace GroupTogether
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // 在此处，builder.Configuration 已经是 IConfiguration 的实例，您可以直接使用它
            var configuration = builder.Configuration;
            // 使用配置，例如获取连接字符串
            var connectionString = configuration.GetConnectionString("DefaultConnection");
           
            // 添加服务到服务容器
            builder.Services.AddDbContext<DataContext>(options => 
            {
                options.UseSqlite(connectionString);
            });
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

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
