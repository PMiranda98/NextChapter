'use server'

import { fetchWrapper } from "@/lib/fetchWrapper";
import { PagedResults, Offer } from "@/types";
import { CreateOfferDto } from "@/types/DTOs/offer/CreateOfferDto";
import { UpdateOfferDto } from "@/types/DTOs/offer/UpdateOfferDto";
import { revalidatePath } from "next/cache";

export async function createOffer(advertisementId: string, createOfferDto: CreateOfferDto){
  return await fetchWrapper.post(`offer/${advertisementId}`, createOfferDto)
}

export async function detailsOffer(id: string) : Promise<Offer>{
  return await fetchWrapper.get(`offer/${id}`)
}

export async function getOffers(queryString: string): Promise<PagedResults<Offer>> {
  return await fetchWrapper.get(`offer${queryString}`)
}

export async function updateOffer(updateOfferDto: UpdateOfferDto, id: string) {
  const response = await fetchWrapper.put(`offer/${id}`, updateOfferDto)
  revalidatePath(`/offer/details/${id}`)
  return response
}

export async function deleteOffer(id: string) {
  const response = await fetchWrapper.del(`offer/${id}`)
  revalidatePath('/offer/list')
  return response
}
