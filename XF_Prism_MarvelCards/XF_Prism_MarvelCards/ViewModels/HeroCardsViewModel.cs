using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace XF_Prism_MarvelCards.ViewModels
{
    public class HeroCardsViewModel : ViewModelBase
    {
        public ObservableCollection<Hero> Heros { get; set; }

        public HeroCardsViewModel(INavigationService navigationService)
     : base(navigationService)
        {
            Title = "Hero Cards";
            Heros = new ObservableCollection<Hero>()
             {
                new Hero()
                {
                   HeroNameLine1="spider",
                   HeroNameLine2="man",
                   RealName="peter parker",
                   HeroColor="#C51925",
                   Image="spiderman.png"
                },
                new Hero()
                {
                   HeroNameLine1="iron",
                   HeroNameLine2="man",
                   RealName="tony stark",
                   HeroColor="#DF8E04",
                   Image="ironman.png"
                },
             };

        }
    }

    public class Hero
    {
        public string HeroNameLine1 { get; set; }
        public string HeroNameLine2 { get; set; }
        public string RealName { get; set; }
        public string Image { get; set; }
        public string HeroColor { get; set; }
    }
}
