import { InventoryItem, PagedResults } from "@/types"
import { shallow } from "zustand/shallow"
import { createWithEqualityFn } from "zustand/traditional"

type State = {
  inventoryItems: InventoryItem[]
  totalCount: number
  pageCount: number
}

type Actions = {
  setData: (data: PagedResults<InventoryItem>) => void
}

const initialState: State = {
  inventoryItems: [],
  totalCount: 0,
  pageCount: 0
}

const useInventoryStore = createWithEqualityFn<State & Actions>((set) => ({
  ...initialState,
  setData: (data: PagedResults<InventoryItem>) => {
    set(()=> ({
      inventoryItems: data.results,
      totalCount: data.totalCount,
      pageCount: data.pageCount
    }))
  }
}), shallow)

export default useInventoryStore