document.addEventListener("DOMContentLoaded", function () {
    const modal = document.getElementById('modal');
    const emailInput = document.getElementById('email');
    const emailError = document.getElementById('emailError');
    const createButton = document.getElementById('createButton');
    const cancelButton = document.getElementById('cancelButton');
    const closeModal = document.getElementById('closeModal');
    const searchButton = document.getElementById('searchButton');
    const searchInput = document.getElementById('searchInput');
    const tableRows = document.querySelectorAll('#colaboradoresTable tbody tr');

    searchButton.addEventListener('click', function () {
        const searchText = searchInput.value.toLowerCase();

        tableRows.forEach(row => {
            const cells = row.getElementsByTagName('td');
            const found = Array.from(cells).some(cell => {
                const content = cell.textContent.toLowerCase();
                const match = content.includes(searchText);
                return match;
            });
            row.style.display = found ? 'table-row' : 'none';
        });
    });

    function performSearch(query) {
        // Suponha que você tenha uma lista de itens no HTML
        const items = document.querySelectorAll('.item'); // Todos os itens têm a classe 'item'
        items.forEach(item => {
            // Suponha que o texto que queremos filtrar esteja no item
            if (item.textContent.toLowerCase().includes(query.toLowerCase())) {
                item.style.display = ''; // Mostra o item
            } else {
                item.style.display = 'none'; // Esconde o item
            }
        });
    }


    function showModal(title, data = {}) {
        document.getElementById('modalTitle').innerText = title;
        modal.style.display = 'block';
        document.getElementById('colaboradorId').value = data.id || '';
        document.getElementById('nome').value = data.nome || '';
        document.getElementById('email').value = data.email || '';
    }

    function closeModalFunction() {
        modal.style.display = 'none';
    }

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


    cancelButton.addEventListener('click', function () {
        modal.style.display = 'none';
    });

    emailInput.addEventListener('input', function () {
        const email = emailInput.value;
        const regex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        emailError.style.display = regex.test(email) ? 'none' : 'block';
    });

    closeModal.addEventListener('click', closeModalFunction);
});
