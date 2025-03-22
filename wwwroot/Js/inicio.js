var janela = document.querySelector(".janela-modal"); // Seleciona o modal corretamente
var botao = document.querySelector(".btn"); // Seleciona o botão de fechar
var body = document.querySelector("body"); // Seleciona o body

// Função para abrir o modal e aplicar o efeito de transparência
function abrirmodal() {
  janela.style.display = "flex"; // Mostra o modal
  body.classList.add("background-transparente"); // Adiciona o efeito de transparência
}

// Função para fechar o modal e remover o efeito de transparência
function fecharmodal() {
  janela.style.display = "none"; // Esconde o modal
  body.classList.remove("background-transparente"); // Remove o efeito de transparência
}

// Adiciona o evento de clique ao botão de fechar

botao.addEventListener("click", fecharmodal);

// Abre o modal automaticamente ao carregar a página
document.addEventListener("DOMContentLoaded", abrirmodal);
