'use server'

import { ErrorType, isErrorType } from "@/lib/helpers/ErrorHandlingHelper"
import { InventoryItem, PagedResults } from "@/types"
import { CreatedInventoryItemDto } from "@/types/DTOs/inventory/input/CreatedInventoryItemDto"
import { revalidatePath } from "next/cache"
import { del, get, post, put } from "./fetchWrapper"

export async function getInventoryData(queryString: string): Promise<PagedResults<InventoryItem>> {
  const response = await fetchWrapperCaller<PagedResults<InventoryItem>>(() => get<PagedResults<InventoryItem>>(`inventory${queryString}`))
  return response
}

export async function getDetailedViewData(id: string) : Promise<InventoryItem>{
  const response = await fetchWrapperCaller<InventoryItem>(() => get<InventoryItem>(`inventory/${id}`))
  return response 
}

export async function createInventoryItem(formData: FormData) : Promise<CreatedInventoryItemDto> {
  const response = await fetchWrapperCaller<CreatedInventoryItemDto>(() => post<CreatedInventoryItemDto>(`inventory`, formData)) 
  return response
}

export async function updateInventoryItem(formData: FormData, id: string) {
  await fetchWrapperExec(() => put(`inventory/${id}`, formData)) 
  revalidatePath(`/inventory/details/${id}`)
}

export async function deleteInventoryItem(id: string) {
  await fetchWrapperExec(() => del(`inventory/${id}`)) 
  revalidatePath('/inventory/list')
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