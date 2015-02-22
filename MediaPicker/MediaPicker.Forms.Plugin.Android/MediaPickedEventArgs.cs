using System;
using System.Threading.Tasks;
using MediaPicker.Forms.Plugin.Abstractions;

namespace MediaPicker.Forms.Plugin.Droid
{
    /// <summary>
    ///     Class MediaPickedEventArgs.
    /// </summary>
    internal class MediaPickedEventArgs
        : EventArgs
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MediaPickedEventArgs" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="error">The error.</param>
        /// <exception cref="System.ArgumentNullException">error</exception>
        public MediaPickedEventArgs(int id, Exception error)
        {
            if (error == null)
                throw new ArgumentNullException("error");

            RequestId = id;
            Error = error;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="MediaPickedEventArgs" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="isCanceled">if set to <c>true</c> [is canceled].</param>
        /// <param name="media">The media.</param>
        /// <exception cref="System.ArgumentNullException">media</exception>
        public MediaPickedEventArgs(int id, bool isCanceled, MediaFile media = null)
        {
            RequestId = id;
            IsCanceled = isCanceled;
            if (!IsCanceled && media == null)
                throw new ArgumentNullException("media");

            Media = media;
        }

        /// <summary>
        ///     Gets the request identifier.
        /// </summary>
        /// <value>The request identifier.</value>
        public int RequestId { get; private set; }

        /// <summary>
        ///     Gets a value indicating whether this instance is canceled.
        /// </summary>
        /// <value><c>true</c> if this instance is canceled; otherwise, <c>false</c>.</value>
        public bool IsCanceled { get; private set; }

        /// <summary>
        ///     Gets the error.
        /// </summary>
        /// <value>The error.</value>
        public Exception Error { get; private set; }

        /// <summary>
        ///     Gets the media.
        /// </summary>
        /// <value>The media.</value>
        public MediaFile Media { get; private set; }

        /// <summary>
        ///     To the task.
        /// </summary>
        /// <returns>Task&lt;MediaFile&gt;.</returns>
        public Task<MediaFile> ToTask()
        {
            var tcs = new TaskCompletionSource<MediaFile>();

            if (IsCanceled)
                tcs.SetCanceled();
            else if (Error != null)
                tcs.SetException(Error);
            else
                tcs.SetResult(Media);

            return tcs.Task;
        }
    }
}