import { getDetailedViewData } from "@/actions/advertisement";
import { getCurrentUser } from "@/actions/auth";
import { detailsOffer } from "@/actions/offer";
import ItemImage from "@/components/core/ItemImage";
import OfferDeleteButton from "@/components/offer/OfferDeleteButton";
import OfferDetailedSpecs from "@/components/offer/OfferDetailedSpecs";
import OfferEditButton from "@/components/offer/OfferEditButton";
import OfferResponseButton from "@/components/offer/OfferResponseButton";

export default async function Details({params} : {params: {id : string}}) {
  const user = await getCurrentUser()
  const offer = await detailsOffer(params.id)
  console.log(offer)
  const advertisement = await getDetailedViewData(offer.advertisementId)

  return (
    <>
      { user?.username == offer.sender && 
      <div className='flex justify-between'>
        <div className='flex gap-3 items-center'>
          <OfferEditButton id={offer.id}/>
          <OfferDeleteButton id={offer.id} />
        </div>
      </div>
      }
      <div className={`grid grid-cols-[25%_75%] gap-6 mt-3`}>
        <div className='w-full bg-gray-200 aspect-h-10 aspect-w-16 rounded-lg overflow-hidden'>
          <ItemImage image={advertisement.item.photo}/>
        </div>
        
        <div className='rounded-lg'>
          <OfferDetailedSpecs offer={offer}/>
        </div>
      </div>
      { user?.username == offer.recipient 
      && offer.status === 'Live'
      && 
      <div className='flex justify-between'>
        <div className='flex gap-3 items-center'>
          <OfferResponseButton offer={offer} action='Accept' />
          <OfferResponseButton offer={offer} action='Reject' />
        </div>
      </div>
      }
    </>
  )
}