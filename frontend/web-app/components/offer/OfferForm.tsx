'use client'

import React, { SetStateAction, useState } from 'react'
import Input from '../core/Input'
import { FieldValues, useForm } from 'react-hook-form'
import { Button } from 'flowbite-react'
import OfferTypeRadioButton from './OfferTypeRadioButton'
import OfferAmoutRangeSlider from './OfferAmoutRangeSlider'
import Heading from '../core/Heading'
import InventoryListing from '../inventory/InventoryListing'
import { Advertisement, InventoryItem, Offer } from '@/types'
import toast from 'react-hot-toast'
import { usePathname, useRouter } from 'next/navigation'
import { CreateOfferDto } from '@/types/DTOs/offer/CreateOfferDto'
import { createOffer, updateOffer } from '@/actions/offer'
import useInventoryParamsStore from '@/hooks/useInventoryParamsStore'
import { UpdateOfferDto } from '@/types/DTOs/offer/UpdateOfferDto'

type Props = {
  username?: string
  offer?: Offer
  advertisement: Advertisement
}

export default function OfferForm({username, offer, advertisement} : Props) {
  const router = useRouter()
  const pathname = usePathname()
  const {control, handleSubmit, formState: {isSubmitting, isValid}} = useForm()
  const setInventoryParams = useInventoryParamsStore(state => state.setStateParams)

  const [exchangeSection, setExchangeSection] = useState(false)
  const [booksSelected, setBooksSelected] = useState<InventoryItem[]>([])
  const [amount, setAmount] = useState(`${advertisement.sellingPrice}`)

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
      if(pathname.startsWith('/advertisement/details') && username !== undefined && advertisement.seller !== undefined){
        const createOfferDto = mapToCreateOfferDto(data, booksSelected, amount, advertisement.seller, username)
        console.log(createOfferDto)
        response = await createOffer(advertisement.id, createOfferDto)
        id = response.id
      } else {
        if(offer){
          const updateAdvertisementDto = mapToUpdateOfferDto(data, booksSelected, amount, offer.recipient, offer.sender, offer.status)
          response = await updateOffer(updateAdvertisementDto, offer.id)
          id = offer.id
        }
        if(response.error){
          throw response.error
        }
      }
      if(response.error){
        throw response.error
      }
      router.push(`/offer/details/${id}`)
    }
    catch (error: any) {
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
            <OfferAmoutRangeSlider setAmount={setAmountHandler} sellingPrice={advertisement.sellingPrice} isExchange={exchangeSection}/>
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

const mapToUpdateOfferDto = (data: FieldValues, booksSelected: InventoryItem[], amount: string, advertisementSeller: string, username: string, status: string) => {
  const createOfferDto : UpdateOfferDto = {
    recipient: advertisementSeller,
    sender: username,
    status: status,
    type: data.offerType,
    amount: Number(amount),
    comment: data.comment,
    itemsToExchange: booksSelected
  }
  return createOfferDto 
}