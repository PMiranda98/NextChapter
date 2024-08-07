import { CreateItemDto } from "../item/CreateItemDto"

export type CreateAdvertisementDto = {
  sellingPrice: number
  offerTypePretended: string
  item: CreateItemDto
}