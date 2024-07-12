import { Auction } from '@/types'
import Image from 'next/image'
import React from 'react'

type Props = {
  auction: Auction
}

export default function AuctionCard({auction}: Props) {
  return (
    <a href='#'>
      <div className='w-full bg-gray-200 aspect-h-6 aspect-w-10 rounded-lg overflow-hidden'>
        <div>
          <Image 
            src={auction.item.imageUrl}
            alt='image'
            fill
            priority
            sizes='(max-width:768px) 100vw, (max-width:1200px) 50vw, 25vw'
            className='object-cover'
          />
        </div>

      </div>
      <div className='flex justify-between items-center mt-4'>
        <h3 className='text-gray-700'>{auction.item.make} {auction.item.model}</h3>
        <p className='font-semibold text-sm'>{auction.item.year}</p>
      </div>
    </a>
  )
}
