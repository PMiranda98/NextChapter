import { Photo } from "./Photo"

export type InventoryItem = {
  id: string
  name: string
  author: string
  literaryGenre: string
  year: number
  photo: Photo
}