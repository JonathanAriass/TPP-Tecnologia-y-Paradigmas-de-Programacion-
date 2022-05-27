# Tema 1 -> Lenguajes y paradigmas de la programación
Un lenguaje de programacion es un lenguaje artificial utilizado para escribir instrucciones, algoritmos o funciones que pueden ser ejecutadas por un ordenador.

Hay varios metodos de traducir esto a un código que el ordenador pueda entender:
* Un traductor es un programa que procesa un texto fuente y genera un texto objeto.
* Un compilador es un traductor que transforma codigo fuente de un lenguaje de alto nivel al codigo fuente de otro lenguaje de bajo nivel.
* Un intérprete ejecuta las instrucciones de los programas escritos en un lenguaje de programación sin necesidad de compilarlos.

Los lenguajes de programación se clasifican o agrupan dependiendo de unas características,  como por ejemplo:
* Nivel de abstracción (alto / bajo): cuanto más próximo este al ordenador este lenguaje se dirá que es de más bajo nivel. Por ejemplo el lenguaje ensamblador es de bajo nivel, mientras que otros lenguajes como por ejemplo Java es de alto nivel.
* En función del dominio:
	* DSL que son lenguajes específicos de un dominio (R, SQL, ...)
	* Lenguajes de propósito general (Java, C#, Python, ...)
* Soporte de concurrencia: la concurrencia se verá reflejada en aquellos lenguajes que permiten la creación de programas mediante un conjunto de procesos o hilos que interaccionan entre sí y que pueden ser ejecutados de forma paralela, como por ejemplo, GO, Ada o Erlang.
* En función de su implementación: compilados o interpretados (no excluyente). Por ejemplo C# y Java son compilados e interpretados. Existe la compilación JIT (Just in Time) que transforma el código a interpretar en código nativo propio de la plataforma (.Net).
* Sistema de tipos: dinámicos o estáticos.
* En función de como se representa el código fuente: lenguajes visuales o "textuales" como podría ser Java, C#, Haskell.

## Paradigmas de programación
Un paradigma de programación es una aproximación para construir programas caracterizada por las abstracciones y conceptos utilizados para representar dichos programas (objetos, funciones, restricciones, predicados). 
El paradigma de programación se usa también para clasificar lenguajes de programación, pudiendo haber lenguajes que siga mas de un paradigma (multiparadigma).

Hay dos tipos claros de paradigmas, los imperativos y los declarativos:
* Un paradigma imperativo describe los programas en términos de sentencias que cambian el estado del programa (o de la máquina), como podría ser Java o C#.
* Un paradigma declarativo se basan en escribir programas que especifican qué se quiere obtener, intentando no especificar el cómo. Este tipo de abstracciones son las funciones, predicados, consultas, etc. Algún ejemplo de lenguajes declarativos son: Prolog, SQL, Haskell.


Los principales paradigmas son los siguientes:

<details>
<summary>Estructurado basado en procedimientos</summary>
 
Este paradigma es llamado simplemente imperativo. Define el procedimiento o subrutina como el primer mecanismo de descomposicion (lista ordenada de instrucciones), como puede ser Algol, Ada, Pascal, C.
</details>
<details>
<summary>Orientado a objetos</summary>
 
Utiliza los objetos, union de datos y metodos, ocmo principal abstraccion, definiendo programas como interacciones entre objetos. Se basa en la idea de modelar objetos reales mediante la codificacion de objetos software. Tipicamente es un paradigma imperativo y se basa en clases y prototipos. Hay lenguajes OO puros como Ruby o Eiffel.
</details>
<details>
<summary>Funcional</summary>
 
Paradigma declarativo basado en la utilizacion de funciones que manejan datos inmutables. Un programa se define mediante un conjunto de funciones invocándose entre sí. Las funciones no generan efectos colaterales. También cabe destacar que se hace uso de la recursividad, en lugar de la iteración.
Hay los llamados lenguajes funcionales puros que no utilizan ni la asignación ni la secuencia de instrucciones. Algunos de estos lenguajes son: Scheme, Lisp, Erlang.
</details>
<details>
<summary>Lógico</summary>
 
Paradigma declarativo basado en la programación de ordenadores mediante lógica matemática. El programador describe, por tanto, un conocimiento mediante reglas lógicas y axiomas (hechos). El lenguaje de programación lógica por excelencia es Prolog.
</details>