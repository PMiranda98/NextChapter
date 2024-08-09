import { getDetailedViewData } from '@/actions/inventory'
import AdvertisementForm from '@/components/advertisement/AdvertisementForm'
import Heading from '@/components/core/Heading'
import InventoryItemForm from '@/components/inventory/InventoryItemForm'
import React from 'react'

export default async function Update({params} : {params: {id : string}}) {
  const data = await getDetailedViewData(params.id)
  return (
    <div className='mx-auto max-w-[75%] shadow-lg p-10 bg-white rounded-lg'>
      <Heading title='Update your inventory item' subtitle='Please update the details of your inventory item.'/>
      <InventoryItemForm item={data}/>
    </div>
  )
}
