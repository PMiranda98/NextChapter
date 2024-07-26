'use client';

import {Advertisement} from "@/types";
import {Table} from "flowbite-react";

type Props = {
    advertisement: Advertisement
}
export default function AdvertisementDetailedSpecs({advertisement}: Props) {
    return (
        <Table striped={true}>
            <Table.Body className="divide-y">
                <Table.Row className="bg-white dark:border-gray-700 dark:bg-gray-800">
                    <Table.Cell className="whitespace-nowrap font-medium text-gray-900 dark:text-white">
                        Seller
                    </Table.Cell>
                    <Table.Cell>
                        {advertisement.seller}
                    </Table.Cell>
                </Table.Row>
                <Table.Row className="bg-white dark:border-gray-700 dark:bg-gray-800">
                    <Table.Cell className="whitespace-nowrap font-medium text-gray-900 dark:text-white">
                        Name
                    </Table.Cell>
                    <Table.Cell>
                        {advertisement.item.name}
                    </Table.Cell>
                </Table.Row>
                <Table.Row className="bg-white dark:border-gray-700 dark:bg-gray-800">
                    <Table.Cell className="whitespace-nowrap font-medium text-gray-900 dark:text-white">
                        Author
                    </Table.Cell>
                    <Table.Cell>
                        {advertisement.item.author}
                    </Table.Cell>
                </Table.Row>
                <Table.Row className="bg-white dark:border-gray-700 dark:bg-gray-800">
                    <Table.Cell className="whitespace-nowrap font-medium text-gray-900 dark:text-white">
                        Year
                    </Table.Cell>
                    <Table.Cell>
                        {advertisement.item.year}
                    </Table.Cell>
                </Table.Row>
                <Table.Row className="bg-white dark:border-gray-700 dark:bg-gray-800">
                    <Table.Cell className="whitespace-nowrap font-medium text-gray-900 dark:text-white">
                        Literary Genre
                    </Table.Cell>
                    <Table.Cell>
                        {advertisement.item.literaryGenre}
                    </Table.Cell>
                </Table.Row>
                <Table.Row className="bg-white dark:border-gray-700 dark:bg-gray-800">
                    <Table.Cell className="whitespace-nowrap font-medium text-gray-900 dark:text-white">
                        Offer Type Pretended
                    </Table.Cell>
                    <Table.Cell>
                        {advertisement.offerTypePretended}
                    </Table.Cell>
                </Table.Row>
                <Table.Row className="bg-white dark:border-gray-700 dark:bg-gray-800">
                    <Table.Cell className="whitespace-nowrap font-medium text-gray-900 dark:text-white">
                        Selling Price
                    </Table.Cell>
                    <Table.Cell>
                        {advertisement.sellingPrice}
                    </Table.Cell>
                </Table.Row>
                <Table.Row className="bg-white dark:border-gray-700 dark:bg-gray-800">
                    <Table.Cell className="whitespace-nowrap font-medium text-gray-900 dark:text-white">
                        Number Of Offers Received
                    </Table.Cell>
                    <Table.Cell>
                        {advertisement.numberOfOffers}
                    </Table.Cell>
                </Table.Row>
            </Table.Body>
        </Table>
    );
}