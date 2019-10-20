﻿using ElectionResults.Core.Infrastructure;
using ElectionResults.Core.Services.BlobContainer;
using ElectionResults.Core.Services.CsvDownload;
using ElectionResults.Core.Services.CsvProcessing;
using ElectionResults.Core.Storage;
using ElectionResults.DataProcessing;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.DependencyInjection;

[assembly: WebJobsStartup(typeof(StartUp))]
namespace ElectionResults.DataProcessing
{
    public class StartUp : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            builder.Services.Configure<AppConfig>(options => Configure(builder));
            builder.Services.AddTransient<ICsvDownloaderJob, CsvDownloaderJob>();
            builder.Services.AddTransient<IBucketUploader, BucketUploader>();
            builder.Services.AddTransient<IElectionConfigurationSource, ElectionConfigurationSource>();
            builder.Services.AddTransient<IResultsRepository, ResultsRepository>();
            builder.Services.AddTransient<IFileProcessor, FileProcessor>();
            builder.Services.AddTransient<IStatisticsAggregator, StatisticsAggregator>();
        }
    }
}
