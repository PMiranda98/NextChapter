'use server'

import { fetchWrapper } from "@/lib/fetchWrapper"
import { InventoryItem, PagedResults } from "@/types"

export async function getInventoryData(queryString: string): Promise<PagedResults<InventoryItem>> {
  return await fetchWrapper.get(`search${queryString}`)
}
