import AuctionForm from '@/components/auctions/AuctionForm'
import Heading from '@/components/core/Heading'
import React from 'react'

export default function Create() {
  return (
    <div className='mx-auto mx-w-[75%] shadow p-10 bg-white rounded-lg'>
      <Heading title='Sell your car!' subtitle='Please enter the details of your car.'/>
      <AuctionForm />
    </div>
  )
}
