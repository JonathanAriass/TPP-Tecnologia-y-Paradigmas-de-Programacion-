# Paradigma orientado a objetos
Utilizan objetos, unión de datos y métodos, como principal abstracción, definiendo programas como interacciones entre objetos.

La abstracción es la forma de expresar las características esenciales de un objeto, las cuales distinguen al objeto de los demás.

El encapsulamiento es el proceso de almacenar en un mismo compartimento los elementos de una abstracción que constituyen su estructura y su comportamiento.
La ocultación de información permite discernir entre qué partes de la abstracción están disponibles al resto de la aplicación y qué partes son internas a la abstracción.

C# ofrece el concepto de propiedad para acceder al estado de los objetos como si de atributos se tratase, obteniendo los beneficios del encapsulamiento. Las propiedades pueden ser de lectura y/o escritura.

Acoplamiento es el nivel de interdependencia entre módulos.
Cohesión es el nivel de uniformidad y relación que existe entre las distintas responsabilidades de un módulo. En desarrollo nos interesa el bajo acoplamiento y elevada cohesión que favorecerán la reutilización y mantenibilida del software.

La sobrecarga de métodos permite dar distintas implementaciones a un mismo identificador de método. Para hacer sobrecarga en C# necesitamos tocar uno de los siguientes aspectos:
* El número de parámetros
* El tipo de alguno de sus parámetros
* El paso de alguno de sus parámetros (valor, ref o out)

La sobrecarga de operadores permite modificar la semántica de los operadores del lenguaje, como por ejemplo usar el símbolo "+" para añadir un elemento a una colección.



### Herencia y poliformismo
La herencia es un mecanismo de reutilización de código. El estado de una instancia derivada está definido por la unión (herencia) de las estructuras de las clases base y derivada. El conjunto de mensajes (interfaz) que puede aceptar un objeto derivado es la unión (herencia) de los mensajes de su clase base y derivada.


### Enlace dinámico
Los métodos heredados se pueden especializar en las clases derivadas. Si queremos que se llame al método real implementado por el objeto, debemos hacer uso del enlace dinámico: mecanismo por el cual, en tiempo de ejecución, se invoca al método del tipo dinámico implementado por el objeto.
Para que exista enlace dinámico en C# tenemos que poner la palabra reservada virtual al método que reciba el mensaje (referencia) y redefinir su funcionalidad utilizando la palabra reservada override en los métodos derivados.


### Operadores is y as
Al utilizar poliformismo tenemos una representacion mas general que el tipo del objeto. El problema de hacer un cast es que se podria lanzar una InvalidCastException que no este controlada. Por ello se introduce el operador is:
```csharp
if (lista[0] is Persona)
	((Persona)lista[0]).cumplirAños();
```

Si despues de utilizar el operador is vamos a realizar un cast, es mejor utilizar el operador as:
```csharp
Persona persona = lista[0] as Persona;
if (persona != null)
	persona.cumplirAños();
```


### Autoboxing
Ejemplo practico -> un int promociona a un Int32 y un Int32 se convierte automaticamente a un int.

### Structs
En C# un conjunto de campos públicos se puede representar como un Struct. Este conjunto puede tener constructores, propiedades, métodos, campos, operadores y miembros de clase (static).

### Interfaces
Una interfaz es un conjunto de métodos (y/o propiedades) públicos, que ofrecen un conjunto de clases. Su declaración es:
```csharp
[public|internal] interface
nombre[:interfaces-base] {
	declaracion-mensaje
}
```

Todos los mensajes de una interfaz son públicos, virtuales y abstractos. Y no puede tener miembros static.

### Excepciones
Una excepción es un objeto que encapsula información acerca de un evento irregular ocurrido en tiempo de ejecución.
Para lanzar una excepción haremos uso de la palabra reservada **throw**. Y para capturarla haremos uso del bloque de codigo try/catch/finally.

### Programación por contratos
Las precondiciones pueden ser de dos tipos:
* Los parámetros son inválidos (factorial de un número negativo)
* El estado del objeto ímplicito no es válido (sacar un elemento de una pila vacia)

Las postcondiciones son parecidas a las precondiciones pero despues de ejecutar un bloque de código.

Y por otro lado tenemos las invariantes que comprueban el estado de los objetos (una cola no puede estar llena y vacia a la vez).


### Genericidad
La genericidad es la propiedad que permite construir abstracciones modleo para otras abstracciones. Ofrece mayor robustez y rendimiento.

En C#, un tipo genérico puede ser cualquier tipo del lenguaje, incluyendo los tipos simples (default(T) devuelve null).

Los métodos genéricos se declaran de la siguiente forma:
```csharp
public static T ConvertirReferencia<T>(Object referencia) {
	if (!(referencia is T))  
		return default(T); // valor por omisión del tipo de T  
	return (T)referencia;
}
```

Las clases genéricas se declaran de la siguiente forma:
```csharp
class GenericidadClase<T> {  
	private T atributo;  
	public GenericidadClase(T atributo) {  
		this.atributo=atributo;  
	}  
	public T get() {  
		return atributo;  
	}  
	public void set(T atributo) {  
		this.atributo = atributo;  
	}  
}
```

La genericidad acotada permite hacer más específico estos tipos, por ejemplo, se puede hacer un método de ordenación donde se puedan ordenar objetos IComparable<T>.