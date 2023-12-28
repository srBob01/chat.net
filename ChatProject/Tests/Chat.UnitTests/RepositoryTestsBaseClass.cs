using Chat.DataAccess;
using Chat.Service.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Chat.UnitTests.Repository;

public class RepositoryTestsBaseClass
{
    public RepositoryTestsBaseClass()
    {
        //13.11 - лекция по бизнес логике 
        //3 лаба включает тесты - дедлайн 13.11
        //20.11 - практика по бизнес логике - делаем лабу 4 - 27.11 включать тесты
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile("appsettings.Test.json", optional: true)
            .Build();

        Settings = ChatSettingsReader.Read(configuration);
        ServiceProvider = ConfigureServiceProvider();

        DbContextFactory = ServiceProvider.GetRequiredService<IDbContextFactory<ChatDbContext>>();        
    }

    private IServiceProvider ConfigureServiceProvider()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddDbContextFactory<ChatDbContext>(
            options => { options.UseSqlServer(Settings.ChatDbContextConnectionString); },
            ServiceLifetime.Scoped);
        return serviceCollection.BuildServiceProvider();
    }

    protected readonly ChatSettings Settings;
    protected readonly IDbContextFactory<ChatDbContext> DbContextFactory;
    protected readonly IServiceProvider ServiceProvider;
}