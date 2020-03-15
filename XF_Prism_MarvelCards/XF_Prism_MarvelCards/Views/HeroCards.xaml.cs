using System;
using System.Diagnostics;
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
            MainCarView.UserInteracted += MainCarView_UserInteracted;
        }


        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MainCarView.UserInteracted -= MainCarView_UserInteracted;
        }

        private void MainCarView_UserInteracted(PanCardView.CardsView view,
            PanCardView.EventArgs.UserInteractedEventArgs args)
        {
            if (args.Status == PanCardView.Enums.UserInteractionStatus.Running)
            {
                var percentFromCenter = Math.Abs(args.Diff / this.Width);
                //Debug.WriteLine($" 當滑動換面時: {args.Diff}");
                Debug.WriteLine($" 計算百分比: {percentFromCenter}");
                //設定滑動時的透明度
                var opacity = 1 - (percentFromCenter);
                MainCarView.CurrentView.Opacity = opacity;
                //改變圖檔的大小

            }
        }
    }
}
