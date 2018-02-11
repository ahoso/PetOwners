using Microsoft.ApplicationInsights;
using Newtonsoft.Json;
using PetOwners.Const;
using PetOwners.Core.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;

namespace DataAccess.WebApi
{
    /// <summary>
    /// AGL People WebAPI accessor implements IDataAccessor <see langword="interface"/>
    /// </summary>
    public class AglPeopleWebApiAccessor : IDataAccessor
    {
        // telemetry client to be used to log into application insights
        TelemetryClient _telemetry = new TelemetryClient();

        // Static strings from Configuration 
        private static readonly string MediaType = ConfigurationManager.AppSettings["MediaType"].ToString();
        private static readonly string WebApiUrl = ConfigurationManager.AppSettings["WebApiUrl"].ToString();

        // HttpClient
        HttpClient client;

        /// <summary>
        /// Constructor: set up HttpClient
        /// </summary>
        public AglPeopleWebApiAccessor()
        {
            client = new HttpClient
            {
                // set WebAPI URL.
                BaseAddress = new Uri(uriString: WebApiUrl)
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(item: new MediaTypeWithQualityHeaderValue(MediaType));
        }

        /// <summary>
        /// Get all Owners and Pets information from WebAPI and deserialize to IEnuerable Owners
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Owner> GetOwners()
        {
            using (var httpClient = new HttpClient())
            {
                // Get information from WebAPI
                try
                {
                    client.GetAsync(WebApiUrl).Result.EnsureSuccessStatusCode();
                    var result = client.GetAsync(WebApiUrl).Result.Content.ReadAsStringAsync().Result;
                    var serializedResult = JsonConvert.DeserializeObject<List<Owner>>(result);

                    // return serialized result, unless result is null.
                    return serializedResult ?? null;
                }
                catch (Exception ex)
                {
                    // Log exception in to application insights
                    Dictionary<string, string> properties = new Dictionary<string, string>();
                    properties.Add(Logging.Location, "AglPeopleWebApiAccessorn - GetOwner");
                    properties.Add(Logging.Message, ex.Message);
                    properties.Add(Logging.StackTrace, ex.StackTrace);
                    _telemetry.TrackException(ex, properties);

                    throw new Exception("Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message);
                }
            }
        }


    }
}