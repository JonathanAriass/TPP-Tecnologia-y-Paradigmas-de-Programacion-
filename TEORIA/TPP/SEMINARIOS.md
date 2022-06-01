# SEMINARIO 1
**Dadas dos clases, Person y Angle, implementar un algoritmo de ordenación válido para ambos tipos de objetos?**

Una posible solución para este problema sería hacer uso de interfaces e implementar un metodo Sort que reciba una lista de Comparables.
Siendo las interfaces:
```csharp
interface Comparable {
	public int CompareTo(Object otro);
}


interface Comparator {
	public int Compare(Object uno, Object dos);
}
```

Las clases por tanto tienen que hacer override de estos métodos:
```csharp
public override Integer CompareTo(Object otro) {
	if (!otro.isAngle()) throw new InvalidFormatException();
	else {
		if (otro.Radians > this.Radians) return -1;
		else if (otro.Radians < this.Radians) return 1;
		else return 0;
	}
}

public override Integer Compare(Object uno, Object dos) {
	if (!uno.isAngle() and !dos.isAngle()) throw new InvalidFormatException();
	else {
		if (uno.Radians > dos.Radians) return 1;
		else if (uno.Radians < dos.Radians) return -1;
		else return 0;
	}
}
```

Habría que hacer lo mismo en la clase de Person pero con el nombre y con los apellidos.

Y a continuación podríamos hacer el metodo Sort que recibe una lista de Comparable con un algoritmo de Burbuja por ejemplo. La cabecera del metodo seria por tanto:
```csharp
Object[] Sort(Comparable[] lista) {
	for
		for
			if  // Se comprueba prioridades con compareTo
				// Se cambian los valores de la lista
	return
}
```


# SEMINARIO 2
## Ejercicio 1
**El framework .NET proporciona el siguiente interface en el espacio de nombres System: IComparable, que tiene un método CompareTo(Object o):int.
¿Crees que su signatura es correcta?**
Es correcta, pero se podría mejorar.

**¿Podría mejorarse?**
Sí, haciendo tanto la interfaz como el método genérico. Quedando como:
```csharp
public interface IComparable<T>
{
	int CompareTo(T o);
}
```

**Con la nueva signatura, implemente el método Ordenar del seminario anterior.**
Pasaría de esta signatura:
```csharp
IComparable<T>[] Sort<T>(IComparable<T>[] lista) {} // Esto no es lo que buscamos
```

A algo por este estilo:
```csharp
T[] Sort<T>(this T[] lista) where T:IComparable<T> {} // Esto es más específico
```

**¿Como puede usarse el nuevo interface para comparar objetos de distintos tipos?**
Buscaremos una interfaz común para comparar los 2 objetos, por ejemplo una interfaz INombrable para comparar un objeto Animal con un objeto Persona (ambos necesitan tener un nombre como campo).


## Ejercicio 2
**La clase Object contiene el siguiente método: Object -> Equals(Object o):bool.
¿Crees que su signatura es correcta?**
Es correcta pero no la más optima.

**¿Podría mejorarse?**
Usando genericidad, quedando la signatura tal que:
```csharp
public interface IEquotable<T> {
	bool Equals(T o);
}
```

**Con la nueva signatura, implemente el método IndexOf que reciba:
* Un array de cualquier tipo
* Un objeto de ese mismo tipo
**y retorne la posición de ese objeto en el array.**
```csharp
int? IndexOf(T[], T) where T:IEquotable<T> {}
```


# SEMINARIO 3
**¿Cuál es la funcionalidad de las dos siguientes funciones?**
* Ax.x -> Funcion identidad -> Ax.x(8) -> 8
* Af.Ax.f(fx) -> Funcion doble aplicacion (orden superior)

### Lógica booleana
true -> At.Af.t
false -> At.Af.f

**Pregunta: ¿Que representan**
Ambas tienen dos parametros.

## Ejercicio 1
**Dadas las dos constantes true y false, implemente la  función if-else que implemente el clásico condicional (en versión funcional)**
**¿Cuántos parámetros recibirá?**
Recibirá 3 parametros, la condición va a ser booleana.

**¿De qué tipo es cada parametro?**


**¿Cual sera su cuerpo?**
```csharp
if (condition)
	True_body
else
	False_body
```

if-else = Acond.Aif.Aelse.(cond)(if)(else)
if-else(true)(x)(y) -> x
if-else(false)(x)(y) -> y

**Implemente la funcion maximo y que use la funcion if-else definida (puede usar el operador >)**
En este caso tomará dos parámetros: *a* y *b*
```csharp
if (a > b)
	return a;
else
	return b;
```

maximo = Aa.Ab.if-else(> a b)(a)(b)
maximo(3)(6) -> 6
maximo(6)(3) -> 6

## Ejercicio 2
**Dadas las dos constantes true y false, implemente una función lambda que implemente el operador and (&& de Java)**

**¿Cuántos parametros recibirá?**
Recibirá 2 parametros.

**¿Cuál será su cuerpo?**
AND = Aa.Ab.(a)(b)(false)

OR = Aa.Ab.(a)(a)(b) -> Si a es verdadero se devuelve a, next(a). Si b es verdadero devuelve b y sino devuelve false.

NOT = Aa.(a)(false)(true) -> Si a es verdadero se devuelve false, en otro caso se devuelve true.


# SEMINARIO 4
## IEnumerable< T >
**¿Cuál es la abstracción que representa IEnumerable< T >?**
Un conjunto de objetos de tipo T.


**¿Cuál es la principal operación a realizar con instancias de IEnumerable< T >?**
Iterar a través de él con un foreach.

## Ejercicio 1
**Empezaremos por una función Filtrar: a partir de una colección de elementos, nos devuelve todos aquellos que cumplan un criterio dado (por ejemplo filtrar los número pares de una colección)**
```csharp
public static IEnumerable<T> Filtrar<T>(this IEnumerable<T> lista, Predicate<T> cond) {
	// Si la implementamos Lazy no hace falta
	IList<T> resultado = new List<T>(); 
	foreach (T obj in lista)
		if (predicate(obj))
			resultado.add(obj); // De forma Lazy -> yield return obj;
	return resultado; // De forma Lazy este return no haria falta
}
```

Un ejemplo de llamada con la lista [1, 2, 3, 4, 5] para filtrar los numeros pares seria:
```csharp
[1, 2, 3, 4, 5].Filtrar(x => x % 2 == 0);

// Otra forma seria declarando el Predicate antes
Predicate<int> pares = x => x % 2 == 0;
[1, 2, 3, 4, 5].Filtrar(pares);
```

## Ejercicio 2
**Función Map: A partir de una colección de n elementos,  nos devuelve otra colección de n elementos obtenidos tras aplicar una función f (dada una coleccion de cadenas devolver la longitud de cada cadena en una coleccion).**
```csharp
public static IEnumerable<TResult> Map<TOrigen, TResult>(this IEnumerable<TOrigen>, Func<TOrigen, TResult> func) {
	IList<TResult> resultado = new List<TResult>();
	foreach (TOrigen obj in lista)
		res.add(func(obj));
	return resultado;
}
```

Un ejemplo de invocación para el ejemplo dado puede ser:
```csharp
["hola", "mundo", "adios", "amigos"].Map(cadena => cadena.length);
```

Este ejemplo devolveria [4, 5, 5, 6].

## Ejercicio 3
**Función Reducir: A partir de una colección se obtiene un  único valor resultado de aplicar sucesivamente una función a los elementos de la colección (dada una coleccion de numeros obtener su suma).**
```csharp
public static TResult Reduce<TOrigen, TResult>(this IEnumerable<TOrigen> lista, Func<TOrigen, TResult, TResult> func, TResult option = default(TResult)) {
	var res = default(TResult) // No hace falta si tenemos semilla
	foreach (TOrigen obj in lista)
		res = func(res, obj);
	return res;
}
```

Un ejemplo de invocacion para el ejemplo dado puede ser:
```csharp
[1, 2, 3, 4, 5].Reduce((acu, num) => acu + num);
```


# Seminario 5
## Ejercicio 1
**Calcular el sumatoriod de todos los multiplos de 3 o 5 que se encuentren por debajo de un nº concreto, por ejemplo 1000 (ejemplo: 3, 5, 6 y 9 son son multiplos de 3 o 5 que estan por debajo de 10)**
```csharp
var c = Contador();
Enumerable.Repeat(0, 100).Map(x => c());
int i = 0;
new int[1000]().Map(x => i++);
```