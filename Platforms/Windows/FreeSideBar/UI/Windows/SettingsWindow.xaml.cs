using Microsoft.UI.Xaml;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace FreeSideBar.UI.Windows
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            this.InitializeComponent();

            ExtendsContentIntoTitleBar=true;
            this.AppWindow.TitleBar.PreferredHeightOption= Microsoft.UI.Windowing.TitleBarHeightOption.Tall;
        }
    }
}
