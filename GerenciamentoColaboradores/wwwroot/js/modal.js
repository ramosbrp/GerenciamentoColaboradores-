document.addEventListener("DOMContentLoaded", function () {
    const modal = document.getElementById('modal');
    const modalForm = document.getElementById('modalForm');
    const emailInput = document.getElementById('email');
    const emailError = document.getElementById('emailError');
    const createButton = document.getElementById('createButton');
    const searchButton = document.getElementById('searchButton');
    const cancelButton = document.getElementById('cancelButton');

    function showModal(title, data = {}) {
        document.getElementById('modalTitle').innerText = title;
        modal.style.display = 'block';
        document.getElementById('colaboradorId').value = data.id || '';
        document.getElementById('nome').value = data.nome || '';
        document.getElementById('email').value = data.email || '';
        document.getElementBy
    }
});