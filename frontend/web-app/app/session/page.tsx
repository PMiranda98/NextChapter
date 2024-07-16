
import { getSession } from '@/actions/auth'
import Heading from '@/components/core/Heading'
import React from 'react'

export default async function Session() {
  const session = await getSession()
  
  return (
    <>
      <Heading title='Session dashboard'></Heading>
      <div className='bg-blue-200 border-2 border-blue-500'>
        <h3 className='text-lg'>Session data</h3>
        <pre>{JSON.stringify(session, null, 2)}</pre>
      </div>
    </>
  )
}
