import useParamsStore from '@/hooks/useParamsStore';
import { Button } from 'flowbite-react';
import React from 'react'
import { AiOutlineClockCircle, AiOutlineSortAscending } from 'react-icons/ai';
import { BsFillStopCircleFill, BsStopwatchFill } from 'react-icons/bs';
import { GiFinishLine, GiFlame } from 'react-icons/gi';

const pageSizeButtons = [3, 6, 9, 12]
const orderButtons = [
  {
    label: 'Alphabetical',
    icon: AiOutlineSortAscending,
    value: 'make'
  },
  {
    label: 'End date',
    icon: AiOutlineClockCircle,
    value: 'endingSoon'
  },
  {
    label: 'Recently added',
    icon: BsFillStopCircleFill,
    value: 'new'
  }
]
const filterButtons = [
  {
    label: 'Live Auctions',
    icon: GiFlame,
    value: 'live'
  },
  {
    label: 'Ending < 6 hours',
    icon: GiFinishLine,
    value: 'endingSoon'
  },
  {
    label: 'Completed',
    icon: BsStopwatchFill,
    value: 'finished'
  }
]

export default function Filters() {
  const params = useParamsStore(state => ({
    pageSize: state.pageSize,
    orderBy: state.orderBy,
    filterBy: state.filterBy
  }))
  const setParams = useParamsStore(state => state.setParams)

  return (
    <div className='flex justify-between items-center mb-4'>
      <div>
        <span className='text-sm text-gray-500 mr-2'>Filter by</span>
        <Button.Group>
          {filterButtons.map(({label, icon: Icon, value}, index) => (
            <Button key={index} onClick={() => setParams({filterBy: value})} color={`${params.filterBy === value ? 'red':'gray'}`}>
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
