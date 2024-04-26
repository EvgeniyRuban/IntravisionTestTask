const url = 'https://localhost:5001/api/products';

const requestProducts = async () => {
    return await fetch(url
        ).then((response) => {
            return response.json();
        }).catch(reason => console.log(reason));
}
const products = await requestProducts();

products.forEach((p) => {
    let div = document.createElement('div');
    let title = document.createElement('p');
    let price = document.createElement('p');
    title.innerText = p.title;
    price.innerText = p.price;
    div.appendChild(title);
    div.appendChild(price);
    document.body.append(div);
    document.body.append(document.createElement('hr'));
});
