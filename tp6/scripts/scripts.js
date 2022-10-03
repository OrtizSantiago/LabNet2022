let nombre = document.getElementById("nombre");
let apellido = document.getElementById("apellido");
let edades = document.getElementById("edades");

const pattern = new RegExp('^[A-Z]+$', 'i');


const abrir = document.getElementById("abrir");
const modal = document.getElementById("modal");
const cerrar = document.getElementById("cerrar");

const modal2 = document.getElementById("modal2");
const cerrar2 = document.getElementById("cerrar2");


abrir.addEventListener("click", () =>{
    if((nombre.value != "") && (apellido.value != "") && (edades.value < 100) && (pattern.test(nombre.value)) && (pattern.test(apellido.value))){
        modal2.style.visibility = "visible";
        cerrar2.onclick = function(){
            modal2.style.visibility = "hidden";
        }
        modal2.onclick = function(){
            modal2.style.visibility = "hidden";
        }
        
    }
    else{
        modal.style.visibility = "visible";
        cerrar.onclick = function(){
            modal.style.visibility = "hidden";
        }
        
        modal.onclick = function(){
            modal.style.visibility = "hidden";
        }
    }
   
})


let form = document.getElementById("form");
const limpiar = document.getElementById("limpiar");
function limparCampos(){
    form.reset();
}
limpiar.addEventListener("click", limparCampos);























