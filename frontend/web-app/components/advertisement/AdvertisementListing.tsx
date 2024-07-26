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

export default function AdvertisementListing() {
  const [data, setData] = useState<PagedResults<Advertisement>>();
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

  const setParams = useParamsStore(state => state.setParams)
  const queryString = qs.stringifyUrl({url: '', query: params})
  const setPageNumber = (pageNumber: number) => setParams({pageNumber})

  useEffect(() => {
      console.log(queryString)
      getData(queryString).then(data => {
        console.log(data)
        setData(data)
      })
  }, [queryString])

  if(!data) return <h3>Loading...</h3>

  //console.log(data);
  return (
    <>
      <Filters/>
      {data.totalCount === 0 ? (
        <EmptyFilter showReset/>
      ) : (
        <>
          <div className='grid grid-cols-4 gap-6'>
            {data.results.map((advertisement) => (
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
