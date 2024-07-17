import { Auction } from '@/types'
import React from 'react'
import AuctionCountdownTimer from './AuctionCountdownTimer'
import ItemImage from './ItemImage'
import Link from 'next/link'

type Props = {
  auction: Auction
}

export default function AuctionCard({auction}: Props) {
  return (
    <Link href={`/auctions/details/${auction.id}`} className='group'>
      <div className='w-full bg-gray-200 aspect-h-6 aspect-w-10 rounded-lg overflow-hidden'>
        <div>
          <ItemImage imageUrl={auction.item.imageUrl} />
          <div className='absolute bottom-0 left-0 pl-2 pb-2'>
            <AuctionCountdownTimer auctionEnd={auction.auctionEnd}/>
          </div>
        </div>

      </div>
      <div className='flex justify-between items-center mt-4'>
        <h3 className='text-gray-700'>{auction.item.make} {auction.item.model}</h3>
        <p className='font-semibold text-sm'>{auction.item.year}</p>
      </div>
      
    </Link>
  )
}
