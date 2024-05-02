import { API_URL } from "../data.js";

const URL = `${API_URL}/productMachines`;

export async function getProductMachines() {
    return await fetch (URL, {
        method: 'GET'
    }).then((response) => {
        return response.json();
    }).catch(error => console.log(error));
};
export async function getProductMachineById(id) {
    return await fetch (`${URL}/${id}`, {
        method: 'GET',
    }).then((response) => {
        return response.json();
    }).catch(error => console.log(error));
}
export async function addProductMachine (capacity) {
    const newProductMachine = {
        capacity: capacity
    };

    return await fetch (URL, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json;charset=utf-8'
        },
        body: JSON.stringify(newProductMachine)
    }).then((response) => {
        return response.json();
    }).catch(error => console.log(error));
};
export async function deleteProductMachine(id) {
    return await fetch (`${URL}/${id}`, {
        method: 'DELETE'
    }).then((response) => {
        return response.json();
    }).catch(error => console.log(error));
};
export async function updateProductMachine({id, capacity}) {
    const productMachineToUpdate = {
        id: id,
        capacity: capacity
    };

    return await fetch (URL, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json;charset=utf-8'
        },
        body: JSON.stringify(productMachineToUpdate)
    }).then((response) => {
        return response.json();
    }).catch(error => console.log(error));
};
export async function clearProductMachine(id) {
    return await fetch (`${URL}/${id}/clear`, {
        method: 'PATCH'
    }).then((response) => {
        return response.json();
    }).catch(error => console.log(error));
};
export async function addProductSlotToMachine({id, productSlotId}) {
    return await fetch (`${URL}/${id}/add/${productSlotId}`, {
        method: 'PATCH'
    }).then((response) => {
        return response.json();
    }).catch(error => console.log(error));
};