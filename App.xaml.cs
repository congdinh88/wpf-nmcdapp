using System.Configuration;
using System.Data;
using System.Windows;

namespace NMCDApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            // Thiết lập ngôn ngữ mặc định cho ứng dụng là tiếng Việt
            FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement), new FrameworkPropertyMetadata(System.Windows.Markup.XmlLanguage.GetLanguage("vi-VN")));

            base.OnStartup(e);
        }
    }

}
