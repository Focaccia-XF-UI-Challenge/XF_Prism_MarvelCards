using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace XF_Prism_MarvelCards
{
    /// <summary>
    /// 實作一個介面給其他平台使用
    /// </summary>
    public interface IFontAssetHelper
    {
        SKTypeface GetSkiaTypefaceFromAssetFont(string fontName);
    }
}
