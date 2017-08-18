using System;
using Android.App;
using Android.Content.PM;
using Android.OS;
using FFImageLoading;
using FFImageLoading.Forms.Droid;

namespace svg_demo_test.Droid
{
	[Activity(Label = "@string/app_name", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

			

			CachedImageRenderer.Init();
			var config = new FFImageLoading.Config.Configuration()
			{
				VerboseLogging = false,
				VerbosePerformanceLogging = false,
				VerboseMemoryCacheLogging = false,
				VerboseLoadingCancelledLogging = false,
				Logger = new CustomLogger(),
			};

			ImageService.Instance.Initialize(config);

			global::Xamarin.Forms.Forms.Init(this, bundle);

			LoadApplication(new App());
		}
	}

	public class CustomLogger : FFImageLoading.Helpers.IMiniLogger
	{
		public void Debug(string message)
		{
			System.Diagnostics.Debug.WriteLine(message);
		}

		public void Error(string errorMessage)
		{
			System.Diagnostics.Debug.WriteLine(errorMessage);
		}

		public void Error(string errorMessage, Exception ex)
		{
			Error(errorMessage + System.Environment.NewLine + ex.ToString());
		}
	}
}