using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;
using WCApp.Core.Model;
using WCApp.Utility;

namespace WCApp.Adapters
{
    public class ProductListAdapter : BaseAdapter<Product>
    {
        private readonly List<Product> _items;
        private readonly Activity _context;

        public ProductListAdapter(Activity context, List<Product> items) : base()
        {
            _context = context;
            _items = items;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Product this[int position] => _items[position];

        public override int Count => _items.Count;

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = _items[position];

            var imageBitmap = ImageHelper.GetImageBitmapFromUrl(item.ImgUrl);

            if (convertView == null)
            {
                convertView = _context.LayoutInflater.Inflate(Resource.Layout.ProductRowView, null);
            }

            convertView.FindViewById<TextView>(Resource.Id.productNameTextView).Text = item.Name;
            convertView.FindViewById<TextView>(Resource.Id.descriptionTextView).Text = item.Description;
            convertView.FindViewById<TextView>(Resource.Id.priceTextView).Text = "$ " + item.Price;
            convertView.FindViewById<ImageView>(Resource.Id.productImageView).SetImageBitmap(imageBitmap);

            return convertView;
        }

    }
}