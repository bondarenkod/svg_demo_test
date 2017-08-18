
using FFImageLoading;
using FFImageLoading.Forms.Touch;
using Foundation;
using UIKit;

namespace svg_demo_test.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();

			CachedImageRenderer.Init();
			var config = new FFImageLoading.Config.Configuration()
			{

				VerboseLogging = false,
				VerbosePerformanceLogging = false,
				VerboseMemoryCacheLogging = false,
				VerboseLoadingCancelledLogging = false,
				//Logger = new CustomLogger(),
			};

			ImageService.Instance.Initialize(config);

			LoadApplication(new App());

			return base.FinishedLaunching(app, options);
		}
	}
}
