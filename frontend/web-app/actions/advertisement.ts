'use server'

import { ErrorType, isErrorType } from "@/lib/helpers/ErrorHandlingHelper";
import { Advertisement, PagedResults } from "@/types";
import { CreatedAdvertisementDto } from "@/types/DTOs/advertisement/input/CreatedAdvertisementDto";
import { revalidatePath } from "next/cache";
import { del, get, post, put } from "./fetchWrapper";


export async function getAdvertisementData(queryString: string): Promise<PagedResults<Advertisement>> {
  const response = await fetchWrapperCaller<PagedResults<Advertisement>>(() => get<PagedResults<Advertisement>>(`search${queryString}`))
  return response
}

export async function getDetailedViewData(id: string) : Promise<Advertisement>{
  const response = await fetchWrapperCaller<Advertisement>(() => get<Advertisement>(`advertisement/${id}`))
  return response 
}

export async function createAdvertisement(formData: FormData) : Promise<CreatedAdvertisementDto>{
  const response = await fetchWrapperCaller<CreatedAdvertisementDto>(() => post<CreatedAdvertisementDto>(`advertisement`, formData)) 
  return response
}


export async function updateAdvertisement(formData: FormData, id: string) {
  await fetchWrapperExec(() => put(`advertisement/${id}`, formData)) 
  revalidatePath(`/advertisement/details/${id}`)
}

export async function deleteAdvertisement(id: string) {
  await fetchWrapperExec(() => del(`advertisement/${id}`)) 
  revalidatePath('/')
}

async function fetchWrapperCaller<T>(call: ()  => Promise<T | ErrorType>) : Promise<T> {
  try {
    const response = await call()
    console.log(response)

    if(isErrorType(response)) 
      throw new Error("test")
      //throw new Error(JSON.stringify(response))
    
    return response

  } catch (error: unknown) {
      throw error
  }
}

async function fetchWrapperExec(call: ()  => Promise<void | ErrorType>){
  try {
    const response = await call()

    if(isErrorType(response)) 
      throw new Error(JSON.stringify(response))

  } catch (error: unknown) {
    throw error
  }
}
