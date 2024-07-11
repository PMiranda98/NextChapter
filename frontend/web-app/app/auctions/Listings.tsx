import React from 'react'
import AuctionCard from './AuctionCard';
import { Console } from 'console';
import { Auction, PagedResults } from '@/types';

async function getData(): Promise<PagedResults<Auction>> {
  const result = await fetch('http://localhost:6001/search');
  if (!result.ok) throw new Error('Failed to fetch data');
  return result.json();
}

export default async function Listings() {
  const data = await getData();
  //console.log(data.auctions);
  return (
    <div className='grid grid-cols-4 gap-6'>
      {data && data.auctions.map((auction) => (
        <AuctionCard key={auction.id} auction={auction}/>
      ))}
    </div>
  )
}
