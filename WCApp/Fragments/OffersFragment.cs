using Android.App;
using Android.OS;
using Android.Views;
using WCApp.Adapters;

namespace WCApp.Fragments
{
    public class OffersFragment : BaseFragment
    {
        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            FindViews();

            HandleEvents();

            Products = ProductService.GetOfferProducts();
            ListView.Adapter = new ProductListAdapter(Activity, Products);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.OffersProductFragment, container, false);
        }
    }
}