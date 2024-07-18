'use server'

import { fetchWrapper } from "@/lib/fetchWrapper";
import { Auction, PagedResults } from "@/types";

export async function getData(queryString: string): Promise<PagedResults<Auction>> {
  return await fetchWrapper.get(`search${queryString}`)
}