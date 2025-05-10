using HomeDecor.Domain;
using HomeDecor.UI;

namespace HomeDecor.Core
{
    public class AppState
    {
        public IDataRepository Repository { get; }
        public CartManager CartManager { get; }
        public WishlistManager WishlistManager { get; }
        public PageManager PageManager { get; }

        public AppState(PageManager pageManager, IDataRepository repository)
        {
            Repository = repository;
            PageManager = pageManager;

            CartManager = new CartManager(repository);
            WishlistManager = new WishlistManager(repository);
        }
    }

}
