using System.IO;
using System.Threading.Tasks;
using MediaPicker.Forms.Plugin.Abstractions;
using Xamarin.Forms;

namespace TestAndSampleApp
{
	public class App : Application
	{
		public App()
		{
			// The root page of your application
			MainPage = new MainContentPage();
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}


	public class MainContentPage : ContentPage
	{
		public MainContentPage()
		{
			IMediaPicker media = DependencyService.Get<IMediaPicker>();
			TaskScheduler scheduler = TaskScheduler.FromCurrentSynchronizationContext();

			var status = new Label();
			ImageSource imageSource = new StreamImageSource();
			var image = new Image()
			{
				Source = imageSource,
				HeightRequest = 100,
				WidthRequest = 100,
				Aspect = Aspect.Fill,
				BackgroundColor = Color.Blue
			};

			var smallerImage = new Image()
			{
				HeightRequest = 100,
				WidthRequest = 100,
				BackgroundColor = Color.Pink
			};

			var button = new Button()
			{
				Text = "Take a picture",
				Command = new Command(async _ =>
				{
					await media.TakePhotoAsync(new CameraMediaStorageOptions { DefaultCamera = CameraDevice.Front, MaxPixelDimension = 400 }).ContinueWith(t =>
					{
						if (t.IsFaulted)
						{
							status.Text = t.Exception.InnerException.ToString();
						}
						else if (t.IsCanceled)
						{
							status.Text = "Canceled";
						}
						else
						{
							var mediaFile = t.Result;
							status.Text = "WE GOT A PHOTO!";
							imageSource = ImageSource.FromStream(() => mediaFile.Source);
							image.Source = ImageSource.FromStream(() => mediaFile.Source);

							
							var smaller = media.ResizeImage(mediaFile.Source, 50, 50);
							smallerImage.Source = ImageSource.FromStream(() => smaller);

						}
					}, scheduler);
				})
			};



			Content = new StackLayout
			{
				VerticalOptions = LayoutOptions.Center,
				Children =
				{
					new Label
					{
						XAlign = TextAlignment.Center,
						Text = "Welcome to Xamarin Forms!"
					},
					button,
					status,
					image,
					smallerImage
				}
			};
		}
	}
}
