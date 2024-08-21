'use client'

import React, { useEffect, useState } from 'react'
import { FieldValues, useForm } from 'react-hook-form'
import Input from '../core/Input'
import { Button } from 'flowbite-react'
import { createAdvertisement, updateAdvertisement } from '@/actions/advertisement'
import { usePathname, useRouter } from 'next/navigation'
import { Advertisement } from '@/types'
import { CreateAdvertisementDto } from '@/types/DTOs/advertisement/CreateAdvertisementDto'
import toast from 'react-hot-toast'
import { UpdateAdvertisementDto } from '@/types/DTOs/advertisement/UpdateAdvertisementDto'
import PhotoUploadWidget from '../core/PhotoUploadWidget'
import Image from 'next/image'
import useInventoryStore from '@/hooks/useInventoryStore'

type Props = {
  advertisement?: Advertisement
}

export default function AdvertisementForm({advertisement} : Props) {
  const router = useRouter()
  const pathname = usePathname()
  const {control, handleSubmit, setFocus, reset, formState: {isSubmitting, isValid, isDirty, errors}} = useForm({
    mode: 'onTouched'
  })
  const inventoryItemSelected = useInventoryStore(state => state.inventoryItemSelected)
  const setInventoryItemSelected = useInventoryStore(state => state.setInventoryItemSelected)

  const [files, setFiles] = useState<Blob[]>([])

  useEffect(() => {
    // This code runs on mount and whenever dependencies change
    console.log('Component mounted or updated');
    
    if(advertisement) {
      console.log(advertisement)
      const {sellingPrice, offerTypePretended, status} = advertisement
      const {name, author, literaryGenre, year, photo} = advertisement.item
      if(photo.url !== '') fetch(photo.url).then((response) => {
        response.blob().then((blob) => {
          setFiles([blob])
        })
      })
      reset({name, author, literaryGenre, year, sellingPrice, offerTypePretended, status})
    }
    if(inventoryItemSelected) {
      console.log(inventoryItemSelected)
      const {name, author, literaryGenre, year, photo} = inventoryItemSelected
      if(photo.url !== '') fetch(photo.url).then((response) => {
        response.blob().then((blob) => {
          setFiles([blob])
        })
      })
      reset({name, author, literaryGenre, year})
    }
    setFocus('name')

    return () => {
      // This code runs on unmount and before the effect runs again
      console.log('Component will unmount or effect will re-run');
      if(inventoryItemSelected) setInventoryItemSelected(undefined)
    }
  }, [setFocus])

  const removePhoto = () => {
    setFiles([])
    if(advertisement?.item) {
      advertisement.item.photo.url = ''
      advertisement.item.photo.id = ''
    }
  }

  const onSubmit = async (data: FieldValues) => {
    try {
      let id 
      let response
      if(files && files.length === 0) throw new Error('A Photo is required!');
      if(pathname === '/advertisement/create'){
        const createAdvertisementDto = mapToCreateAdvertisementDto(data)
        const formData = new FormData()
        formData.append('file', files[0])
        formData.append('createAdvertisementDtoJson', JSON.stringify(createAdvertisementDto))
        response = await createAdvertisement(formData)
        id = response.id
      } else {
        if(advertisement){
          const updateAdvertisementDto = mapToUpdateAdvertisementDto(data)
          const formData = new FormData()
          formData.append('file', files[0])
          formData.append('updateAdvertisementDtoJson', JSON.stringify(updateAdvertisementDto))
          response = await updateAdvertisement(formData, advertisement.id)
          id = advertisement.id
        }
      }
      if(response.error){
        throw response.error
      }
      router.push(`/advertisement/details/${id}`)
    } catch (error: any) {
      toast.error(error.status + ' ' + error.message)
    }
  }

  return (
    <form className='flex flex-col mt-3' onSubmit={handleSubmit(onSubmit)}>
      <Input label='Name' name='name' control={control} rules={{required: 'Name is required.'}} />
      <Input label='Author' name='author' control={control} rules={{required: 'Author is required.'}} />
      <Input label='Literary Genre' name='literaryGenre' control={control} rules={{required: 'Literary Genre is required.'}} />
      <div className='grid grid-cols-2 gap-3'>
        <Input label='Year' name='year' control={control} type='number' rules={{required: 'Year is required.'}} />
      </div>

      {pathname === '/advertisement/create' && 
      <>
        <div className='grid grid-cols-2 gap-3'>
          <Input label='Selling Price' name='sellingPrice' control={control} type='number' rules={{required: 'Selling price is required.'}} />
          <Input label='Offer type pretended' name='offerTypePretended' control={control} rules={{required: 'Offer type pretended is required.'}} />
        </div>
      </>}

      {pathname.startsWith('/advertisement/update') && 
        <Input label='Status' name='status' control={control} rules={{required: 'Status is required.'}} />
      }
      
      {files && files.length === 0 && (
        <PhotoUploadWidget setFiles={setFiles}/>
      )}

      {files && files.length > 0 && inventoryItemSelected?.photo.url === undefined &&(
        <div className='grid grid-rows-80/20 place-items-center'>
          <Image src={URL.createObjectURL(files[0])} alt='Book Image' width='200' height='200' />
          <Button outline color='red' onClick={() => removePhoto()} className='border mt-3'>
            Remove
          </Button>
        </div>
      )}

      {inventoryItemSelected && inventoryItemSelected?.photo.url !== undefined && (
        <div className='grid grid-rows-80/20 place-items-center'>
        <Image src={inventoryItemSelected.photo.url} alt='Book Image' width='200' height='200' />
      </div>
      )}
      
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

const mapToCreateAdvertisementDto = (data: FieldValues) => {
  const createAdvertisementDto : CreateAdvertisementDto = {
    sellingPrice: data.sellingPrice,
    offerTypePretended: data.offerTypePretended,
    item: {
      name: data.name,
      author: data.author,
      literaryGenre: data.literaryGenre,
      year: data.year,
    }
  }
  return createAdvertisementDto 
}

const mapToUpdateAdvertisementDto = (data: FieldValues) => {
  const updateAdvertisementDto : UpdateAdvertisementDto = {
    sellingPrice: data.sellingPrice,
    status: data.status,
    offerTypePretended: data.offerTypePretended,
    item: {
      name: data.name,
      author: data.author,
      literaryGenre: data.literaryGenre,
      year: data.year,
    }
  }
  return updateAdvertisementDto 
}

