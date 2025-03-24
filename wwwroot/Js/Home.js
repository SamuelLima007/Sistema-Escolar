var window = document.querySelector(".modal-window");
var botao = document.querySelector(".btn");
var body = document.querySelector("body");
var dashboard = document.querySelector(".dashboard");

function abrirmodal() {
  window.style.display = "flex";

  body.classList.add("background-transparente");
}

function fecharmodal() {
  window.style.display = "none";
  body.classList.remove("background-transparente");
  dashboard.style.display = "flex";
}

botao.addEventListener("click", fecharmodal);

document.addEventListener("DOMContentLoaded", abrirmodal);

const time = document.querySelector(".Hora");

function AtualizarHora() {
  const timerio = new Date();
  const timerioformatado = timerio.toLocaleDateString("pt-BR");
  time.textContent = `${timerioformatado}`;
}

setInterval(AtualizarHora, 1000);
AtualizarHora();
