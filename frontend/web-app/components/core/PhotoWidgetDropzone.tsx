import { Label } from 'flowbite-react'
import React, {useCallback} from 'react'
import {useDropzone} from 'react-dropzone'
import { FaUpload } from 'react-icons/fa'

type Props = {
  setFiles: (files: File[]) => void
}

export default function PhotoWidgetDropzone({setFiles} : Props) {
  const onDrop = useCallback((acceptedFiles: File[]) => {
    //setFiles(acceptedFiles.map((file: any) => {
    //  Object.assign(file, {
    //    preview: URL.createObjectURL(file)
    //  })
    //}))
    setFiles(acceptedFiles)
  }, [setFiles])
  const {getRootProps, getInputProps, isDragActive} = useDropzone({onDrop})

  return (
    <div className={`grid place-items-center rounded-md border-dashed border-2 p-10 text-wrap hover:border-green-400 ${isDragActive ? 'border-green-400' : 'border-[#eee]'}`} {...getRootProps()}>
      <input {...getInputProps()} />
      <FaUpload />
      <Label value='Drop photo here.'/>
    </div>
  )
}