import axios from 'axios';

function login(data){
    const url= 'http://localhost:49694/users/login'

    const config={
        method:'POST',
        data:data,
    }
    return axios(url, config)
        .then(responseSuccess)
        .catch(responseError)
}

function create(data) {
    const url= 'http://localhost:49694/users'
    
    const config={
        method:'POST',
        data:data,
        //withCredentials: true

    }
    return axios(url, config)
        .then(responseSuccess)
        .catch(responseError)
}
function validationRequest(data) {
    const url= 'http://localhost:49694/users/sendValidation'
    
    const config={
        method:'POST',
        data:data,
        //withCredentials: true

    }
    return axios(url, config)
        .then(responseSuccess)
        .catch(responseError)
}

function verifyAccount(key) {
    const url= 'http://localhost:49694/users/validate/'+key
    
    const config={
        method:'GET',

    }
    return axios(url, config)
        .then(responseSuccess)
        .catch(responseError)
}
function getAll() {
    const url= 'http://localhost:49694/users'
    
    const config={
        method:'GET',
        //withCredentials: true

    }
    return axios(url, config)
        .then(responseSuccess)
        .catch(responseError)
}

function checkExpireDate(key) {
    const url= 'http://localhost:49694/expire-check/'+key
    debugger
    const config={
        method:'GET',
        //withCredentials: true

    }
    return axios(url, config)
        .then(responseSuccess)
        .catch(responseError)
}

function getById(id) {
    const url = 'http://localhost:49694/users/' + id

    return axios.get(url)
        .then(responseSuccess)
        .catch(responseError)
}

function getUserProfile(id) {
    const url = 'http://localhost:49694/users/profile/' + id

    return axios.get(url)
        .then(responseSuccess)
        .catch(responseError)
}

function update(id, data) {
    
    const url= 'http://localhost:49694/users/'+id
    const config={
        method:'PUT',
        data:data
    }
    return axios(url, config)
        .then(responseSuccess)
        .catch(responseError)
}

function passwordResetRequest(data){
    const url= 'http://localhost:49694/users/passwordResetRequest'
    
    const config={
        method:'PUT',
        data:data
    }
    return axios(url, config)
        .then(responseSuccess)
        .catch(responseError) 
}

function passwordReset(data){
    const url= 'http://localhost:49694/users/passwordReset'
    debugger
    const config={
        method:'PUT',
        data:data
    }
    return axios(url, config)
        .then(responseSuccess)
        .catch(responseError) 
}

function updatePassword(data){
    const url= 'http://localhost:49694/users/updatePassword'
    debugger
    const config={
        method:'PUT',
        data:data
    }
    return axios(url, config)
        .then(responseSuccess)
        .catch(responseError) 
}

function deleteById(id) {
    const url= 'http://localhost:49694/users/'+id
    
    const config={
        method:'DELETE',
    }
    return axios(url, config)
        .then(responseSuccess)
        .catch(responseError)
}

const responseSuccess = response => {
    console.log(response);
    return response.data
}

const responseError = error => {
    
    if (error && error.response && error.response.data && error.response.data.errors) {
        console.log(error.response.data.errors)
    } else {
        console.log(error);
    }
    return Promise.reject(error);
}
export {verifyAccount,create, getAll,validationRequest, getById,update,deleteById,login,getUserProfile,passwordResetRequest,checkExpireDate,updatePassword,passwordReset}
  
