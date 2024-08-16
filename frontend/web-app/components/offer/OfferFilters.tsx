import useOfferParamsStore from '@/hooks/useOfferParamsStore';
import { Button } from 'flowbite-react';
import React from 'react'
import { AiOutlineSortAscending } from 'react-icons/ai';
import { BsFillStopCircleFill} from 'react-icons/bs';
import { MdDownload, MdUpload } from 'react-icons/md';

const orderButtons = [
  {
    label: 'Recently',
    icon: BsFillStopCircleFill,
    value: 'new'
  }
]

const offerDirectionButtons = [
    {
      label: 'Sent',
      icon: MdUpload,
      value: 'sent'
    },
    {
        label: 'Received',
        icon: MdDownload,
        value: 'received'
      },
  ]
  
const pageSizeButtons = [3, 6, 9, 12]

export default function OfferFilters() {
  const stateParams = useOfferParamsStore(state => {
    return {
      orderBy: state.orderBy,
      pageSize: state.pageSize,
      direction: state.direction
    }
  })
  const setParams = useOfferParamsStore(state => state.setStateParams)

  return (
    <div className='flex justify-between items-center mb-4'>
      <div>
        <span className='text-sm text-gray-500 mr-2'>Order by</span>
        <Button.Group>
          {orderButtons.map(({label, icon: Icon, value}, index) => (
            <Button key={index} onClick={() => setParams({orderBy: value})} color={`${stateParams.orderBy === value ? 'red':'gray'}`}>
              <div className='flex items-center'>
                <Icon className='mr-3 h-4 w-4'/>
                {label}
              </div>
            </Button>
          ))}
        </Button.Group>
      </div>

      <div>
        <span className='text-sm text-gray-500 mr-2'>Direction</span>
        <Button.Group>
          {offerDirectionButtons.map(({label, icon: Icon, value}, index) => (
            <Button key={index} onClick={() => setParams({direction: value})} color={`${stateParams.direction === value ? 'red':'gray'}`}>
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
            <Button key={index} onClick={() => setParams({pageSize: value})} color={`${stateParams.pageSize === value ? 'red':'gray'}`}>
              {value}
            </Button>
          ))}
        </Button.Group>
      </div>
    </div>
  );
}
