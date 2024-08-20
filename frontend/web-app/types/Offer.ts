import { Item } from "./Item"

export type Offer = {
  id: string
  advertisementId: string
  buyer: string
  date: string
  status: string
  type: string
  amount: number
  comment: string
  itemsToExchange: Item[]
}