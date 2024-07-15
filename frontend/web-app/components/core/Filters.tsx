import useParamsStore from '@/hooks/useParamsStore';
import { Button } from 'flowbite-react';
import React from 'react'

type Props = {
  pageSize: number
  setPageSize: (size: number) => void
}

const pageSizeButtons = [3, 6, 9, 12]

export default function Filters() {
  const pageSize = useParamsStore(state => state.pageSize)
  const setParams = useParamsStore(state => state.setParams)

  return (
    <div className='flex justify-between items-center mb-4'>
      <div>
        <span className='text-sm text-gray-500 mr-2'>Page Size</span>
        <Button.Group>
          {pageSizeButtons.map((value, index) => (
            <Button key={index} onClick={() => setParams({pageSize : value})} color={`${pageSize === value ? 'red':'gray'}`}>
              {value}
            </Button>
          ))}
        </Button.Group>
      </div>
    </div>
  );
}
