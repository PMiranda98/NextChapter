import { Advertisement, PagedResults } from "@/types"
import { shallow } from "zustand/shallow"
import { createWithEqualityFn } from "zustand/traditional"

type State = {
  advertisements: Advertisement[]
  totalCount: number
  pageCount: number
}

type Actions = {
  setData: (data: PagedResults<Advertisement>) => void
  setNumberOfOffers: (advertisementId: string, value: number) => void
}

const initialState: State = {
  advertisements: [],
  totalCount: 0,
  pageCount: 0
}

const useAdvertisementStore = createWithEqualityFn<State & Actions>((set) => ({
  ...initialState,
  setData: (data: PagedResults<Advertisement>) => {
    set(()=> ({
      advertisements: data.results,
      totalCount: data.totalCount,
      pageCount: data.pageCount
    }))
  },
  setNumberOfOffers: (advertisementId: string, value: number) => {
    set((currentState) => ({
      advertisements: currentState.advertisements.map((advertisement) => advertisement.id === advertisementId ? {...advertisement, numberOfOffers: value} : advertisement)
    }))
  }
}), shallow)

export default useAdvertisementStore