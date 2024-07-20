'use client'

import { Button } from "flowbite-react";
import Link from "next/link";
import React from "react";

type Props = {
    id: string
}

export default function AuctionEditButton({id} : Props){
    return (
        <div>
            <Button outline>
                <Link href={`/auctions/update/${id}`}>Update Auction</Link>
            </Button>
        </div>
    )
}