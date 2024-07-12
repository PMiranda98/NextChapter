'use server'

import { Auction, PagedResults } from "@/types";

export async function getData(pageNumber: number = 1, pageSize: number): Promise<PagedResults<Auction>> {
  const result = await fetch(`http://localhost:6001/search?pageSize=${pageSize}&pageNumber=${pageNumber}`);
  if (!result.ok) throw new Error('Failed to fetch data');
  return result.json();
}