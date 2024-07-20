import { getDetailedViewData } from '@/actions/auction'
import AuctionForm from '@/components/auctions/AuctionForm'
import Heading from '@/components/core/Heading'
import React from 'react'

export default async function Update({params} : {params: {id : string}}) {
  const data = await getDetailedViewData(params.id)
  return (
    <div className='mx-auto max-w-[75%] shadow-lg p-10 bg-white rounded-lg'>
      <Heading title='Update your auction' subtitle='Please update the details of your car'/>
      <AuctionForm auction={data}/>
    </div>
  )
}
