'use client'

import React, { Dispatch, SetStateAction, useEffect, useState } from 'react'
import AppPagination from '../core/AppPagination'
import qs from 'query-string'
import EmptyFilter from '../core/EmptyFilter'
import { Spinner } from 'flowbite-react'
import { InventoryItem } from '@/types'
import { getOffers } from '@/actions/offer'
import useOfferStore from '@/hooks/useOfferStore'
import useOfferParamsStore from '@/hooks/useOfferParamsStore'
import OfferFilters from './OfferFilters'
import OfferCard from './OfferCard'

type Props = {
  from?: string
  setBooksSelected?: Dispatch<SetStateAction<InventoryItem[]>>
}

export default function OfferListing() {
  const [loading, setLoading] = useState(true)

  // This is not advisable because if any of the state changes (we might have a lot more in the store than what we actually need here)
  // that would cause this component to rerender. 
  // const params = useParamsStore(state => state)

  // This is a more advisable way of getting all the states that we are interesting in this component in a single property.
  const stateParams = useOfferParamsStore(state => {
    return {
      pageNumber: state.pageNumber,
      pageSize: state.pageSize,
      pageCount: state.pageCount,
      orderBy: state.orderBy,
      status: state.status,
      direction: state.direction
    }
  })

  const data = useOfferStore(state => ({
    offers: state.offers,
    totalCount: state.totalCount,
    pageCount: state.pageCount
  }))

  const setData = useOfferStore(state => state.setData)

  const setParams = useOfferParamsStore(state => state.setStateParams)
  const queryString = qs.stringifyUrl({url: '', query: stateParams})
  const setPageNumber = (pageNumber: number) => setParams({pageNumber: pageNumber})

  useEffect(() => {
      getOffers(queryString).then(data => {
        console.log(data)
        setData(data)
        setLoading(false)
      })
  }, [queryString])

  if(loading) return (
    <div className='flex h-screen justify-center items-center'>
      <Spinner />
    </div>
  )

  return (
    <>
      <OfferFilters />
      {data.totalCount === 0 ? (
        <EmptyFilter showReset/>
      ) : (
        <>
          <div className='grid grid-cols-4 gap-6'>
            {data.offers.map((offer) => 
            (
              <OfferCard key={offer.id} offer={offer}/>
            ))}
          </div>
          <div className='flex justify-center mt-4'>
            <AppPagination currentPage={stateParams.pageNumber} pageCount={data.pageCount} pageChanged={setPageNumber}/>
          </div>
        </>
      )}
    </>
  )
}
