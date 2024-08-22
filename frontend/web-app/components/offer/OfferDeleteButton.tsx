'use client'

import { deleteOffer } from "@/actions/offer";
import { Button } from "flowbite-react";
import { useRouter } from "next/navigation";
import React, { useState } from "react";
import toast from "react-hot-toast";

type Props = {
    id: string
}

export default function OfferDeleteButton({id} : Props){
    const [loading, setLoading] = useState(false)
    const router = useRouter()

    const doDelete = () => {
        setLoading(true)
        deleteOffer(id).then((response) => {
            if(response.error) throw response.error
            router.push('/offer/list')
        }).catch(error => {
            toast.error(error.status + ' ' + error.message)
        }).finally(() => {
            setLoading(false)
        })
    }

    return (
        <div>
            <Button outline className="border" color='failure' isProcessing={loading} onClick={doDelete}>
                Delete Offer
            </Button>
        </div>
    )
}