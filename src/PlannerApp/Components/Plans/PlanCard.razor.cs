using Microsoft.AspNetCore.Components;
using PlanerApp.Shared.Models;

namespace PlannerApp.Components
{
    public partial class PlanCard
    {

        [Parameter]
        public PlansSummary PlanSummary { get; set; }

        [Parameter]
        public bool IsBusy { get; set; }

        [Parameter]
        public EventCallback<PlansSummary> OnViewClicked { get; set; }

        [Parameter]
        public EventCallback<PlansSummary> OnDeleteClicked { get; set; }

        [Parameter]
        public EventCallback<PlansSummary> OnEditClicked { get; set; }


    }
}
