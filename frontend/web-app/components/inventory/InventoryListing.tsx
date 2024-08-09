'use client'

import React, { useEffect, useState } from 'react'
import InventoryCard from './InventoryCard'
import AppPagination from '../core/AppPagination'
import qs from 'query-string'
import { getInventoryData } from '@/actions/inventory'
import useInventoryStore from '@/hooks/useInventoryStore'
import useInventoryParamsStore from '@/hooks/useInventoryParamsStore'
import EmptyFilter from '../core/EmptyFilter'
import InventoryFilters from './InventoryFilters'

export default function InventoryListing() {
  const [loading, setLoading] = useState(true)

  // This is not advisable because if any of the state changes (we might have a lot more in the store than what we actually need here)
  // that would cause this component to rerender. 
  // const params = useParamsStore(state => state)

  // This is a more advisable way of getting all the states that we are interesting in this component in a single property.
  const params = useInventoryParamsStore(state => ({
    pageNumber: state.pageNumber,
    pageSize: state.pageSize,
    orderBy: state.orderBy,
    owner: state.owner
  }))

  const data = useInventoryStore(state => ({
    inventoryItems: state.inventoryItems,
    totalCount: state.totalCount,
    pageCount: state.pageCount
  }))

  const setData = useInventoryStore(state => state.setData)

  const setParams = useInventoryParamsStore(state => state.setParams)
  const queryString = qs.stringifyUrl({url: '', query: params})
  const setPageNumber = (pageNumber: number) => setParams({pageNumber})

  useEffect(() => {
      getInventoryData(queryString).then(data => {
        console.log(data) 
        setData(data)
        setLoading(false)
      })
  }, [queryString])

  if(loading) return <h3>Loading...</h3>

  return (
    <>
      <InventoryFilters />
      {data.totalCount === 0 ? (
        <EmptyFilter showReset/>
      ) : (
        <>
          <div className='grid grid-cols-4 gap-6'>
            {data.inventoryItems.map((item) => (
              <InventoryCard key={item.id} item={item}/>
            ))}
          </div>
          <div className='flex justify-center mt-4'>
            <AppPagination currentPage={params.pageNumber} pageCount={data.pageCount} pageChanged={setPageNumber}/>
          </div>
        </>
      )}
    </>
  )
}
