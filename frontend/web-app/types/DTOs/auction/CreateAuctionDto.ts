import { CreateItemDto } from "../item/CreateItemDto"

export type CreateAuctionDto = {
  id: string
  reservePrice: number
  auctionEnd: string
  item: CreateItemDto
}