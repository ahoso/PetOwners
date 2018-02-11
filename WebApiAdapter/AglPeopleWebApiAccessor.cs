using Newtonsoft.Json;
using PetOwners.Core.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;

namespace DataAccess.WebApi
{
    /// <summary>
    /// AGL People WebAPI accessor implements IDataAccessor interface
    /// </summary>
    public class AglPeopleWebApiAccessor : IDataAccessor
    {
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
                BaseAddress = new Uri(WebApiUrl)
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaType));
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
                var response = client.GetAsync(WebApiUrl).Result;
                var result = response.Content.ReadAsStringAsync().Result;
                var serializedResult = JsonConvert.DeserializeObject<List<Owner>>(result);

                // return serialized result, unless result is null.
                return serializedResult ?? null;
            }
        }


    }
}