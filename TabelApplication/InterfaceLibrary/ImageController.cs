using System;
using System.Collections.Generic;
using System.Drawing;
using DevExpress.Utils;
using NLog;

namespace InterfaceLibrary
{
    public class ImageController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public ImageController(ImageCollection imageCollection)
        {
            _imageCollection = imageCollection;
        }

        private readonly ImageCollection _imageCollection;
        public ImageCollection ImageCollection 
        {
            get { return _imageCollection; }
        }

        Dictionary<int, ImageDescriptor> _images = new Dictionary<int, ImageDescriptor>();

        static object IconLockObject = new object();

        public int Add(Icon icon)
        {
            if (icon == null)
                return -1;
            
            var image = icon.ToBitmap();

            return Add(image);
        }

        public int Add(Image image)
        {
            if (image == null)
                return -1;


            lock (IconLockObject)
            {
                ImageCollection.AddImage(image);
            }


            //logger.Info("количество иконок: {0}", ImageCollection.Images.Count);

            int imageIndex = ImageCollection.Images.Count - 1;
            var imageDescriptor = new ImageDescriptor()
            {
                Icon = Icon.FromHandle(new Bitmap(image).GetHicon()),
                Image = image,
                ImageIndex = imageIndex
            };

            _images.Add(imageIndex, imageDescriptor);


            return imageIndex;
        }

        Dictionary<Type, int> _indexByType = new Dictionary<Type, int>();

        public int Add(Icon icon, Type objectType)
        {
            if (icon == null)
                return -1;

            Bitmap image = null;
            int imageIndex = -1;

            if (_indexByType.ContainsKey(objectType))
            {
                imageIndex = _indexByType[objectType];
            }
            else
            {
                lock (ImageCollection)
                {
                    image = icon.ToBitmap();
                }

                lock (ImageCollection)
                {
                    ImageCollection.AddImage(image);
                    imageIndex = ImageCollection.Images.Count - 1;
                }

                _indexByType[objectType] = imageIndex;
            }


            //logger.Info("количество иконок: {0}", ImageCollection.Images.Count);

            if (!_images.ContainsKey(imageIndex))
            {
                var imageDescriptor = new ImageDescriptor()
                {
                    Icon = icon,
                    Image = image,
                    ImageIndex = imageIndex
                };

                _images[imageIndex] = imageDescriptor;
            }

            return imageIndex;
        }

        public int GetIndexForIcon(Icon icon)
        {
            foreach (var imageDescriptor in _images)
            {
                if (imageDescriptor.Value.Icon.Equals(icon))
                    return imageDescriptor.Value.ImageIndex;
            }

            return -1;
        }
    }
}
