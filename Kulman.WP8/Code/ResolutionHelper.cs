using System.Windows;
using Microsoft.Phone.Info;

namespace Kulman.WP8.Code
{
    public static class ResolutionHelper
    {
        private static int? _scaleFactor;

        static ResolutionHelper()
        {
            object physicalScreenResolutionObject;

            if (DeviceExtendedProperties.TryGetValue("PhysicalScreenResolution", out physicalScreenResolutionObject))
            {
                var physicalScreenResolution = (Size)physicalScreenResolutionObject;

                _scaleFactor= (int)(physicalScreenResolution.Width / 4.8);
            }

            _scaleFactor= Application.Current.Host.Content.ScaleFactor;
        }

        private static bool IsWvga
        {
            get { return _scaleFactor.HasValue && _scaleFactor.Value == 100; }
        }

        private static bool IsWxga
        {
            get { return _scaleFactor.HasValue && _scaleFactor.Value == 160; }
        }

        private static bool Is720p
        {
            get { return _scaleFactor.HasValue && _scaleFactor.Value == 150; }
        }

        private static bool Is1080p
        {
            get { return _scaleFactor.HasValue && _scaleFactor.Value == 225; }
        }

        public static Size CurrentResolution
        {
            get
            {
                if (IsWxga) return new Size(1280,768);
                if (Is720p) return new Size(1280,720);
                if (Is1080p) return new Size(1920,1080);
                return new Size(480,800);
            }
        }        
    }
}
