using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XF_Prism_MarvelCards.Model;

namespace XF_Prism_MarvelCards.ViewModels
{
    public class HeroCardsViewModel : ViewModelBase
    {
        private ObservableCollection<Hero> _heros;

        public ObservableCollection<Hero> Heros
        {
            get { return _heros; }
            set
            {
                SetProperty(ref _heros, value);
            }
        }
        public HeroCardsViewModel(INavigationService navigationService)
       : base(navigationService)
        {
            Title = "Hero Cards";
            //Heros = new ObservableCollection<Hero>()
            // {
            //    new Hero()
            //    {
            //       HeroName="spider man",
            //       RealName="peter parker",
            //       HeroColor="#C51925",
            //       Image="spiderman.png"
            //    },
            //    new Hero()
            //    {
            //       HeroName="iron man",
            //       RealName="tony stark",
            //       HeroColor="#DF8E04",
            //       Image="ironman.png"
            //    },
            // };
        }

        public override async void Initialize(INavigationParameters parameters)
        {
            Heros = await GetHeroList();
        }

        private async Task<ObservableCollection<Hero>> GetHeroList()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync($"{webAPI_Url}/api/Heroes");
            return JsonConvert.DeserializeObject<ObservableCollection<Hero>>(json);
        }
    }
}
