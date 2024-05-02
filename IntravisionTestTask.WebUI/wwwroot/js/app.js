import { getProductMachines, getProductMachineById } from './requests/productMachine.js';
import { getProductSlotById} from './requests/productSlot.js';

export async function loadPageContent() {
    await loadProductMachinesToSelect();
    let options = document.getElementById('product-machine-list');

    if (options.length > 0) {
        const machineId = options[0].id;
        await loadProductSlots(machineId);
    }
};

export async function loadProductMachinesToSelect () {
    let productMachines = await getProductMachines();

    for (let i = 0; i < productMachines.length; i += 1) {
        let option = document.createElement('option');
        option.innerText = `Product machine ${i + 1}`;
        option.id = productMachines[i].id;
        let productMachineSelect = document.getElementById('product-machine-list');
        productMachineSelect.appendChild(option);
    }
};

export async function loadProductSlots (id) {
    let productSlots = await getProductSlotsByMachineId(id);

    let contentSectionDiv = document.getElementById('content-section');
    productSlots.forEach(element => {
        let productSlotDiv = document.createElement('div');
        productSlotDiv.class = 'product-slot';
        productSlotDiv.id = element.id;

        let productSlotImage = document.createElement('img');
        productSlotImage.className = 'product-slot-image';
        productSlotImage.src = element.imageUrl;
        productSlotImage.alt = 'None'

        let productSlotPriceEl = document.createElement('p');
        productSlotPriceEl.innerText = `cost: ${element.price}`;

        let productSlotPurchaseBtn = document.createElement('button');
        productSlotPurchaseBtn.innerText = 'Buy';

        let productSlotTitleEl = document.createElement('p');

        let productCountEl = document.createElement('p');
        productCountEl.innerText = `count: ${element.products.length}`;

        if (element.products.length > 0) {
            productSlotTitleEl.innerText = element.products[0].title;
        }else{
            productSlotTitleEl.innerText = 'Empty';
        }

        productSlotDiv.appendChild(productSlotTitleEl);
        productSlotDiv.appendChild(productSlotImage);
        productSlotDiv.appendChild(productSlotPriceEl);
        productSlotDiv.appendChild(productCountEl);
        productSlotDiv.appendChild(productSlotPurchaseBtn);
        contentSectionDiv.appendChild(productSlotDiv);
    });
};

async function getProductSlotsByMachineId(id) {
    const productMachine = await getProductMachineById(id);
    let productSlots = new Array(productMachine.productSlots.length);

    for(let i = 0; i < productSlots.length; i += 1){
        let productSlot = await getProductSlotById(productMachine.productSlots[i].id);
        productSlots[i] = productSlot;
    };

    return productSlots;
}