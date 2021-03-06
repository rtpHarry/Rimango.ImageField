﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Rimango.ImageField.Helper;

namespace Rimango.ImageField.Settings
{
    public class ImageFieldSettings
    {
        [Range(0, 2048)]
        public int MaxWidth { get; set; }
        [Range(0, 2048)]
        public int MaxHeight { get; set; }
        public ResizeActions ResizeAction { get; set; }
        public bool Required { get; set; }

        public bool AlternateText { get; set; }

        public string DefaultImage { get; set; }
        public string Hint { get; set; }
        public string MediaFolder { get; set; }
        public string FileName { get; set; }

        public UserCropOptions UserCropOption { get; set; }

        public Dimensions GetPreviewImageDimension() {
            return TransformationHelper.GetTransformDimensionsOnMax(new Dimensions(MaxWidth, MaxHeight), new Dimensions(200, 200));
        }


    }

    public class Dimensions {
        public int Width { get; set; }
        public int Height { get; set; }

        public Dimensions(int width, int height) {
            Width = width;
            Height = height;
        }
    }

    public enum ResizeActions
    {
        // Ensures the original image is in the boundaries
        Validate,
        // Apply binary transformation so that the new image complies with boundaries
        Resize,
        // Don't alter the image, the html code will define the size to render
        Scale,
        // If the image is out of bounds, the image is cropped
        Crop,
        // The User get an Dialog to crop the image themself
        UserCrop
    }

    public enum UserCropOptions 
    {
        // The size of the crop area is fixed
        Fixed,
        // The size of the crop area is dynamic, but it keeps the ratio
        OnlyKeepRatio,
        // No restriction to the crop area
        FreeTransformation
    }
}