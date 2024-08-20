'use client'

import React, { SetStateAction, useEffect, useState } from 'react'
import Input from '../core/Input'
import { FieldValues, useForm } from 'react-hook-form'
import { Button, Label } from 'flowbite-react'
import OfferTypeRadioButton from './OfferTypeRadioButton'
import OfferAmoutRangeSlider from './OfferAmoutRangeSlider'
import Heading from '../core/Heading'
import InventoryListing from '../inventory/InventoryListing'
import { InventoryItem } from '@/types'
import toast from 'react-hot-toast'
import { useRouter } from 'next/navigation'
import { CreateOfferDto } from '@/types/DTOs/offer/CreateOfferDto'
import { createOffer } from '@/actions/offer'
import useInventoryParamsStore from '@/hooks/useInventoryParamsStore'

type Props = {
  advertisementId: string
  username: string
  advertisementSeller: string
  sellingPrice: number
}

export default function OfferForm({advertisementId, advertisementSeller, sellingPrice, username} : Props) {
  const router = useRouter()
  const {control, handleSubmit, formState: {isSubmitting, isValid}} = useForm()
  const setInventoryParams = useInventoryParamsStore(state => state.setStateParams)

  const [exchangeSection, setExchangeSection] = useState(false)
  const [booksSelected, setBooksSelected] = useState<InventoryItem[]>([])
  const [amount, setAmount] = useState(`${sellingPrice}`)

  const handleSetExchangeSection = (value: SetStateAction<boolean>) => {
    if(value === false){
      setBooksSelected([])
      setInventoryParams({owner: undefined})
    }
    setInventoryParams({owner: username})
    setExchangeSection(value)
  }

  const setAmountHandler = (value: string) => {
    setAmount(value)
  }

  const onSubmit = async (data: FieldValues) => {
    try {
      let id 
      let response
      //console.log(data)
      const createOfferDto = mapToCreateOfferDto(data, booksSelected, amount, advertisementSeller, username)
      console.log(createOfferDto)
      response = await createOffer(advertisementId, createOfferDto)
      id = response.id
      if(response.error){
        throw response.error
      }
      router.push(`/offer/details/${id}`)
    } catch (error: any) {
      toast.error(error.status + ' ' + error.message)
    }
  }

  return (
    <div className='mt-3 mb-3 grid grid-cols-2 gap-3'>
      <div className='bg-gray-100 rounded-lg p-2 border-2'>
        <Heading title='Make an offer' center />
        <div className='ml-3'>
          <form className='flex flex-col mt-3' onSubmit={handleSubmit(onSubmit)}>
            <OfferTypeRadioButton control={control} name='offerType' handleSetExchangeSection={handleSetExchangeSection}/>
            <OfferAmoutRangeSlider setAmount={setAmountHandler} sellingPrice={sellingPrice} isExchange={exchangeSection}/>
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
          <InventoryListing from='offer' setBooksSelected={setBooksSelected}/>
        </div>
      } 
    </div>

    
  )
}

const mapToCreateOfferDto = (data: FieldValues, booksSelected: InventoryItem[], amount: string, advertisementSeller: string, username: string) => {
  const createOfferDto : CreateOfferDto = {
    recipient: advertisementSeller,
    sender: username,
    type: data.offerType,
    amount: Number(amount),
    comment: data.comment,
    itemsToExchange: booksSelected
  }
  return createOfferDto 
}
