using System;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;
using XF_Prism_MarvelCards.Common;
using XF_Prism_MarvelCards.ViewModels;

namespace XF_Prism_MarvelCards.Views
{
    public partial class HeroCards : ContentPage
    {
        private double _heroImageTranslationY = -150;
        private double _movementFactor = 0;

        public HeroCards()
        {
            InitializeComponent();
            //Xamarin.Forms.DebugRainbows.DebugRainbow.SetShowColors(this, true);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MainCardView.UserInteracted += MainCarView_UserInteracted;
            MessagingCenter.Subscribe<CardEvent>(this, CardState.Expanded.ToString(), CardExpand);

        }

        private void CardExpand(CardEvent obj)
        {
            //關掉滑動功能
            MainCardView.IsUserInteractionEnabled = false;

            AnimationTitle(CardState.Expanded);
        }



        private void BackArrowTapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            AnimationTitle(CardState.Collapsed);
            ((HeroCard)MainCardView.CurrentView).GoToState(CardState.Collapsed);

            MainCardView.IsUserInteractionEnabled = true; // 是否可以使用 (不影響UI的寫法)
        }

        private void AnimationTitle(CardState cardState)
        {
            var translationY = cardState == CardState.Expanded ? 0 - (MoviesHeader.Height + MoviesHeader.Margin.Top) : 0; //使用畫面上所設定元件的高度去調整而非寫一個固定的數字
            var opacity = cardState == CardState.Expanded ? 0 : 1;

            var animation = new Animation();
            animation.Add(0, 1, new Animation(v => MoviesHeader.TranslationY = v, MoviesHeader.TranslationY, translationY));
            animation.Add(0, 1, new Animation(v => MoviesHeader.Opacity = v, MoviesHeader.Opacity, opacity));
            animation.Commit(this, "titleAnimation", 20, 400);
        }


        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MainCardView.UserInteracted -= MainCarView_UserInteracted;
            MessagingCenter.Unsubscribe<CardEvent>(this, CardState.Expanded.ToString());
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
                Debug.WriteLine($" Scale: {Scale}");

                if (percentFromCenter > 0 && card.Scale == 1)
                    card.ScaleTo(.95, 50); //??

                AnimateFrontCardDuringSwipe(card, percentFromCenter);

                //調整後面那張圖的透明度
                var nectCard = MainCardView.CurrentBackViews.First() as HeroCard;
                nectCard.MainImage.Opacity = LimitToRange(percentFromCenter * 1.5, 0, 1);
                nectCard.MainImage.Scale = LimitToRange(percentFromCenter * 1.5, 0, 1);

            }
            if (args.Status == PanCardView.Enums.UserInteractionStatus.Ended ||
               args.Status == PanCardView.Enums.UserInteractionStatus.Ending)
            {
                AnimateFrontCardDuringSwipe(card, 0);
                card.ScaleTo(1, 50);//??
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

        /// <summary>
        /// 當前方的卡片在滑動時要做的事
        /// </summary>
        /// <param name="card"></param>
        /// <param name="percentFromCenter"></param>
        private void AnimateFrontCardDuringSwipe(HeroCard card, double percentFromCenter)
        {
            // 調整整個 HeroCard 的透明度
            MainCardView.CurrentView.Opacity = LimitToRange((1 - (percentFromCenter)) * 2, 0, 1);

            #region 針對HeroCard 上的圖檔進行微調
            //大小
            card.MainImage.Scale = LimitToRange((1 - (percentFromCenter) * 1.5), 0, 1);

            //從上往下移動
            card.MainImage.TranslationY = _heroImageTranslationY + (_movementFactor * percentFromCenter);

            //透明度
            card.MainImage.Opacity = LimitToRange((1 - (percentFromCenter)) * 1.5, 0, 1); ;
            #endregion
        }


    }
}
