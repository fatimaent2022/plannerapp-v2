using Microsoft.AspNetCore.Components;
using PlanerApp.Shared.Models;
using PlannerApp.Client.Services.Exceptions;
using PlannerApp.Client.Services.Interfaces;

namespace PlannerApp.Components
{
    public partial class PlansList
    {

        [Inject]
        public IPlansService PlansService { get; set; }

        private bool _isBusy = false;
        private string _errorMessage = string.Empty;
        private int _pageNumber = 1;
        private int _pageSize = 10;
        private int _totalpages = 1;
        private string _query=string.Empty;
        private List<PlansSummary> _plans = new ();
        private async Task<PagedList<PlansSummary>> GetPlansAsycn(string query = "", int pageNumber = 1, int pageSize = 10)
        { 
        _isBusy = true;
            try
            {
                var result= await PlansService.GetPlansAsync(query, pageNumber, pageSize);
                _plans= result.Value.Records.ToList();
                _pageNumber = result.Value.Page;
                _pageSize = result.Value.PageSize;
                _totalpages = result.Value.TotalPages;
                return result.Value;
            }
            catch (ApiException ex)
            {
                _errorMessage = ex.ApiErrorResponse.Message;
            }
            catch (Exception ex)
            {

                _errorMessage = ex.Message;
            }
            _isBusy = false;
            return null;
            
        }

        #region View Toggler
        private bool _isCardsViewEnabled = true;

        private void SetCardsView()
        {
            _isCardsViewEnabled = true;
        }
        private void SetTableView()
        {
            _isCardsViewEnabled = false;
        }
        #endregion
    }
}
