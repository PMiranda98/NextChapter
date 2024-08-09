import Heading from '@/components/core/Heading'
import InventoryItemForm from '@/components/inventory/InventoryItemForm'
import React from 'react'

export default function Create() {
  return (
    <div className='mx-auto mx-w-[75%] shadow p-10 bg-white rounded-lg'>
      <Heading title='Add an item!' subtitle='Please enter the details of the new item.'/>
      <InventoryItemForm />
    </div>
  )
}