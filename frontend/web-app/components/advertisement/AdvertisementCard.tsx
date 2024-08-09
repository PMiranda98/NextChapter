import { Advertisement } from '@/types'
import React from 'react'
import ItemImage from '../core/ItemImage'
import Link from 'next/link'

type Props = {
  advertisement: Advertisement
}

export default function AdvertisementCard({advertisement}: Props) {
  return (
    <Link href={`/advertisement/details/${advertisement.id}`} className='group'>
      <div className='w-full bg-gray-200 aspect-h-6 aspect-w-10 rounded-lg overflow-hidden'>
        <div>
          <ItemImage image={advertisement.item.photo} />
        </div>

      </div>
      <div className='flex justify-between items-center mt-4'>
        <h3 className='text-gray-700'>
          <p>{advertisement.item.name}</p> 
          <p>{advertisement.item.author}</p> 
          <p>{advertisement.item.literaryGenre}</p>
        </h3>
        <p className='font-semibold text-sm'>{advertisement.item.year}</p>
      </div>
    </Link>
  )
}
