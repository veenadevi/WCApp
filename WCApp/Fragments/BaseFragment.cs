using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Widget;
using WCApp.Core.Model;
using WCApp.Core.Service;

namespace WCApp.Fragments
{
    public class BaseFragment : Fragment
    {
        protected ListView ListView;
        protected ProductService ProductService;
        protected List<Product> Products;

        public BaseFragment()
        {
            ProductService = new ProductService();
        }

        protected void HandleEvents()
        {
            ListView.ItemClick += ListView_ItemClick;
        }
        protected void FindViews()
        {
            ListView = View.FindViewById<ListView>(Resource.Id.productListView);
        }

        protected void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var product = Products[e.Position];

            var intent = new Intent();
            intent.SetClass(Activity, typeof(ProductDetailActivity));
            intent.PutExtra("selectedProductId", product.Id);

            StartActivityForResult(intent, 100);
        }
        public override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (resultCode == Result.Ok && requestCode == 100)
            {
                var selectedProduct = ProductService.GetProductById(data.GetIntExtra("selectedProductId", 0));

                var dialog = new AlertDialog.Builder(Context);
                dialog.SetTitle("Confirmation");
                dialog.SetMessage($"You've added {data.GetIntExtra("amount", 0)} time(s) the {selectedProduct.Name}");
                dialog.Show();
            }
        }
    }
}