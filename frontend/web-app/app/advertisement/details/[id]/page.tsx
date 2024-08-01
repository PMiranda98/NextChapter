import { getDetailedViewData } from '@/actions/advertisement'
import { getCurrentUser } from '@/actions/auth'
import AdvertisementDeleteButton from '@/components/advertisement/AdvertisementDeleteButton'
import AdvertisementDetailedSpecs from '@/components/advertisement/AdvertisementDetailedSpecs'
import AdvertisementEditButton from '@/components/advertisement/AdvertisementEditButton'
import ItemImage from '@/components/advertisement/ItemImage'
import Heading from '@/components/core/Heading'
import OfferForm from '@/components/offer/OfferForm'
import React from 'react'

export default async function Details({params} : {params: {id : string}}) {
  const data = await getDetailedViewData(params.id)
  const user = await getCurrentUser()

  return (
    <div>
      <div className='flex justify-between'>
        <div className='flex gap-3 items-center'>
          <Heading title={`${data.item.name}`}/>
          {data.seller === user?.username && (
            <>
              <AdvertisementEditButton id={data.id}/>
              <AdvertisementDeleteButton id={data.id} />
            </>
          )}
        </div>
      </div>
      <div className={`grid grid-cols-2 gap-6 mt-3`}>
        <div className='w-full bg-gray-200 aspect-h-10 aspect-w-16 rounded-lg overflow-hidden'>
          <ItemImage image={data.item.image}/>
        </div>
        
        <div className='rounded-lg'>
        <AdvertisementDetailedSpecs advertisement={data}/>
      </div>
      </div>
      {user && <OfferForm sellingPrice={data.sellingPrice}/>}
    </div>
  )
}