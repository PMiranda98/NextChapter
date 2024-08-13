'use client'

import React, { SetStateAction, useState } from 'react'
import Input from '../core/Input'
import { FieldValues, useForm } from 'react-hook-form'
import { Button, Label } from 'flowbite-react'
import OfferTypeRadioButton from './OfferTypeRadioButton'
import OfferAmoutRangeSlider from './OfferAmoutRangeSlider'
import Heading from '../core/Heading'
import InventoryListing from '../inventory/InventoryListing'

type Props = {
  sellingPrice: number
}

export default function OfferForm({sellingPrice} : Props) {

  const {control, handleSubmit, formState: {isSubmitting, isValid}} = useForm()
  const onSubmit = async (data: FieldValues) => {}

  const [exchangeSection, setExchangeSection] = useState(false)

  const handleSetExchangeSection = (value: SetStateAction<boolean>) => {
    setExchangeSection(value)
  }

  return (
    <div className='mt-3 mb-3 grid grid-cols-2 gap-3'>
      <div className='bg-gray-100 rounded-lg p-2 border-2'>
        <Heading title='Make an offer' center />
        <div className='ml-3'>
          <form className='flex flex-col mt-3' onSubmit={handleSubmit(onSubmit)}>
            <OfferTypeRadioButton handleSetExchangeSection={handleSetExchangeSection}/>
            <OfferAmoutRangeSlider sellingPrice={sellingPrice} isExchange={exchangeSection}/>
            <Input label='Comment' name='comment' control={control}  />
            <Button
              isProcessing={isSubmitting}
              disabled={!isValid}
              type='submit' 
              outline 
              color='success'>
                Submit
            </Button>
          </form>
        </div>
      </div>
      {exchangeSection && 
        <div className='bg-gray-100 rounded-lg p-2 border-2'>
          <Heading title='Choose books from your inventory' center />
          <InventoryListing from='offer'/>
        </div>
      } 
    </div>

    
  )
}
