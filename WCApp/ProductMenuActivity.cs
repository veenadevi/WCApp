using Android.App;
using Android.OS;
using WCApp.Fragments;

namespace WCApp
{
    [Activity(Label = "@string/ProductList")]
    public class ProductMenuActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ProductMenuView);

            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

            AddTab(Resources.GetString(Resource.String.Offers), Resource.Drawable.OffersIcon, new OffersFragment());
            AddTab(Resources.GetString(Resource.String.Electronics), Resource.Drawable.ElectronicsIcon, new ElectronicsFragment());
            AddTab(Resources.GetString(Resource.String.Furniture), Resource.Drawable.FurnitureIcon, new FurnitureFragment());
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