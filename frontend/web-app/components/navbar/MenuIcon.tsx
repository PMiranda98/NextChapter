'use client'

import { User } from 'next-auth'
import React, { useState } from 'react'
import { CiMenuBurger } from 'react-icons/ci'
import UserActionsDrawer from './UserActionsDrawer'
import { Label } from 'flowbite-react'

type Props = {
  user: Partial<User>
}

export default function MenuIcon({user} : Props) {

  const [displayDrawer, setDisplayDrawer] = useState(false)

  function handleOnMouseEnter() {
    setDisplayDrawer(true)
  }

  function onCloseDrawerClick(){
    setDisplayDrawer(false)
  }

  return (
    <>
      {displayDrawer && (<UserActionsDrawer user={user} onCloseDrawerClick={onCloseDrawerClick}/>)}
      <div className='flex'>
        <Label>{`Welcome ${user.name}`}</Label>
        <CiMenuBurger className='ml-3' onMouseEnter={() => handleOnMouseEnter()} />
      </div>
    </>
  )
}
