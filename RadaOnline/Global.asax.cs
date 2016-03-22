namespace RadaOnline
{
    using System;
    using System.Web.Http;

    using RadaOnline.App_Start;

    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}