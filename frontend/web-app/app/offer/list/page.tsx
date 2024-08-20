import Heading from '@/components/core/Heading'
import OfferListing from '@/components/offer/OfferListing'
import React from 'react'

export default function List() {
  return (
    <div className='mx-auto mx-w-[75%] shadow p-10 bg-white rounded-lg'>
      <Heading title='Offers'/>
      <OfferListing />
    </div>
  )
}