using Microsoft.Extensions.Configuration;
using RestSharp;
using Polly;
using TechsysLog.Application.WebServices.ViaCep.Interfaces;
using TechsysLog.Application.WebServices.ViaCep.Responses;

namespace TechsysLog.Application.WebServices.ViaCep
{
    public class ViaCepService : IViaCepService
    {
        private readonly string _baseUrl;

        public ViaCepService(IConfiguration configuration)
        {
            _baseUrl = configuration["ViaCep:BaseUrl"] ?? throw new ArgumentNullException(nameof(configuration), "Base URL cannot be null");
        }

        public async Task<AddressResponseModel> GetAddressvViaCepAsync(string cep)
        {
            var client = new RestClient(_baseUrl);
            var request = new RestRequest($"{cep}/json", Method.Get);

            var retryPolicy = Policy
                .Handle<Exception>()
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(3),
                (exception, timeSpan, retryCount, context) =>
                {
                    Console.WriteLine($"Try number {retryCount} failed. Trying again in {timeSpan.TotalSeconds} seconds...");
                });

            return await retryPolicy.ExecuteAsync(async () =>
            {
                var response = await client.ExecuteAsync<AddressResponseModel>(request);

                if (response.IsSuccessful)
                {
                    return response.Data ?? throw new Exception("Response data is null.");
                }
                else
                {
                    throw new Exception("Unable to fetch the address.");
                }
            });
        }
    }
}
