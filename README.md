# TesteProjetoLojaAPI

Loja Online - README
Este � um projeto de loja online desenvolvido com React e integra��o com uma API em C#. O projeto inclui funcionalidades para listar produtos, realizar pedidos e exibir a lista de pedidos.

Configura��o do Ambiente
Certifique-se de ter o Node.js instalado em seu ambiente de desenvolvimento. Voc� tamb�m precisar� de um ambiente de backend para interagir com a API de pedidos.

Instala��o das Depend�ncias
Para instalar as depend�ncias do projeto, execute o seguinte comando na pasta raiz do projeto:

bash
Copy code
npm install
Este comando instalar� todas as depend�ncias necess�rias listadas no arquivo package.json.

Configura��o da API
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
Isso iniciar� a aplica��o em modo de desenvolvimento. Abra http://localhost:3000 no seu navegador para visualizar o projeto.

Componentes Principais
ListaProdutos
O componente ListaProdutos exibe uma lista de produtos dispon�veis para compra. Voc� pode visualizar os produtos e adicionar itens ao carrinho clicando no bot�o "Comprar".

ListaPedidos
O componente ListaPedidos exibe a lista de todos os pedidos realizados, incluindo detalhes como ID do pedido, produto, pre�o, quantidade, data da compra e ID do usu�rio.

Loja
O componente Loja �onde o usuario pode efetuar a compra dos produtos.

Funcionalidades Adicionais
Autentica��o e Autoriza��o: Implementado autentica��o e autoriza��o para proteger certas rotas, especialmente aquelas relacionadas ao painel administrativo.
Cadastro de Usu�rios e Produtos: Implementado para cadastrar novos usu�rios e produtos na loja.
Painel Administrativo: Implementado o painel administrativo com funcionalidades adicionais para gerenciar produtos e usu�rios.
