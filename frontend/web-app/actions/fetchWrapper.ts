'use server'

import { getTokenWorkaround } from "@/actions/auth"
import { APIErrorResponse, APIExceptionResponse, ErrorType, isAPIErrorResponseType, isAPIExceptionResponseType } from "@/lib/helpers/ErrorHandlingHelper"

const baseUrl = 'http://localhost:6001/'

export async function get<T>(url: string) : Promise<T | ErrorType>{
  const requestOptions = {
    method: 'GET',
    headers: await getHeaders('application/json')
  }
  
  const response = await fetch(baseUrl + url, requestOptions)

  console.log(response)

  return await handleResponse<T>(response)
}

export async function post<T>(url: string, data: FormData | {}) : Promise<T | ErrorType>{
  const isFormData = data instanceof FormData

  const requestOptions = {
    method: 'POST',
    headers: isFormData ? await getHeaders() : await getHeaders('application/json'),
    body: isFormData ? data : JSON.stringify(data)
  }

  console.log(url)
  console.log(requestOptions)

  const response = await fetch(baseUrl + url, requestOptions)

  console.log(response)
  
  return await handleResponse<T>(response)
}

export async function put(url: string, data: FormData | {}) : Promise<void | ErrorType>{
  const isFormData = data instanceof FormData

  const requestOptions = {
    method: 'PUT',
    headers: isFormData ? await getHeaders() : await getHeaders('application/json'),
    body: isFormData ? data: JSON.stringify(data)
  }
  
  console.log(url)
  console.log(requestOptions)

  const response = await fetch(baseUrl + url, requestOptions)

  console.log(response)

  return await checkResponse(response)
}

export async function del(url: string) : Promise<void | ErrorType>{
  const requestOptions = {
    method: 'DELETE',
    headers: await getHeaders('application/json')
  }

  console.log(url)
  console.log(requestOptions)

  const response = await fetch(baseUrl + url, requestOptions)

  console.log(response)

  return await checkResponse(response)
}


async function getHeaders(contentType?: string){
  const token = await getTokenWorkaround()
  const headers = {} as any
  if(contentType) headers['Content-Type'] = contentType
  if(token) headers['Authorization'] = 'Bearer ' + token.access_token
  return headers
}

async function checkResponse(response: Response) : Promise<void | ErrorType> {
  const text = await response.text()
  let data
  try {
    data = JSON.parse(text)  
  } catch (error) {
    throw Error("Something went wrong!")
  }

  if(!response.ok){
    if (isAPIErrorResponseType(data)) {
      const error : ErrorType = {
       error: {
         status: response.status,
         message: data.errorMessage 
       }
      }
      return error
   } else if (isAPIExceptionResponseType(data)){
       const error : ErrorType = {
         error: {
           status: data.statusCode,
           message: data.message,
           details: data.details
         } 
       }
       return error
   } else {
     console.log(`=====> Response - Error - JSON parse error`)
     throw Error("Something went wrong!")
   }
  } 
}

async function handleResponse<T>(response: Response) : Promise<T | ErrorType> {
  const text = await response.text()
  let data
  
  //const a = { errorMessage: 'Failure test!' }
  //const b = typeof a === 'object' && typeof a.errorMessage === 'string' 
  //console.log(`=====>>>>> Test: ${b}`)
  
  try {
    data = JSON.parse(text) as T | APIErrorResponse | APIExceptionResponse  
  } catch (error) {
    throw new Error("Something went wrong!")
  }
  
  if(response.ok && !isAPIErrorResponseType(data) && !isAPIExceptionResponseType(data)){
    console.log(`=====> Response - Ok`)
    return data 
  } else if (isAPIErrorResponseType(data)) {
    console.log(`=====> Response - Error - APIErrorResponseType`)
    console.log(data)
    const error : ErrorType = {
      error: {
        status: response.status,
        message: data.errorMessage 
      }
     }
     return error
  } else if (isAPIExceptionResponseType(data)){
      console.log(`=====> Response - Error - APIExceptionResponseType`)
      console.log(data)
      const error : ErrorType = {
        error: {
          status: data.statusCode,
          message: data.message,
          details: data.details
        } 
      }
      return error
  } else {
    console.log(`=====> Response - Error - Unknown`)
    console.log(data)
    throw new Error("Something went wrong!")
  }
}