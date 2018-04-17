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
            double textAreaHeightOffset = 100d;
            TextBlock textBlockTitle = new TextBlock();
            textBlockTitle.Text = _mainWindow.TextBox_Title.Text;
            textBlockTitle.FontFamily = _mainWindow.SettingInfo.TitleFontInfo.Family;
            textBlockTitle.FontSize = _mainWindow.SettingInfo.TitleSize;
            textBlockTitle.FontWeight = _mainWindow.SettingInfo.TitleFontInfo.Weight;
            textBlockTitle.SetValue(Canvas.LeftProperty, 50d + textAreaWidthOffset);
            textBlockTitle.SetValue(Canvas.TopProperty, textAreaHeightOffset);
            dragCanvas.Children.Add(textBlockTitle);
            this.UpdateLayout();
            textAreaHeightOffset += textBlockTitle.ActualHeight + 10;

            TextBlock textBlockTitleDetail = new TextBlock();
            textBlockTitleDetail.Text = _mainWindow.TextBox_TitleDetail.Text;
            textBlockTitleDetail.FontFamily = _mainWindow.SettingInfo.TitleDetailFontInfo.Family;
            textBlockTitleDetail.FontSize = _mainWindow.SettingInfo.TitleDetailSize;
            textBlockTitleDetail.FontWeight = _mainWindow.SettingInfo.TitleDetailFontInfo.Weight;
            textBlockTitleDetail.SetValue(Canvas.LeftProperty, 50d + textAreaWidthOffset);
            textBlockTitleDetail.SetValue(Canvas.TopProperty, textAreaHeightOffset);
            dragCanvas.Children.Add(textBlockTitleDetail);
            this.UpdateLayout();
            textAreaHeightOffset += textBlockTitleDetail.ActualHeight + 25;

            for (int i = 0; i < _mainWindow.SpotList.Count; i++)
            {
                TextBlock textIndex = new TextBlock();
                textIndex.Text = (i + 1).ToString();
                textIndex.FontFamily = _mainWindow.SettingInfo.SpotFontInfo.Family;
                textIndex.FontSize = _mainWindow.SettingInfo.SpotSize;
                textIndex.FontWeight = _mainWindow.SettingInfo.SpotFontInfo.Weight;
                textIndex.Foreground = new SolidColorBrush(ContrastColor(_mainWindow.SettingInfo.SpotColorList[i]));
                textIndex.SetValue(Canvas.LeftProperty, 40d + textAreaWidthOffset);
                textIndex.SetValue(Canvas.TopProperty, textAreaHeightOffset);
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
                textSpot.SetValue(Canvas.LeftProperty, 40d + textAreaWidthOffset + textIndex.ActualWidth + 30);
                textSpot.SetValue(Canvas.TopProperty, textAreaHeightOffset);
                dragCanvas.Children.Add(textSpot);
                this.UpdateLayout();

                textAreaHeightOffset += textSpot.ActualHeight + 20;

                TextBlock textSpotDetail = new TextBlock();
                textSpotDetail.Text = _mainWindow.SpotDetailList[i].Text;
                textSpotDetail.FontFamily = _mainWindow.SettingInfo.SpotDetailFontInfo.Family;
                textSpotDetail.FontSize = _mainWindow.SettingInfo.SpotDetailSize;
                textSpotDetail.FontWeight = _mainWindow.SettingInfo.SpotDetailFontInfo.Weight;
                textSpotDetail.SetValue(Canvas.LeftProperty, 40d + textAreaWidthOffset + textIndex.ActualWidth + 30);
                textSpotDetail.SetValue(Canvas.TopProperty, textAreaHeightOffset);
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
