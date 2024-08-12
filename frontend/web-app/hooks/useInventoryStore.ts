import { InventoryItem, PagedResults } from "@/types"
import { shallow } from "zustand/shallow"
import { createWithEqualityFn } from "zustand/traditional"

type State = {
  inventoryItems: InventoryItem[]
  totalCount: number
  pageCount: number
  inventoryItemSelected?: InventoryItem
}

type Actions = {
  setData: (data: PagedResults<InventoryItem>) => void
  setInventoryItemSelected: (item?: InventoryItem) => void
}

const initialState: State = {
  inventoryItems: [],
  totalCount: 0,
  pageCount: 0,
  inventoryItemSelected: undefined
}

const useInventoryStore = createWithEqualityFn<State & Actions>((set) => ({
  ...initialState,
  setData: (data: PagedResults<InventoryItem>) => {
    set(()=> ({
      inventoryItems: data.results,
      totalCount: data.totalCount,
      pageCount: data.pageCount
    }))
  },
  setInventoryItemSelected: (item?: InventoryItem) => {
    set((currentState) => ({
      ...currentState,
      inventoryItemSelected: item
    }))
  }
}), shallow)

export default useInventoryStore