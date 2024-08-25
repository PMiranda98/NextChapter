import { PagedResults } from "@/types"
import { Offer } from "@/types"
import { shallow } from "zustand/shallow"
import { createWithEqualityFn } from "zustand/traditional"

type State = {
    offers: Offer[]
    totalCount: number
    pageCount: number
}

type Actions = {
    setData: (data: PagedResults<Offer>) => void
}

const initialState: State = {
    offers: [],
    totalCount: 0,
    pageCount: 0,
}

const useOfferStore = createWithEqualityFn<State & Actions>((set) => ({
    ...initialState,
    setData: (data: PagedResults<Offer>) => {
      console.log("setData:" + data)
      set(()=> ({
        offers: data.results,
        totalCount: data.totalCount,
        pageCount: data.pageCount
      }))
    }
  }), shallow)
  
  export default useOfferStore