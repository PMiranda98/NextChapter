import { getDetailedViewData } from '@/actions/advertisement'
import { getCurrentUser } from '@/actions/auth'
import AdvertisementDeleteButton from '@/components/advertisement/AdvertisementDeleteButton'
import AdvertisementDetailedSpecs from '@/components/advertisement/AdvertisementDetailedSpecs'
import AdvertisementEditButton from '@/components/advertisement/AdvertisementEditButton'
import ItemImage from '@/components/core/ItemImage'
import Heading from '@/components/core/Heading'
import OfferForm from '@/components/offer/OfferForm'
import React from 'react'

export default async function Details({params} : {params: {id : string}}) {
  const advertisement = await getDetailedViewData(params.id)
  const user = await getCurrentUser()

  return (
    <div>
      <div className='flex justify-between'>
        <div className='flex gap-3 items-center'>
          <Heading title={`${advertisement.item.name}`}/>
          {advertisement.seller === user?.username && (
            <>
              <AdvertisementEditButton id={advertisement.id}/>
              <AdvertisementDeleteButton id={advertisement.id} />
            </>
          )}
        </div>
      </div>
      <div className={`grid grid-cols-[30%_70%] gap-6 mt-3`}>
        <div className='w-full bg-gray-200 aspect-h-10 aspect-w-16 rounded-lg overflow-hidden'>
          <ItemImage image={advertisement.item.photo}/>
        </div>
        
        <div className='rounded-lg'>
          <AdvertisementDetailedSpecs advertisement={advertisement}/>
        </div>
      </div>
      {advertisement.seller !== user?.username 
      && advertisement.seller !== undefined
      && user?.username !== undefined 
      && <OfferForm advertisement={advertisement}  username={user.username}/>}
    </div>
  )
}