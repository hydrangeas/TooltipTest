using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TooltipTest
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        ToolTip toolTip;
        public MainWindow()
        {
            InitializeComponent();

            // Define the Columns
            ColumnDefinition colDef1 = new ColumnDefinition();
            ColumnDefinition colDef2 = new ColumnDefinition();
            ColumnDefinition colDef3 = new ColumnDefinition();
            grid.ColumnDefinitions.Add(colDef1);
            grid.ColumnDefinitions.Add(colDef2);
            grid.ColumnDefinitions.Add(colDef3);

            // Define the Rows
            RowDefinition rowDef1 = new RowDefinition();
            RowDefinition rowDef2 = new RowDefinition();
            RowDefinition rowDef3 = new RowDefinition();
            RowDefinition rowDef4 = new RowDefinition();
            grid.RowDefinitions.Add(rowDef1);
            grid.RowDefinitions.Add(rowDef2);
            grid.RowDefinitions.Add(rowDef3);
            grid.RowDefinitions.Add(rowDef4);

            // Add the first text cell to the Grid
            TextBlock txt1 = new TextBlock();
            txt1.Text = "2005 Products Shipped";
            txt1.FontSize = 20;
            txt1.FontWeight = FontWeights.Bold;
            Grid.SetColumnSpan(txt1, 3);
            Grid.SetRow(txt1, 0);

            // Add the second text cell to the Grid
            TextBox txt2 = new TextBox();
            txt2.Text = "Quarter 1";
            txt2.FontSize = 12;
            txt2.FontWeight = FontWeights.Bold;

            txt2.Height = 20;

            Grid.SetRow(txt2, 1);
            Grid.SetColumn(txt2, 0);

            txt2.TextChanged += Txt2_TextChanged;

            // Add the TextBlock elements to the Grid Children collection
            grid.Children.Add(txt1);
            grid.Children.Add(txt2);
            this.Content = grid;



            toolTip = new ToolTip { Content = "lock is on!" };
            toolTip.Name = "tip";
            toolTip.PlacementTarget = txt2;
            toolTip.Placement = System.Windows.Controls.Primitives.PlacementMode.Relative;
            toolTip.HorizontalOffset = txt2.HorizontalOffset;
            toolTip.VerticalOffset = txt2.VerticalOffset + txt2.Height;
            txt2.ToolTip = toolTip;
            ToolTipService.SetIsEnabled(txt2, false);
            toolTip.IsOpen = false;

        }

        private void Txt2_TextChanged(object sender, TextChangedEventArgs e)
        {
            toolTip.IsOpen = true;
        }
    }
}
