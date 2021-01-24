# Projeto 3

 **Francisco Pires a21804873:**
 - Planeamento, estrutura��o, organiza��o e gest�o do projeto.
 - C�digo comum.
 - Implementa��o do c�digo comum na Consola.
 - Implementa��o do c�digo comum no *Unity*.
 - *Polishing* e documenta��o do c�digo.
 - Corre��o de *bugs*.
 - Relat�rio
 
 **Nuno Figueiredo a21705451:**
 
 **Andr� Cosme a21802129:**
 
 **Reposit�rio do projeto**: https://github.com/FRP7/Projeto3LP2
 **Reposit�rio do c�digo comum**: https://github.com/FRP7/Projeto3LP2_Common
 
# Arquitetura da solu��o
**Descri��o breve da solu��o:**

Esta solu��o tem como objetivo replicar o jogo marroquino *Felli* para a 
Consola e para o *Unity* com o c�digo da l�gica do jogo igual para ambos, 
em *C#*.

**Desafios:**

O c�digo comum foi feito com o objetivo de ser completamente independente da
Consola e do *Unity*, por isso exigiu um n�vel de abstra��o significativo, 
pelo que foi bastante dif�cil de realizar. Na implementa��o da Consola e do 
*Unity*, tamb�m tent�mos organizar o c�digo de maneira a que fossem 
semelhantes e por ventura, de f�cil compreens�o.
Tamb�m evit�mos ao m�ximo o uso de vari�veis e propriedades *static* de forma a
manter o c�digo profissional e n�o tanto de *Unity Programmer*.

**Organiza��o:**

A solu��o foi feita tentando sempre que poss�vel respeitar os princ�pios
*SOLID* (especialmente o *Single-responsibility principle*), e para isso
utiliz�mos como *Design Pattern* o *Model-View-Controller* (MVC) para
organiza��o do projeto (com o uso de subm�dulos no *Git* para facilitar). 
Tent�mos sempre que poss�vel evitar o uso de vari�veis e propriedades
*static* por isso, utiliz�mos tamb�m o *Service Locator* *pattern* quando 
necessit�vamos. 
O primeiro *pattern*, foi utilizado para separarmos o que � comum em ambas as 
implementa��es e para evitarmos andar a copiar e a colar c�digo frequentemente
(por isso o uso de subm�dulos), o segundo *pattern* foi utilizado para replicar
o *GetComponent* do *Unity* e para evitarmos o uso de vari�veis e propriedades
*static*. 
Na Consola, utiliz�mos o *GameLoop pattern* e o *Update pattern* (com forte 
inspira��o na arquitetura do *Unity*) para assim mantermos o projeto organizado
e f�cil de entender.  O *Component pattern* n�o foi utilizado porque sentimos
que o jogo era demasiado simples para exigir isso, respeitando assim o 
princ�pio *KISS* (*Keep it Simple, Stupid*) e *YAGNI* (*You Ain't Gonna Need
It*).
No *Unity* n�o utiliz�mos nenhum *pattern* visto j� ter o *GameLoop pattern*
na sua arquitetura mas, tent�mos sempre que poss�vel respeitar os princ�pios
*SOLID* na mesma. 

**L�gica:**

No c�digo comum, � listado numa cole��o (neste caso, uma lista) todas as casas
do tabuleiro (sejam vazias ou ocupadas pelo jogador ou oponente). Essa lista
indica exatamente o que cont�m cada espa�o (vazio ou ocupado pelo jogador ou
pelo oponente) e a sua respetiva cor (branco, preto ou cinzento) atrav�s de 
*enums*. Em todos os turnos, essa mesma lista � atualizada para assim guardar
o estado l�gico atual do tabuleiro. Al�m desta lista, tamb�m tem uma lista de
jogadas legais poss�veis que � atualizado sempre que o jogador ou o oponente 
desejam jogar, e ap�s jogar, essa lista � esvaziada e a lista do estado do jogo
� atualizada.
No c�digo da Consola e do *Unity*, detetam o input do jogador, chamam os
respetivos m�todos do c�digo comum  e depois desenham o resultado no ecr�. 

**C�digo de terceiros:**

Durante o projeto, evit�mos sempre que poss�vel o uso de *static* por isso, nas
situa��es em que sentimos  necessidade para tal, utiliz�mos o c�digo do
*Service Locator pattern* disponibilizado pelo professor para assim evitar o 
uso do mesmo.
Na renderiza��o do jogo na consola, para melhorarmos a performance e reduzirmos
o *tearing*, utiliz�mos o c�digo do *DoubleBuffer* que foi feito num exerc�cio
em contexto de aulas.

**UML do c�digo comum**

![image](P3_Common_UML.JPG)

**UML da Consola**

![image](P3_Console_UML.JPG)

**UML do Unity**

![image](P3_Unity_UML)

## Refer�ncias

Para criar os par�metros que aceitam m�todos, baseei-me nesta solu��o no
*StackOverflow*:
https://stackoverflow.com/questions/1996426/pass-multiple-optional-parameters-to-a-c-sharp-function
```cs
public static int AddUp(params int[] values)
{
    int sum = 0;
    foreach (int value in values)
    {
        sum += value;
    }
    return sum;
}
```
Para criar o *DoubleBuffer*, utilizei este exerc�cio feito numa das aulas:
https://github.com/VideojogosLusofona/lp2_2020_aulas/tree/main/Aula11/Exercicio1

Utilizei tamb�m o *Service Locator* feito pelo professor demostrado numa das 
aulas.

Tamb�m consult�mos os slides das aulas e a documenta��o *C#* da *Microsoft* e
do *Unity*.