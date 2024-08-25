import { Photo } from "@/types/Models/Photo"

export type CreatedItemDto = {
    name: string
    author: string
    literaryGenre: string
    year: number
    photo: Photo
}