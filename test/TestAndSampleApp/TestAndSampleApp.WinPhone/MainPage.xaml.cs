using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using MediaPicker.Forms.Plugin.Abstractions;
using MediaPicker.Forms.Plugin.WindowsPhone;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Xamarin.Forms;

namespace TestAndSampleApp.WinPhone
{
	public partial class MainPage : global::Xamarin.Forms.Platform.WinPhone.FormsApplicationPage
	{

		public MainPage()
		{
			InitializeComponent();
			SupportedOrientations = SupportedPageOrientation.PortraitOrLandscape;

			DependencyService.Register<IMediaPicker, MediaPickerImplementation>();	

			global::Xamarin.Forms.Forms.Init();
			LoadApplication(new TestAndSampleApp.App());
		}
	}
}
