'use server'

import { fetchWrapper } from "@/lib/fetchWrapper";
import { Advertisement, PagedResults } from "@/types";
import { CreateAdvertisementDto } from "@/types/DTOs/advertisement/CreateAdvertisementDto";
import { UpdateAdvertisementDto } from "@/types/DTOs/advertisement/UpdateAdvertisementDto";
import { revalidatePath } from "next/cache";

export async function getData(queryString: string): Promise<PagedResults<Advertisement>> {
  return await fetchWrapper.get(`search${queryString}`)
}

export async function createAdvertisement(data: CreateAdvertisementDto, file: Blob){
  return await fetchWrapper.post(`advertisement`, data, file)
}

export async function getDetailedViewData(id: string) : Promise<Advertisement>{
  return await fetchWrapper.get(`advertisement/${id}`)
}

export async function updateAdvertisement(data: UpdateAdvertisementDto, id: string) {
  const response = await fetchWrapper.put(`advertisement/${id}`, data)
  revalidatePath(`/advertisement/details/${id}`)
  return response
}

export async function deleteAdvertisement(id: string) {
  const response = await fetchWrapper.del(`advertisement/${id}`)
  revalidatePath('/')
  return response
}