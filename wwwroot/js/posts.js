// document.addEventListener("DOMContentLoaded", function () {
//     const postItems = document.querySelectorAll(".post_popup-item");
//     const popupContainer = document.getElementById("post_popupContainer");
//     const popupImage = document.getElementById("post_popup-image");
//     const popupDescription = document.getElementById("post_popup-description");
//     const closePopupBtn = document.getElementById("post_popup-close");

//     postItems.forEach((postItem) => {
//         postItem.addEventListener("click", function () {
//             const imageSrc = this.querySelector(".post_popup-image").src;
//             const description = this.getAttribute("data-description");

//             // Actualizar el contenido del popup
//             popupImage.src = imageSrc;

//             //Quitar estos comentarios cuando la base de datos este conectada
//             // popupTitle.textContent = title;
//             popupDescription.textContent = description;

//             // Mostrar el popup
//             popupContainer.style.display = "block";
//         });
//     });

//     closePopupBtn.addEventListener("click", function () {
//         // Cerrar el popup al hacer clic en el botón de cierre
//         popupContainer.style.display = "none";
//     });

//     // Cerrar el popup al hacer clic fuera de él
//     document.addEventListener("click", function (e) {
//         if (
//             !popupContainer.contains(e.target) &&
//             !Array.from(postItems).some((item) => item.contains(e.target))
//         ) {
//             popupContainer.style.display = "none";
//         }
//     });
// });

const imgs = document.getElementsByClassName("img_post");
const icons = document.getElementsByClassName("heart");

for (let i = 0; i < imgs.length; i++) {
  imgs[i].addEventListener("dblclick", () => {
    icons[i].classList.add("like");

    setTimeout(() => {
      icons[i].classList.remove("like");
    }, 1000);
  });
}
