'use server'

import { fetchWrapper } from "@/lib/fetchWrapper";
import { PagedResults } from "@/types";
import { CreateOfferDto } from "@/types/DTOs/offer/CreateOfferDto";
import { Offer } from "@/types/Offer";

export async function createOffer(advertisementId: string, createOfferDto: CreateOfferDto){
  return await fetchWrapper.post(`offer/${advertisementId}`, createOfferDto)
}

export async function detailsOffer(id: string) : Promise<Offer>{
  return await fetchWrapper.get(`offer/${id}`)
}

export async function getOffers(queryString: string): Promise<PagedResults<Offer>> {
  return await fetchWrapper.get(`offer${queryString}`)
}

