import { CreateItemDto } from "../../item/output/CreateItemDto"

export type CreateAdvertisementDto = {
  sellingPrice: number
  offerTypePretended: string
  item: CreateItemDto
}