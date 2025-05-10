using HomeDecor.Core;
using HomeDecor.Pages;
using HomeDecor.UI;
using UnityEngine;

namespace HomeDecor.Bootstrap
{
    public class AppBootstrapper : MonoBehaviour
    {
        [SerializeField] private PageManager _pageManager;
        [SerializeField] private NavigationBar _navBar;

        private async void Start()
        {
            var repository = new DataRepository();
            await repository.FetchData();

            var state = new AppState(_pageManager, repository);
            _pageManager.Init(state);
            _navBar.Init(state);

            _pageManager.Show<HomePageView>();
        }
    }
}
