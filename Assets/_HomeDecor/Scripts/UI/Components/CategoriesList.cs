using HomeDecor.Pages;
using UnityEngine;
using UnityEngine.UI;

namespace HomeDecor.UI
{
    public class CategoriesList : MonoBehaviour
    {
        [SerializeField] private Button _btnBedroom;
        [SerializeField] private Button _btnDiningRoom;
        [SerializeField] private Button _btnKitchen;
        [SerializeField] private Button _btnLivingRoom;
        [SerializeField] private Button _btnOffice;

        private PageManager _pageManager;

        public void Init(PageManager pageManager)
        {
            _pageManager = pageManager;

            _btnBedroom.onClick.AddListener(() => OpenCategory(Constants.Bedroom));
            _btnDiningRoom.onClick.AddListener(() => OpenCategory(Constants.DiningRoom));
            _btnKitchen.onClick.AddListener(() => OpenCategory(Constants.Kitchen));
            _btnLivingRoom.onClick.AddListener(() => OpenCategory(Constants.LivingRoom));
            _btnOffice.onClick.AddListener(() => OpenCategory(Constants.Office));
        }

        private void OpenCategory(string categoryName)
        {
            _pageManager.Select<CategoryPage>().SetCategory(categoryName);
            _pageManager.Show<CategoryPage>();
        }

        private void OnDestroy()
        {
            _btnBedroom.onClick.RemoveAllListeners();
            _btnDiningRoom.onClick.RemoveAllListeners();
            _btnKitchen.onClick.RemoveAllListeners();
            _btnLivingRoom.onClick.RemoveAllListeners();
            _btnOffice.onClick.RemoveAllListeners();
        }

}
}
