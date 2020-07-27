import "regenerator-runtime/runtime";
import { BASE_URL_API } from '../config.js';

const getUrlApiLogin = `${BASE_URL_API}token`;

export function login(username, password) {
    const base64UuserAndPasword = window.btoa(`${username}:${password}`);

    var myHeaders = new Headers();
    myHeaders.append("Content-Type", "application/x-www-form-urlencoded");
    myHeaders.append("Authorization", `BASIC ${base64UuserAndPasword}`);
    //myHeaders.append("Access-Control-Allow-Origin", "http://localhost:1337");

    var urlencoded = new URLSearchParams();
    urlencoded.append("username", username);
    urlencoded.append("password", password);
    urlencoded.append("grant_type", "password");

    var requestOptions = {
        method: 'POST',
        headers: myHeaders,
        body: urlencoded,
        redirect: 'follow'
    };

    return fetch(getUrlApiLogin, requestOptions)
        .then(handleResponse)
        .then(result => {
            if (result) {
                localStorage.setItem('token', JSON.stringify(result));
            }
            console.log(result)
        })
        .catch(error => console.log('error', error));
}

function handleResponse(response) {
    return response.text().then(text => {
        const data = text && JSON.parse(text);
        if (!response.ok) {
            if (response.status === 401) {
                logout();
                location.reload(true);
            }

            const error = (data && data.error_description) || response.statusText;
            alert(data.error_description);
            return Promise.reject(error);
        }

        return data;
    });
}