import { UpdateItemDto } from "../item/UpdateItemDto"

export type UpdateAdvertisementDto = {
    sellingPrice: number
    status: string
    offerTypePretended: string
    item: UpdateItemDto
  }