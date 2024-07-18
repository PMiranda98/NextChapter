'use server'

import { fetchWrapper } from "@/lib/fetchWrapper";
import { Auction, PagedResults } from "@/types";
import { FieldValues } from "react-hook-form";

export async function getData(queryString: string): Promise<PagedResults<Auction>> {
  return await fetchWrapper.get(`search${queryString}`)
}

export async function createAuction(data: FieldValues) {
  return await fetchWrapper.post(`auctions`, data)
}