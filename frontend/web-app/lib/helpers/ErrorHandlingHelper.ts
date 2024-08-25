export type APIErrorResponse = {
  errorMessage: string
}

export type APIExceptionResponse = {
  statusCode: number,
  message: string,
  details?: string
}

export type ErrorType = {
    error: {
      status: number
      message: string
      details?: string 
    }
}

export function isErrorType(obj: any): obj is ErrorType {
    return typeof obj === 'object' &&
    obj !==  null && 
    typeof obj.error === 'object' &&
    obj.error !== null
}

export function isAPIErrorResponseType(obj: any): obj is APIErrorResponse {
  return typeof obj === 'object' &&
  obj !==  null &&
  typeof obj.errorMessage === 'string'
}

export function isAPIExceptionResponseType(obj: any): obj is APIExceptionResponse {
  return typeof obj === 'object' &&
  obj !==  null &&
  typeof obj.statusCode === 'number' &&
  typeof obj.message === 'string' &&
  (typeof obj.details === undefined || typeof obj.details === 'string')
}