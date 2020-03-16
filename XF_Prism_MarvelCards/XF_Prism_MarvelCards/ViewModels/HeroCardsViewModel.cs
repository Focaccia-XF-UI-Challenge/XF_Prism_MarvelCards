using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using XF_Prism_MarvelCards.Model;

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
                   HeroName="spider man",
                   RealName="peter parker",
                   HeroColor="#C51925",
                   Image="spiderman.png"
                },
                new Hero()
                {
                   HeroName="iron man",
                   RealName="tony stark",
                   HeroColor="#DF8E04",
                   Image="ironman.png"
                },
             };

        }
    }
}
