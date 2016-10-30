using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace WCApp
{
    [Activity(Label = "Winner Comercial", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private Button _orderButton;
        private Button _aboutButton;
        private Button _takePictureButton;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            SetContentView (Resource.Layout.Main);

            FindViews();

            HandleEvents();
        }

        private void FindViews()
        {
            _orderButton = FindViewById<Button>(Resource.Id.orderButton);
            _aboutButton = FindViewById<Button>(Resource.Id.aboutButton);
            _takePictureButton = FindViewById<Button>(Resource.Id.takePictureButton);
        }

        private void HandleEvents()
        {
            _orderButton.Click += OrderButton_Click;
            _aboutButton.Click += AboutButton_Click;
            _takePictureButton.Click += TakePictureButton_Click;
        }

        private void TakePictureButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(TakePictureActivity));
            StartActivity(intent);
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(AboutActivty));
            StartActivity(intent);
        }

        private void OrderButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(ProductMenuActivity));
            StartActivity(intent);
        }
    }
}

