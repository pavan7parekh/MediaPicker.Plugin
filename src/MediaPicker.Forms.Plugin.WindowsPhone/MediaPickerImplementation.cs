using MediaPicker.Forms.Plugin.Abstractions;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using MediaPicker.Forms.Plugin.WindowsPhone;

[assembly: Dependency(typeof(MediaPickerImplementation))]
namespace MediaPicker.Forms.Plugin.WindowsPhone
{
	/// <summary>
	/// MediaPicker Implementation
	/// </summary>
	public class MediaPickerImplementation : IMediaPicker
	{
		/// <summary>
		/// Used for registration with dependency service
		/// </summary>
		public static void Init() { }

		public bool IsCameraAvailable
		{
			get { throw new NotImplementedException(); }
		}

		public bool IsPhotosSupported
		{
			get { throw new NotImplementedException(); }
		}

		public bool IsVideosSupported
		{
			get { throw new NotImplementedException(); }
		}

		public Task<MediaFile> SelectPhotoAsync(CameraMediaStorageOptions options)
		{
			throw new NotImplementedException();
		}

		public Task<MediaFile> TakePhotoAsync(CameraMediaStorageOptions options)
		{
			throw new NotImplementedException();
		}

		public Task<MediaFile> SelectVideoAsync(VideoMediaStorageOptions options)
		{
			throw new NotImplementedException();
		}

		public Task<MediaFile> TakeVideoAsync(VideoMediaStorageOptions options)
		{
			throw new NotImplementedException();
		}

		public EventHandler<MediaPickerArgs> OnMediaSelected
		{
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}

		public EventHandler<MediaPickerErrorArgs> OnError
		{
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}
	}
}
