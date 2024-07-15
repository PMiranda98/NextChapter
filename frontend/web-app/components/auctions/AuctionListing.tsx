'use client'

import React, { useEffect, useState } from 'react'
import AuctionCard from './AuctionCard';
import { Auction, PagedResults } from '@/types';
import AppPagination from '../core/AppPagination';
import { getData } from '@/actions/auction';
import Filters from '../core/Filters';
import useParamsStore from '@/hooks/useParamsStore';
import qs from 'query-string'

export default function AuctionListing() {
  const [data, setData] = useState<PagedResults<Auction>>();
  // This is not advisable because if any of the state changes (we might have a lot more in the store than what we actually need here)
  // that would cause this component to rerender. 
  // const params = useParamsStore(state => state)

  // This is a more advisable way of getting all the states that we are interesting in this component in a single property.
  const params = useParamsStore(state => ({
    pageNumber: state.pageNumber,
    pageSize: state.pageSize,
    searchTerm: state.searchTerm
  }))

  const setParams = useParamsStore(state => state.setParams)
  const queryString = qs.stringifyUrl({url: '', query: params})
  const setPageNumber = (pageNumber: number) => setParams({pageNumber})

  useEffect(() => {
      getData(queryString).then(data => {
        setData(data)
      })
  }, [queryString])

  if(!data) return <h3>Loading...</h3>

  //console.log(data);
  return (
    <>
      <Filters/>
      <div className='grid grid-cols-4 gap-6'>
        {data.results.map((auction) => (
          <AuctionCard key={auction.id} auction={auction}/>
        ))}
      </div>
      <div className='flex justify-center mt-4'>
        <AppPagination currentPage={params.pageNumber} pageCount={data.pageCount} pageChanged={setPageNumber}/>
      </div>
    </>
  )
}
