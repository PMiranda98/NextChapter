'use server'

import { ErrorType, isErrorType } from "@/lib/helpers/ErrorHandlingHelper";
import { PagedResults, Offer } from "@/types";
import { CreatedOfferDto } from "@/types/DTOs/offer/input/CreatedOfferDto";
import { CreateOfferDto } from "@/types/DTOs/offer/output/CreateOfferDto";
import { UpdateOfferDto } from "@/types/DTOs/offer/output/UpdateOfferDto";
import { revalidatePath } from "next/cache";
import { del, get, post, put } from "./fetchWrapper";

export async function getOffers(queryString: string): Promise<PagedResults<Offer>> {
  const response = await fetchWrapperCaller<PagedResults<Offer>>(() => get<PagedResults<Offer>>(`offer${queryString}`))
  return response
}

export async function detailsOffer(id: string) : Promise<Offer>{
  const response = await fetchWrapperCaller<Offer>(() => get<Offer>(`offer/${id}`))
  return response 
}

export async function createOffer(advertisementId: string, createOfferDto: CreateOfferDto) : Promise<CreatedOfferDto>{
  const response = await fetchWrapperCaller<CreatedOfferDto>(() => post<CreatedOfferDto>(`offer/${advertisementId}`, createOfferDto)) 
  return response
}

export async function updateOffer(updateOfferDto: UpdateOfferDto, id: string) {
  await fetchWrapperExec(() => put(`offer/${id}`, updateOfferDto)) 
  revalidatePath(`/offer/details/${id}`)
}

export async function deleteOffer(id: string) {
  await fetchWrapperExec(() => del(`offer/${id}`)) 
  revalidatePath('/offer/list')
}

async function fetchWrapperCaller<T>(call: ()  => Promise<T | ErrorType>) : Promise<T> {
  try {
    const response = await call()

    if(isErrorType(response)) throw Error(response.error.message)
    
    return response

  } catch (error: unknown) {
    if(error instanceof Error)
      throw error
      //toast.error(error.message)
    else 
      //toast.error("Something went wrong.")
      throw error
  }
}

async function fetchWrapperExec(call: ()  => Promise<void | ErrorType>){
  try {
    const response = await call()

    if(isErrorType(response)) throw Error(response.error.message)

  } catch (error: unknown) {
    if(error instanceof Error)
      throw error
      //toast.error(error.message)
    else 
      //toast.error("Something went wrong.")
      throw error
  }
}