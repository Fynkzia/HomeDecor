using HomeDecor.Core;
using HomeDecor.Pages;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace HomeDecor.UI
{
    public class PageManager : MonoBehaviour
    {
        [SerializeField] private Page[] _pagePrefabs;
        [SerializeField] private RectTransform _pageContainer;

        private Page _active;
        private AppState _state;
        public List<Page> Pages { get; private set; }

        public void Init(AppState state)
        {
            _state = state;
            Pages = new List<Page>();
            foreach (var prefab in _pagePrefabs)
            {
                Page page = Instantiate(prefab, _pageContainer);
                page.Init(state);
                Pages.Add(page);
            }
            DeactivateAll();
        }

        public T Select<T>() where T : Page => Pages.OfType<T>().FirstOrDefault();

        public T Show<T>() where T : Page
        {

            var newPage = Select<T>();

            if (_active == newPage)
            {
                _active.Show();
                return _active as T;
            }

            _active?.Hide();
            _active = newPage;
            _active.Show();

            return _active as T;
        }

        private void DeactivateAll() => Pages?.ForEach(view => view.gameObject.SetActive(false));
    }
}
