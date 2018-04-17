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
using System.Windows.Shapes;

namespace IntroducePictureGenerator
{
    /// <summary>
    /// PreviewWindow.xaml 的交互逻辑
    /// </summary>
    public partial class PreviewWindow : Window
    {
        private MainWindow _mainWindow;

        private double _width;

        private double _height;

        public PreviewWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        public void GeneratePreview()
        {
            _width = dragCanvas.ActualWidth;
            _height = dragCanvas.ActualHeight;
            dragCanvas.Children.Clear();
            double imageAreaWitdth = _width * _mainWindow.SettingInfo.ImageAreaRatio;
            if (File.Exists(_mainWindow.TextBox_ImgPath1.Text))
            {
                Image image = new Image();
                image.SetValue(Canvas.LeftProperty, 5d);
                image.SetValue(Canvas.TopProperty, 5d);
                image.Width = imageAreaWitdth / 2 - 10;
                image.Height = _height / 3 - 10;
                image.Stretch = Stretch.Fill;
                image.UseLayoutRounding = true;
                image.SetValue(RenderOptions.BitmapScalingModeProperty, BitmapScalingMode.HighQuality);
                image.Source = new BitmapImage(new Uri(_mainWindow.TextBox_ImgPath1.Text, UriKind.Absolute));
                dragCanvas.Children.Add(image);
            }
            if (File.Exists(_mainWindow.TextBox_ImgPath2.Text))
            {
                Image image = new Image();
                image.SetValue(Canvas.LeftProperty, imageAreaWitdth / 2 + 5);
                image.SetValue(Canvas.TopProperty, 5d);
                image.Width = imageAreaWitdth / 2 - 10;
                image.Height = _height / 3 - 10;
                image.Stretch = Stretch.Fill;
                image.UseLayoutRounding = true;
                image.SetValue(RenderOptions.BitmapScalingModeProperty, BitmapScalingMode.HighQuality);
                image.Source = new BitmapImage(new Uri(_mainWindow.TextBox_ImgPath2.Text, UriKind.Absolute));
                dragCanvas.Children.Add(image);
            }
            if (File.Exists(_mainWindow.TextBox_ImgPath3.Text))
            {
                Image image = new Image();
                image.SetValue(Canvas.LeftProperty, 5d);
                image.SetValue(Canvas.TopProperty, _height / 3 + 5);
                image.Width = imageAreaWitdth / 2 - 10;
                image.Height = _height / 3 - 10;
                image.Stretch = Stretch.Fill;
                image.UseLayoutRounding = true;
                image.SetValue(RenderOptions.BitmapScalingModeProperty, BitmapScalingMode.HighQuality);
                image.Source = new BitmapImage(new Uri(_mainWindow.TextBox_ImgPath3.Text, UriKind.Absolute));
                dragCanvas.Children.Add(image);
            }
            if (File.Exists(_mainWindow.TextBox_ImgPath4.Text))
            {
                Image image = new Image();
                image.SetValue(Canvas.LeftProperty, imageAreaWitdth / 2 + 5);
                image.SetValue(Canvas.TopProperty, _height / 3 + 5);
                image.Width = imageAreaWitdth / 2 - 10;
                image.Height = _height / 3 - 10;
                image.Stretch = Stretch.Fill;
                image.UseLayoutRounding = true;
                image.SetValue(RenderOptions.BitmapScalingModeProperty, BitmapScalingMode.HighQuality);
                image.Source = new BitmapImage(new Uri(_mainWindow.TextBox_ImgPath4.Text, UriKind.Absolute));
                dragCanvas.Children.Add(image);
            }
            if (File.Exists(_mainWindow.TextBox_ImgPath5.Text))
            {
                Image image = new Image();
                image.SetValue(Canvas.LeftProperty, 5d);
                image.SetValue(Canvas.TopProperty, _height / 3 * 2 + 5);
                image.Width = imageAreaWitdth - 10;
                image.Height = _height / 3 - 15;
                image.Stretch = Stretch.Fill;
                image.UseLayoutRounding = true;
                image.SetValue(RenderOptions.BitmapScalingModeProperty, BitmapScalingMode.HighQuality);
                image.Source = new BitmapImage(new Uri(_mainWindow.TextBox_ImgPath5.Text, UriKind.Absolute));
                dragCanvas.Children.Add(image);
            }
            double textAreaWidthOffset = _width * _mainWindow.SettingInfo.ImageAreaRatio;
            double textAreaHeightOffset = 80d;
            TextBlock textBlockTitle = new TextBlock();
            textBlockTitle.Text = _mainWindow.TextBox_Title.Text;
            textBlockTitle.FontFamily = _mainWindow.SettingInfo.TitleFontInfo.Family;
            textBlockTitle.FontSize = _mainWindow.SettingInfo.TitleSize;
            textBlockTitle.FontWeight = _mainWindow.SettingInfo.TitleFontInfo.Weight;
            _mainWindow.SettingInfo.TitleLeft = _mainWindow.SettingInfo.TitleLeft == 0d ? 50d + textAreaWidthOffset : _mainWindow.SettingInfo.TitleLeft;
            _mainWindow.SettingInfo.TitleTop = _mainWindow.SettingInfo.TitleTop == 0d ? textAreaHeightOffset : _mainWindow.SettingInfo.TitleTop;
            textBlockTitle.SetBinding(Canvas.LeftProperty, new Binding("TitleLeft") { Source = _mainWindow.SettingInfo, Mode = BindingMode.TwoWay });
            textBlockTitle.SetBinding(Canvas.TopProperty, new Binding("TitleTop") { Source = _mainWindow.SettingInfo, Mode = BindingMode.TwoWay });
            dragCanvas.Children.Add(textBlockTitle);
            this.UpdateLayout();
            textAreaHeightOffset += textBlockTitle.ActualHeight + 20;

            TextBlock textBlockTitleDetail = new TextBlock();
            textBlockTitleDetail.Text = _mainWindow.TextBox_TitleDetail.Text;
            textBlockTitleDetail.FontFamily = _mainWindow.SettingInfo.TitleDetailFontInfo.Family;
            textBlockTitleDetail.FontSize = _mainWindow.SettingInfo.TitleDetailSize;
            textBlockTitleDetail.FontWeight = _mainWindow.SettingInfo.TitleDetailFontInfo.Weight;
            _mainWindow.SettingInfo.TitleDetailLeft = _mainWindow.SettingInfo.TitleDetailLeft == 0d ? 50d + textAreaWidthOffset : _mainWindow.SettingInfo.TitleDetailLeft;
            _mainWindow.SettingInfo.TitleDetailTop = _mainWindow.SettingInfo.TitleDetailTop == 0d ? textAreaHeightOffset : _mainWindow.SettingInfo.TitleDetailTop;
            textBlockTitleDetail.SetBinding(Canvas.LeftProperty, new Binding("TitleDetailLeft") { Source = _mainWindow.SettingInfo, Mode = BindingMode.TwoWay });
            textBlockTitleDetail.SetBinding(Canvas.TopProperty, new Binding("TitleDetailTop") { Source = _mainWindow.SettingInfo, Mode = BindingMode.TwoWay });
            dragCanvas.Children.Add(textBlockTitleDetail);
            this.UpdateLayout();
            textAreaHeightOffset += textBlockTitleDetail.ActualHeight + 30;

            for (int i = 0; i < _mainWindow.SpotList.Count; i++)
            {
                TextBlock textIndex = new TextBlock();
                textIndex.Text = (i + 1).ToString();
                textIndex.FontFamily = _mainWindow.SettingInfo.SpotFontInfo.Family;
                textIndex.FontSize = _mainWindow.SettingInfo.SpotSize;
                textIndex.FontWeight = _mainWindow.SettingInfo.SpotFontInfo.Weight;
                textIndex.Foreground = new SolidColorBrush(ContrastColor(_mainWindow.SettingInfo.SpotColorList[i]));
                _mainWindow.SettingInfo.SpotIndexLeftList[i] = _mainWindow.SettingInfo.SpotIndexLeftList[i] == 0d ? 50d + textAreaWidthOffset : _mainWindow.SettingInfo.SpotIndexLeftList[i];
                _mainWindow.SettingInfo.SpotIndexTopList[i] = _mainWindow.SettingInfo.SpotIndexTopList[i] == 0d ? textAreaHeightOffset : _mainWindow.SettingInfo.SpotIndexTopList[i];
                textIndex.SetBinding(Canvas.LeftProperty, new Binding($"SpotIndexLeftList[{i}]") { Source = _mainWindow.SettingInfo, Mode = BindingMode.TwoWay });
                textIndex.SetBinding(Canvas.TopProperty, new Binding($"SpotIndexTopList[{i}]") { Source = _mainWindow.SettingInfo, Mode = BindingMode.TwoWay });
                textIndex.SetValue(Canvas.ZIndexProperty, 1);
                dragCanvas.Children.Add(textIndex);
                this.UpdateLayout();

                Border border = new Border();
                border.Background = new SolidColorBrush(_mainWindow.SettingInfo.SpotColorList[i]);
                border.Width = textIndex.ActualHeight * 2;
                border.Height = textIndex.ActualHeight * 2;
                border.CornerRadius = new CornerRadius(50);
                border.SetValue(Canvas.LeftProperty, 40d + textAreaWidthOffset - (border.Width - textIndex.ActualWidth) / 2);
                border.SetValue(Canvas.TopProperty, textAreaHeightOffset - (border.Height - textIndex.ActualHeight) / 2);
                dragCanvas.Children.Remove(textIndex);
                border.Child = textIndex;
                textIndex.HorizontalAlignment = HorizontalAlignment.Center;
                textIndex.VerticalAlignment = VerticalAlignment.Center;
                dragCanvas.Children.Add(border);
                this.UpdateLayout();

                TextBlock textSpot = new TextBlock();
                textSpot.Text = _mainWindow.SpotList[i].Text;
                textSpot.FontFamily = _mainWindow.SettingInfo.SpotFontInfo.Family;
                textSpot.FontSize = _mainWindow.SettingInfo.SpotSize;
                textSpot.FontWeight = _mainWindow.SettingInfo.SpotFontInfo.Weight;
                _mainWindow.SettingInfo.SpotLeftList[i] = _mainWindow.SettingInfo.SpotLeftList[i] == 0d ? 40d + textAreaWidthOffset + textIndex.ActualWidth + 30 : _mainWindow.SettingInfo.SpotLeftList[i];
                _mainWindow.SettingInfo.SpotTopList[i] = _mainWindow.SettingInfo.SpotTopList[i] == 0d ? textAreaHeightOffset : _mainWindow.SettingInfo.SpotTopList[i];
                textSpot.SetBinding(Canvas.LeftProperty, new Binding($"SpotLeftList[{i}]") { Source = _mainWindow.SettingInfo, Mode = BindingMode.TwoWay });
                textSpot.SetBinding(Canvas.TopProperty, new Binding($"SpotTopList[{i}]") { Source = _mainWindow.SettingInfo, Mode = BindingMode.TwoWay });
                dragCanvas.Children.Add(textSpot);
                this.UpdateLayout();

                textAreaHeightOffset += textSpot.ActualHeight + 20;

                TextBlock textSpotDetail = new TextBlock();
                textSpotDetail.Text = _mainWindow.SpotDetailList[i].Text;
                textSpotDetail.FontFamily = _mainWindow.SettingInfo.SpotDetailFontInfo.Family;
                textSpotDetail.FontSize = _mainWindow.SettingInfo.SpotDetailSize;
                textSpotDetail.FontWeight = _mainWindow.SettingInfo.SpotDetailFontInfo.Weight;
                _mainWindow.SettingInfo.SpotDetailLeftList[i] = _mainWindow.SettingInfo.SpotDetailLeftList[i] == 0d ? 40d + textAreaWidthOffset + textIndex.ActualWidth + 30 : _mainWindow.SettingInfo.SpotDetailLeftList[i];
                _mainWindow.SettingInfo.SpotDetailTopList[i] = _mainWindow.SettingInfo.SpotDetailTopList[i] == 0d ? textAreaHeightOffset : _mainWindow.SettingInfo.SpotDetailTopList[i];
                textSpotDetail.SetBinding(Canvas.LeftProperty, new Binding($"SpotDetailLeftList[{i}]") { Source = _mainWindow.SettingInfo, Mode = BindingMode.TwoWay });
                textSpotDetail.SetBinding(Canvas.TopProperty, new Binding($"SpotDetailTopList[{i}]") { Source = _mainWindow.SettingInfo, Mode = BindingMode.TwoWay });
                dragCanvas.Children.Add(textSpotDetail);
                this.UpdateLayout();

                textAreaHeightOffset += textSpotDetail.ActualHeight + 20;
            }


        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            GeneratePreview();
        }

        private Color ContrastColor(Color color)
        {
            byte d = 0;
            double a = 1 - (0.299 * color.R + 0.587 * color.G + 0.114 * color.B) / 255;
            if (a < 0.5)
                d = 0;
            else
                d = 255;
            return Color.FromArgb(255, d, d, d);
        }
    }
}
