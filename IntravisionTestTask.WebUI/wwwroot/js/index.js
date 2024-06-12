import { ADMIN_HREF } from './data.js';
import { loadPageContent } from './app.js';


function log(data) {
    data.forEach((element => {
        console.log(element);
    }));
}

const navigateToAdminPage = (pageHref) => location.href = pageHref;

document.getElementById('admin-page-button')
    .addEventListener('click', () => navigateToAdminPage(ADMIN_HREF));


loadPageContent();



document.getElementById('admin-page-button')
    .removeEventListener('click', navigateToAdminPage);


/*products.forEach((p) => {
    let div = document.createElement('div');
    let title = document.createElement('p');
    let price = document.createElement('p');
    title.innerText = p.title;
    price.innerText = p.price;
    div.appendChild(title);
    div.appendChild(price);
    document.body.append(div);
    document.body.append(document.createElement('hr'));
});*/

