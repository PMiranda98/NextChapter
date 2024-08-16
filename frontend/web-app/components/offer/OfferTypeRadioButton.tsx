'use client'

import { Label, Radio } from 'flowbite-react'
import React, { SetStateAction } from 'react'
import { useController, UseControllerProps } from 'react-hook-form'

type Props = {
  handleSetExchangeSection: (value: SetStateAction<boolean>) => void
} & UseControllerProps

export default function OfferTypeRadioButton(props : Props) {
  const {fieldState, field} = useController({...props, defaultValue: 'Purchase'})

  return (
    <fieldset className="flex max-w-md flex-col gap-4">
      <legend className="mb-2">Choose the offer type:</legend>
      <div className="flex items-center gap-2">
        <Radio
          {...props}
          {...field} 
          id="purchase" 
          value="Purchase" 
          defaultChecked 
          onClick={() => props.handleSetExchangeSection(false)}/>
        <Label htmlFor="purchase">Purchase</Label>
      </div>
      <div className="flex items-center gap-2">
        <Radio 
          {...props}
          {...field}
          id="exchange" 
          value="Exchange" 
          onClick={() => props.handleSetExchangeSection(true)}/>
        <Label htmlFor="exchange">Exchange</Label>
      </div>
    </fieldset>
  )
}