'use client'

import { Button } from "flowbite-react";
import Link from "next/link";
import React from "react";

type Props = {
    id: string
}

export default function InventoryItemEditButton({id} : Props){
    return (
        <div>
            <Button outline>
                <Link href={`/inventory/update/${id}`}>Update Item</Link>
            </Button>
        </div>
    )
}