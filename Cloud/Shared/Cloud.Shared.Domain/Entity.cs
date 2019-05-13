using System;
using System.Threading;

namespace Cloud.Shared.Domain
{
    public class Entity : IEntity
    {
        private long id = 0;
        private IUniqueIdGeneratorService uniqueIdGeneratorService = new UniqueIdGeneratorService();

        public long Id
        {
            get
            {
                if (this.id == 0)
                {
                    this.id = uniqueIdGeneratorService.GenerateUniqueId();
                }

                return this.id;
            }
            set { this.id = value; }
        }


    }
}