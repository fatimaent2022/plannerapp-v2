using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.JSInterop;
using PlannerApp;
using PlannerApp.Components;
using PlannerApp.Shared;
using MudBlazor;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Authorization;
using Blazored.FluentValidation;
using PlanerApp.Shared.Models;
using PlannerApp.Client.Services.Interfaces;

namespace PlanerApp.Components
{
    public partial class PlansTable
    {
        [Inject]
        public IPlansService PlanService { get; set; }

        [Parameter]
        public EventCallback<PlansSummary> OnViewClicked { get; set; }

        [Parameter]
        public EventCallback<PlansSummary> OnDeleteClicked { get; set; }

        [Parameter]
        public EventCallback<PlansSummary> OnEditClicked { get; set; }

        private string _query = string.Empty;

        private MudTable<PlansSummary> _table;

        private async Task<TableData<PlansSummary>> ServerReloadAsync(TableState state)
        {
            var result = await PlanService.GetPlansAsync(_query, state.Page, state.PageSize);
            return new TableData<PlansSummary>
            {
                Items = result.Value.Records,
                TotalItems = result.Value.ItemsCount
            };
        }

        private void OnSearch(string query)
        {
            _query = query;
            _table.ReloadServerData();
        }
    }
}