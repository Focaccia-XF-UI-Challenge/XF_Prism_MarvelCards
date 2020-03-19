using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using Xamarin.Forms;
using XF_Prism_MarvelCards.Common;
using XF_Prism_MarvelCards.Model;

namespace XF_Prism_MarvelCards.Views
{
    public partial class HeroCard : ContentView
    {
        private Hero _viewModel;
        private readonly float _desity;
        private readonly float _cardTopMargin;
        private float _cornerRadius = 60f;
        private CardState _cardState = CardState.Collapsed;

        SKColor _heroColor;
        SKPaint _heroPaint;
        private double _cardTopAnimPosition;

        public HeroCard()
        {
            InitializeComponent();

            _desity = (float)Xamarin.Essentials.DeviceDisplay.MainDisplayInfo.Density; //取得螢幕相關資訊
            _cardTopMargin = 200f * _desity;
            _cornerRadius = 30f * _desity;
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            if (this.BindingContext == null) return;
            _viewModel = this.BindingContext as Hero;

            _heroColor = Color.FromHex(_viewModel.HeroColor).ToSKColor();
            _heroPaint = new SKPaint() { Color = _heroColor };

            // setup initial values
            _cardTopAnimPosition = _cardTopMargin;

            CardBackground.InvalidateSurface();
        }

        #region MainImage相同寫法簡化

        /// <summary>
        /// 可以透過這種方式回傳畫面上的元件
        /// </summary>
        public Image MainImage => HeroImage;

        ///// <summary>
        ///// 可以透過這種方式回傳畫面上的元件
        ///// </summary>
        //public Image MainImage
        //{
        //    get
        //    {
        //        return HeroImage;
        //    }
        //}
        #endregion


        private void KnowMoreTapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            //讓背景區塊長大
            GoToState(CardState.Expanded);
        }

        public void GoToState(CardState cardState)
        {
            if (_cardState == cardState)
                return;

            MessagingCenter.Send<CardEvent>(new CardEvent(), cardState.ToString());
            AnimateTransition(cardState);
            _cardState = cardState;
        }

        private void AnimateTransition(CardState cardState)
        {
            var parentAnimation = new Animation();
            if (cardState == CardState.Expanded)
            {
                ShadowBox_1.Opacity = 0;
                ShadowBox_2.Opacity = 0;
                parentAnimation.Add(0.00, 0.10, CreateCardAnimation(cardState));
                parentAnimation.Add(0.00, 0.50, CreateImageAnimation(cardState));
            }
            else
            {
                parentAnimation.Add(0.00, 0.40, CreateImageAnimation(cardState));
                parentAnimation.Add(0.20, 0.40, CreateCardAnimation(cardState));
                ShadowBoxViewAnimation(cardState);
            }
            parentAnimation.Commit(this, "CardExpand", 16, 2000);

        }

        private Animation CreateCardAnimation(CardState cardState)
        {
            var cardAnimaStart = cardState == CardState.Expanded ? _cardTopMargin : -_cornerRadius;
            var cardAnimEnd = cardState == CardState.Expanded ? -_cornerRadius : _cardTopMargin;

            var cardAnim = new Animation(
                v =>
                {
                    _cardTopAnimPosition = v;
                    CardBackground.InvalidateSurface();
                },
                cardAnimaStart,
                cardAnimEnd,
                Easing.SinInOut);

            return cardAnim;
        }

        private Animation CreateImageAnimation(CardState cardState)
        {
            var imageAnimStart = cardState == CardState.Expanded ? -150 : -200;
            var imageAnimEnd = cardState == CardState.Expanded ? -200 : -150;

            var imageAnim = new Animation(
                v =>
                {
                    HeroImage.TranslationY = v;
                },
                imageAnimStart,
                imageAnimEnd,
                Easing.SpringOut);

            return imageAnim;
        }

        private void ShadowBoxViewAnimation(CardState cardState)
        {
            var opacity = cardState == CardState.Expanded ? 0 : 1;
            var animation = new Animation();
            animation.Add(0.40, 0.41, new Animation(v => ShadowBox_1.Opacity = v, ShadowBox_1.Opacity, opacity));
            animation.Add(0.42, 0.44, new Animation(v => ShadowBox_2.Opacity = v, ShadowBox_1.Opacity, opacity));

            animation.Commit(this, "ShadowBoxViewAnimation", 32, 3000);
        }

        private void CardBackground_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs args)
        {
            if (_viewModel == null) return;

            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            // draw top hero color
            canvas.DrawRoundRect(
                rect: new SKRect(0, (float)_cardTopAnimPosition, info.Width, info.Height),
                r: new SKSize(_cornerRadius, _cornerRadius),
                paint: _heroPaint);
        }
    }
}
