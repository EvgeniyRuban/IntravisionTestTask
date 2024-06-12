import { API_URL } from "../data.js";

const URL = `${API_URL}/productSlots`;

export async function getProductSlots () {
    return await fetch (URL, {
        method: 'GET'
    }).then((response) => {
        return response.json();
    }).catch(error => console.log(error));
};
export async function getProductSlotById (id) {
    return await fetch (`${URL}/${id}`, {
        method: 'GET'
    }).then((response => {
        return response.json();
    })).catch(error => console.log(error));
};
export async function addProductSlot ({productMachineId, imageUrl, capacity, price}) {
    const newProductSlot = {
        productMachineId: productMachineId,
        imageUrl: imageUrl,
        capacity: capacity,
        price: price
    }

    return await fetch (URL, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json;charset=utf-8'
        },
        body: JSON.stringify(newProductSlot)
    }).then((response) => {
        return response.json();
    }).catch(error => console.log(error));
};
export async function deleteProductSlot (id) {
    return await fetch (`${URL}/${id}`, {
        method: 'DELETE'
    }).then((response) => {
        return response.json();
    }).catch(error => console.log(error));
};
export async function updateProductSlot ({id, imageUrl, capacity, price}) {
    const productSlotToUpdate = {
        id: id,
        productMachineId: productMachineId,
        imageUrl: imageUrl,
        capacity: capacity,
        price: price
    };

    return await fetch (URL, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json;charset=utf-8'
        },
        body: JSON.stringify(productSlotToUpdate)
    }).then((response) => {
        return response.json();
    }).catch(error => console.log(error));
};
export async function fillProductSlotByProducts({ id, productTitle }) {
    return await fetch (`${URL}/${id}/fill/${productTitle}`, {
        method: 'PATCH'
    }).then((response) => {
        return response.json();
    }).catch(error => console.log(error));
};
export async function clearProductSlot (id) {
    return await fetch (`${URL}/${id}/clear`, {
        method: 'PATCH'
    }).then((response) => {
        return response.json();
    }).catch(error => console.log(error));
};
export async function addProductToProductSlot( {id, productId}) {
    return await fetch (`${URL}/${id}/add/${productId}`, {
        method: 'PATCH'
    }).then((response) => {
        return response.json();
    }).catch(error => console.log(error));
}