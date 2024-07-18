import { CreateItemDto } from "../item/CreateItemDto"

export type CreateAuctionDto = {
  reservePrice: number
  auctionEnd: string
  item: CreateItemDto
}