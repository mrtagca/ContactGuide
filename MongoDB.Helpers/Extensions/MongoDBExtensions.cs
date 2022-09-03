using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDB.Helpers.Extensions
{
    public static class ServiceCollectionExtensions
    {
        //public static IServiceCollection AddMongoDbSettings(this IServiceCollection services,
        //    IConfiguration configuration)
        //{
            
        //    return services.AddSingleton<MongoDbSettings>(options =>
        //    {
        //        options.ConnectionString = configuration
        //            .GetSection(nameof(MongoDbSettings) + ":" + MongoDbSettings.ConnectionStringValue).Value;
        //        options.Database = configuration
        //            .GetSection(nameof(MongoDbSettings) + ":" + MongoDbSettings.DatabaseValue).Value;
        //    });
        //}
    }
}
