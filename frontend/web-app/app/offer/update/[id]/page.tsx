import { getDetailedViewData } from '@/actions/advertisement'
import { detailsOffer } from '@/actions/offer'
import AdvertisementForm from '@/components/advertisement/AdvertisementForm'
import Heading from '@/components/core/Heading'
import InventoryItemForm from '@/components/inventory/InventoryItemForm'
import OfferForm from '@/components/offer/OfferForm'
import React from 'react'

export default async function Update({params} : {params: {id : string}}) {
  const offer = await detailsOffer(params.id)
  const advertisement = await getDetailedViewData(offer.advertisementId)

  return (
    <div className='mx-auto max-w-[75%] shadow-lg p-10 bg-white rounded-lg'>
      <Heading title='Update your offer' subtitle='Please update the details of your offer.'/>
      <OfferForm advertisement={advertisement} offer={offer}/>
    </div>
  )
}