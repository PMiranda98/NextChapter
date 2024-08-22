'use client';

import { InventoryItem } from "@/types";
import {Table} from "flowbite-react";

type Props = {
    inventoryItem: InventoryItem
}
export default function InventoryItemDetailedSpecs({inventoryItem}: Props) {
    return (
        <Table striped={true}>
            <Table.Body className="divide-y">
                <Table.Row className="bg-white dark:border-gray-700 dark:bg-gray-800">
                    <Table.Cell className="whitespace-nowrap font-medium text-gray-900 dark:text-white">
                        Name
                    </Table.Cell>
                    <Table.Cell>
                        {inventoryItem.name}
                    </Table.Cell>
                </Table.Row>
                <Table.Row className="bg-white dark:border-gray-700 dark:bg-gray-800">
                    <Table.Cell className="whitespace-nowrap font-medium text-gray-900 dark:text-white">
                        Author
                    </Table.Cell>
                    <Table.Cell>
                        {inventoryItem.author}
                    </Table.Cell>
                </Table.Row>
                <Table.Row className="bg-white dark:border-gray-700 dark:bg-gray-800">
                    <Table.Cell className="whitespace-nowrap font-medium text-gray-900 dark:text-white">
                        Year
                    </Table.Cell>
                    <Table.Cell>
                        {inventoryItem.year}
                    </Table.Cell>
                </Table.Row>
                <Table.Row className="bg-white dark:border-gray-700 dark:bg-gray-800">
                    <Table.Cell className="whitespace-nowrap font-medium text-gray-900 dark:text-white">
                        Literary Genre
                    </Table.Cell>
                    <Table.Cell>
                        {inventoryItem.literaryGenre}
                    </Table.Cell>
                </Table.Row>
            </Table.Body>
        </Table>
    );
}