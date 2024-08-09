import { InventoryItem } from '@/types'
import React from 'react'
import ItemImage from '../core/ItemImage'
import Link from 'next/link'

type Props = {
  item: InventoryItem
}

export default function InventoryCard({item} : Props) {
  return (
      <Link href={`/inventory/details/${item.id}`} className='group'>
        <div className='w-full bg-gray-200 aspect-h-6 aspect-w-10 rounded-lg overflow-hidden'>
          <div>
            <ItemImage image={item.photo} />
          </div>

        </div>
        <div className='flex justify-between items-center mt-4'>
          <h3 className='text-gray-700'>
            <p>{item.name}</p> 
            <p>{item.author}</p> 
            <p>{item.literaryGenre}</p>
          </h3>
          <p className='font-semibold text-sm'>{item.year}</p>
        </div>
      </Link>
  )
}
