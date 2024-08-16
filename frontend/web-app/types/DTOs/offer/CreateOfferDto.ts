import { InventoryItem } from "@/types/InventoryItem"

export type CreateOfferDto = {
    type: string,
    amount: number,
    comment: string,
    itemsToExchange: InventoryItem[]
}