using System;

namespace Common.Domain
{
    public class Entity : IEntity
    {
        private long id = 0;

        public long Id
        {
            get
            {
                if (this.id == 0)
                {
                    this.id = this.GenerateUniqueId();
                }

                return this.id;
            }
            set { this.id = value; }
        }


        private static int middleFix = new Random().Next(short.MaxValue);


        private long GenerateUniqueId()
        {
            long unixTimestamp = (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds; ;
            int increment = 4320;
            return ((short)unixTimestamp << 32) | ((short)middleFix << 16) | increment;
        }
    }

}