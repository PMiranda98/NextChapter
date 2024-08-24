using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IOfferPublisher
    {
        public Task PublishOfferPlaced(Offer offer);
        public Task PublishOfferAccepted(Offer offer);
        public Task PublishOfferDeleted(Offer offer);
    }
}
