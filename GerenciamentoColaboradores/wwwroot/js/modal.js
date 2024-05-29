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
    }

        console.log('ok');
    createButton.addEventListener('click', function () {
        showModal('Criar Novo Colaborador');
    });

    document.querySelectorAll('tbody tr').forEach(row => {
        row.addEventListener('click', function () {
            const id = this.getAttribute('data-id');
            const nome = this.querySelector('td:nth-child(1)').innerText;
            const email = this.querySelector('td:nth-child(2)').innerText;
            const telefone = this.querySelector('td:nth-child(3)').innerText;
            const cargo = this.querySelector('td:nth-child(4)').innerText;

            showModal('Editar Colaborador', { id, nome, email, telefone, cargo });
        });
    });

    modalForm.addEventListener('submit', function (e) {
        e.preventDefault();
        // Lógica para salvar os dados do formulário.
    });

    cancelButton.addEventListener('click', function () {
        modal.style.display = 'none';
    });

    emailInput.addEventListener('input', function () {
        const email = emailInput.value;
        const regex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        emailError.style.display = regex.test(email) ? 'none' : 'block';
    });
});
