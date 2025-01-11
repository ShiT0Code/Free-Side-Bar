using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics;
using WinUIEx;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace FreeSideBar.UI.Windows
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SideBarButton : Window
    {
        public SideBarButton()
        {
            this.InitializeComponent();


            RectInt32 Bounds = new RectInt32(-116, 540, 15, 100);

            if (App.IsRight)
            {
                SideBar.HorizontalAlignment = HorizontalAlignment.Left;
                Bounds = new RectInt32(1420, 540, 25, 100);

                this.Title = "Right";

                App.IsRight = false;
            }
            else
            {
                this.Title = "Left";

                App.IsRight = true; 
            }

            this.AppWindow.MoveAndResize(Bounds);

            this.ExtendsContentIntoTitleBar = true;
            this.SystemBackdrop = new WinUIEx.TransparentTintBackdrop();

            this.AppWindow.IsShownInSwitchers = false;
            this.AppWindow.SetPresenter(Microsoft.UI.Windowing.AppWindowPresenterKind.Overlapped);

            var overlappedPresenter = this.AppWindow.Presenter as OverlappedPresenter;

            if (overlappedPresenter != null)
            {
                overlappedPresenter.IsAlwaysOnTop = true;
                overlappedPresenter.IsMaximizable = false;
                overlappedPresenter.IsMinimizable = false;
                overlappedPresenter.IsResizable = false;
                overlappedPresenter.SetBorderAndTitleBar(true, false);
            }
        }

        private void SideBar_Click(object sender, RoutedEventArgs e)
        {
            if (this.Title == "Right")
                App.IsRight = true;
            else
                App.IsRight = false;

            var Menu=new SideBarMenu();
            Menu.Show();
        }
    }
}
