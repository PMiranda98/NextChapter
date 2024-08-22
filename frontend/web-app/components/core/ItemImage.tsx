'use client'

import React, { useState } from 'react'
import Image from 'next/image'
import { Photo } from '@/types/Models/Photo'

type Props = {
  image: Photo
}

export default function ItemImage({ image } : Props) {
  const [isLoading, setLoading] = useState(true);
  return (
    <Image 
            src={image.url}
            alt='image'
            fill
            priority
            sizes='(max-width:768px) 100vw, (max-width:1200px) 50vw, 25vw'
            className={`
              object-cover
              group-hover:opacity-75
              duration-500
              ease-in-out
              ${isLoading ? 'grayscale blur-2xl scale-110' : 'grayscale-0 blur-0 scale-100'}
              `}
            onLoadingComplete={() => setLoading(false)}
          />
  )
}
