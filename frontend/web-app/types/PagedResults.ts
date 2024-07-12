export type PagedResults<T> = {
  results: T[]
  pageCount: number // number of pages
  totalCount: number // total number of items 
}