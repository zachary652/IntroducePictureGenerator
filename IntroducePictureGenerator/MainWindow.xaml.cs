using System;
using System.Collections.Generic;
using System.IO;
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
using System.ComponentModel;
using System.Collections.ObjectModel;
using ColorFont;
using Microsoft.Win32;
using Xceed.Wpf.Toolkit;

namespace IntroducePictureGenerator
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<TextBox> SpotList;

        public List<TextBox> SpotDetailList;

        public List<Xceed.Wpf.Toolkit.ColorPicker> SpotIndexColorList;

        PreviewWindow _previewWindow;

        public SettingInfo SettingInfo { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            SpotList = new List<TextBox>();
            SpotDetailList = new List<TextBox>();
            SpotIndexColorList = new List<Xceed.Wpf.Toolkit.ColorPicker>();
            SettingInfo = new SettingInfo();
            SettingInfo.TitleFontInfo = FontInfo.GetControlFont(this.TextBox_Title);
            SettingInfo.TitleDetailFontInfo = FontInfo.GetControlFont(this.TextBox_Title);
            SettingInfo.SpotFontInfo = FontInfo.GetControlFont(this.TextBox_Title);
            SettingInfo.SpotDetailFontInfo = FontInfo.GetControlFont(this.TextBox_Title);
            SettingInfo.TitleSize = 25d;
            SettingInfo.TitleDetailSize = 20d;
            SettingInfo.SpotSize = 15d;
            SettingInfo.SpotDetailSize = 12d;
            SettingInfo.ImageAreaRatio = 0.618d;
            Button_Generate.IsEnabled = false;
            this.DataContext = SettingInfo;
        }

        private void AddSpot()
        {
            Grid grid = new Grid();
            grid.Margin = new Thickness(15);
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(3, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            TextBlock textBlock = new TextBlock() { Text = $"特点{SpotList.Count + 1}" };
            textBlock.VerticalAlignment = VerticalAlignment.Center;
            textBlock.HorizontalAlignment = HorizontalAlignment.Center;
            textBlock.SetValue(Grid.RowProperty, 0);
            textBlock.SetValue(Grid.ColumnProperty, 0);
            TextBox textBox = new TextBox();
            textBox.VerticalAlignment = VerticalAlignment.Center;
            textBox.SetValue(Grid.RowProperty, 0);
            textBox.SetValue(Grid.ColumnProperty, 1);
            textBox.Margin = new Thickness(0, 0, 95, 0);
            TextBlock textBlockColor = new TextBlock();
            textBlockColor.Text = "序号颜色";
            textBlockColor.VerticalAlignment = VerticalAlignment.Center;
            textBlockColor.HorizontalAlignment = HorizontalAlignment.Right;
            textBlockColor.SetValue(Grid.RowProperty, 0);
            textBlockColor.SetValue(Grid.ColumnProperty, 1);
            textBlockColor.Margin = new Thickness(0, 0, 40, 0);
            Xceed.Wpf.Toolkit.ColorPicker colorPicker = new Xceed.Wpf.Toolkit.ColorPicker();
            colorPicker.Width = 35;
            colorPicker.VerticalAlignment = VerticalAlignment.Center;
            colorPicker.HorizontalAlignment = HorizontalAlignment.Right;
            colorPicker.SetValue(Grid.RowProperty, 0);
            colorPicker.SetValue(Grid.ColumnProperty, 1);
            //colorPicker.SelectedColor = Colors.White;
            Binding binding = new Binding($"SpotColorList[{SpotList.Count}]");
            colorPicker.SetBinding(Xceed.Wpf.Toolkit.ColorPicker.SelectedColorProperty, binding);
            grid.Children.Add(textBlock);
            grid.Children.Add(textBox);
            grid.Children.Add(textBlockColor);
            grid.Children.Add(colorPicker);
            SpotList.Add(textBox);
            SpotIndexColorList.Add(colorPicker);

            TextBlock textBlockDetail = new TextBlock() { Text = $"特点详细{SpotList.Count}" };
            textBlockDetail.VerticalAlignment = VerticalAlignment.Center;
            textBlockDetail.HorizontalAlignment = HorizontalAlignment.Center;
            textBlockDetail.SetValue(Grid.RowProperty, 1);
            textBlockDetail.SetValue(Grid.ColumnProperty, 0);
            textBlockDetail.Margin = new Thickness(0, 5, 0, 0);
            TextBox textBoxDetail = new TextBox();
            textBoxDetail.VerticalAlignment = VerticalAlignment.Center;
            textBoxDetail.SetValue(Grid.RowProperty, 1);
            textBoxDetail.SetValue(Grid.ColumnProperty, 1);
            textBoxDetail.Margin = new Thickness(0, 5, 0, 0);
            textBoxDetail.AcceptsReturn = true;
            grid.Children.Add(textBlockDetail);
            grid.Children.Add(textBoxDetail);
            SpotDetailList.Add(textBoxDetail);

            int index = containerStackPanel.Children.IndexOf(addDetailGrid);
            containerStackPanel.Children.Insert(index, grid);

            Button_SpotFont.IsEnabled = true;
            Button_SpotDetailFont.IsEnabled = true;
        }

        private void RemoveSpot()
        {
            int index = containerStackPanel.Children.IndexOf(addDetailGrid);
            if (index > 1)
            {
                containerStackPanel.Children.RemoveAt(index - 1);
                SpotList.RemoveAt(SpotList.Count - 1);
                SpotDetailList.RemoveAt(SpotDetailList.Count - 1);
                SpotIndexColorList.RemoveAt(SpotIndexColorList.Count - 1);
            }
            if (containerStackPanel.Children.IndexOf(addDetailGrid) == 1)
            {
                Button_SpotFont.IsEnabled = false;
                Button_SpotDetailFont.IsEnabled = false;
            }
        }

        private void addDetailButton_Click(object sender, RoutedEventArgs e)
        {
            if (SpotList.Count == 6)
            {
                System.Windows.MessageBox.Show("我觉得特点太多了，要不您再考虑下？目前只支持最多6个特点", "请考虑", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            AddSpot();
        }

        private void removeDetailButton_Click(object sender, RoutedEventArgs e)
        {
            RemoveSpot();
        }

        private void Button_TitleFont_Click(object sender, RoutedEventArgs e)
        {
            ColorFont.ColorFontDialog fntDialog = new ColorFont.ColorFontDialog();
            fntDialog.Owner = this;
            fntDialog.Font = FontInfo.GetControlFont(this.TextBox_Title);
            if (fntDialog.ShowDialog() == true)
            {
                SettingInfo.TitleFontInfo = fntDialog.Font;
            }
        }

        private void Button_TitleDetailFont_Click(object sender, RoutedEventArgs e)
        {
            ColorFont.ColorFontDialog fntDialog = new ColorFont.ColorFontDialog();
            fntDialog.Owner = this;
            fntDialog.Font = FontInfo.GetControlFont(this.TextBox_TitleDetail);
            if (fntDialog.ShowDialog() == true)
            {
                SettingInfo.TitleDetailFontInfo = fntDialog.Font;
            }
        }

        private void Button_SpotFont_Click(object sender, RoutedEventArgs e)
        {
            ColorFont.ColorFontDialog fntDialog = new ColorFont.ColorFontDialog();
            fntDialog.Owner = this;
            fntDialog.Font = FontInfo.GetControlFont(this.SpotList[0]);
            if (fntDialog.ShowDialog() == true)
            {
                SettingInfo.SpotFontInfo = fntDialog.Font;
            }
        }

        private void Button_SpotDetailFont_Click(object sender, RoutedEventArgs e)
        {
            ColorFont.ColorFontDialog fntDialog = new ColorFont.ColorFontDialog();
            fntDialog.Owner = this;
            fntDialog.Font = FontInfo.GetControlFont(this.SpotDetailList[0]);
            if (fntDialog.ShowDialog() == true)
            {
                SettingInfo.SpotDetailFontInfo = fntDialog.Font;
            }
        }

        private void Button_Generate_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PNG文件(*.png)|*.png";
            if (sfd.ShowDialog() == true)
            {
                RenderTargetBitmap renderBitmap = new RenderTargetBitmap((int)_previewWindow.dragCanvas.ActualWidth, (int)_previewWindow.dragCanvas.ActualHeight, 96d, 96d, PixelFormats.Pbgra32);
                renderBitmap.Render(_previewWindow.dragCanvas);
                using (FileStream outStream = new FileStream(sfd.FileName, FileMode.Create))
                {
                    PngBitmapEncoder encoder = new PngBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(renderBitmap));
                    encoder.Save(outStream);
                }
            }
        }

        private void Button_Preview_Click(object sender, RoutedEventArgs e)
        {
            if (_previewWindow == null)
            {
                _previewWindow = new PreviewWindow(this);
                _previewWindow.Closed += _previewWindow_Closed;
                _previewWindow.Show();
                _previewWindow.GeneratePreview();
            }
            else
            {
                _previewWindow.GeneratePreview();
            }
            Button_Generate.IsEnabled = true;
        }

        private void _previewWindow_Closed(object sender, EventArgs e)
        {
            _previewWindow = null;
            Button_Generate.IsEnabled = false;
        }

        private void Button_BrowseImg1_Click(object sender, RoutedEventArgs e)
        {
            TextBox_ImgPath1.Text = SelectPicture();
        }

        private void Button_BrowseImg2_Click(object sender, RoutedEventArgs e)
        {
            TextBox_ImgPath2.Text = SelectPicture();
        }

        private void Button_BrowseImg3_Click(object sender, RoutedEventArgs e)
        {
            TextBox_ImgPath3.Text = SelectPicture();
        }

        private void Button_BrowseImg4_Click(object sender, RoutedEventArgs e)
        {
            TextBox_ImgPath4.Text = SelectPicture();
        }

        private void Button_BrowseImg5_Click(object sender, RoutedEventArgs e)
        {
            TextBox_ImgPath5.Text = SelectPicture();
        }

        private string SelectPicture()
        {
            OpenFileDialog sfd = new OpenFileDialog();
            sfd.Filter = "PNG文件(*.png)|*.png|JPEG文件(*.jpg)|*.jpg|BMP文件(*.bmp)|*.bmp";
            if (sfd.ShowDialog() == true)
            {
                return sfd.FileName;
            }
            else
            {
                return string.Empty;
            }
        }
    }

    public class SettingInfo : INotifyPropertyChanged
    {
        public FontInfo TitleFontInfo;

        public FontInfo TitleDetailFontInfo;

        public FontInfo SpotFontInfo;

        public FontInfo SpotDetailFontInfo;

        private double _titleSize;

        public double TitleSize
        {
            get { return _titleSize; }
            set
            {
                _titleSize = value;
                OnPropertyChanged("TitleSize");
            }
        }

        private double _titleDetailSize;

        public double TitleDetailSize
        {
            get { return _titleDetailSize; }
            set
            {
                _titleDetailSize = value;
                OnPropertyChanged("TitleDetailSize");
            }
        }

        private double _spotSize;

        public double SpotSize
        {
            get { return _spotSize; }
            set
            {
                _spotSize = value;
                OnPropertyChanged("SpotSize");
            }
        }

        private double _spotDetailSize;

        public double SpotDetailSize
        {
            get { return _spotDetailSize; }
            set
            {
                _spotDetailSize = value;
                OnPropertyChanged("SpotDetailSize");
            }
        }

        private double _ImageAreaRatio;

        public double ImageAreaRatio
        {
            get { return _ImageAreaRatio; }
            set
            {
                _ImageAreaRatio = value;
                OnPropertyChanged("ImageAreaRatio");
            }
        }

        private ObservableCollection<Color> _spotColorList;

        public ObservableCollection<Color> SpotColorList
        {
            get { return _spotColorList; }
            set
            {
                _spotColorList = value;
                OnPropertyChanged("SpotColorList");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public SettingInfo()
        {
            SpotColorList = new ObservableCollection<Color>();
            SpotColorList.Add(Colors.White);
            SpotColorList.Add(Colors.White);
            SpotColorList.Add(Colors.White);
            SpotColorList.Add(Colors.White);
            SpotColorList.Add(Colors.White);
            SpotColorList.Add(Colors.White);
        }
    }
}
