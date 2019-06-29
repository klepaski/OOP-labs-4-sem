using System;
using System.Windows;
namespace lab13
{
    public partial class Create : Window
    {
        public Create()
        {
            InitializeComponent();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        public string FirureName
        {
            get { return figureList.Text; }
        }

        public int FigureCount
        {
            get {
                int x = Int32.Parse(itemBox.Text);
                return x;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
