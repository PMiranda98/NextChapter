import { Item } from "./Item"

export type Auction = {
  id: string
  reservePrice: number
  seller: string
  winner?: string
  soldAmount: number
  currentHighBid: number
  createdAt: string
  updateAt: string
  auctionEnd: string
  status: string
  item: Item
}