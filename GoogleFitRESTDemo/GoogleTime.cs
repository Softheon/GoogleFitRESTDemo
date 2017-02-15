using System;

namespace GoogleFitRESTDemo
{
    /// <summary>
    /// Helper class to convert between milliseconds since 1970-1-1 and C# <see cref="DateTime"/> objects.
    /// </summary>
    public class GoogleTime
    {
        /// <summary>
        /// The zero UTC Time.
        /// </summary>
        private static readonly DateTime _zero = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// Gets the total milliseconds.
        /// </summary>
        /// <value>
        /// The total milliseconds.
        /// </value>
        public long TotalMilliseconds { get; private set; }

        /// <summary>
        /// Gets the current time.
        /// </summary>
        /// <value>
        /// The now.
        /// </value>
        public static GoogleTime Now
        {
            get { return FromDateTime(DateTime.Now);}
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="GoogleTime"/> class from being created.
        /// </summary>
        private GoogleTime()
        {
        }

        /// <summary>
        /// Create a time object from the given date time.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns>The time object.</returns>
        public static GoogleTime FromDateTime(DateTime dateTime)
        {
            if (dateTime < _zero)
            {
                throw new ArgumentException("Invalid Google datetime", "dateTime");
            }

            return new GoogleTime
            {
                TotalMilliseconds = (long) (dateTime - _zero).TotalMilliseconds
            };
        }

        /// <summary>
        /// Creates a time object from the given nanoseconds.
        /// </summary>
        /// <param name="nanoseconds">The nanoseconds.</param>
        /// <returns>The time object.</returns>
        public static GoogleTime FromNanoseconds(long? nanoseconds)
        {
            if (nanoseconds < 0)
            {
                throw new ArgumentOutOfRangeException("nanoseconds",
                    "Nanoseconds must be greater than 0.");
            }

            return new GoogleTime
            {
                TotalMilliseconds = (long) (nanoseconds.GetValueOrDefault(0) / 1000000)
            };
        }

        /// <summary>
        /// Adds the specified time span.
        /// </summary>
        /// <param name="timeSpan">The time span.</param>
        /// <returns>The timespan.</returns>
        public GoogleTime Add(TimeSpan timeSpan)
        {
            return new GoogleTime
            {
                TotalMilliseconds = this.TotalMilliseconds + (long) timeSpan.TotalMilliseconds
            };
        }

        /// <summary>
        /// Converts this instance into a <see cref="DateTime"/> object.
        /// </summary>
        /// <returns></returns>
        public DateTime ToDateTime()
        {
            return _zero.AddMilliseconds(this.TotalMilliseconds);
        }
    }
}