using System.IO;
using System.Threading.Tasks;
using MediaPicker.Forms.Plugin.Abstractions;
using Xamarin.Forms;
using System;

namespace TestAndSampleApp
{
	public class App : Application
	{
		public App ()
		{
			// The root page of your application
			MainPage = new MainContentPage ();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}


	public class MainContentPage : ContentPage
	{
		public MainContentPage ()
		{
			IMediaPicker media = DependencyService.Get<IMediaPicker> ();
			TaskScheduler scheduler = TaskScheduler.FromCurrentSynchronizationContext ();

			var status = new Label () {
				XAlign = TextAlignment.Center
			};

			var qualityLabel = new Label () {
				Text = "Quality:",
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				XAlign = TextAlignment.Center
			};
			var quality = new Slider () {
				Value = 50,
				Maximum = 100,
				HeightRequest = 50,
				WidthRequest = 400,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};
			quality.ValueChanged += (sender, e) => {
				qualityLabel.Text = "Quality:" + ((Slider)sender).Value;
			};

			var pixelDimensionLabel = new Label () {
				Text = "Pixel Dimension:",
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				XAlign = TextAlignment.Center
			};
			var pixelDimension = new Slider () {
				Value = 500,
				Maximum = 5000,
				HeightRequest = 50,
				WidthRequest = 400,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};

			pixelDimension.ValueChanged += (sender, e) => {
				pixelDimensionLabel.Text = "Pixel Dimension:" + ((Slider)sender).Value;
			};

			ImageSource imageSource = new StreamImageSource ();
			var image = new Image () {
				Source = imageSource,
				BackgroundColor = Color.Blue
			};

			var button = new Button () {
				Text = "Take a picture",
				Command = new Command (async _ => {
					await media.TakePhotoAsync (new CameraMediaStorageOptions {
						DefaultCamera = CameraDevice.Front,
						MaxPixelDimension = Convert.ToInt32 (pixelDimension.Value),
						PercentQuality = Convert.ToInt32 (quality.Value),
					}).ContinueWith (t => {
						if (t.IsFaulted) {
							status.Text = t.Exception.InnerException.ToString ();
						} else if (t.IsCanceled) {
							status.Text = "Canceled";
						} else {
							var mediaFile = t.Result;
							status.Text = "Photo loaded";
							image.Source = ImageSource.FromStream (() => mediaFile.Source);
						}
					}, scheduler);
				})
			};



			Content = new StackLayout {
				VerticalOptions = LayoutOptions.Center,
				Children = {
					new Label {
						XAlign = TextAlignment.Center,
						Text = "Take a picture"
					},
					qualityLabel,
					quality,
					pixelDimensionLabel,
					pixelDimension,
					button,
					status,
					image,
				}
			};
		}
	}
}
