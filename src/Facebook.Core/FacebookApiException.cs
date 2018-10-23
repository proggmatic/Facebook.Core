﻿using System;
using System.Globalization;
using System.Runtime.Serialization;


namespace Facebook.Api.Client
{
    /// <summary>
    /// Represent errors that occur while calling a Facebook API.
    /// </summary>
    [Serializable]
    public class FacebookApiException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FacebookApiException"/> class.
        /// </summary>
        public FacebookApiException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FacebookApiException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public FacebookApiException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FacebookApiException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="errorType">Type of the error.</param>
        public FacebookApiException(string message, string errorType)
            : this(String.Format(CultureInfo.InvariantCulture, "({0}) {1}", errorType ?? "Unknown", message))
        {
            ErrorType = errorType;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FacebookApiException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="errorType">Type of the error.</param>
        /// <param name="errorCode">Code of the error.</param>
        public FacebookApiException(string message, string errorType, int errorCode)
            : this(String.Format(CultureInfo.InvariantCulture, "({0} - #{1}) {2}", errorType ?? "Unknown", errorCode, message))
        {
            ErrorType = errorType;
            ErrorCode = errorCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FacebookApiException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="errorType">Type of the error.</param>
        /// <param name="errorCode">Code of the error.</param>
        /// <param name="errorSubcode">Subcode of the error.</param>
        public FacebookApiException(string message, string errorType, int errorCode, int errorSubcode)
            : this(message, errorType, errorCode)
        {
            ErrorSubcode = errorSubcode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FacebookApiException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public FacebookApiException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FacebookApiException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination.</param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="info"/> parameter is null. </exception>
        /// <exception cref="T:System.Runtime.Serialization.SerializationException">The class name is null or <see cref="P:System.Exception.HResult"/> is zero (0). </exception>
        protected FacebookApiException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Gets or sets the type of the error.
        /// </summary>
        /// <value>The type of the error.</value>
        public string ErrorType { get; set; }

        /// <summary>
        /// Gets or sets the code of the error.
        /// </summary>
        /// <value>The code of the error.</value>
        public int ErrorCode { get; set; }

        /// <summary>
        /// Gets or sets the error subcode.
        /// </summary>
        /// <value>The code of the error subcode.</value>
        public int ErrorSubcode { get; set; }

        /// <summary>
        /// Gets or sets the error user title.
        /// </summary>
        public string ErrorUserTitle { get; set; }

        /// <summary>
        /// Gets or sets the error user message.
        /// </summary>
        public string ErrorUserMsg { get; set; }
    }
}