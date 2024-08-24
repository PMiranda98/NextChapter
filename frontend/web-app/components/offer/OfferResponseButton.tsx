'use client'

import { deleteOffer, updateOffer } from "@/actions/offer";
import { Offer } from "@/types";
import { UpdateOfferDto } from "@/types/DTOs/offer/UpdateOfferDto";
import { Button } from "flowbite-react";
import { useRouter } from "next/navigation";
import React, { useState } from "react";
import toast from "react-hot-toast";

type Props = {
    offer: Offer
    action: string
}

export default function OfferResponseButton({offer, action} : Props){
    const [loading, setLoading] = useState(false)
    const router = useRouter()

    const doAccept = () => {
        setLoading(true)
        offer.status = action == 'Accept' ? 'Accepted' : 'Rejected'
        console.log(offer)
        const updateOfferDto = mapToUpdateOfferDto(offer) 
        updateOffer(updateOfferDto, offer.id).then((response) => {
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
            <Button outline className="border" color={action == 'Accept' ? 'success' : 'failure'} isProcessing={loading} onClick={doAccept}>
                {action}
            </Button>
        </div>
    )
}

const mapToUpdateOfferDto = (offer: Offer) => {
    const updateOfferDto : UpdateOfferDto = {
      recipient: offer.recipient,
      sender: offer.sender,
      status: offer.status,
      type: offer.type,
      amount: offer.amount,
      comment: offer.comment,
      itemsToExchange: offer.itemsToExchange
    }
    return updateOfferDto 
}