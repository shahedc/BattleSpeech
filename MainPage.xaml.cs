using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BattleSpeech
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter.ToString() == "Red")
                Container.Background = new SolidColorBrush(Windows.UI.Colors.DarkRed);
            
            InitShips();

            base.OnNavigatedTo(e);
        }

        private void InitShips()
        {
            Random random = new Random();
            var row = random.Next(1, 4);
            var column = random.Next(1, 4);

            var rect = new Windows.UI.Xaml.Shapes.Rectangle();
            rect.Height = 100;
            rect.Width = 100;
            rect.Margin = new Thickness(1, 1, 1, 1);

            rect.Fill = new SolidColorBrush(Colors.Gray);
            Grid.SetRow(rect, row);
            Grid.SetColumn(rect, column);
            Container.Children.Add(rect);
        }

        public void Attack(string row, string column)
        {
            var attackPosition = GetPositionFromCommands(row, column);
            
            var rect = new Windows.UI.Xaml.Shapes.Rectangle();
            rect.Height = 100;
            rect.Width = 100;
            rect.Margin = new Thickness(1, 1, 1, 1);

            rect.Fill = new SolidColorBrush(Colors.DarkRed);
            Grid.SetRow(rect, attackPosition.row);
            Grid.SetColumn(rect, attackPosition.column);
            Container.Children.Add(rect);
            //Container.Background = new SolidColorBrush(Windows.UI.Colors.DarkRed);
            Debug.WriteLine("Row " + row + ", Column" + column + ".");
        }

        private GridPosition GetPositionFromCommands(string row, string column)
        {
            int r = 0;
            int c = 0;

            if (row.ToLower() == "one") r = 1;
            if (row.ToLower() == "two") r = 2;
            if (row.ToLower() == "three") r = 3;
            if (row.ToLower() == "four") r = 4;

            if (column.ToLower() == "one") c = 1;
            if (column.ToLower() == "two") c = 2;
            if (column.ToLower() == "three") c = 3;
            if (column.ToLower() == "four") c = 4;

            return new GridPosition(r, c);
        }

        struct GridPosition
        {
            public int row;
            public int column;

            public GridPosition(int r, int c)
            {
                row = r;
                column = c;
            }
        }
    }
}
