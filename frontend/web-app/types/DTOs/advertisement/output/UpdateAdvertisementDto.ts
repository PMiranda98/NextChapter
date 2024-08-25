import { UpdateItemDto } from "../../item/output/UpdateItemDto"


export type UpdateAdvertisementDto = {
    sellingPrice: number
    status: string
    offerTypePretended: string
    item: UpdateItemDto
  }