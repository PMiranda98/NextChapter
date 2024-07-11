export type PagedResults<Auction> = {
  auctions: Auction[]
  pageCount: number
  totalCount: number
}

export type Auction = {
  id: string
  reservePrice: number
  seller: string
  winner?: string
  soldAmount: number
  currentHighBid: number
  createdAt: string
  updateAt: string
  auctionEnd: string
  status: string
  item: Item
}

export type Item = {
  make: string
  model: string
  year: number
  color: string
  mileage: number
  imageUrl: string
}