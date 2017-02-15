using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace GoogleFitRESTDemo.Configuration
{
    /// <summary>
    /// Defins the AppSettings keys for the Google API Client
    /// </summary>
    public static class GoogleClientSettings
    {
        /// <summary>
        /// Gets the API key configuration value.
        /// </summary>
        /// <value>
        /// The API key.
        /// </value>
        /// <exception cref="KeyNotFoundException"></exception>
        public static string ApiKey
        {
            get
            {
                if (!ConfigurationManager.AppSettings.AllKeys.Contains(AppSettingsKeys.ApiKey))
                {
                    throw new KeyNotFoundException(AppSettingsKeys.ApiKey);
                }
                return ConfigurationManager.AppSettings[AppSettingsKeys.ApiKey];
            }
        }

        /// <summary>
        /// Gets the name of the application configuration value.
        /// </summary>
        /// <value>
        /// The name of the application.
        /// </value>
        /// <exception cref="KeyNotFoundException"></exception>
        public static string ApplicationName
        {
            get
            {
                if (!ConfigurationManager.AppSettings.AllKeys.Contains(AppSettingsKeys.ApplicationName))
                {
                    throw new KeyNotFoundException(AppSettingsKeys.ApplicationName);
                }
                return ConfigurationManager.AppSettings[AppSettingsKeys.ApplicationName];
            }
        }

        /// <summary>
        /// Gets the client identifier configuration value.
        /// </summary>
        /// <value>
        /// The client identifier.
        /// </value>
        /// <exception cref="KeyNotFoundException"></exception>
        public static string ClientId
        {
            get
            {
                if (!ConfigurationManager.AppSettings.AllKeys.Contains(AppSettingsKeys.ClientId))
                {
                    throw new KeyNotFoundException(AppSettingsKeys.ClientId);
                }
                return ConfigurationManager.AppSettings[AppSettingsKeys.ClientId];
            }
        }

        /// <summary>
        /// Gets the client secret configuration value..
        /// </summary>
        /// <value>
        /// The client secret.
        /// </value>
        /// <exception cref="KeyNotFoundException"></exception>
        public static string ClientSecret
        {
            get
            {
                if (!ConfigurationManager.AppSettings.AllKeys.Contains(AppSettingsKeys.ClientSecret))
                {
                    throw new KeyNotFoundException(AppSettingsKeys.ClientSecret);
                }
                return ConfigurationManager.AppSettings[AppSettingsKeys.ClientSecret];
            }
        }

        /// <summary>
        /// Gets the data store path configuration value.
        /// </summary>
        /// <value>
        /// The data store path.
        /// </value>
        /// <exception cref="KeyNotFoundException"></exception>
        public static string DataStorePath
        {
            get
            {
                if (!ConfigurationManager.AppSettings.AllKeys.Contains(AppSettingsKeys.DataStorePath))
                {
                    throw new KeyNotFoundException(AppSettingsKeys.DataStorePath);
                }
                return ConfigurationManager.AppSettings[AppSettingsKeys.DataStorePath];
            }
        }
    }
}