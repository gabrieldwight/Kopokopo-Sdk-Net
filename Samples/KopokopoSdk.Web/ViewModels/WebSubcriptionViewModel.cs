using Microsoft.AspNetCore.Mvc.Rendering;

namespace KopokopoSdk.Web.ViewModels
{
    public class WebSubcriptionViewModel
    {
        public List<SelectListItem> WebhookEventType { get; set; }
        public string SelectedEventType { get; set; }
        public string WebhookUrl { get; set; }
        public List<SelectListItem> WebhookScope { get; set; }
        public string SelectedScope { get; set; }
        public string WebhookScopeReference { get; set; }
    }
}
