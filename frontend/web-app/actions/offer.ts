import { fetchWrapper } from "@/lib/fetchWrapper";
import { CreateOfferDto } from "@/types/DTOs/offer/CreateOfferDto";

export async function createOffer(advertisementId: string, createOfferDto: CreateOfferDto){
    return await fetchWrapper.post(`offer/${advertisementId}`, createOfferDto)
  }