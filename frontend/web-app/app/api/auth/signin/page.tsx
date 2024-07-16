import LoginRequired from '@/components/core/LoginRequired'
import React from 'react'

export default function Page({searchParams}: {searchParams: {callbackUrl: string}}) {
  return (
    <LoginRequired 
      title='You need to be logged in to do that'
      subtitle='Please click below to sign in'
      showLogin
      callbackUrl={searchParams.callbackUrl}
    />
  )
}
