import { Photo } from "@/types/Models/Photo"

export type CreateItemDto = {
  name: string
  author: string
  literaryGenre: string
  year: number
}