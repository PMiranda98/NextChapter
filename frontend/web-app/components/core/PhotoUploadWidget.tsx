'use client'

import { Label } from 'flowbite-react'
import Reactv from 'react'
import PhotoWidgetDropzone from './PhotoWidgetDropzone'

export default function PhotoUploadWidget() {
  
  return (
    <div className='grid grid-cols-3 gap-6 mt-3 mb-3'>
      <div className='grid grid-rows-2 text-center'>
        <Label value='Step 1 - Add Photo'/>
        <PhotoWidgetDropzone />
      </div>
      <div className='grid grid-rows-2 text-center'>
        <Label value='Step 2 - Resize Photo'/>
      </div>
      <div className='grid grid-rows-2 text-center'>
        <Label value='Step 3 - Preview'/>
      </div>
    </div>
  )
}
