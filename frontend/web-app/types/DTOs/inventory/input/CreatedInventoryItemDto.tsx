import { Photo } from "@/types/Models/Photo"

export type CreatedInventoryItemDto = {
    id: string,
    name: string,
    author: string,
    literaryGenre: string,
    year: number,
    owner: string,
    photo: Photo
}