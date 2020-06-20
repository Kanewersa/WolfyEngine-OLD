using System;
using System.Runtime.Serialization;

namespace WolfyCore.Engine.Exceptions
{
    public class WolfyEcsException : Exception
    {
        /// <summary>
        /// Create the exception.
        /// </summary>
        public WolfyEcsException()
            : base()
        {
        }

        /// <summary>
        /// Create the exception with description.
        /// </summary>
        /// <param name="message">Exception description</param>
        public WolfyEcsException(String message)
            : base(message)
        {
        }

        /// <summary>
        /// Create the exception with description and inner cause.
        /// </summary>
        /// <param name="message">Exception description</param>
        /// <param name="innerException">Exception inner cause</param>
        public WolfyEcsException(String message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Create the exception from serialized data.
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Serialization context</param>
        protected WolfyEcsException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
