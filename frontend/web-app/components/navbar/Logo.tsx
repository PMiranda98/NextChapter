'use client'

import useAdvertisementParamsStore from '@/hooks/useAdvertisementParamsStore'
import { usePathname, useRouter } from 'next/navigation'
import React from 'react'
import { BiBook } from 'react-icons/bi'

export default function Logo() {
  const router = useRouter();
  const pathname = usePathname();  
  const reset = useAdvertisementParamsStore(state => state.reset)
  const doReset = () => {
    if(pathname !== '/')
      router.push('/')
    reset()
  }
  
  return (
    <div onClick={doReset} className='flex items-center gap-2 text-lg font-semibold text-red-500 cursor-pointer'>
        <BiBook size={28} />
        <div>Book Advertisements</div>
    </div>
  )
}
