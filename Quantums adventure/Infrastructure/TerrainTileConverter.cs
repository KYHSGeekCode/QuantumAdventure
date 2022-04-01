using Quantums_adventure.model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Quantums_adventure.Infrastructure
{
    public class TerrainTileConverter : IValueConverter

    {

        private static Dictionary<TerrainTileType, ImageSource> _cache;



        Dictionary<TerrainTileType, ImageSource> GetCache()

        {

            var conv = new ImageSourceConverter();

            return _cache ?? (_cache = Enum.GetValues(typeof(TerrainTileType)).OfType<TerrainTileType>().ToDictionary(t => t, t =>
                       (ImageSource)Convert(new Bitmap(Properties.Resources.plain))));
            //return _cache ?? (_cache = Enum.GetValues(typeof(TerrainTileType)).OfType<TerrainTileType>().ToDictionary(t => t, t =>
            //(ImageSource)BitmapFrame.Create(new Uri($"pack://application:,,,/{Assembly.GetAssembly(typeof(TerrainTileType))};component/{t}.png", UriKind.RelativeOrAbsolute))));
        }
        public BitmapSource Convert(System.Drawing.Bitmap bitmap)
        {
            var bitmapData = bitmap.LockBits(
                new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height),
                System.Drawing.Imaging.ImageLockMode.ReadOnly, bitmap.PixelFormat);

            var bitmapSource = BitmapSource.Create(
                bitmapData.Width, bitmapData.Height,
                bitmap.HorizontalResolution, bitmap.VerticalResolution,
                PixelFormats.Bgr24, null,
                bitmapData.Scan0, bitmapData.Stride * bitmapData.Height, bitmapData.Stride);

            bitmap.UnlockBits(bitmapData);
            return bitmapSource;
        }
        //
        //return

        //        _cache ??

        //        (_cache = Enum.GetValues(typeof(TerrainTileType)).OfType<TerrainTileType>().ToDictionary(t => t, t =>

        //           (ImageSource) conv.ConvertFrom(uri= new System.Uri($"pack://application:,,,/Quantums adventure;component/Resources/{t}.png", System.UriKind.RelativeOrAbsolute)/*new Uri(

        //               $"pack://application:,,,/{Assembly.GetAssembly(typeof(TerrainTileType))};component/Resources/{t}.png",

        //               UriKind.RelativeOrAbsolute))*/)));

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => GetCache()[(TerrainTileType)value];



        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)

        {

            throw new NotImplementedException();

        }

    }
}
