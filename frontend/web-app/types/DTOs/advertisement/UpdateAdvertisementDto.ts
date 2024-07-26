import { UpdateItemDto } from "../item/UpdateItemDto"

export type UpdateAdvertisementDto = {
    sellingPrice: number
    offerTypePretended: string
    item: UpdateItemDto
  }