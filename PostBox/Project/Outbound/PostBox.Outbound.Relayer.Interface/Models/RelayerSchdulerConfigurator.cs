using System;
using Microsoft.Extensions.DependencyInjection;
namespace PostBox.Outbound.Relayer.Interface.Models
{
	public static class RelayerSchdulerConfigurator
	{
		public static void ConfigureRealyerSchedule(IServiceCollection serviceCollection)
		{
            //serviceCollection.AddHangfire(configuration => configuration
            //.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
            //.UseSimpleAssemblyNameTypeSerializer()
            //.UseRecommendedSerializerSettings()
            //.UseSqlServerStorage(Configuration.GetConnectionString("HangfireConnection"), new SqlServerStorageOptions
            //{
            //    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
            //    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
            //    QueuePollInterval = TimeSpan.Zero,
            //    UseRecommendedIsolationLevel = true,
            //    DisableGlobalLocks = true
            //}));

            // Add the processing server as IHostedService
            //serviceCollection.AddHangfireServer();
        }

	}
}

