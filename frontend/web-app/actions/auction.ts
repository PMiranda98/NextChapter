'use server'

import { Auction, PagedResults } from "@/types";

export async function getData(queryString: string): Promise<PagedResults<Auction>> {
  const result = await fetch(`http://localhost:6001/search${queryString}`);
  if (!result.ok) throw new Error('Failed to fetch data');
  return result.json();
}