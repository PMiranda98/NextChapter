import useAdvertisementParamsStore from '@/hooks/useAdvertisementParamsStore';
import { Button } from 'flowbite-react';
import React from 'react'
import { AiOutlineSortAscending } from 'react-icons/ai';
import { BsFillStopCircleFill, BsStopwatchFill } from 'react-icons/bs';
import { GiFlame } from 'react-icons/gi';

const pageSizeButtons = [3, 6, 9, 12]
const orderButtons = [
  {
    label: 'Alphabetical',
    icon: AiOutlineSortAscending,
    value: 'name'
  },
  {
    label: 'Recently added',
    icon: BsFillStopCircleFill,
    value: 'new'
  }
]
const anonymounsUserFilterButtons = [
  {
    label: 'Live',
    icon: GiFlame,
    value: 'live'
  }
]

const userFilterButtons = [
  {
    label: 'Live',
    icon: GiFlame,
    value: 'live'
  },
  {
    label: 'Sold',
    icon: BsStopwatchFill,
    value: 'sold'
  },
  {
    label: 'Archived',
    icon: BsStopwatchFill,
    value: 'archived'
  }
]

type Props = {
  username: string | undefined
}

export default function AdvertisementFilters({username} : Props) {
  const params = useAdvertisementParamsStore(state => ({
    pageSize: state.pageSize,
    orderBy: state.orderBy,
    status: state.status,
    seller: state.seller
  }))
  const setParams = useAdvertisementParamsStore(state => state.setParams)

  return (
    <div className='flex justify-between items-center mb-4'>
      <div>
        <span className='text-sm text-gray-500 mr-2'>Filter by</span>
        <Button.Group>
          {(username === undefined || username !== params.seller) && anonymounsUserFilterButtons.map(({label, icon: Icon, value}, index) => (
            <Button key={index} onClick={() => setParams({status: value})} color={`${params.status === value ? 'red':'gray'}`}>
              <div className='flex items-center'>
                <Icon className='mr-3 h-4 w-4'/>
                {label}
              </div>
            </Button>
          ))}
          {username && username === params.seller && userFilterButtons.map(({label, icon: Icon, value}, index) => (
            <Button key={index} onClick={() => setParams({status: value})} color={`${params.status === value ? 'red':'gray'}`}>
              <div className='flex items-center'>
                <Icon className='mr-3 h-4 w-4'/>
                {label}
              </div>
            </Button>
          ))}
        </Button.Group>
      </div>
      <div>
        <span className='text-sm text-gray-500 mr-2'>Order by</span>
        <Button.Group>
          {orderButtons.map(({label, icon: Icon, value}, index) => (
            <Button key={index} onClick={() => setParams({orderBy: value})} color={`${params.orderBy === value ? 'red':'gray'}`}>
              <div className='flex items-center'>
                <Icon className='mr-3 h-4 w-4'/>
                {label}
              </div>
            </Button>
          ))}
        </Button.Group>
      </div>
      <div>
        <span className='text-sm text-gray-500 mr-2'>Page Size</span>
        <Button.Group>
          {pageSizeButtons.map((value, index) => (
            <Button key={index} onClick={() => setParams({pageSize : value})} color={`${params.pageSize === value ? 'red':'gray'}`}>
              {value}
            </Button>
          ))}
        </Button.Group>
      </div>
    </div>
  );
}
