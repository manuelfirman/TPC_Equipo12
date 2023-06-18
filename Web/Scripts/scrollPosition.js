// Función para guardar la posición actual de la ventana en una cookie
function guardarPosicionVentana() {
    document.cookie = "posicionVentana=" + window.pageYOffset + "; path=/";
}

// Función para obtener la posición almacenada en la cookie y ajustar la posición de la ventana
function ajustarPosicionVentana() {
    var posicionCookie = document.cookie.match('(^|;) ?posicionVentana=([^;]*)(;|$)');
    if (posicionCookie && posicionCookie.length >= 3) {
        var posicion = parseInt(posicionCookie[2]);
        if (!isNaN(posicion)) {
            window.scrollTo(0, posicion);
        }
    }
}

// Ejecutar la función de ajuste de posición al cargar la página
window.onload = function () {
    ajustarPosicionVentana();
};