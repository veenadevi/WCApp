using System;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Provider;
using Android.Widget;
using Java.IO;
using WCApp.Utility;

namespace WCApp
{
    [Activity(Label = "Take a picture with WC")]
    public class TakePictureActivity : Activity
    {
        private ImageView _rayPictureImageView;
        private Button _takePictureButton;
        private File _imageDirectory;
        private File _imageFile;
        private Bitmap _imageBitmap;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.TakePictureView);

            FindViews();

            HandleEvents();

            _imageDirectory = new File(Android.OS.Environment.GetExternalStoragePublicDirectory(
                Android.OS.Environment.DirectoryPictures), "WC");

            if (!_imageDirectory.Exists())
            {
                _imageDirectory.Mkdirs();
            }
        }

        private void FindViews()
        {
            _rayPictureImageView = FindViewById<ImageView>(Resource.Id.rayPictureImageView);
            _takePictureButton = FindViewById<Button>(Resource.Id.takePictureButton);
        }

        private void HandleEvents()
        {
            _takePictureButton.Click += TakePictureButton_Click;
        }

        private void TakePictureButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(MediaStore.ActionImageCapture);
            _imageFile = new File(_imageDirectory, $"PhotoWithWC_{Guid.NewGuid()}.jpg");
            intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(_imageFile));
            StartActivityForResult(intent, 0);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            var height = _rayPictureImageView.Height;
            var width = _rayPictureImageView.Width;
            _imageBitmap = ImageHelper.GetImageBitmapFromFilePath(_imageFile.Path, width, height);

            if (_imageBitmap != null)
            {
                _rayPictureImageView.SetImageBitmap(_imageBitmap);
                _imageBitmap = null;
            }

            //required to avoid memory leaks!
            GC.Collect();
        }
    }
}