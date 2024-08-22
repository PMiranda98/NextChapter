'use client'

import { Button } from "flowbite-react";
import Link from "next/link";
import React from "react";

type Props = {
    id: string
}

export default function OfferEditButton({id} : Props){
    return (
        <div>
            <Button outline>
                <Link href={`/offer/update/${id}`}>Update Offer</Link>
            </Button>
        </div>
    )
}