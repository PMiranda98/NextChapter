'use client'

import React, { useEffect, useState } from 'react'
import AuctionCard from './AuctionCard';
import { PagedResults, Auction } from '@/types';
import AppPagination from '../other/AppPagination';
import { getData } from '@/actions/auction';
import Filters from '../other/Filters';

export default function Listings() {
  const [auctions, setAuctions] = useState<Auction[]>([]);
  // Total number of pages based on the total number of items and the page size selected.
  const [pageCount, setPageCount] = useState(0)
  // Current page number selected.
  const [pageNumber, setPageNumber] = useState(1)
  // Current page size selected.
  const [pageSize, setPageSize] = useState(3)
  
  useEffect(() => {
      getData(pageNumber, pageSize).then(data => {
        setAuctions(data.results)
        setPageCount(data.pageCount)
      })
  }, [pageNumber, pageSize])

  if(auctions.length === 0) return <h3>Loading...</h3>

  //console.log(data);
  return (
    <>
      <Filters pageSize={pageSize} setPageSize={setPageSize}/>
      <div className='grid grid-cols-4 gap-6'>
        {auctions.map((auction) => (
          <AuctionCard key={auction.id} auction={auction}/>
        ))}
      </div>
      <div className='flex justify-center mt-4'>
        <AppPagination currentPage={pageNumber} pageCount={pageCount} pageChanged={setPageNumber}/>
      </div>
    </>
  )
}
