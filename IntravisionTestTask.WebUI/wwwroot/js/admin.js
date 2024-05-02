import { INDEX_HREF } from "./data.js";
import { loadProductMachinesToSelect } from './app.js';


const navigateToAdminPage = (pageHref) => location.href = pageHref;

document.getElementById('public-page-button')
    .addEventListener('click', () => navigateToAdminPage(INDEX_HREF));


loadProductMachinesToSelect();


document.getElementById('public-page-button')
    .removeEventListener('click', navigateToAdminPage);