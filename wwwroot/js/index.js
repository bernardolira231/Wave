const darkMode = document.querySelector(".dark-mode");
const body = document.body;

// Función para activar o desactivar el modo oscuro
const toggleDarkMode = () => {
    body.classList.toggle("dark-mode-variables");
    darkMode.querySelector("span:nth-child(1)").classList.toggle("active");
    darkMode.querySelector("span:nth-child(2)").classList.toggle("active");

    // Almacena el estado actual del modo oscuro en localStorage
    const isDarkModeEnabled = body.classList.contains("dark-mode-variables");
    localStorage.setItem("darkMode", isDarkModeEnabled);
};

// Verifica el estado almacenado en localStorage y aplica el modo oscuro si es necesario
const applyStoredDarkMode = () => {
    const isDarkModeEnabled = localStorage.getItem("darkMode") === "true";

    if (isDarkModeEnabled) {
        toggleDarkMode();
    }
};

// Evento click para el botón darkMode
darkMode.addEventListener("click", toggleDarkMode);

// Aplicar el modo oscuro almacenado al cargar la página
applyStoredDarkMode();

//popup
document.addEventListener("DOMContentLoaded", function () {
    const addPostBtn = document.getElementById("add-post-btn");
    const addPostPopup = document.getElementById("add-post-popup");
    const closePopupBtn = document.getElementById("close-popup");
    const postForm = document.getElementById("post-form");
    const postImageInput = document.getElementById("post-image");
    const imagePreview = document.getElementById("image-preview");

    addPostBtn.addEventListener("click", function (e) {
        e.preventDefault(); // Prevenir el comportamiento predeterminado del enlace
        addPostPopup.style.display = "block";
    });

    closePopupBtn.addEventListener("click", () => {
        addPostPopup.style.display = "none";
        postForm.reset();
        imagePreview.innerHTML = "";
        imagePreview.style.backgroundImage = "none";
    });

    postImageInput.addEventListener("change", function () {
        const file = postImageInput.files[0];
        if (file) {
            const reader = new FileReader();
            reader.onload = function (e) {
                imagePreview.innerHTML = `<img src="${e.target.result}" alt="Preview">`;
            };
            reader.readAsDataURL(file);
        }
    });

    postForm.addEventListener("submit", function (e) {
        e.preventDefault();
        addPostPopup.style.display = "none";
        postForm.reset();
        imagePreview.innerHTML = "";
    });
});

const fileDropArea = document.getElementById("fileDropArea");
const fileInput = document.getElementById("post-image");
const fileMsg = document.querySelector(".file-msg");
const imagePreview = document.getElementById("image-preview");

fileDropArea.addEventListener("dragover", (e) => {
    e.preventDefault();
    fileDropArea.classList.add("drag-over");
});

fileDropArea.addEventListener("dragleave", () => {
    fileDropArea.classList.remove("drag-over");
});

fileDropArea.addEventListener("drop", (e) => {
    e.preventDefault();
    fileDropArea.classList.remove("drag-over");

    const droppedFiles = e.dataTransfer.files;
    if (droppedFiles.length > 0) {
        fileInput.files = droppedFiles;
        handleFile();
    }
});

fileInput.addEventListener("change", () => {
    handleFile();
});

function handleFile() {
    const file = fileInput.files[0];
    if (file) {
        const fileName = file.name;
        fileMsg.textContent = fileName;

        // Previsualización de la imagen
        const reader = new FileReader();
        reader.onload = (e) => {
            const imageUrl = e.target.result;
            imagePreview.innerHTML = `<img src="${imageUrl}" alt="Preview">`;
        };
        reader.readAsDataURL(file);
    } else {
        fileMsg.textContent = "Selecciona un archivo";
        imagePreview.innerHTML = ""; // Limpiar la previsualización de la imagen cuando no se selecciona ningún archivo
    }
}
