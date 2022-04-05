using Microsoft.AspNetCore.Components;
using PlanerApp.Shared.Models;

namespace PlannerApp.Components
{
    public partial class PlanCardsList
    {
        private bool _isBusy { get; set; }
        private int _pageNumber = 1;
        private int _pageSize = 10;
        private string _query = string.Empty;

        [Parameter]
        public Func<string, int, int, Task<PagedList<PlansSummary>>> FetchPlans { get; set; }

        private PagedList<PlansSummary> _result = new();
        protected override async Task OnInitializedAsync()
        {
            await GetPlansAsync(1);
        }

        private async Task GetPlansAsync(int pageNumber = 1)
        {
            _pageNumber = pageNumber;
            _isBusy = true;

            _result = await FetchPlans?.Invoke(_query, _pageNumber, _pageSize);

            _isBusy = false;
        }
    }
}
