using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System;

namespace WCApp
{
    [Activity(Label = "About Winner Comercial")]
    public class AboutActivty : Activity
    {
        private TextView _phoneNumberTextView;
        private Button _externalMapButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.AboutView);

            FindViews();
            HandleEvents();
        }

        private void FindViews()
        {
            _phoneNumberTextView = FindViewById<TextView>(Resource.Id.phoneNumberTextView);
            _externalMapButton = FindViewById<Button>(Resource.Id.externalMapButton);
        }

        private void HandleEvents()
        {
            _phoneNumberTextView.Click += PhoneNumberTextView_Click;
            _externalMapButton.Click += ExternalMapButton_Click;
        }

        private void PhoneNumberTextView_Click(object sender, EventArgs e)
        {
            var intent = new Intent(Intent.ActionCall);
            intent.SetData(Android.Net.Uri.Parse("tel:" + _phoneNumberTextView.Text));
            StartActivity(intent);
        }

        private void ExternalMapButton_Click(object sender, EventArgs e)
        {
            var locationUri = Android.Net.Uri.Parse("geo:18.5208626,-70.0156556?q=18.5208626,-70.0156556(Winner Comercial)");
            var mapIntent = new Intent(Intent.ActionView, locationUri);
            StartActivity(mapIntent);
        }
    }
}