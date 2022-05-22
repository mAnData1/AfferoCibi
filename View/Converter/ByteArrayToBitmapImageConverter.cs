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
            if (value == null)
            {
                return null;
            }
            else
                return  ToImage(value as byte[]);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }
            else
                return ToBinary(value as Image);

        }

        public static Image ToImage(Byte[] binary)
        {
            Image image = null;
            if (binary == null || binary.Length < 100) 
                return image;

            using (MemoryStream ms = new MemoryStream(binary))
            {
                image = Image.FromStream(ms);
            }
            return image;
        }

        public static Byte[] ToBinary(Image image)
        {
            if (image == null) 
                return null;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                image.Save(memoryStream, ImageFormat.Png);
                return memoryStream.ToArray();
            }
        }

    }
    
}
