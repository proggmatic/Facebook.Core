﻿using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Facebook
{
    public static class ServiceRegistrationExtensions
    {
        internal const string HTTP_CLIENT_NAME = "FacebookApiHttpClient";

        public static IServiceCollection AddFacebookAPI(this IServiceCollection services, IConfiguration? configuration = null, string configurationSection = "facebookApi")
        {
            if (configuration != null && !string.IsNullOrEmpty(configurationSection))
                services.Configure<FacebookApiConfig>(configuration.GetSection(configurationSection));

            services.AddHttpClient(HTTP_CLIENT_NAME, client =>
                {
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders
                        .Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                })
                .ConfigureHttpMessageHandlerBuilder(config =>
                    config.PrimaryHandler = new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate });

            return services;
        }
    }
}