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
        HttpClient _client;

        /// <summary>
        /// Constructor: set up HttpClient
        /// </summary>
        public AglPeopleWebApiAccessor()
        {
            _client = new HttpClient
            {
                // set WebAPI URL.
                BaseAddress = new Uri(uriString: WebApiUrl)
            };
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(item: new MediaTypeWithQualityHeaderValue(MediaType));
        }

        /// <summary>
        /// Get all Owners and Pets information from WebAPI and deserialize to IEnuerable Owners
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Owner> GetOwners()
        {
            using (var _httpClient = new HttpClient())
            {
                // Get information from WebAPI
                try
                {
                    _client.GetAsync(WebApiUrl).Result.EnsureSuccessStatusCode();
                    var _result = _client.GetAsync(WebApiUrl).Result.Content.ReadAsStringAsync().Result;
                    var _serializedResult = JsonConvert.DeserializeObject<List<Owner>>(_result);

                    // return serialized result, unless result is null.
                    return _serializedResult ?? null;
                }
                catch (Exception ex)
                {
                    // Log exception in to application insights
                    Dictionary<string, string> _properties = new Dictionary<string, string>
                    {
                        { Logging.Location, "AglPeopleWebApiAccessorn - GetOwner" },
                        { Logging.Message, ex.Message },
                        { Logging.StackTrace, ex.StackTrace }
                    };
                    _telemetry.TrackException(ex, _properties);

                    throw new Exception("Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message);
                }
            }
        }


    }
}