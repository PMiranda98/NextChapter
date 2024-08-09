'use server'

import { fetchWrapper } from "@/lib/fetchWrapper"
import { InventoryItem, PagedResults } from "@/types"
import { UpdateInventoryItemDto } from "@/types/DTOs/inventory/UpdateInventoryItemDto"
import { revalidatePath } from "next/cache"

export async function getInventoryData(queryString: string): Promise<PagedResults<InventoryItem>> {
  return await fetchWrapper.get(`inventory${queryString}`)
}

export async function getDetailedViewData(id: string) : Promise<InventoryItem>{
  return await fetchWrapper.get(`inventory/${id}`)
}

export async function createInventoryItem(formData: FormData){
  return await fetchWrapper.post(`inventory`, formData)
}

export async function updateInventoryItem(formData: FormData, id: string) {
  const response = await fetchWrapper.put(`inventory/${id}`, formData)
  revalidatePath(`/inventory/details/${id}`)
  return response
}

export async function deleteInventoryItem(id: string) {
  const response = await fetchWrapper.del(`inventory/${id}`)
  revalidatePath('/inventory/list')
  return response
}