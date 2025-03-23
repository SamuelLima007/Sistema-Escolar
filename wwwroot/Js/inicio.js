// var janela = document.querySelector(".janela-modal");
// var botao = document.querySelector(".btn");
// var body = document.querySelector("body");

// function abrirmodal() {
//   janela.style.display = "flex";
//   body.classList.add("background-transparente");
// }

// function fecharmodal() {
//   janela.style.display = "none";
//   body.classList.remove("background-transparente");
// }

// botao.addEventListener("click", fecharmodal);

// document.addEventListener("DOMContentLoaded", abrirmodal);

const hora = document.querySelector(".Hora");

function AtualizarHora() {
  const horario = new Date();
  const horarioformatado = horario.toLocaleDateString("pt-BR");
  hora.textContent = `${horarioformatado}`;
}

setInterval(AtualizarHora, 1000);
AtualizarHora();
