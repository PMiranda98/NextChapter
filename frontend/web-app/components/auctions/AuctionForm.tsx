'use client'

import React, { useEffect } from 'react'
import { FieldValues, useForm } from 'react-hook-form'
import Input from '../core/Input'
import { Button } from 'flowbite-react'
import DateInput from '../core/DateInput'
import { createAuction, updateAuction } from '@/actions/auction'
import { usePathname, useRouter } from 'next/navigation'
import { Auction } from '@/types'
import { getCurrentUser } from '@/actions/auth'
import { CreateAuctionDto } from '@/types/DTOs/auction/CreateAuctionDto'
import toast from 'react-hot-toast'
import { UpdateAuctionDto } from '@/types/DTOs/auction/UpdateAuctionDto'

type Props = {
  auction?: Auction
}

export default function AuctionForm({auction} : Props) {
  const router = useRouter()
  const pathname = usePathname()
  const {control, handleSubmit, setFocus, reset, formState: {isSubmitting, isValid, isDirty, errors}} = useForm({
    mode: 'onTouched'
  })

  useEffect(() => {
    if(auction) {
      const {make, model, color, mileage, year} = auction.item
      reset({make, model, color, mileage, year})
    }
    setFocus('make')
  }, [setFocus])

  const onSubmit = async (data: FieldValues) => {
    try {
      let id 
      let response
      console.log('Path name: ' + pathname)
      if(pathname === '/auctions/create'){
        const createAuctionDto = mapToCreateAuctionDto(data)
        response = await createAuction(createAuctionDto)
        id = response.id
      } else {
        if(auction){
          const updateAuctionDto = mapToUpdateAuctionDto(data)
          response = await updateAuction(updateAuctionDto, auction.id)
          id = auction.id
        }
      }
      if(response.error){
        throw response.error
      }
      router.push(`/auctions/details/${id}`)
    } catch (error: any) {
      toast.error(error.status + ' ' + error.message)
    }
  }

  return (
    <form className='flex flex-col mt-3' onSubmit={handleSubmit(onSubmit)}>
      <Input label='Make' name='make' control={control} rules={{required: 'Make is required.'}} />
      <Input label='Model' name='model' control={control} rules={{required: 'Model is required.'}} />
      <Input label='Color' name='color' control={control} rules={{required: 'Color is required.'}} />
      <div className='grid grid-cols-2 gap-3'>
        <Input label='Year' name='year' control={control} type='number' rules={{required: 'Year is required.'}} />
        <Input label='Mileage' name='mileage' control={control} type='number' rules={{required: 'Mileage is required.'}} />
      </div>

      {pathname === '/auctions/create' && 
      <>
        <Input label='Image URL' name='imageUrl' control={control} rules={{required: 'Image URL is required.'}} />
        <div className='grid grid-cols-2 gap-3'>
          <Input label='Reserve Price (enter 0 if no reserve)' name='reservePrice' control={control} type='number' rules={{required: 'Reserve price is required.'}} />
          <DateInput label='Auction end date/time' name='auctionEnd' control={control} rules={{required: 'Auction end date is required.'}} />
        </div>
      </>}
      
      <div className='flex justify-between'>
        <Button outline color='gray'>Cancel</Button>
        <Button
          isProcessing={isSubmitting}
          disabled={!isValid}
          type='submit' 
          outline 
          color='success'>
            Submit
        </Button>
      </div>
    </form>
  )
}

const mapToCreateAuctionDto = (data: FieldValues) => {
  const createAuctionDto : CreateAuctionDto = {
    id: data.id,
    reservePrice: data.reservePrice,
    auctionEnd: data.auctionEnd,
    item: {
      make: data.make,
      model: data.model,
      year: data.year,
      color: data.color,
      mileage: data.mileage,
      imageUrl: data.imageUrl,
    }
  }
  return createAuctionDto 
}

const mapToUpdateAuctionDto = (data: FieldValues) => {
  const updateAuctionDto : UpdateAuctionDto = {
    item: {
      make: data.make,
      model: data.model,
      year: data.year,
      color: data.color,
      mileage: data.mileage,
    }
  }
  return updateAuctionDto 
}

