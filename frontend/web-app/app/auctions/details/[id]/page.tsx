import { getDetailedViewData } from '@/actions/auction'
import { getCurrentUser } from '@/actions/auth'
import AuctionCountdownTimer from '@/components/auctions/AuctionCountdownTimer'
import AuctionDeleteButton from '@/components/auctions/AuctionDeleteButton'
import AuctionDetailedSpecs from '@/components/auctions/AuctionDetailedSpecs'
import AuctionEditButton from '@/components/auctions/AuctionEditButton'
import ItemImage from '@/components/auctions/ItemImage'
import Heading from '@/components/core/Heading'
import React from 'react'

export default async function Details({params} : {params: {id : string}}) {
  const data = await getDetailedViewData(params.id)
  const user = await getCurrentUser()

  return (
    <div>
      <div className='flex justify-between'>
        <div className='flex gap-3 items-center'>
          <Heading title={`${data.item.make}`}/>
          {data.seller === user?.username && (
            <>
              <AuctionEditButton id={data.id}/>
              <AuctionDeleteButton id={data.id} />
            </>
          )}
        </div>
        <div className='flex gap-3'>
          <h3 className='text-2xl font-semibold'>Time remaining:</h3>
          <AuctionCountdownTimer auctionEnd={data.auctionEnd}/>
        </div>
      </div>
      <div className='grid grid-cols-2 gap-6 mt-3'>
        <div className='w-full bg-gray-200 aspect-h-10 aspect-w-16 rounded-lg overflow-hidden'>
          <ItemImage imageUrl={data.item.imageUrl}/>
        </div>
        <div className='border-2 rounded-lg p-2 bg-gray-100'>
          <Heading title='Bids'/>
        </div>
      </div>
      <div className='mt-3 grid grid-cols-1 rounded-lg'>
        <AuctionDetailedSpecs auction={data}/>
      </div>
    </div>
  )
}