'use client'

import { Button } from "flowbite-react";
import Link from "next/link";
import React from "react";

type Props = {
    id: string
}

export default function AdvertisementEditButton({id} : Props){
    return (
        <div>
            <Button outline>
                <Link href={`/advertisement/update/${id}`}>Update Advertisement</Link>
            </Button>
        </div>
    )
}