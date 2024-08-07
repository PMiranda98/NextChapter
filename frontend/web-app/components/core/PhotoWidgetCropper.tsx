'use client'

import { setConfig } from 'next/config'
import React from 'react'
import { Cropper } from 'react-cropper'
import "cropperjs/dist/cropper.css";

type Props = {
  photo: Blob
  setCropper: (cropper: Cropper) => void
}

export default function PhotoWidgetCropper({photo, setCropper} : Props) {
  return (
    <Cropper 
      src={URL.createObjectURL(photo)}
      width='200'
      height='200'
      initialAspectRatio={1}
      aspectRatio={1}
      preview='.img-preview'
      guides={false}
      viewMode={1}
      autoCropArea={1}
      background={false}
      onInitialized={(cropper) => setCropper(cropper)}
    />
  )
}
