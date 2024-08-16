import { Item } from "./Item"

export type Offer = {
  id: string
  advertisementId: string
  buyer: string
  date: string
  status: string
  type: string
  amount: string
  comment: string
  item: Item[]
}