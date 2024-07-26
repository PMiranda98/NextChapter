import { Item } from "./Item"

export type Advertisement = {
  id: string
  sellingPrice: number
  seller?: string
  buyer?: string
  soldAmount?: number
  numberOfOffers: number
  createdAt: string
  updateAt: string
  endedAt: string
  status: string
  offerTypePretended: string
  item: Item
}