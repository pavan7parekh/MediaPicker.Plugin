using System;
using System.IO;
using System.Threading.Tasks;

namespace MediaPicker.Forms.Plugin.Abstractions
{
    /// <summary>
    ///     Interface IMediaPicker
    /// </summary>
    public interface IMediaPicker
    {
        /// <summary>
        ///     Gets a value indicating whether this instance is camera available.
        /// </summary>
        /// <value><c>true</c> if this instance is camera available; otherwise, <c>false</c>.</value>
        bool IsCameraAvailable { get; }

        /// <summary>
        ///     Gets a value indicating whether this instance is photos supported.
        /// </summary>
        /// <value><c>true</c> if this instance is photos supported; otherwise, <c>false</c>.</value>
        bool IsPhotosSupported { get; }

        /// <summary>
        ///     Gets a value indicating whether this instance is videos supported.
        /// </summary>
        /// <value><c>true</c> if this instance is videos supported; otherwise, <c>false</c>.</value>
        bool IsVideosSupported { get; }

        /// <summary>
        ///     Event the fires when media has been selected
        /// </summary>
        /// <value>The on photo selected.</value>
        EventHandler<MediaPickerArgs> OnMediaSelected { get; set; }

        /// <summary>
        ///     Gets or sets the on error.
        /// </summary>
        /// <value>The on error.</value>
        EventHandler<MediaPickerErrorArgs> OnError { get; set; }

        /// <summary>
        ///     Select a picture from library.
        /// </summary>
        /// <param name="options">The storage options.</param>
        /// <returns>Task&lt;IMediaFile&gt;.</returns>
        Task<MediaFile> SelectPhotoAsync(CameraMediaStorageOptions options);

        /// <summary>
        ///     Takes the picture.
        /// </summary>
        /// <param name="options">The storage options.</param>
        /// <returns>Task&lt;IMediaFile&gt;.</returns>
        Task<MediaFile> TakePhotoAsync(CameraMediaStorageOptions options);

        /// <summary>
        ///     Selects the video asynchronous.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>Task&lt;IMediaFile&gt;.</returns>
        Task<MediaFile> SelectVideoAsync(VideoMediaStorageOptions options);

        /// <summary>
        ///     Takes the video asynchronous.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>Task&lt;IMediaFile&gt;.</returns>
        Task<MediaFile> TakeVideoAsync(VideoMediaStorageOptions options);

        byte[] ResizeImage(byte[] imageData, float width, float height);
        Stream ResizeImage(Stream imageData, float width, float height);
    }
}