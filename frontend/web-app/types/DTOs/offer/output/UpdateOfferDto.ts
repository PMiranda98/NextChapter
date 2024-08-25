import { InventoryItem } from "@/types"

export type UpdateOfferDto = {
    sender: string,
    recipient: string,
    status: string,
    type: string,
    amount: number,
    comment?: string,
    itemsToExchange: InventoryItem[]
}