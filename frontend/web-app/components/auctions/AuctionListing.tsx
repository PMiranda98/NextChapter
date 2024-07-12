import React from 'react'
import AuctionCard from './AuctionCard';
import { PagedResults, Auction } from '@/types';

async function getData(): Promise<PagedResults<Auction>> {
  const result = await fetch('http://localhost:6001/search');
  if (!result.ok) throw new Error('Failed to fetch data');
  return result.json();
}

export default async function Listings() {
  const data = await getData();
  console.log(data);
  console.log(data.results);
  return (
    <div className='grid grid-cols-4 gap-6'>
      {data && data.results.map((auction) => (
        <AuctionCard key={auction.id} auction={auction}/>
      ))}
    </div>
  )
}
