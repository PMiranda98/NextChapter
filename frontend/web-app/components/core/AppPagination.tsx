'use client'

import { Pagination } from "flowbite-react";
import React from 'react'

type Props = {
  currentPage: number
  pageCount: number
  pageChanged: (pageNumber: number) => void
}

export default function AppPagination({currentPage, pageCount, pageChanged} : Props) { 
  return (
    <Pagination 
      currentPage={currentPage} 
      totalPages={pageCount}
      onPageChange={ page => pageChanged(page)} 
      layout='pagination'
      showIcons={true}
      className='text-blue-500 mb-5'
      />
  )
}
