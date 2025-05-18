using Android.Hardware;
using Android.Views;
using Tutoriels;

namespace Tutoriel
{
    [Activity(Label = "TextureViewActivity")]
    public class TextureViewActivity : Activity, TextureView.ISurfaceTextureListener
    {
        Camera _camera;
        TextureView _textureView;

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            _textureView = new TextureView(this);
            _textureView.SurfaceTextureListener = this;

            SetContentView(_textureView);
        }

        public void OnSurfaceTextureAvailable(Android.Graphics.SurfaceTexture surface, int width, int height)
        {
            if (Camera.NumberOfCameras == 0)
            {
                Toast.MakeText(this, Resource.String.no_camera, ToastLength.Long).Show();
                return;
            }
            _camera = Camera.Open();
            if (_camera == null)
                _camera = Camera.Open(0);

            var previewSize = _camera.GetParameters().PreviewSize;
            _textureView.LayoutParameters = new FrameLayout.LayoutParams(previewSize.Width, previewSize.Height, GravityFlags.Center);

            try
            {
                _camera.SetPreviewTexture(surface);
                _camera.StartPreview();
            }
            catch (Java.IO.IOException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // this is the sort of thing TextureView enables
            _textureView.Rotation = 45.0f;
            _textureView.Alpha = 0.5f;
        }

        public bool OnSurfaceTextureDestroyed(Android.Graphics.SurfaceTexture surface)
        {
            _camera.StopPreview();
            _camera.Release();

            return true;
        }

        public void OnSurfaceTextureSizeChanged(Android.Graphics.SurfaceTexture surface, int width, int height)
        {
            // camera takes care of this
        }

        public void OnSurfaceTextureUpdated(Android.Graphics.SurfaceTexture surface)
        {

        }
    }
}