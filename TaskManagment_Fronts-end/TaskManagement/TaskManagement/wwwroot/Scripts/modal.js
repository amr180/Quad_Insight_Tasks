document.addEventListener("DOMContentLoaded", () => {

    const modalOverlay = document.getElementById("modalOverlay");
    const modalClose = document.getElementById("modalClose");

    if (!modalOverlay) return;

    // Open Modal

    window.openModal = function () {

        modalOverlay.classList.add("active");

        document.body.style.overflow = "hidden";
    };

    // Close Modal

    window.closeModal = function () {

        modalOverlay.classList.remove("active");

        document.body.style.overflow = "";
    };

    // Close By X
  
    if (modalClose) {

        modalClose.addEventListener("click", () => {

            closeModal();

        });

    }

    // Close By Clicking Outside
    modalOverlay.addEventListener("click", (event) => {

        if (event.target === modalOverlay) {

            closeModal();

        }

    });

    // Close By Escape
    document.addEventListener("keydown", (event) => {

        if (event.key === "Escape") {

            closeModal();

        }

    });

});
window.openUserModal = function (name, email) {

    document.getElementById("modalUserName").textContent = name;

    document.getElementById("modalUserEmail").textContent = email;

    openModal();
};