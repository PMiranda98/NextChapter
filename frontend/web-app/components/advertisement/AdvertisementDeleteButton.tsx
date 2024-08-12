'use client'

import { deleteAdvertisement } from "@/actions/advertisement";
import { Button } from "flowbite-react";
import Link from "next/link";
import { useRouter } from "next/navigation";
import React, { useState } from "react";
import toast from "react-hot-toast";

type Props = {
    id: string
}

export default function AdvertisementEditButton({id} : Props){
    const [loading, setLoading] = useState(false)
    const router = useRouter()

    const doDelete = () => {
        setLoading(true)
        deleteAdvertisement(id).then((response) => {
            if(response.error) throw response.error
            router.push('/')
        }).catch(error => {
            toast.error(error.status + ' ' + error.message)
        }).finally(() => {
            setLoading(false)
        })
    }

    return (
        <div>
            <Button outline color='failure' className="border" isProcessing={loading} onClick={doDelete}>
                Delete Advertisement
            </Button>
        </div>
    )
}