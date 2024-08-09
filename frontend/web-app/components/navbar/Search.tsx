'use client'

import useAdvertisementParamsStore from '@/hooks/useAdvertisementParamsStore'
import { usePathname, useRouter } from 'next/navigation'
import { FaSearch } from 'react-icons/fa'

export default function Search() {
  const router = useRouter()
  const pathname = usePathname()
  const setParams = useAdvertisementParamsStore(state => state.setParams)
  const searchValue = useAdvertisementParamsStore(state => state.searchValue)

  const setSearchValue = (searchValue: string) => setParams({searchValue: searchValue})
  const onChange = (event: any) => {
    setSearchValue(event.target.value)
  }
  const search = () => {
    if(pathname !== '/') router.push('/')
    setParams({searchTerm: searchValue})
  }

  return (
    <div className='flex w-[50%] items-center border-2 rounded-full py-2 shadow-sm'> 
      <input 
        onKeyDown={(e:any) => {
          if(e.key === 'Enter')
            search()
        }}
        onChange={onChange}
        value={searchValue}
        type='text'
        placeholder='Search for books by name, author or literary genre'
        className='flex-grow pl-5 bg-transparent focus:outline-none border-transparent focus:border-transparent focus:ring-0 text-sm text-gray-600'
      />
      <button onClick={search}>
        <FaSearch size={34} 
          className='bg-red-400 text-white rounded-full p-2 cursor-pointer mx-2'/>
      </button>
    </div>
  )
}
