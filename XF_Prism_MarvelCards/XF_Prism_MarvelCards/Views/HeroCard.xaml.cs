using SkiaSharp;
using SkiaSharp.Views.Forms;
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
        private float _gradientHeight = 200f;
        private SKColor _heroColor;
        private SKPaint _heroPaint;
        private float _cardTopAnimPosition;
        private float _gradientTransitionY;

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
            _gradientTransitionY = float.MaxValue;
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

        #endregion MainImage相同寫法簡化

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
                parentAnimation.Add(0.00, 0.25, CreateKnowMoreAnimation(cardState));
                parentAnimation.Add(0.00, 0.50, CreateImageAnimation(cardState));
                parentAnimation.Add(0.10, 0.50, CreateHearoNameAnimation(cardState));
                parentAnimation.Add(0.15, 0.50, CreateRealNameAnimation(cardState));
                parentAnimation.Add(0.50, 0.75, CreateGradientAnimation(cardState));
            }
            else
            {
                parentAnimation.Add(0.00, 0.25, CreateGradientAnimation(cardState));
                parentAnimation.Add(0.25, 0.45, CreateImageAnimation(cardState));
                parentAnimation.Add(0.35, 0.55, CreateKnowMoreAnimation(cardState));
                parentAnimation.Add(0.25, 0.45, CreateCardAnimation(cardState));
                parentAnimation.Add(0.30, 0.50, CreateHearoNameAnimation(cardState));
                parentAnimation.Add(0.25, 0.50, CreateRealNameAnimation(cardState));

                ShadowBoxViewAnimation(cardState);
            }
            parentAnimation.Commit(this, "CardExpand", 16, 2000);
        }

        /// <summary>
        /// 讓中間漸層的區塊跟著跑
        /// </summary>
        /// <param name="cardState"></param>
        /// <returns></returns>
        private Animation CreateGradientAnimation(CardState cardState)
        {
            double start;
            double end;
            if (cardState == CardState.Expanded)
            {
                _gradientTransitionY = CardBackground.CanvasSize.Height;
                start = _gradientTransitionY;
                end = -_gradientHeight;
            }
            else
            {
                _gradientTransitionY = -_gradientHeight;
                start = -_gradientTransitionY;
                end = CardBackground.CanvasSize.Height;
            }

            var gradientAnimation = new Animation(callback: v =>
            {
                _gradientTransitionY = (float)v;
                CardBackground.InvalidateSurface();
            },
            start: start,
            end: end,
            easing: Easing.Linear,
            finished: () =>
            {
                Color fontColor = cardState == CardState.Expanded ? Color.Black : Color.White;
                HeroNameLabel.TextColor = fontColor;
                RealNameLabel.TextColor = fontColor;
            });

            return gradientAnimation;
        }

        private Animation CreateKnowMoreAnimation(CardState cardState)
        {
            var knowMoreAnimStart = cardState == CardState.Expanded ? 0 : 100;
            var knowMoreAnimEnd = cardState == CardState.Expanded ? 100 : 0;

            var imageAnim = new Animation(
                v =>
                {
                    knowMoreLabel.TranslationX = v;
                    knowMoreLabel.Opacity = 1 - (v / 100);
                },
                knowMoreAnimStart,
                knowMoreAnimEnd,
                Easing.SpringOut);

            return imageAnim;
        }

        private Animation CreateCardAnimation(CardState cardState)
        {
            var cardAnimaStart = cardState == CardState.Expanded ? _cardTopMargin : -_cornerRadius;
            var cardAnimEnd = cardState == CardState.Expanded ? -_cornerRadius : _cardTopMargin;

            var cardAnim = new Animation(
                v =>
                {
                    _cardTopAnimPosition = (float)v;
                    CardBackground.InvalidateSurface();
                },
                cardAnimaStart,
                cardAnimEnd,
                Easing.SinInOut);

            return cardAnim;
        }

        private Animation CreateHearoNameAnimation(CardState cardState)
        {
            var nameAnimStart = cardState == CardState.Expanded ? 0 : -50;
            var nameAnimEnd = cardState == CardState.Expanded ? -50 : 0;

            var imageAnim = new Animation(
                v =>
                {
                    HeroNameLabel.TranslationY = v;
                },
                nameAnimStart,
                nameAnimEnd,
                Easing.SpringOut);

            return imageAnim;
        }

        private Animation CreateRealNameAnimation(CardState cardState)
        {
            var realNameAnimStart = cardState == CardState.Expanded ? 0 : -50;
            var realNameAnimEnd = cardState == CardState.Expanded ? -50 : 0;

            var imageAnim = new Animation(
                v =>
                {
                    RealNameLabel.TranslationY = v;
                },
                realNameAnimStart,
                realNameAnimEnd,
                Easing.SpringOut);

            return imageAnim;
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
            var opacity_1 = cardState == CardState.Expanded ? 0 : 0.35;
            var opacity_2 = cardState == CardState.Expanded ? 0 : 0.7;
            var animation = new Animation();
            animation.Add(0.40, 0.44, new Animation(v => ShadowBox_2.Opacity = v, ShadowBox_2.Opacity, opacity_2));
            animation.Add(0.46, 0.50, new Animation(v => ShadowBox_1.Opacity = v, ShadowBox_1.Opacity, opacity_1));

            animation.Commit(this, "ShadowBoxViewAnimation", 20, 3000);
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
                rect: new SKRect(0, (float)_cardTopAnimPosition, info.Width, info.Height + _cornerRadius), //左上右下要畫到哪(下面也都有圓角所以加上圓角高度讓下方不會顯示)
                r: new SKSize(_cornerRadius, _cornerRadius),
                paint: _heroPaint);

            //draw the gradient(畫中間那個件層的區塊)
            var gradienRect = new SKRect(0, _gradientTransitionY, info.Width, _gradientTransitionY + _gradientHeight);
            var gradientPaint = new SKPaint() { Style = SKPaintStyle.Fill };
            gradientPaint.Shader = SKShader.CreateLinearGradient(
                start: new SKPoint(0, _gradientTransitionY),
                end: new SKPoint(0, _gradientTransitionY + _gradientHeight),
                colors: new SKColor[] { _heroColor, SKColors.White },
                colorPos: new float[] { 0, 1 },
                SKShaderTileMode.Clamp);
            canvas.DrawRect(gradienRect, gradientPaint);

            //draw the white bit(畫下面白色)
            SKRect bottomRect = new SKRect(0, _gradientTransitionY + _gradientHeight, info.Width, info.Height);
            canvas.DrawRect(bottomRect, new SKPaint() { Color = SKColors.White });
        }
    }
}