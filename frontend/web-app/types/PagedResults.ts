export type PagedResults<T> = {
  results: T[]
  pageCount: number
  totalCount: number
}