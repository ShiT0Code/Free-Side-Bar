using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Collections.Generic;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Quick_Launch_Bar.UI.Pages.Settings
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SideBarSetting : Page
    {
#pragma warning disable CS8618 // ���˳����캯��ʱ������Ϊ null ���ֶα�������� null ֵ���뿼����� "required" ���η�������Ϊ��Ϊ null��
        public SideBarSetting()
#pragma warning restore CS8618 // ���������߼��ǲ�����������ģ�
        {
            this.InitializeComponent();

            SwitchViewModel = new SwitchViewModel();

            viewModel = new SideBarSettingsViewModel();
        }

        public SideBarSettingsViewModel viewModel { get; set; }

        public SwitchViewModel SwitchViewModel { get; set; }

        private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            var setting = new SettingsManager();
            setting.SaveBoolSetting("IsSideBarOn", Tog.IsOn);
        }


        public static string EditMode { get; set; } = "";
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            EditMode = "�����Ŀ";

            this.Frame.Navigate(typeof(SideBarEditAction));
        }

        private SideBarItem SelectItem;
        public void ItemsView_SelectionChanged(ItemsView sender, ItemsViewSelectionChangedEventArgs args)
        {
            var SelItem = sender.SelectedItem;
            if (sender.SelectedItem != null)
            { 
                EditButton.IsEnabled = true;

                EditMode = "�༭��Ŀ";

                SelectItem = (SideBarItem)SelItem;
            }
            else
                EditButton.IsEnabled = false;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SideBarEditAction), SelectItem);
        }

        private void ToggleSwitch_Toggled_Item(object sender, RoutedEventArgs e)
        {

        }


        public static bool IsLoadedLeft { get; set; } = false;
    }


    public class SideBarItem
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string Icon { get; set; } = "";
        public int Style { get; set; }
        public bool IsEnable { get; set; }
        public List<SideBarItemAction> Actions { get; set; } = [];
    }

    public class SideBarItemAction
    {
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public string Action { get; set; } = "";
        public bool IsEnable { get; set; }
        public string Icon { get; set; } = "";
    }

    public class SideBarSettingsViewModel
    {
        public List<SideBarItem> Items { get; set; }

        public SideBarSettingsViewModel() 
        {
            Items = new List<SideBarItem>
            {
                new SideBarItem
                {
                    Name = "1",
                    Description = "No.",
                    Icon = "",
                    Style = 0,
                    IsEnable = true,
                    Actions =
                    [
                        new SideBarItemAction
                        {
                            Title = "Tit",
                            Description = "Yes.",
                            Icon = "",
                            IsEnable = true,
                            Action = ""
                        }
                    ]
                },
                new SideBarItem
                {
                    Name = "2",
                    Description = "Yes.",
                    Icon = "",
                    Style = 1,
                    IsEnable = false,
                    Actions =
                    [
                        new SideBarItemAction
                        {
                            Title = "1999",
                            Description = "Yes.",
                            Icon = "",
                            IsEnable = true,
                            Action = ""
                        },
                        new SideBarItemAction
                        {
                            Title = "4999",
                            Description = "15",
                            Icon = "",
                            IsEnable = false,
                            Action = ""
                        }
                    ]
                },
                new SideBarItem
                {
                    Name = "3",
                    Description = "???",
                    Icon = "",
                    Style = 3,
                    IsEnable = true,
                    Actions =
                    [
                        new SideBarItemAction
                        {
                            Title = "����Ҫ��",
                            Description = "No!!!",
                            Icon = "",
                            IsEnable = true,
                            Action = ""
                        },
                        new SideBarItemAction
                        {
                            Title = "����Ҫ��",
                            Description = "No!!!",
                            Icon = "",
                            IsEnable = true,
                            Action = ""
                        },
                        new SideBarItemAction
                        {
                            Title = "����Ҫ��",
                            Description = "No!!!",
                            Icon = "",
                            IsEnable = true,
                            Action = ""
                        }
                    ]
                }
            };
        } 
    }
}