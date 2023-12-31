export function getWidth(id) {
    var width = document.getElementById(id).getBoundingClientRect().width;
    return width;
}
export function getHeight(id) {
    var height = document.getElementById(id).getBoundingClientRect().height;
    return height;
}
