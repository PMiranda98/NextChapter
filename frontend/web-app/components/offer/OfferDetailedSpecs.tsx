'use client';

import { Offer } from "@/types";
import {Table} from "flowbite-react";

type Props = {
    offer: Offer
}

export default function OfferDetailedSpecs({offer}: Props) {
    return (
        <Table striped={true}>
            <Table.Body className="divide-y">
                <Table.Row className="bg-white dark:border-gray-700 dark:bg-gray-800">
                    <Table.Cell className="whitespace-nowrap font-medium text-gray-900 dark:text-white">
                        Recipient
                    </Table.Cell>
                    <Table.Cell>
                        {offer.recipient}
                    </Table.Cell>
                </Table.Row>
                <Table.Row className="bg-white dark:border-gray-700 dark:bg-gray-800">
                    <Table.Cell className="whitespace-nowrap font-medium text-gray-900 dark:text-white">
                        Sender
                    </Table.Cell>
                    <Table.Cell>
                        {offer.sender}
                    </Table.Cell>
                </Table.Row>
                <Table.Row className="bg-white dark:border-gray-700 dark:bg-gray-800">
                    <Table.Cell className="whitespace-nowrap font-medium text-gray-900 dark:text-white">
                        Created At
                    </Table.Cell>
                    <Table.Cell>
                        {offer.createdAt}
                    </Table.Cell>
                </Table.Row>
                {offer.endedAt && 
                    <Table.Row className="bg-white dark:border-gray-700 dark:bg-gray-800">
                        <Table.Cell className="whitespace-nowrap font-medium text-gray-900 dark:text-white">
                            EndedAt
                        </Table.Cell>
                        <Table.Cell>
                            {offer.endedAt}
                        </Table.Cell>
                    </Table.Row>
                }
                <Table.Row className="bg-white dark:border-gray-700 dark:bg-gray-800">
                    <Table.Cell className="whitespace-nowrap font-medium text-gray-900 dark:text-white">
                        Status
                    </Table.Cell>
                    <Table.Cell>
                        {offer.status}
                    </Table.Cell>
                </Table.Row>
                <Table.Row className="bg-white dark:border-gray-700 dark:bg-gray-800">
                    <Table.Cell className="whitespace-nowrap font-medium text-gray-900 dark:text-white">
                        Type
                    </Table.Cell>
                    <Table.Cell>
                        {offer.type}
                    </Table.Cell>
                </Table.Row>
                <Table.Row className="bg-white dark:border-gray-700 dark:bg-gray-800">
                    <Table.Cell className="whitespace-nowrap font-medium text-gray-900 dark:text-white">
                        Amount
                    </Table.Cell>
                    <Table.Cell>
                        {offer.amount}
                    </Table.Cell>
                </Table.Row>
                {offer.comment && 
                    <Table.Row className="bg-white dark:border-gray-700 dark:bg-gray-800">
                        <Table.Cell className="whitespace-nowrap font-medium text-gray-900 dark:text-white">
                            Comment
                        </Table.Cell>
                        <Table.Cell>
                            {offer.comment}
                        </Table.Cell>
                    </Table.Row>
                }
            </Table.Body>
        </Table>
    );
}