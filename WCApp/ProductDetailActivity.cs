using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using WCApp.Core.Model;
using WCApp.Core.Service;
using WCApp.Utility;

namespace WCApp
{
    [Activity(Label = "@string/ProductDetail")]
    public class ProductDetailActivity : Activity
    {
        private ImageView _productImageView;
        private TextView _productNameTextView;
        private TextView _descriptionTextView;
        private TextView _priceTextView;
        private EditText _amountEditText;
        private Button _cancelButton;
        private Button _orderButton;

        private Product _selectedproduct;
        private readonly ProductService _productService;

        public ProductDetailActivity()
        {
            _productService = new ProductService(); 
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.ProductDetailView);
            
            var selectedproductId = Intent.Extras.GetInt("selectedProductId");
            _selectedproduct = _productService.GetProductById(selectedproductId);

            FindViews();

            BindData();

            HandleEvents();
        }

        private void FindViews()
        {
            _productImageView = FindViewById<ImageView>(Resource.Id.productImageView);
            _productNameTextView = FindViewById<TextView>(Resource.Id.productNameTextView);
            _descriptionTextView = FindViewById<TextView>(Resource.Id.descriptionTextView);
            _priceTextView = FindViewById<TextView>(Resource.Id.priceTextView);
            _amountEditText = FindViewById<EditText>(Resource.Id.amountEditText);
            _cancelButton = FindViewById<Button>(Resource.Id.cancelButton);
            _orderButton = FindViewById<Button>(Resource.Id.orderButton);
        }

        private void BindData()
        {
            _productNameTextView.Text = _selectedproduct.Name;
            _descriptionTextView.Text = _selectedproduct.Description;
            _priceTextView.Text = Resources.GetString(Resource.String.Price) + ": " + _selectedproduct.Price;

            var imageBitmap = ImageHelper.GetImageBitmapFromUrl(_selectedproduct.ImgUrl);
            _productImageView.SetImageBitmap(imageBitmap);
        }

        private void HandleEvents()
        {
            _orderButton.Click += OrderButton_Click;
            _cancelButton.Click += CancelButton_Click;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Finish();
        }

        private void OrderButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent();
            intent.PutExtra("selectedProductId", _selectedproduct.Id);
            intent.PutExtra("amount", Convert.ToInt32(_amountEditText.Text));

            SetResult(Result.Ok, intent);
            Finish();
        }
    }
}