'use server'

import { fetchWrapper } from "@/lib/fetchWrapper";
import { Auction, PagedResults } from "@/types";
import { CreateAuctionDto } from "@/types/DTOs/auction/CreateAuctionDto";
import { UpdateAuctionDto } from "@/types/DTOs/auction/UpdateAuctionDto";
import { revalidatePath } from "next/cache";
import { FieldValues } from "react-hook-form";

export async function getData(queryString: string): Promise<PagedResults<Auction>> {
  return await fetchWrapper.get(`search${queryString}`)
}

export async function createAuction(data: CreateAuctionDto){
  return await fetchWrapper.post(`auctions`, data)
}

export async function getDetailedViewData(id: string) : Promise<Auction>{
  return await fetchWrapper.get(`auctions/${id}`)
}

export async function updateAuction(data: UpdateAuctionDto, id: string) {
  const response = await fetchWrapper.put(`auctions/${id}`, data)
  revalidatePath(`/auctions/details/${id}`)
  return response
}

export async function deleteAuction(id: string) {
  const response = await fetchWrapper.del(`auctions/${id}`)
  revalidatePath('/')
  return response
}