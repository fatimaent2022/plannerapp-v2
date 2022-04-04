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
    public class HttpPlansService : IPlansService
    {
        private readonly HttpClient _httpClient;

        public HttpPlansService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ApiResponse<PagedList<PlansSummary>>> GetPlansAsync(string query = null, int pageNumber = 1, int pageSize = 10)
        {
            var response = await _httpClient.GetAsync($"/api/v2/plans?query={query}&pageNumber={pageNumber}&pageSize={pageSize}");
            if(response.IsSuccessStatusCode)
            {
                var result= await response.Content.ReadFromJsonAsync<ApiResponse<PagedList<PlansSummary>>>();
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
