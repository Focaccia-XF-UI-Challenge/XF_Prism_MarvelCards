using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SkiaSharp;

namespace XF_Prism_MarvelCards.Droid
{
    /// <summary>
    /// 建立一個Skia的字體
    /// </summary>
    public class FontAssetHelper : IFontAssetHelper
    {
        public SKTypeface GetSkiaTypefaceFromAssetFont(string fontName)
        {
            throw new NotImplementedException();
        }
    }
}