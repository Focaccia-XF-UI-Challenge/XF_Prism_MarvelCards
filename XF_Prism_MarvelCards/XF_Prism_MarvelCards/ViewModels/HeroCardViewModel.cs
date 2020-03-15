using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace XF_Prism_MarvelCards.ViewModels
{
    public class HeroCardViewModel : ViewModelBase
    {
        public HeroCardViewModel(INavigationService navigationService)
     : base(navigationService)
        {
        }
    }
}
