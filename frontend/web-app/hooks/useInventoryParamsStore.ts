// This store is where we will store the state of the parameters that are needed to the search query string endpoint.
import { shallow } from "zustand/shallow"
import { createWithEqualityFn } from "zustand/traditional"

type State = {
  pageNumber: number // current page selected
  pageSize: number // page size selected
  pageCount: number // number of pages that exists that depends on the total number of results and the pageSize selected. 
  orderBy: string
  owner: string
}

type Actions = {
  // The type Partial here gives use the ability of make the State properties optional
  setStateParams: (state: Partial<State>) => void
  reset: () => void
}

const initialState: State = {
  pageNumber: 1,
  pageSize: 3,
  pageCount: 1,
  orderBy: '',
  owner: ''
}

const getFromSessionStorage = <T>(key: string, defaultValue: T): T => {
  const storedValue = sessionStorage.getItem(key);
  if (storedValue) {
    try {
      return JSON.parse(storedValue) as T;
    } catch (e) {
      console.error(`Failed to parse sessionStorage item "${key}":`, e);
    }
  }
  return defaultValue;
};

const useInventoryParamsStore = createWithEqualityFn<State & Actions>((set) => ({
  pageNumber: getFromSessionStorage<number>('pageNumber', initialState.pageNumber),
  pageSize: getFromSessionStorage<number>('pageSize', initialState.pageSize),
  pageCount: getFromSessionStorage<number>('pageCount', initialState.pageCount),
  orderBy: getFromSessionStorage<string>('orderBy', initialState.orderBy),
  owner: getFromSessionStorage<string>('owner', initialState.owner),
  setStateParams: (newState: Partial<State>) => {
      set((currentState) => {
          if (newState.pageNumber){
            const state : State = {...currentState, pageNumber: newState.pageNumber };
            Object.entries(state).forEach(([key, value])=> {
              sessionStorage.setItem(key, JSON.stringify(value))
            })
            return state
          }
          else{
            // The pageNumber:1 is needed because for example if we set the pageSize to 10000 and we have less then 10000 results that means that all result will be in the page 1.
            // If the pageNumber currently selected is some page different than 1 we will end up with a empty list of results returned.
            const state : State = {...currentState, ...newState, pageNumber: 1}
            Object.entries(state).forEach(([key, value])=> {
              sessionStorage.setItem(key, JSON.stringify(value))
            })
            return state
          }
      });
  },
  reset: () => {
    const state : State = initialState
    set(state)
  }
}), shallow);

export default useInventoryParamsStore