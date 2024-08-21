// This store is where we will store the state of the parameters that are needed to the search query string endpoint.
import { shallow } from "zustand/shallow"
import { createWithEqualityFn } from "zustand/traditional"

type State = {
  pageNumber: number // current page selected
  pageSize: number // page size selected
  pageCount: number // number of pages that exists that depends on the total number of results and the pageSize selected. 
  searchTerm: string
  searchValue: string
  orderBy: string
  status: string
  seller?: string
  buyer?: string
}

type Actions = {
  // The type Partial here gives use the ability of make the State properties optional
  setParams: (params: Partial<State>) => void
  reset: () => void
}

const initialState: State = {
  pageNumber: 1,
  pageSize: 3,
  pageCount: 1,
  searchTerm: '',
  searchValue:'',
  orderBy: '',
  status: 'live',
  seller: undefined,
  buyer: undefined
}

const useAdvertisementParamsStore = createWithEqualityFn<State & Actions>((set) => ({
  ...initialState,
  setParams: (newParams: Partial<State>) => {
      set((currentState) => {
          if (newParams.pageNumber)
              return { ...currentState, pageNumber: newParams.pageNumber };
          else
              // The pageNumber:1 is needed because for example if we set the pageSize to 10000 and we have less then 10000 results that means that all result will be in the page 1.
              // If the pageNumber currently selected is some page different than 1 we will end up with a empty list of results returned.
              return { ...currentState, ...newParams, pageNumber: 1 };
      });
  },
  reset: () => set(initialState),
}), shallow);

export default useAdvertisementParamsStore