'use client'

import { Label, RangeSlider } from 'flowbite-react'
import React, { useState } from 'react'

type Props = {
  sellingPrice: number
  offerType: string
}

export default function OfferAmoutRangeSlider({sellingPrice, offerType} : Props) {
  const [amountValue, setAmountValue] = useState(offerType === 'purchase' ? sellingPrice.toString() : '0')

  const handleAmountValue = (value: string) => {
    setAmountValue(value)
  }
  
  return (
    <div className="relative mb-8 mt-6">
      <div className="mb-1 grid grid-rows-2">
        <Label htmlFor="default-range" value="Amount" />
        <Label className='text-center' value={`${amountValue.toString()}€`}/>
      </div>
      <RangeSlider id="default-range" defaultValue={offerType === 'purchase' ? sellingPrice : 0} min='0' max={sellingPrice} className='mb-2' step={1} onChange={(event) => handleAmountValue(event.target.value)}/>
      <span className="text-sm text-gray-500 dark:text-gray-400 absolute start-0 -bottom-6">Min (0€)</span>
      <span className="text-sm text-gray-500 dark:text-gray-400 absolute start-1/4 -translate-x-1/2 rtl:translate-x-1/2 -bottom-6">{sellingPrice*1/4}€</span>
      <span className="text-sm text-gray-500 dark:text-gray-400 absolute start-2/4 -translate-x-1/2 rtl:translate-x-1/2 -bottom-6">{sellingPrice*2/4}€</span>
      <span className="text-sm text-gray-500 dark:text-gray-400 absolute start-3/4 -translate-x-1/2 rtl:translate-x-1/2 -bottom-6">{sellingPrice*3/4}€</span>
      <span className="text-sm text-gray-500 dark:text-gray-400 absolute end-0 -bottom-6">Max ({sellingPrice}€)</span>
  </div>
  )
}
