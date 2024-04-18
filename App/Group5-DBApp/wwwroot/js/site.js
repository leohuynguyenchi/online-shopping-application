// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.addEventListener('DOMContentLoaded', function() {
    const searchInput = document.getElementById('searchInput');
    const productContainer = document.getElementById('featured-products');

    searchInput.addEventListener('input', function(event) {
        const searchQuery = event.target.value.trim().toLowerCase();

        // Select all product cards within the product container
        const productCards = productContainer.querySelectorAll('.product-card');

        productCards.forEach(function(productCard) {
            const productName = productCard.querySelector('h3').textContent.trim().toLowerCase();
            const isVisible = productName.includes(searchQuery);
            productCard.style.display = isVisible ? 'block' : 'none';
        });
    });
});