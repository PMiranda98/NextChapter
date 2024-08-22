import { getDetailedViewData } from "@/actions/advertisement";
import { detailsOffer } from "@/actions/offer";
import ItemImage from "@/components/core/ItemImage";
import OfferDeleteButton from "@/components/offer/OfferDeleteButton";
import OfferDetailedSpecs from "@/components/offer/OfferDetailedSpecs";
import OfferEditButton from "@/components/offer/OfferEditButton";

export default async function Details({params} : {params: {id : string}}) {
  const offer = await detailsOffer(params.id)
  const advertisement = await getDetailedViewData(offer.advertisementId)

  return (
    <>
      <div className='flex justify-between'>
        <div className='flex gap-3 items-center'>
          <OfferEditButton id={offer.id}/>
          <OfferDeleteButton id={offer.id} />
        </div>
      </div>
      <div className={`grid grid-cols-[30%_70%] gap-6 mt-3`}>
        <div className='w-full bg-gray-200 aspect-h-10 aspect-w-16 rounded-lg overflow-hidden'>
          <ItemImage image={advertisement.item.photo}/>
        </div>
        
        <div className='rounded-lg'>
          <OfferDetailedSpecs offer={offer}/>
        </div>
      </div>
    </>
  )
}