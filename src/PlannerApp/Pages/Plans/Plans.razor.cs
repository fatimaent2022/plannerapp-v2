using MudBlazor;

namespace PlannerApp.Pages.Plans
{
    public partial class Plans
    {
        private List<BreadcrumbItem> _breadcrumbItems = new()
        {
            new BreadcrumbItem("Home", "/index"),
            new BreadcrumbItem("Plans", "/plans", true)
        };
    }
}
