* Criado Projeto Book com Entity Framework .NEt Core 3.1
* Feito no Conceito DDD (Domain, Drive, Data)
* Feito os endpoints de Consulta do Livro por Name, Author and Calculate % de Taxa de Entrega

  * Consulta por name trazendo a taxa de 20% sobre o Preço: http://localhost:5000/api/books/calculate/Harry Potter and the Goblet of Fire
  * Consulta do Livro por nome http://localhost:5000/api/books/name/Harry Potter and the Goblet of Fire
  * Consulta por Author do livro fazendo ordenação por Preço: se for 0 será crescente, se for 1 será decrescente: http://localhost:5000/api/books/author/J. K. Rowling/0
  * Pode ser usado o Postman
  * Criei um BD MySql com os dados para Consulta. Neste caso terá que instalar o Mysql Workbench
  * Segue os inserts caso precise: 
  
    * insert into book
(`id`,  `Name`,`Price`, `Specifications_OriginallyPublished`, `Specifications_Author`, `Specifications_PageCount`, `Specifications_Illustrator`, `Specifications_Genres`) values 
('1', 'Journey to the Center of the Earth', '10.00', 'November 25, 1864', 'Jules Verne', '183', 'Édouard Riou', 'Science Fiction,
        Adventure fiction')
   * insert into book
(`id`,  `Name`,`Price`, `Specifications_OriginallyPublished`, `Specifications_Author`, `Specifications_PageCount`, `Specifications_Illustrator`, `Specifications_Genres`) values 
('2', '20,000 Leagues Under the Sea', '10.10', 'June 20, 1870', 'Jules Verne', '213', 'Édouard Riou', 'Adventure fiction)
   * insert into book
(`id`,  `Name`,`Price`, `Specifications_OriginallyPublished`, `Specifications_Author`, `Specifications_PageCount`, `Specifications_Illustrator`, `Specifications_Genres`) values 
('3', 'Harry Potter and the Goblet of Fire', '7.31', 'July 8, 2000', 'J. K. Rowling', '636', 'Cliff Wright', 'Fantasy Fiction')
   * insert into book
(`id`,  `Name`,`Price`, `Specifications_OriginallyPublished`, `Specifications_Author`, `Specifications_PageCount`, `Specifications_Illustrator`, `Specifications_Genres`) values 
('4', 'Fantastic Beasts and Where to Find Them: The Original Screenplay', '11.15', 'November 18, 2016', 'J. R. R. Tolkien', '457', 'Cliff Wright', 'Fantasy Fiction')
   * insert into book
(`id`,  `Name`,`Price`, `Specifications_OriginallyPublished`, `Specifications_Author`, `Specifications_PageCount`, `Specifications_Illustrator`, `Specifications_Genres`) values 
('5', 'The Lord of the Rings', '6.15', 'July 29, 1954', 'J. R. R. Tolkien', '715', 'Alan Lee', 'Fantasy Fiction')


* Incluido Swagger para ajudar na abertura da API junto a documentação
* Criado Testes Unitários com XUnit

Obs: Não usei JWT

