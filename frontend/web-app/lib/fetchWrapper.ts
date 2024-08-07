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



async function post(url: string, body: {}, file: Blob){
  const formData = new FormData()
  formData.append('file', file)
  formData.append('createAdvertisementDto', JSON.stringify(body))
  const requestOptions = {
    method: 'POST',
    headers: await getHeaders('multipart/form-data'),
    body: formData
  }

  console.log(requestOptions)
  //const response = await fetch(baseUrl + url, requestOptions)
  const response = new Response()
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

async function put(url: string, body: {}){
  const requestOptions = {
    method: 'PUT',
    headers: await getHeaders('application/json'),
    body: JSON.stringify(body)
  }

  const response = await fetch(baseUrl + url, requestOptions)
  return await handleResponse(response)
}

async function del(url: string){
  const requestOptions = {
    method: 'DELETE',
    headers: await getHeaders('application/json')
  }

  const response = await fetch(baseUrl + url, requestOptions)
  return await handleResponse(response)
}


async function getHeaders(contentType: string){
  const token = await getTokenWorkaround()
  const headers = {
    'Content-Type' : contentType
  } as any
  if(token){
    headers.Authorization = 'Bearer ' + token.access_token
  }
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

