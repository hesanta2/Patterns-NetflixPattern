using System;
using System.Threading;

namespace Cloud.Shared.Domain
{
    public class UniqueIdGeneratorService : IUniqueIdGeneratorService
    {
        private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1);
        private static Int32 __staticIncrement = 4320;
        private static volatile UInt16 MiddleFix = 0;

        public long GenerateUniqueId()
        {
            Int32 increment = Interlocked.Increment(ref __staticIncrement);
            Int32 unixTimeStamp = GetTimestampFromDateTime(DateTime.Now);
            Int64 idGenerated = ((Int64)unixTimeStamp << 32) | (MiddleFix << 16) | increment;
            MiddleFix++;
            return idGenerated >> 12;
        }

        private static int GetTimestampFromDateTime(DateTime timestamp)
        {
            var secondsSinceEpoch = (long)Math.Floor((ToUniversalTime(timestamp) - UnixEpoch).TotalSeconds);
            if (secondsSinceEpoch < int.MinValue || secondsSinceEpoch > int.MaxValue)
            {
                throw new ArgumentOutOfRangeException("timestamp");
            }
            return (int)secondsSinceEpoch;
        }

        public static DateTime ToUniversalTime(DateTime dateTime)
        {
            if (dateTime == DateTime.MinValue)
            {
                return DateTime.SpecifyKind(DateTime.MinValue, DateTimeKind.Utc);
            }
            if (dateTime == DateTime.MaxValue)
            {
                return DateTime.SpecifyKind(DateTime.MaxValue, DateTimeKind.Utc);
            }

            return dateTime.ToUniversalTime();


        }

    }
}