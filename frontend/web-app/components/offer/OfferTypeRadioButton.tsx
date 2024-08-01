'use client'

import { Label, Radio } from 'flowbite-react'
import React, { SetStateAction } from 'react'

type Props = {
  handleSetExchangeSection: (value: SetStateAction<boolean>) => void
}

export default function OfferTypeRadioButton({handleSetExchangeSection} : Props) {
  return (
    <fieldset className="flex max-w-md flex-col gap-4">
      <legend className="mb-2">Choose the offer type:</legend>
      <div className="flex items-center gap-2">
        <Radio id="purchase" name="offer-type" value="Purchase" defaultChecked onClick={() => handleSetExchangeSection(false)}/>
        <Label htmlFor="purchase">Purchase</Label>
      </div>
      <div className="flex items-center gap-2">
        <Radio id="exchange" name="offer-type" value="Exchange" onClick={() => handleSetExchangeSection(true)}/>
        <Label htmlFor="exchange">Exchange</Label>
      </div>
    </fieldset>
  )
}