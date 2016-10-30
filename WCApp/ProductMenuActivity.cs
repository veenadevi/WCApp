using Android.App;
using Android.Content;
using Android.OS;
using WCApp.Core.Service;
using WCApp.Fragments;

namespace WCApp
{
    [Activity(Label = "ProductMenuActivity")]
    public class ProductMenuActivity : Activity
    {
        private readonly ProductService _productService;

        public ProductMenuActivity()
        {
            _productService = new ProductService();
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ProductMenuView);

            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

            AddTab("Offers", Resource.Drawable.OffersIcon, new OffersFragment());
            AddTab("Electronics", Resource.Drawable.ElectronicsIcon, new ElectronicsFragment());
            AddTab("Furniture", Resource.Drawable.FurnitureIcon, new FurnitureFragment());
        }
        private void AddTab(string tabText, int iconResourceId, Fragment view)
        {
            var tab = ActionBar.NewTab();
            tab.SetText(tabText);
            tab.SetIcon(iconResourceId);

            tab.TabSelected += delegate (object sender, ActionBar.TabEventArgs e)
            {
                var fragment = FragmentManager.FindFragmentById(Resource.Id.fragmentContainer);
                if (fragment != null)
                    e.FragmentTransaction.Remove(fragment);
                e.FragmentTransaction.Add(Resource.Id.fragmentContainer, view);
            };

            tab.TabUnselected += (sender, e) => e.FragmentTransaction.Remove(view);

            ActionBar.AddTab(tab);
        }
    }
}