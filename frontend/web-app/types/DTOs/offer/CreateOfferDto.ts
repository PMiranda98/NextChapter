import { InventoryItem } from "@/types/InventoryItem"

export type CreateOfferDto = {
    sender: string,
    recipient: string,
    type: string,
    amount: number,
    comment: string,
    itemsToExchange: InventoryItem[]
}