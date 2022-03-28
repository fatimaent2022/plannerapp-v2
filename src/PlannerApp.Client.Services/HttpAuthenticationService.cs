using PlanerApp.Shared.Models;
using PlanerApp.Shared.Responses;
using PlannerApp.Client.Services.Exceptions;
using PlannerApp.Client.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace PlannerApp.Client.Services
{
    public class HttpAuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _httpClient;

        public HttpAuthenticationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ApiResponse> RegisterUserAsync(RegisterRequest model)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/v2/auth/register", model);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ApiResponse>();
                return result;
            }
            else
            {
                var errorresponse = await response.Content.ReadFromJsonAsync<ApiErrorResponse>();
                throw new ApiException(errorresponse, response.StatusCode);
            }
        }

    }
}
