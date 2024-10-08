import React from 'react'
import Link from 'next/link'
import { Offer } from '@/types'
import { FaExchangeAlt } from 'react-icons/fa'
import { MdCurrencyExchange } from 'react-icons/md'

type Props = {
  offer: Offer
}

export default function OfferCard({offer} : Props) {
  return (
      <Link href={`/offer/details/${offer.id}`} className='group'>
        <div className='w-80 h-auto bg-gray-200 aspect-h-10 aspect-w-8 rounded-lg overflow-hidden'>
          {offer.type === "Purchase" && (
            <div>
                <MdCurrencyExchange className='w-full h-full'/>
            </div>
          )}
          {offer.type === "Exchange" && (
            <div>
                <FaExchangeAlt className='w-full h-full'/>
            </div>
          )}
        </div>
        <div className='flex justify-between items-center mt-4'>
          <h3 className='text-gray-700'>
            <p>{offer.advertisementId}</p>
            <p>{offer.amount}</p>
            <p>{offer.recipient}</p>
            <p>{offer.sender}</p>
            <p>{offer.comment}</p>
            <p>{offer.createdAt}</p>
            {offer.endedAt && (
              <p>{offer.endedAt}</p>
            )}
            <p>{offer.status}</p>
          </h3>
        </div>
      </Link>
  )
}
