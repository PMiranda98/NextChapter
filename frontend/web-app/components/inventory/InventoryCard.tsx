import { InventoryItem } from '@/types'
import React from 'react'
import ItemImage from '../advertisement/ItemImage'

type Props = {
  item: InventoryItem
}

export default function InventoryCard({item} : Props) {
  return (
    <>
      <div className='w-full bg-gray-200 aspect-h-6 aspect-w-10 rounded-lg overflow-hidden'>
          <div>
            <ItemImage image={item.photo} />
          </div>

        </div>
        <div className='flex justify-between items-center mt-4'>
          <h3 className='text-gray-700'>{item.name} {item.author} {item.literaryGenre}</h3>
          <p className='font-semibold text-sm'>{item.year}</p>
        </div>
    </>
  )
}
