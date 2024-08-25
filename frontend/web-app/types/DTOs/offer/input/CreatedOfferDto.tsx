import { CreatedItemDto } from "../../item/input/CreatedItemDto"

export type CreatedOfferDto = {
    id: string,
    advertisementId: string,
    recipient: string,
    sender: string,
    createdAt: string,
    status: string,
    type: string,
    amount: number,
    comment?: string,
    itemsToExchange: CreatedItemDto[]
}