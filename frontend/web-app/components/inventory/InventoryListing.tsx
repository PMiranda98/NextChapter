'use client'

import React, { Dispatch, SetStateAction, useEffect, useState } from 'react'
import InventoryCard from './InventoryCard'
import AppPagination from '../core/AppPagination'
import qs from 'query-string'
import { getInventoryData } from '@/actions/inventory'
import useInventoryStore from '@/hooks/useInventoryStore'
import useInventoryParamsStore from '@/hooks/useInventoryParamsStore'
import EmptyFilter from '../core/EmptyFilter'
import InventoryFilters from './InventoryFilters'
import { Button, Spinner } from 'flowbite-react'
import { IoAddCircleOutline } from 'react-icons/io5'
import Link from 'next/link'
import { copyFileSync } from 'fs'
import InventoryCardSelectable from './InventoryCardSelectable'
import { InventoryItem } from '@/types'

type Props = {
  from?: string
  setBooksSelected?: Dispatch<SetStateAction<InventoryItem[]>>
}

export default function InventoryListing({from, setBooksSelected} : Props) {
  const [loading, setLoading] = useState(true)

  // This is not advisable because if any of the state changes (we might have a lot more in the store than what we actually need here)
  // that would cause this component to rerender. 
  // const params = useParamsStore(state => state)

  // This is a more advisable way of getting all the states that we are interesting in this component in a single property.
  const stateParams = useInventoryParamsStore(state => {
    return {
      pageNumber: state.pageNumber,
      pageSize: state.pageSize,
      pageCount: state.pageCount,
      orderBy: state.orderBy,
      owner: state.owner
    }
  })

  const data = useInventoryStore(state => ({
    inventoryItems: state.inventoryItems,
    totalCount: state.totalCount,
    pageCount: state.pageCount
  }))

  const setData = useInventoryStore(state => state.setData)

  const setParams = useInventoryParamsStore(state => state.setStateParams)
  const queryString = qs.stringifyUrl({url: '', query: stateParams})
  const setPageNumber = (pageNumber: number) => setParams({pageNumber: pageNumber})

  useEffect(() => {
      getInventoryData(queryString).then(data => {
        setData(data)
        setLoading(false)
      })
  }, [queryString])

  if(loading) return (
    <div className='flex h-screen justify-center items-center'>
      <Spinner />
    </div>
  )

  return (
    <>
      <InventoryFilters />
      <div className='flex justify-center mb-6'>
        <Link href='/inventory/create'>
          <Button outline color='green' className='border'>
            <IoAddCircleOutline className="mr-2 h-5 w-5" />
            Add an Item
          </Button>
        </Link>
      </div>
      {data.totalCount === 0 ? (
        <EmptyFilter showReset/>
      ) : (
        <>
          <div className='grid grid-cols-4 gap-6'>
            {data.inventoryItems.map((item) => 
            {
              if(from==='offer' && setBooksSelected !== undefined)
                return (<InventoryCardSelectable key={item.id} item={item} setBooksSelected={setBooksSelected}/>)
              else 
                return (<InventoryCard key={item.id} item={item}/>)
            })}
          </div>
          <div className='flex justify-center mt-4'>
            <AppPagination currentPage={stateParams.pageNumber} pageCount={data.pageCount} pageChanged={setPageNumber}/>
          </div>
        </>
      )}
    </>
  )
}
