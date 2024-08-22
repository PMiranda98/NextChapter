import { Item } from "./Item"

export type Offer = {
  id: string
  advertisementId: string
  recipient: string
  sender: string
  createdAt: string
  endedAt?: string 
  status: string
  type: string
  amount: number
  comment?: string
  itemsToExchange: Item[]
}