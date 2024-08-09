import { getTokenWorkaround } from "@/actions/auth"

const baseUrl = 'http://localhost:6001/'

async function get(url: string) {
  const requestOptions = {
    method: 'GET',
    headers: await getHeaders('application/json')
  }

  const response = await fetch(baseUrl + url, requestOptions)
  return await handleResponse(response)
}

async function post(url: string, formData: FormData){
  const requestOptions = {
    method: 'POST',
    headers: await getHeaders(),
    body: formData
  }
  const response = await fetch(baseUrl + url, requestOptions)
  return await handleResponse(response)
}

/*
async function post(url: string, body: {}){
  const requestOptions = {
    method: 'POST',
    headers: await getHeaders(),
    body: JSON.stringify(body)
  }

  const response = await fetch(baseUrl + url, requestOptions)
  return await handleResponse(response)
}
*/

async function put(url: string, formData: FormData){
  const requestOptions = {
    method: 'PUT',
    headers: await getHeaders(),
    body: formData
  }
  const response = await fetch(baseUrl + url, requestOptions)
  console.log(response)
  return await handleResponse(response)
}

async function del(url: string){
  const requestOptions = {
    method: 'DELETE',
    headers: await getHeaders('application/json')
  }

  const response = await fetch(baseUrl + url, requestOptions)
  console.log(response)
  return await handleResponse(response)
}


async function getHeaders(contentType?: string){
  const token = await getTokenWorkaround()
  const headers = {} as any
  if(contentType) headers['Content-Type'] = contentType
  if(token) headers['Authorization'] = 'Bearer ' + token.access_token
  return headers
}

async function handleResponse(response: Response) {
  const text = await response.text()
  const data = text && JSON.parse(text)
  if(response.ok){
    return data || response.statusText
  } else {
     const error = {
      status: response.status,
      message: response.statusText
     }

     return {error}
  }
}

export const fetchWrapper = {
  get,
  post,
  put,
  del
}

