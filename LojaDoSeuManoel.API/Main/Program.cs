using LojaDoSeuManoel.Infrastruture.Auth;
using LojaDoSeuManoel.Infrastruture.ExternalService;
using LojaDoSeuManoel.Infrastruture.Persistense;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace LojaDoSeuManoel.API.Main
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Loja do seu Manoel",
                    Version = "v1",
                    Description = "API criada para automatização do processo de dimensionamento de produtos (games) para alguma caixa conforme as dimensões dos produtos.",
                    Contact = new OpenApiContact
                    {
                        Name = "Paulo Andrade",
                        Email = "parthur207@gmail.com"
                    }
                });

                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "Informe o token JWT: Bearer {seu token}",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };

                c.AddSecurityDefinition("Bearer", securityScheme);

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });

            //banco de dados InMemory
            builder.Services.AddDbContext<LojaDoSeuManoelDbContext>(options =>
                options.UseInMemoryDatabase("LojaDoSeuManoelDbContext"));

            //Banco de dados SQL
            /*var cnn = builder.Configuration.GetConnectionString("DefaultConnection");
            Console.WriteLine($"Conexão: {cnn}");

            builder.Services.AddDbContext<LojaDoSeuManoelDbContext>(options => options.UseSqlServer(cnn));*/

            /*
            builder.Services.AddScoped<IAdminProductInterface, AdminProductService>();
            builder.Services.AddScoped<IAdminTransactionInterface, AdminTransactionService>();
            builder.Services.AddScoped<IAdminUserInterface, AdminUserService>();
            builder.Services.AddScoped<IProductInterface, ProductService>();
            builder.Services.AddScoped<ITransactionInterface, TransactionService>();
            builder.Services.AddScoped<IUserInterface, UserService>();


            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            */

            builder.Services.AddScoped<IJwtInterface, JwtService>();

            builder.Services.AddTransient<INotificationInterface, NotificationService>();

            //Autenticação JWT
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                    };
                });

            //Autorização
            builder.Services.AddAuthorization();

            var app = builder.Build();

            //pipeline HTTP
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "LojaDoSeuManoel API v1");
                });
            }
            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}

