'use client'

import React, { useEffect, useState } from 'react'
import AdvertisementCard from './AdvertisementCard';
import { Advertisement, PagedResults } from '@/types';
import AppPagination from '../core/AppPagination';
import { getData } from '@/actions/advertisement';
import Filters from '../core/Filters';
import useParamsStore from '@/hooks/useParamsStore';
import qs from 'query-string'
import EmptyFilter from '../core/EmptyFilter';
import useAdvertisementStore from '@/hooks/useAdvertisementStore';

export default function AdvertisementListing() {
  const [loading, setLoading] = useState(true)

  // This is not advisable because if any of the state changes (we might have a lot more in the store than what we actually need here)
  // that would cause this component to rerender. 
  // const params = useParamsStore(state => state)

  // This is a more advisable way of getting all the states that we are interesting in this component in a single property.
  const params = useParamsStore(state => ({
    pageNumber: state.pageNumber,
    pageSize: state.pageSize,
    searchTerm: state.searchTerm,
    orderBy: state.orderBy,
    filterBy: state.filterBy,
    seller: state.seller,
    winner: state.winner
  }))

  const data = useAdvertisementStore(state => ({
    advertisements: state.advertisements,
    totalCount: state.totalCount,
    pageCount: state.pageCount
  }))

  const setData = useAdvertisementStore(state => state.setData)

  const setParams = useParamsStore(state => state.setParams)
  const queryString = qs.stringifyUrl({url: '', query: params})
  const setPageNumber = (pageNumber: number) => setParams({pageNumber})

  useEffect(() => {
      getData(queryString).then(data => {
        console.log(data) 
        setData(data)
        setLoading(false)
      })
  }, [queryString])

  if(loading) return <h3>Loading...</h3>

  return (
    <>
      <Filters/>
      {data.totalCount === 0 ? (
        <EmptyFilter showReset/>
      ) : (
        <>
          <div className='grid grid-cols-4 gap-6'>
            {data.advertisements.map((advertisement) => (
              <AdvertisementCard key={advertisement.id} advertisement={advertisement}/>
            ))}
          </div>
          <div className='flex justify-center mt-4'>
            <AppPagination currentPage={params.pageNumber} pageCount={data.pageCount} pageChanged={setPageNumber}/>
          </div>
        </>
      )}
    </>
  )
}
