import { CreatedItemDto } from "../../item/input/CreatedItemDto"

export type CreatedAdvertisementDto = {
    id: string,
    sellingPrice: number,
    item: CreatedItemDto
}