using System;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;
using XF_Prism_MarvelCards.ViewModels;

namespace XF_Prism_MarvelCards.Views
{
    public partial class HeroCards : ContentPage
    {
        public HeroCards()
        {
            InitializeComponent();
            //Xamarin.Forms.DebugRainbows.DebugRainbow.SetShowColors(this, true);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MainCardView.UserInteracted += MainCarView_UserInteracted;
        }


        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MainCardView.UserInteracted -= MainCarView_UserInteracted;
        }

        private void MainCarView_UserInteracted(PanCardView.CardsView view,
            PanCardView.EventArgs.UserInteractedEventArgs args)
        {
            //Get the Current(當前) card
            var card = MainCardView.CurrentView as HeroCard;

            if (args.Status == PanCardView.Enums.UserInteractionStatus.Running)
            {
                var percentFromCenter = Math.Abs(args.Diff / this.Width);
                //Debug.WriteLine($" 當滑動換面時: {args.Diff}");
                Debug.WriteLine($" 計算百分比: {percentFromCenter}");
                //設定滑動時的透明度
                var opacity = 1 - percentFromCenter;
                if (opacity > 1) opacity = 1;

                Debug.WriteLine($"透明度: {opacity}");
                card.MainImage.Opacity = opacity;
                card.Opacity = opacity;
                //改變圖檔的大小
                var scale = (1 - (percentFromCenter) * 1.5);
                if (scale > 1) scale = 1;
                //Debug.WriteLine($" 縮小: {scale}");
                card.MainImage.Scale = scale;

                var imageBaseMargin = -150;
                var movementFactor = 0;

                var translation = imageBaseMargin + (movementFactor * percentFromCenter);
                card.MainImage.TranslationY = translation;

                //調整後面那張圖的透明度
                var nectCard = MainCardView.CurrentBackViews.First() as HeroCard;
                nectCard.MainImage.Opacity = LimitToRange(percentFromCenter * 1.5, 0, 1);
                nectCard.MainImage.Scale = LimitToRange(percentFromCenter * 1.5, 0, 1);

            }
            if (args.Status == PanCardView.Enums.UserInteractionStatus.Ended ||
               args.Status == PanCardView.Enums.UserInteractionStatus.Ending)
            {
                card.Opacity = 1;
                card.MainImage.Scale = 1;
                card.MainImage.TranslationY = -150;
                card.MainImage.Opacity = 1;
            }
        }

        /// <summary>
        /// 限制元素最大最小值上限
        /// </summary>
        /// <param name="value"></param>
        /// <param name="inclusiveMinimum"></param>
        /// <param name="inclusiveMaximum"></param>
        /// <returns></returns>
        public double LimitToRange(double value, double inclusiveMinimum, double inclusiveMaximum)
        {
            if (value >= inclusiveMinimum)
            {
                if (value <= inclusiveMaximum)
                {
                    return value;
                }
                return inclusiveMaximum;
            }
            return inclusiveMaximum;
        }
        //private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        //{
        //}
    }
}
