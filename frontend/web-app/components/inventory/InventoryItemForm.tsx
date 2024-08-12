'use client'

import React, { useEffect, useState } from 'react'
import { FieldValues, useForm } from 'react-hook-form'
import Input from '../core/Input'
import { Button } from 'flowbite-react'
import { usePathname, useRouter } from 'next/navigation'
import { InventoryItem  } from '@/types'
import toast from 'react-hot-toast'
import PhotoUploadWidget from '../core/PhotoUploadWidget'
import Image from 'next/image'
import { CreateInventoryItemDto } from '@/types/DTOs/inventory/CreateInventoryItemDto'
import { createInventoryItem, updateInventoryItem } from '@/actions/inventory'

type Props = {
  item?: InventoryItem
}


export default function InventoryItemForm({item} : Props) {
  const router = useRouter()
  const pathname = usePathname()
  const {control, handleSubmit, setFocus, reset, formState: {isSubmitting, isValid, isDirty, errors}} = useForm({
    mode: 'onTouched'
  })

  const [files, setFiles] = useState<Blob[]>([])

  useEffect(() => {
    if(item) {
      const {name, author, literaryGenre, year, photo} = item
      if(photo.url !== '') fetch(photo.url).then((response) => {
        response.blob().then((blob) => {
          setFiles([blob])
        })
      })
      reset({name, author, literaryGenre, year})
    }
    setFocus('name')
  }, [setFocus])

  const removePhoto = () => {
    setFiles([])
    if(item) {
      item.photo.url = ''
      item.photo.id = ''
    }
  }

  const onSubmit = async (data: FieldValues) => {
    try {
      let id 
      let response
      if(files && files.length === 0) throw new Error('A Photo is required!');
      if(pathname === '/inventory/create'){
        const createInventoryItemDto = mapToCreateInventoryItemDto(data)
        const formData = new FormData()
        formData.append('file', files[0])
        formData.append('createItemDtoJson', JSON.stringify(createInventoryItemDto))
        response = await createInventoryItem(formData)
        id = response.id
      } else {
        if(item){
          const updateInventoryItemDto = mapToUpdateInventoryItemDto(data)
          const formData = new FormData()
          formData.append('file', files[0])
          formData.append('updateItemDtoJson', JSON.stringify(updateInventoryItemDto))
          response = await updateInventoryItem(formData, item.id)
          id = item.id
        }
      }
      if(response.error){
        throw response.error
      }
      router.push(`/inventory/details/${id}`)
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
      
      {files && files.length === 0 && (
        <PhotoUploadWidget setFiles={setFiles}/>
      )}

      {files && files.length > 0 && (
        <div className='grid grid-rows-80/20 place-items-center'>
          <Image src={URL.createObjectURL(files[0])} alt='Book Image' width='200' height='200' />
          <Button outline color='red' onClick={() => removePhoto()} className='border mt-3'>
            Remove
          </Button>
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

const mapToCreateInventoryItemDto = (data: FieldValues) => {
  const createInventoryItemDto : CreateInventoryItemDto = {
    name: data.name,
    author: data.author,
    literaryGenre: data.literaryGenre,
    year: data.year
  }
  return createInventoryItemDto 
}

const mapToUpdateInventoryItemDto = (data: FieldValues) => {
  const updateInventoryItemDto : CreateInventoryItemDto = {
    name: data.name,
    author: data.author,
    literaryGenre: data.literaryGenre,
    year: data.year
  }
  return updateInventoryItemDto 
}

