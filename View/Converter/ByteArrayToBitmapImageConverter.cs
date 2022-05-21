using System;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Drawing;
using System.Windows.Media.Imaging;

namespace View.Converter
{
    public class ByteArrayToBitmapImageConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object parameter, CultureInfo culture)
        {
            BitmapImage img = new BitmapImage();
            if (value != null)
            {
                img = ConvertByteArrayToBitMapImage(value as byte[]);
            }
            return img;
        }
        public BitmapImage ConvertByteArrayToBitMapImage(byte[]? imageByteArray)
        {
            BitmapImage img = new BitmapImage();
            using (MemoryStream memStream = new MemoryStream(imageByteArray))
            {
                img.BeginInit();
                img.CacheOption = BitmapCacheOption.OnLoad;
                img.StreamSource = memStream;
                img.EndInit();
                img.Freeze();
            }
            return img;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }
            byte[] bytes = imageToByteArray (value as Image);
            return bytes;
        }

        public byte[] imageToByteArray(Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                if (imageIn == null)
                {
                    return null;
                }
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }
    }
    
}
