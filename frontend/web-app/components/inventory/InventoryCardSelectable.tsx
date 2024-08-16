'use client'

import { InventoryItem } from '@/types'
import React, { Dispatch, SetStateAction, useState } from 'react'
import ItemImage from '../core/ItemImage'
import Link from 'next/link'
import { FaCircleCheck } from 'react-icons/fa6'
import { FaRegCheckCircle } from 'react-icons/fa'

type Props = {
  item: InventoryItem
  setBooksSelected: Dispatch<SetStateAction<InventoryItem[]>>
}

export default function InventoryCard({item, setBooksSelected} : Props) {
    const [selected, setSelected] = useState(false)
  
    const handleClick = () => {
        if(selected){
          setSelected(false)
          setBooksSelected((prevState) => [
            ...prevState.filter((value) => value.id !== item.id)
          ])
        } 
        else{
          setSelected(true)
          setBooksSelected((prevState) => [
            ...prevState,
            item
          ])
        } 
    }

    return (
      <div className='group' onClick={() => handleClick()}>
        <div className='relative w-full bg-gray-200 aspect-h-6 aspect-w-10 rounded-lg overflow-hidden'>
          <div>
            <ItemImage image={item.photo} />
          </div>
          {selected && (
            <div className='absolute left-2 top-2'>
              <FaRegCheckCircle color='#ADD8E6' />
            </div>
          )}
        </div>
        <div className='flex justify-between items-center mt-4'>
          <h3 className='text-gray-700'>
            <p>{item.name}</p> 
            <p>{item.author}</p> 
            <p>{item.literaryGenre}</p>
          </h3>
          <p className='font-semibold text-sm'>{item.year}</p>
        </div>
      </div>
  )
}