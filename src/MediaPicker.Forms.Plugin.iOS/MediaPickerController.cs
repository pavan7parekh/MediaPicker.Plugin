using MediaPicker.Forms.Plugin.Abstractions;
#if __UNIFIED__
using Foundation;
using UIKit;
#endif
#if !__UNIFIED__
using MonoTouch.Foundation;
using MonoTouch.UIKit;
#endif



namespace MediaPicker.Forms.Plugin.iOS
{
	using System;
	using System.Threading.Tasks;



	/// <summary>
	/// Class MediaPickerController. This class cannot be inherited.
	/// </summary>
	public sealed class MediaPickerController : UIImagePickerController
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="MediaPickerController"/> class.
		/// </summary>
		/// <param name="mpDelegate">The mp delegate.</param>
		internal MediaPickerController(MediaPickerDelegate mpDelegate)
		{
			base.Delegate = mpDelegate;
		}

		/// <summary>
		/// Gets or sets the delegate.
		/// </summary>
		/// <value>The delegate.</value>
		/// <exception cref="NotSupportedException"></exception>
		public override NSObject Delegate
		{
			get
			{
				return base.Delegate;
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		/// <summary>
		/// Gets the result asynchronous.
		/// </summary>
		/// <returns>Task&lt;MediaFile&gt;.</returns>
		public Task<MediaFile> GetResultAsync()
		{
			return ((MediaPickerDelegate)Delegate).Task;
		}
	}
}