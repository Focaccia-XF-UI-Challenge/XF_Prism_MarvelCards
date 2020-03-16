using Xamarin.Forms;

namespace XF_Prism_MarvelCards.Views
{
    public partial class HeroCard : ContentView
    {
        public HeroCard()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 可以透過這種方式回傳畫面上的元件
        /// </summary>
        public Image MainImage
        {
            get
            {
                return HeroImage;
            }
        }
    }
}
