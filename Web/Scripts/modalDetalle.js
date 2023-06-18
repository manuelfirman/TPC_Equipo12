// Obtener la imagen seleccionada y mostrarla en el modal
var modalImagen = document.getElementById('modalImagen');
var imgModal = document.getElementById('imgModal');

modalImagen.addEventListener('show.bs.modal', function (event) {
    var trigger = event.relatedTarget; // Elemento que activó el modal
    var imgUrl = trigger.getAttribute('data-bs-img'); // Obtener la URL de la imagen

    // Mostrar la imagen en el modal
    imgModal.src = imgUrl;
});