using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace Lab4_5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FlowDocument flowDoc = new FlowDocument();
        TitleInfo _titleInfo = new TitleInfo();
        internal TitleInfo TitleInfo
        {
            get => _titleInfo;
        }

        internal bool IsMain { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Application.Current.MainWindow.Closing += new CancelEventHandler(MainWindow_Closing);
            _titleInfo.FilePath = "";
            TitleInfo.NumWindows = ++TitleInfo.NumWindows;
            if (TitleInfo.NumWindows == 1) IsMain = true;
            else IsMain = false;
            Uri iconUri = new Uri("MainIcon.png", UriKind.RelativeOrAbsolute);
            this.Icon = BitmapFrame.Create(iconUri);
            this.Title += " Path: " + _titleInfo.FilePath + ", № " + TitleInfo.NumWindows;
            this.DataContext = this;
            this.docText.AllowDrop = true;
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Queue<string>));
            using (FileStream fs = new FileStream("lastDocs.json", FileMode.OpenOrCreate))
            {
                if (fs.Length != 0)
                {
                    object res = jsonFormatter.ReadObject(fs);
                    TitleInfo._lastDocs = (Queue<string>)res;
                    foreach(var doc in TitleInfo._lastDocs)
                    {
                        MenuItem menuItemDoc = new MenuItem()
                        {
                            Header = doc.Split('\\').Last(),
                            Foreground = Brushes.Black,
                        };
                        menuItemDoc.Click += MenuItemDoc_Click;
                        fileMenu.Items.Add(menuItemDoc);
                    }
                }
            }
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Queue<string>));
            using (FileStream fs = new FileStream("lastDocs.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, TitleInfo._lastDocs);
            }
        }

        private void MenuItemDoc_Click(object sender, RoutedEventArgs e)
        {
            MenuItem mu = (MenuItem)sender;
            string clicked_path = TitleInfo._lastDocs.Where(path => path.Contains((string)mu.Header)).First();
            TextRange tr = new TextRange(docText.Document.ContentStart, docText.Document.ContentEnd);
            using (FileStream fs = File.Open(clicked_path, FileMode.Open))
            {
                tr.Load(fs, DataFormats.Rtf);
                this.Title = "Path: " + clicked_path + ", № " + TitleInfo.NumWindows;
            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text Files (*.txt)|*.txt|RichText Files (*.rtf)|*.rtf|XAML Files (*.xaml)|*.xaml|All files (*.*)|*.*";
            if (sfd.ShowDialog() == true)
            {
                TextRange doc = new TextRange(docText.Document.ContentStart, docText.Document.ContentEnd);
                using (FileStream fs = File.Create(sfd.FileName))
                {
                    if (System.IO.Path.GetExtension(sfd.FileName).ToLower() == ".rtf")
                        doc.Save(fs, DataFormats.Rtf);
                    else if (System.IO.Path.GetExtension(sfd.FileName).ToLower() == ".txt")
                        doc.Save(fs, DataFormats.Text);
                    else
                        doc.Save(fs, DataFormats.Xaml);
                    this.Title = "Path: " + sfd.FileName + ", № " + TitleInfo.NumWindows;
                }
                AddPathMenuItem(sfd.FileName);
            }
        }

        private void AddPathMenuItem(string path)
        {
            if(TitleInfo._lastDocs.Count < 5)
            {
                TitleInfo._lastDocs.Enqueue(path);
            }
            else
            {
                TitleInfo._lastDocs.Dequeue();
                TitleInfo._lastDocs.Enqueue(path);
            }
            MenuItem menuItemDoc = new MenuItem()
            {
                Header = path.Split('\\').Last(),
                Foreground = Brushes.Black,
            };
            menuItemDoc.Click += MenuItemDoc_Click;
            fileMenu.Items.Add(menuItemDoc);
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            OpenFileDialog myDialog = new OpenFileDialog();
            myDialog.Filter = "RichText files (*.rtf)|*.rtf|All files (*.*)|*.*";
            if (myDialog.ShowDialog() == true)
            {
                TextRange tr = new TextRange(docText.Document.ContentStart, docText.Document.ContentEnd);
                using (FileStream fs = File.Open(myDialog.FileName, FileMode.Open))
                {
                    tr.Load(fs, DataFormats.Rtf);
                    this.Title = "Path: " + myDialog.FileName + ", № " + TitleInfo.NumWindows;
                }
                AddPathMenuItem(myDialog.FileName);
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void docText_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            flowDoc = new FlowDocument();
            docText.Document = flowDoc;
            this.TitleInfo.FilePath = "";
            this.Title = " Path: " + _titleInfo.FilePath;
        }

        private void docText_SelectionChanged(object sender, RoutedEventArgs e)
        {
            object temp = docText.Selection.GetPropertyValue(Inline.FontWeightProperty);
            bold.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontWeights.Bold));
            temp = docText.Selection.GetPropertyValue(Inline.FontStyleProperty);
            italic.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontStyles.Italic));
            temp = docText.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            underline.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(TextDecorations.Underline));
            docText.Selection.ApplyPropertyValue(Inline.FontSizeProperty, fontSize.Value);
            amoutWords.Text = (new TextRange(docText.Document.ContentStart, docText.Document.ContentEnd).Text.Split(' ').Length).ToString();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            docText?.Selection.ApplyPropertyValue(Inline.FontSizeProperty, fontSize.Value);
        }

        private void fontFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            docText?.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, new FontFamily((string)fontFamily.SelectedItem));
        }

        private void docText_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string filePath in files)
                {
                    if (filePath.Split('.').Last() == "txt")
                    {
                        using (StreamReader sr = new StreamReader(filePath))
                        {
                            docText.AppendText(sr.ReadToEnd());
                        }
                    }
                }
            }
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            TitleInfo.NumWindows = --TitleInfo.NumWindows;
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            foreach(Window window in App.Current.Windows)
            {
                if(window is MainWindow)
                {
                    MainWindow mw = (MainWindow)window;
                    if (!mw.IsMain) mw.Close();
                }
            }
        }


        //ЯЗЫКИ 

        private void lang_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch ((string)lang.SelectedItem)
            {
                case "Rus":
                    this.Resources.Source = new Uri("pack://application:,,,/Resources/lang.ru-RU.xaml");
                    break;
                case "En":
                    this.Resources.Source = new Uri("pack://application:,,,/Resources/lang.xaml");
                    break;
            }
        }

        //private void _color_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        //{
        //    BrushConverter bc = new BrushConverter();
        //    docText?.Selection.ApplyPropertyValue(Inline.ForegroundProperty, bc.ConvertFromString(_color.SelectedColor.Value.ToString()));
        //}


            //ТЕМЫ




            //ТЕМЫ


        private void _Theme1_Selected(object sender, RoutedEventArgs e)
        {
            ComboBoxItem si = (ComboBoxItem)selectedTheme.SelectedItem;
            Application.Current.Resources.Clear();

            switch ((string)si?.Content)
            {
                case "Мрачная":
                    var uri = new Uri("/Themes/Theme1.xaml", UriKind.Relative);
                    ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
                    Application.Current.Resources.Clear();
                    Application.Current.Resources.MergedDictionaries.Add(resourceDict);
                    break;
                case "Дымчатая":
                    var uri2 = new Uri("/Themes/Theme2.xaml", UriKind.Relative);
                    ResourceDictionary resourceDict2 = Application.LoadComponent(uri2) as ResourceDictionary;
                    Application.Current.Resources.Clear();
                    Application.Current.Resources.MergedDictionaries.Add(resourceDict2);
                    break;
                case "Веселая":
                    var uri3 = new Uri("/Themes/Theme3.xaml", UriKind.Relative);
                    ResourceDictionary resourceDict3 = Application.LoadComponent(uri3) as ResourceDictionary;
                    Application.Current.Resources.Clear();
                    Application.Current.Resources.MergedDictionaries.Add(resourceDict3);
                    break;
            }

        }

        private void CustomControl1_ICall(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Inverted call of mouse");
        }

        private void CustomControl1_InvertCall(object sender, RoutedEventArgs e)
        {
        }
    }
}
