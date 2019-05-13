using System;

namespace AddMicroservice.Application
{
    public class AddService : IAddService
    {
        public decimal Add(decimal n1, decimal n2)
        {
            return n1 + n2;
        }
    }
}
