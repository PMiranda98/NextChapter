'use client'

import { Button, ButtonGroup, Label } from 'flowbite-react'
import { useState } from 'react'
import PhotoWidgetDropzone from './PhotoWidgetDropzone'
import PhotoWidgetCropper from './PhotoWidgetCropper'
import { FaCheck } from 'react-icons/fa'
import { IoClose } from 'react-icons/io5'


export default function PhotoUploadWidget() {
  const [files, setFiles] = useState<any>([])
  const [cropper, setCropper] = useState<Cropper>()

  function onCrop() {
    if(cropper){
      cropper.getCroppedCanvas().toBlob(blob => console.log(blob))
    }
  }

  return (
    <div className='grid grid-cols-3 gap-6 mt-3 mb-3'>
      <div className='grid grid-rows-5 place-items-center'>
        <div className='row-span-1'>
          <Label value='Step 1 - Add Photo'/>
        </div>
        <div className='row-span-4'>
          <PhotoWidgetDropzone setFiles={setFiles}/>
        </div>
      </div>
      <div className='grid grid-rows-5 place-items-center'>
        <div className='row-span-1'>
          <Label value='Step 2 - Resize Photo'/>
        </div>
        <div className='row-span-4'>
          {files && files.length > 0 && (
            <PhotoWidgetCropper file={files[0]} setCropper={setCropper}/>
          )}
        </div>
      </div>
      <div className='grid grid-rows-5 place-items-center'>
        <div className='row-span-1'>
          <Label value='Step 3 - Preview'/>
        </div>
        {files && files.length > 0 && (
          <>
            {console.log(cropper)}
            <div className='row-span-4 img-preview' />
            <ButtonGroup>
              <Button onClick={onCrop} color="success">
                <FaCheck className="mr-2 h-5 w-5" />
              </Button>
              <Button onClick={() => setFiles([])} color="failure">
                <IoClose className="mr-2 h-5 w-5" />
              </Button>
            </ButtonGroup>
          </>
        )}
      </div>
    </div>
  )
}
