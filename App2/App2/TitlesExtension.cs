using App2.Resources.Localization;
using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2
{
    [ContentProperty("Text")]
    public class TitlesExtension : IMarkupExtension
    {
        readonly CultureInfo ci;
        const string ResourceId = "App2.Resources.Localization.Titles";

        public TitlesExtension()
        {
            ci = new CultureInfo("ru-RU");//DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
                //DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
        }

        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
                return "";

            ResourceManager resmgr = new ResourceManager(ResourceId
                                , typeof(TitlesExtension).GetTypeInfo().Assembly);

            var translation = resmgr.GetString(Text, ci);

            if (translation == null)
            {
                translation = Text;
            }
            return translation;
        }
    }
}
