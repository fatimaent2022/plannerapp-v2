using PlanerApp.Shared.Models;
using PlanerApp.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannerApp.Client.Services.Interfaces
{
    public interface IPlansService
    {
        Task<ApiResponse<PagedList<PlansSummary>>> GetPlansAsync(string query = null, int pageNumber = 1, int pageSize = 10);
    }
}
