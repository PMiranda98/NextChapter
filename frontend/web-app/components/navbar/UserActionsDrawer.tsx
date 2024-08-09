'use client'

import useAdvertisementParamsStore from '@/hooks/useAdvertisementParamsStore'
import useInventoryParamsStore from '@/hooks/useInventoryParamsStore'
import { Drawer, Sidebar } from 'flowbite-react'
import { User } from 'next-auth'
import { signOut } from 'next-auth/react'
import Link from 'next/link'
import { usePathname, useRouter } from 'next/navigation'
import React, { useState } from 'react'
import { AiOutlineLogout } from 'react-icons/ai'
import { BiBook, BiBookOpen } from 'react-icons/bi'
import { GiBookshelf } from 'react-icons/gi'
import { HiCog, HiUser } from 'react-icons/hi2'

type Props = {
  user: Partial<User>
  onCloseDrawerClick: () => void
}

export default function UserActionsDrawer({user, onCloseDrawerClick} : Props) {
  const [isOpen, setIsOpen] = useState(true);
  const handleClose = () => {
    setIsOpen(false)
    onCloseDrawerClick()
  };
  
  const setAdvertisementParams = useAdvertisementParamsStore(state => state.setParams)
  const setInventoryParams = useInventoryParamsStore(state => state.setParams)
  const router = useRouter()
  const pathname = usePathname()

  const setSeller = () => {
    setAdvertisementParams({
      seller: user.username,
      winner: undefined
    })

    handleClose()

    if(pathname !== '/') router.push('/')
  }
  const setWinner = () => {
    setAdvertisementParams({
      seller: undefined,
      winner: user.username
    })

    handleClose()

    if(pathname !== '/') router.push('/')
  }

  const goToInventory = () => {
    setInventoryParams({
      owner: user.username
    })

    handleClose()
    if(pathname !== '/inventory/list') router.push('/inventory/list')
  }

  return (
    <>
      <Drawer open={isOpen} onClose={handleClose} position='right' >
        <Drawer.Header title={user.name ? user.name : user.username } titleIcon={() => <></>} />
        <Drawer.Items>
          <Sidebar
            aria-label="Sidebar with multi-level dropdown example"
            className="[&>div]:bg-transparent [&>div]:p-0"
          >
            <div className="flex h-full flex-col justify-between py-2">
              <div>
                <Sidebar.Items className='cursor-pointer'>
                  <Sidebar.ItemGroup>
                    <div onClick={setSeller}>
                      <Sidebar.Item icon={HiUser}>
                        My Advertisements
                      </Sidebar.Item>
                    </div>
                    <div onClick={goToInventory}>
                      <Sidebar.Item icon={GiBookshelf}>
                        Inventory
                      </Sidebar.Item>
                    </div>
                    <div onClick={setWinner}>
                      <Sidebar.Item icon={BiBookOpen}>
                        Books bought
                      </Sidebar.Item>
                    </div>
                    <div onClick={handleClose}>
                      <Sidebar.Item icon={BiBook}>
                        <Link href='/advertisement/create'>Sell my book</Link>
                      </Sidebar.Item>
                    </div>
                    <div onClick={handleClose}>
                      <Sidebar.Item icon={HiCog}>
                        <Link href='/session'>Session (dev only)</Link>
                      </Sidebar.Item>
                    </div>
                  </Sidebar.ItemGroup>
                  <Sidebar.ItemGroup>
                    <div onClick={() => {
                        signOut({callbackUrl: '/'})
                        handleClose()
                      }}>
                      <Sidebar.Item icon={AiOutlineLogout}>
                        Sign out
                      </Sidebar.Item>
                    </div>
                  </Sidebar.ItemGroup>
                </Sidebar.Items>
              </div>
            </div>
          </Sidebar>
        </Drawer.Items>
      </Drawer>
    </>
  )
}
