import {API_URL} from '../data.js';

const URL = `${API_URL}/productTypes`;

export async function getProductTypes() {
    return await fetch (URL, {
        method: 'GET'
    }).then((response) => {
        return response.json();
    }).catch(error => console.log(error));
};
export async function getProductTypeById(id) {
    return await fetch (`${URL}/${id}`, {
        method: 'GET'
    }).then((response) => {
        return response.json();
    }).catch(error => console.log(error));
};
export async function addProductType(title) {
    const newProductType = {
        title: title
    }

    return await fetch (URL, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json;charset=utf-8'
        },
        body: JSON.stringify(newProductType)
    }).then((response) => {
        return response.json();
    }).catch(error => console.log(error));
};
export async function deleteProductType(id) {
    return await fetch (`${URL}/${id}`, {
        method: 'DELETE'
    }).then((response) => {
        return response.json();
    }).catch(error => console.log(error));
};
export async function updateProductType({id, title}) {
    const productTypeToUpdate = {
        id: id,
        title: title
    }

    return await fetch (URL, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json;charset=utf-8'
        },
        body: JSON.stringify(productTypeToUpdate)
    }).then((response) => {
        return response.json();
    }).catch(error => console.log(error));
};