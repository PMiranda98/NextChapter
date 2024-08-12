'use client'

import useInventoryStore from "@/hooks/useInventoryStore";
import { InventoryItem } from "@/types";
import { Button } from "flowbite-react";
import Link from "next/link";
import { FaBook } from "react-icons/fa";

type Props = {
    item: InventoryItem
}

export default function AdvertisementCreateButton({item} : Props) {
    const setInventoryItemSelected = useInventoryStore(state => state.setInventoryItemSelected)

    return (
        <Button outline color='green' className="border" onClick={() => {
            if(item) setInventoryItemSelected(item)
        }}>
            <FaBook className="mr-2 h-5 w-5"/>
            <Link href='/advertisement/create'>Sell my book</Link>
        </Button>
    )
}