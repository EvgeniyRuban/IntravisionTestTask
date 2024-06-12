import {API_URL} from '../data.js';

const URL = `${API_URL}/products`

export async function getProducts() {
    return await fetch(URL, {
        method: 'GET',
    }).then((response) => {
        return response.json();
    }).catch(error => console.log(error));
};
export async function getProductById(id) {
    return await fetch(`${URL}/${id}`, {
        method: 'GET',
    }).then((response) => {
        return response.json();
    }).catch(error => console.log(error));
};
export async function addProduct({title, productTypeId, productSlotId}) {
    const newProduct = {
        productTypeId: productTypeId,
        productSlotId: productSlotId,
        title: title
    };

    return await fetch (URL, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json;charset=utf-8'
        },
        body: JSON.stringify(newProduct)
    }).then((response) => {
        return response.json();
    }).catch(error => console.log(error));
};
export async function deleteProduct(id) {
    return await fetch (`${URL}/${id}`, {
        method: 'DELETE'
    }).then((response) => {
        return response.json();
    }).catch(error => console.log(error));
};
export async function updateProduct({id, productTypeId}) {
    const productToUpdate = {
        id: id,
        productTypeId: productTypeId
    };

    return await fetch (URL, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json;charset=utf-8'
        },
        body: JSON.stringify(productToUpdate)
    }).then((response) => {
        return response.json();
    }).catch(error => console.log(error));
};