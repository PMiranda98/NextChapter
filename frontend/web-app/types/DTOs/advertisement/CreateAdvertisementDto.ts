import { CreateItemDto } from "../item/CreateItemDto"

export type CreateAdvertisementDto = {
  id: string
  sellingPrice: number
  offerTypePretended: string
  item: CreateItemDto
}