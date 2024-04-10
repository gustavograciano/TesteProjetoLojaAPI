# TesteProjetoLojaAPI

Loja Online - README
Este é um projeto de loja online desenvolvido com React e integração com uma API em C#. O projeto inclui funcionalidades para listar produtos, realizar pedidos e exibir a lista de pedidos.

Configuração do Ambiente
Certifique-se de ter o Node.js instalado em seu ambiente de desenvolvimento. Você também precisará de um ambiente de backend para interagir com a API de pedidos.

Instalação das Dependências
Para instalar as dependências do projeto, execute o seguinte comando na pasta raiz do projeto:

bash
Copy code
npm install
Este comando instalará todas as dependências necessárias listadas no arquivo package.json.

Configuração da API
Certifique-se de configurar corretamente a URL da API no arquivo services/api.js para apontar para o seu ambiente de backend:

javascript
Copy code
import axios from 'axios';

const api = axios.create({
  baseURL: 'http://localhost:3001/api', // URL da sua API
});

export default api;
Executando o Projeto
Para iniciar o projeto, execute o seguinte comando na pasta raiz do projeto:

bash
Copy code
npm start
Isso iniciará a aplicação em modo de desenvolvimento. Abra http://localhost:3000 no seu navegador para visualizar o projeto.

Componentes Principais
ListaProdutos
O componente ListaProdutos exibe uma lista de produtos disponíveis para compra. Você pode visualizar os produtos e adicionar itens ao carrinho clicando no botão "Comprar".

ListaPedidos
O componente ListaPedidos exibe a lista de todos os pedidos realizados, incluindo detalhes como ID do pedido, produto, preço, quantidade, data da compra e ID do usuário.

Loja
O componente Loja éonde o usuario pode efetuar a compra dos produtos.

Funcionalidades Adicionais
Autenticação e Autorização: Implementado autenticação e autorização para proteger certas rotas, especialmente aquelas relacionadas ao painel administrativo.
Cadastro de Usuários e Produtos: Implementado para cadastrar novos usuários e produtos na loja.
Painel Administrativo: Implementado o painel administrativo com funcionalidades adicionais para gerenciar produtos e usuários.
