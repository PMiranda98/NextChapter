'use client'

import { Label } from 'flowbite-react'
import Reactv, { useState } from 'react'
import PhotoWidgetDropzone from './PhotoWidgetDropzone'
import Image from 'next/image'

export default function PhotoUploadWidget() {
  const [files, setFiles] = useState<any>([])

  return (
    <div className='grid grid-cols-3 gap-6 mt-3 mb-3'>
      <div className='grid grid-rows-2 text-center'>
        <Label value='Step 1 - Add Photo'/>
        <PhotoWidgetDropzone setFiles={setFiles}/>
      </div>
      <div className='grid grid-rows-2 text-center'>
        <Label value='Step 2 - Resize Photo'/>
        {files && files.length > 0 && (
          <Image src={URL.createObjectURL(files[0])} alt="Book image." width='100' height='100'/>
        )}
      </div>
      <div className='grid grid-rows-2 text-center'>
        <Label value='Step 3 - Preview'/>
      </div>
    </div>
  )
}
