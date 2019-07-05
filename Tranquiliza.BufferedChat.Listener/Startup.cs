using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Tranquiliza.BufferedChat.Listener.Twitch;
using Scrutor;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tranquiliza.BufferedChat.Core;

namespace Tranquiliza.BufferedChat.Listener
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                 .SetBasePath(env.ContentRootPath)
                 .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var botSettings = Configuration.GetSection("ChatbotClient");
            var botName = botSettings.GetValue<string>("BotUserName");
            var botOAuthToken = botSettings.GetValue<string>("BotOAuthToken");

            //Per Server
            var chatbotsettings = new TwitchClientSettings(botName, botOAuthToken);
            var client = new TwitchChatClient(chatbotsettings, shouldReplateEmotes: true);
            services.AddSingleton<ITwitchChatClient>(client);

            services.AddSingleton<BotMain, BotMain>();
            services.AddHostedService<ServiceHost>();

            //This must be last!
            services.AddScoped<ServiceFactory>(p => p.GetService);
            services.Scan(scan => scan
                .FromAssembliesOf(typeof(IMediator), typeof(Program), typeof(IDateTimeProvider))
                .AddClasses()
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsImplementedInterfaces());

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseExceptionHandler("/Error");

            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
