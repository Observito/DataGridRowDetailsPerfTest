using Microsoft.Toolkit.Uwp.UI.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DataGridRowDetailsPerfTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        public MainPage()
        {
            var names = new[] { "Billy", "Bob", "John", "Alan", "Julie", "Fox" };
            var rnd = new Random();
            this.InitializeComponent();
            for (var i = 0; i < SampleSize; i++)
            {
                TestItems.Add(new TestItemViewModel() { Name = names[i % names.Length], Age = rnd.Next(8, 80), Id = i });
            }
        }

        public const int SampleSize = 20_000;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<TestItemViewModel> TestItems { get; } = new ObservableCollection<TestItemViewModel>();

        public ObservableCollection<DataGridRowDetailsVisibilityMode> VisibilityModes { get; } = 
            new ObservableCollection<DataGridRowDetailsVisibilityMode>() {
                DataGridRowDetailsVisibilityMode.Collapsed,
                DataGridRowDetailsVisibilityMode.Visible,
                DataGridRowDetailsVisibilityMode.VisibleWhenSelected
            };

        private DataGridRowDetailsVisibilityMode _selectedVisibilityMode = DataGridRowDetailsVisibilityMode.Collapsed;
        public DataGridRowDetailsVisibilityMode SelectedVisibilityMode
        {
            get => _selectedVisibilityMode;
            set
            {
                if (value != _selectedVisibilityMode)
                {
                    _selectedVisibilityMode = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedVisibilityMode)));
                }
            }
        }
    }
}
