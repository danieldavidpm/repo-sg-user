using System.Globalization;

namespace api_user_security.Configurations
{
    public static class CultureConfig
    {
        public static void AddCultureConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (configuration is null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            var cultureInfo = new CultureInfo("es-PE");
            cultureInfo.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            //cultureInfo.NumberFormat.CurrencySymbol = "S/";

            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
        }
    }
}
