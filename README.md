# Desafio Backend Siagri

Quer fazer parte da transformação do campo ~~escrevendo~~ codando o futuro do agronegócio?

Se deseja participar do nosso processo seletivo, siga as instruções deste desafio e execute os seguintes passos: 

* Nos mande sua resolução em um *pull request* neste repositório.

* Deixe a aplicação disponível publicamente em imagem docker em qualquer host. Na descrição do PR passe o link para que consigamos usar sua imagem.

* Por último, **caso ainda não esteja cadastrado no processo seletivo**, envie um email para [murilo.silva@siagri.com.br](mailto:murilo.silva@siagri.com.br) com seu CV anexado e o link da aplicação (se já estiver no processo seletivo, não precisa);

  

# Sobre a Siagri

O [Grupo Siagri](https://www.siagri.com.br/) está entre as maiores empresas de software para agronegócio do país. Nascemos no agro e somos especialistas em levar tecnologia para gestão de empresas e propriedades rurais.

Estamos com nossos clientes, pra fazer o campo acontecer. Temos orgulho de ajudar a construir o presente e o futuro do agronegócio.



# O desafio

Crie um microsserviço capaz de aceitar solicitações RESTful que recebam como parâmetro o nome da cidade ou as coordenadas (*latitude e longitude*) e retorne uma sugestão de playlist (*apenas nomes da músicas*) de acordo com a temperatura atual.



## Requisitos

1. Se a temperatura (*celsius*) estiver acima de 30 graus, as músicas sugeridas serão para festas
2. Caso a temperatura esteja entre 15 e 30 graus, sugira faixas de música pop
3. Se estiver um pouco frio (entre 10 e 14 graus), sugira faixas de rock
4. Caso contrário, se estiver frio lá fora, proponha músicas clássicas

## Requisitos não funcionais

- Como este serviço será um sucesso mundial, ele deve estar preparado para ser tolerante a falhas, responsivo e resiliente.

- Utilize a linguagem C# .Net. Use qualquer ferramenta e estrutura com as quais se sinta confortável e elabore brevemente sua solução, detalhes de arquitetura, escolha de padrões e estruturas.

- Além disso, facilite a implantação/execução de seus serviços localmente (*considere usar alguma solução de container/VM para isso*). 

## Dicas

Você pode usar a API do *[OpenWeatherMaps](https://openweathermap.org)* para buscar dados de temperatura e o *[Spotify](https://developer.spotify.com/)* para sugerir as músicas da playlist.


## Recomendações

* Utilize C#;
* Utilize .NET Core 3.1;
* Utilize docker;
* Utilize boas práticas de codificação, isso será avaliado;
* Mostre que você manja dos paranauê do C#;
* Código limpo, organizado e documentado (quando necessário);
* Use e abuse de:
  * SOLID;
  * Criatividade;
  * Performance;
  * Manutenabilidade;
  * Testes Unitários (quando necessário)
  * ... pois avaliaremos tudo isso!
