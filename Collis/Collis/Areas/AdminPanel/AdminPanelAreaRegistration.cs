using System.Web.Mvc;

namespace Collis.Areas.AdminPanel
{
    public class AdminPanelAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AdminPanel";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Manage_default",
                "AdminPanel/{controller}/{action}/{id}",
                new { controller= "Manage" , action = "Index", id = UrlParameter.Optional },
                new[] { "Collis.Areas.AdminPanel.Controllers" }

            );
        }
    }
}