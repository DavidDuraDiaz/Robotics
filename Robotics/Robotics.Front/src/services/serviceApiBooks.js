import "regenerator-runtime/runtime";
import { BASE_URL_API } from '../config.js';

var getUrlApiBooks = `${BASE_URL_API}/api/books`;

export function retrieve(filter, filterValue) {

    var Token = JSON.parse(localStorage.getItem('token'));

    var myHeaders = new Headers();
    myHeaders.append("Authorization", `Bearer ${Token.access_token}`);

    var url = getUrlApiBooks;
    var urlencoded = new URLSearchParams();
    if (filter && filterValue) url += `?${filter}=${filterValue}`

    const requestOptions = {
        method: 'GET',
        headers: myHeaders,
        params: urlencoded
    };

    return fetch(url, requestOptions)
        .then(handleResponse)
        .catch(error => console.log('error', error));

    function handleResponse(response) {
        return response.text().then(text => {
            const data = text && JSON.parse(text);
            if (!response.ok || response.status === 401) {
                const error = (data && data.Message) || response.statusText;
                alert(data.Message);
                return Promise.reject(error);
            }

            return data;
        });
    }
}