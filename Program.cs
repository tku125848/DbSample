using Microsoft.AspNetCore.HttpOverrides;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using Microsoft.AspNetCore.HttpOverrides;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace DbSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
           

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddCors();
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession();

            builder.Services.AddHttpClient();
            builder.Services.AddRazorPages()
                .AddJsonOptions(options =>
                {
                    //�쥻�O JsonNamingPolicy.CamelCase�A�j���Y��r��p�g�A�ڰ��n������ˡA�]��null
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                    //���\�򥻩ԤB�^��Τ�������r������r��
                    options.JsonSerializerOptions.Encoder =
                        JavaScriptEncoder.Create(UnicodeRanges.BasicLatin
                        , UnicodeRanges.CjkUnifiedIdeographs
                        , UnicodeRanges.AlphabeticPresentationForms
                        , UnicodeRanges.HalfwidthandFullwidthForms
                        );
                });

            builder.Services.AddMemoryCache();
            builder.Services.AddSingleton<HtmlEncoder>(HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.BasicLatin, UnicodeRanges.CjkUnifiedIdeographs }));
            builder.Services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders =
                    ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseForwardedHeaders();
            //var origins = builder.Configuration.GetSection("CORS:Origins").Get<string[]>();

            //app.UseCors(cors => {
            //    cors.WithOrigins(origins).AllowAnyMethod().AllowCredentials().AllowAnyHeader();
            //});
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSession();
            app.Use(async (context, next) =>
            {
                context.Session.SetString("SessionKey", "SessoinValue");
                await next.Invoke();
            });
            app.MapRazorPages();

            app.Run();

        }
    }
}