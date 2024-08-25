'use client'

import { ErrorType } from "@/lib/helpers/ErrorHandlingHelper"

type Props = {
    error: Error
    reset: () => void
}

export default function Error({ error, reset } : Props){
    let knownError
    try {
        knownError = JSON.parse(error.message) as ErrorType
    } catch (errorCatched) {
        // Its an unknown error, show a dialog of unknow error
        return (
            <>
                Error Page
                <p>{error.message}</p>
            </>
        )
    }
    // Its a known error, show a dialog of a known error
    return (
        <>
            Error Page
            <p>{knownError?.error.message}</p>
            <p>{knownError?.error.status}</p>
        </>
    )
}