# Fundamentos del paradigma funcional
El paradigma funcional es un paradigma declarativo basado en la utilización de funciones que manejan datos inmutables:
* Nunca se modifican
* En lugar de cambiar un dato se llama a una función que devuelve el dato modificado, sin modificar el original

Las funciones no generan efectos colaterales (secundarios).

## Expresiones Lambda
En el cálculo lambda, una expresión lambda (o término) se define como:
* Una abstracción lamdba Ax.M, donde x es una variable - parametro - y M es una expresión lambda - cuerpo de la función.
* Una aplicación M N donde M y N son expresiones lambda

Algunos ejemplos de abstracciones (funciones):
* La función identidad f(x) = x puede representarse como la expresion Ax.x
* La función doble g(x) = x + x puede representarse con la expresión Ax.x+x

## Aplicación (reducción-B)
La aplicación de una función representa su invocación.
Una reduccion-B -> (Ax.M)N -> M[x:=N] (o M[N/x])
Siendo x una variable y M y N expresiones lambda.
Esta sustitución se denomina reducción-B y algún ejemplo de aplicación es:
* (Ax.x+x)3 -> 3+3
* (Ax.x) Ay.y*2 -> Ay.y*2

## Teorema de Church-Rosser
El teorema de Church-Rosser establece que el orden en el que se hagan las reducciones B no van a afectar al resultado final:
* (Ax.x) (Ay.y·2)3 -> (Ay.y·2)3 -> 3·2
* (Ax.x) (Ay.y·2)3 -> (Ax.x)(3·2) -> 3·2

Por tanto los paréntesis se usan normalmente para delimitar términos lambda.

## Variables libres y ligadas
Una abstracción Ax.xy se dice que:
* La variable x está ligada
* La variable y es libre

En una sustitución, sólo se sustituyen las variables libres:
* (Ax.x(Ax.2+x)y)M -> x(Ax.2+x)y[x:=M] = M(Ax.2+x)y
La segunda x no se sustituye (esta ligada) ya que representa una variabel distinta (aunque tenga el mismo nombre).

## Conversión-alpha
Gracias a esta conversión podemos aplicar funciones a sí mismas, por ejemplo:
* La identidad de la función identidad es ella misma:
	* (Ax.x)(Ax.x) = (Ax.x)(Ay.y) -> Ay.y = Ax.x

Un ejemplo más complejo es el siguiente:
(Af.(Ax.f(fx)))(Ax.x+x)(m) -> (Ax.(Ax.x+x)((Ax.x+x)x))(m) -> (Ax.(Ay.y+y)((Az.z+z)n)))(m) -> (Ay.y+y)((Az.z+z)m) -> (Ay.y+y)(m+m) -> **m+m+m+m**

## El problema de la parada
Dada la especificación de un programa, demostrar si este finalizará su ejecución o tendrá una ejecución infinita. Por ejemplo en cáculo lambda se pueden escribir programas que no terminan (que divergen): (Ax.x·x)(Ax.x·x) -> (Ax.x·x)(Ax.x·x)

## Paradigma funcional
El paradigma funcional identifica las funciones como entidades de primer orden, igual que el resto de los valores (Ejemplo: objetos): Funciones de primer orden
Esto significa que las funciones son un tipo más, pudiendo ser instanciadas.
Una función se dice que es de orden superior si:
* Recibe alguna función como parámetro
* O bien retorna una función como resultado

La función de doble aplicación es un ejemplo de función de orden superior: Af.(Ax.f(fx))
Recibe una función como parametro (f) y, dada una expresión (x), la utiliza para pasársela a la función (fx) y, su resultado, se lo devuelve a la función (f(fx)).
En el ejemplo anterior:
(Af.(Ax.f(fx)))(Ay.y+y)(3) -> 12 (3+3+3+3)
La función de doble aplicación hara y+y dos veces, por tanto y+y+y+y.

### Delegados 
Un delegado constituye un tipo que representa un método de instancia o de clase (static). Las variables de tipo delegado representan un modo de referenciar un método:
```csharp
namespace PA.Delegates
{
    public delegate void ImprimirDelegado(string value);
    public class EjemploDelegado
    {
        private void Imprimir(string valor)
        {
            Console.WriteLine(valor);
        }

        public void EjemploDelegate()
        {
            //Declaración
            ImprimirDelegado imprimirDelegado = new ImprimirDelegado(Imprimir);

            //invocación
            imprimirDelegado("texto de ejemplo");
        }

    }
}
```

Como se puede ver en este ejemplo la variable imprimirDelegado viene dada por el delegado ImprimirDelegado().

Otro ejemplo podría ser:
```csharp
public delegate int Comparacion(Persona p1, Persona p2);

static public void OrdenarPersonas(Persona[] vector, Comparacion comparacion) {
	if (comparacion(vector[i], vector[j]) >0) {  
		Persona aux = vector[i];  
		vector[i] = vector[j];  
		vector[j] = aux;  
	}
}
```

Como se puede apreciar podemos declarar el método OrdenarPersonas independiente del criterio de ordenación ya que podemos declarar otros métodos que cumplan la función del delegado creando una variable.


### Patrón observer
Los suscriptores (observer) se registran y desregistran en un asunto (subject). Cuando sucede un evento, el asunto notifica de tal evento a los elementos suscritos.
```csharp
class Boton {  
	public delegate void BotonClick();  
	private BotonClick metodosAInvocar; // Instancia de delegado que colecciona los metodos que se van a invocar cuando el evento sea trigereado.  
	
	public void AñadirDelegado(BotonClick metodo) {  
	metodosAInvocar += metodo;  
	}
	  
	public void EliminarDelegado(BotonClick metodo) {  
	metodosAInvocar -= metodo;  
	}  
	
	public void Click() {  
	metodosAInvocar();  
	}  
}
```

Y a continuación podemos añadir a nuestro delegado un evento:
```csharp
static void Main() {  
	Boton boton = new Boton();  
	
	Entero entero = new Entero(3);  
	Controlador controlador = new Controlador();  
	
	boton.AñadirDelegado(entero.Mostrar);  
	
	boton.AñadirDelegado(controlador.OnClick); 
	// Se trigerea el evento, por tanto el delegado cumplira su funcion 
	boton.Click();  
}
```


### Tipos de delegados predefinidos
Los más utilizados son **Func, Action y Predicate**. Sus funciones son:
* Func< T >: Métodos sin parametros que retorna un T
* Func<T1, T2>: Método con un parametro T1 que retorn T2
* Action: Método sin parametros ni retorno
* Action< T >: Método con parametro sin retorno
* Predicate< T >: Método que retorna un bool y recibe T

### Delegados anónimos
Sintaxis para definir una variable delegado indicando sus parámetros y su cuerpo:
```csharp
Persona[] personas = ListadoPersonas.CrearPersonasAleatorias();  
Persona[] mayoresEdad = Array.FindAll(personas,  
									delegate(Persona p) { return p.Edad >= 18; });
```

### Expresiones lambda
Las expresiones (funciones) lambda de C# permiten escribir el cuerpo de funciones completas como expresiones, siendo la mejora de los delegados anónimos.
Comparemos por tanto los delegados anónimos con una expresión lambda:
```csharp
mayoresEdad = Array.FindAll(personas,delegate (Persona p){ return p.Edad >= 18; });
```

Miremos ahora como seria con una expresion lambda:
```csharp
mayoresEdad = Array.FindAll(personas, p => p.Edad >= 18);
```


## Clausulas
Una cláusula es una función de primer orden junto con su ámbito: una tabla que guarda las referencias a sus variables libres. Un ejemplo será:
```csharp
int valor = 1;  
Func<int> dobleDeValor = () => valor * 2;  
dobleDeValor(); // 2  
valor = 7;  
dobleDeValor(); // 14
```

Se puede ver como en la Func se accede a una variable externa (closure) y se puede cambiar el valor del resultado cosa que por definicion no sera una funcion pura, ya que el resultado no debe de cambiar.

Las variables libres de una clausula representan estado, por tanto puede representar objetos o estructuras de control.

## Currificación
La currificación es la técnica para transformar una función de varios parametros en una función que recibe un único parámetro:
* La función recibe un parámetro y retorna otra función que se puede llamar con el segundo parámetro
* Esto puede repetirse para todos los parámetros de la función orignal
* La invocación pasará de ser f(1,2,3) a f(1)(2)(3).

Un ejemplo en código podría ser el siguiente:
```csharp
static Func<int, int> SumaCurrificada(int a) {  
	return b => a + b;  
}  
 
const int a = 2, b = 1;
Console.WriteLine("Curried addition: {0}", CurriedAdd(a)(b));
```

Su aplicación parcial es su principal beneficio, que consiste en pasar un número menor de parámetros en la invocación de la función lo que resulta en una menor aridad (número de parametros).

## Continuaciones
Una continuacion representa el estado de computación en un momento de ejecución. El estado de computación suele estar compuesto por:
* El estado de la pila de ejecución
* La siguiente instrucción a ejecutar

## Generadores
Un generador es una función que simula la devolución de una colección de elementos sin tener que construir toda la colección, devolviendo un elemento cada vez que la función es invocada.
Los beneficios de los generadores son que requiere de menos memoria y que solo se generarán los elementos necesarios.

Los generadores se implementan con yield una especie de continuacion *ad hoc*:
```csharp
static internal IEnumerable<int> InfiniteFibonacci() {
    int first = 1, second = 1;
    while (true) {
        yield return first;
        int addition = first + second;
        first = second;
        second = addition;
    }
}

static internal IEnumerable<int> FiniteFibonacci(int maximumTerm) {
    int first = 1, second = 1, term = 1;
    while (true) {
        yield return first;
        int addition = first + second;
        first = second;
        second = addition;
		if (term++ == maximumTerm)
            yield break;
    }
}    
```

Estos son ejemplos de generadores, en este caso de la serie de fibonacci.

## Evaluación perezosa
La evaluación perezosa es la técnica por la que se demora la evaluación de una expresión hasta que ésta es utilizada.
Los beneficios de la evaluación perezosa son:
* Menor consumo de memoria
* Mayor rendimiento
* Posibilidad de crear estructuras de datos potencialmente infinitas

Podemos hacer uso de un generador y después de los métodos extensores Skip y Take:
```csharp
static private IEnumerable<int> GeneradorLazyNumerosPrimos() {  
	int n = 1;  
	while (true) {  
		if (EsPrimo(n))  
		yield return n;  
		n++;  
	}  
}  
static internal IEnumerable<int> NumerosPrimosLazy(int desde, int númeroDeNúmeros) {  
	return GeneradorLazyNumerosPrimos().Skip(desde).Take(númeroDeNúmeros);  
}
```


## Transparencia referencial
Una expresión se dice que es referencialmente transparente si dada una función y un input, siempre se tendrá el mismo output (no ocurre en C# por las clausuras).

## Memorización
La memorización (memoization):
* Si una expresión posee transparencia referencial, esta puede sustituirse por su valor
* Si la expresión es una invocación a una función pura, esta puede sustituirse por el valor de retorno
* La primera vez que se invoca se retorna el valor guardandolo en una cache
* En sucesivas invocaciones, se retornará el valor de la cache sin necesidad de ejecutar la función

Un ejemplo se puede implementar para la serie de Fibonnaci:
```csharp
static class FibonacciMemorizacion {  
	private static IDictionary<int, int> valores = new Dictionary<int, int>();  
	
	internal static int Fibonacci(int n) {  
		if (valores.Keys.Contains(n))  
			return valores[n];  
		int valor = n <= 2 ? 1 : Fibonacci(n - 2) + Fibonacci(n - 1);  
		valores.Add(n, valor);  
		return valor;  
	}  
}
```

Como podemos ver tendremos un diccionario que cumplira la función de caché guardando los resultados.

Con la memorizacion podemos conseguir implementar evaluacion perezosa, por ejemplo:
```csharp
internal static double LazySquare(Func<int> param1, Func<int> param2) {
    if (new Random().Next()%2==0) 
        return param1.Memoize() * param1.Memoize();
    else 
        return param2.Memoize() * param2.Memoize();
}

// En caso de que exista el valor no hace falta volver a invocar la funcion
internal static int Memoize(this Func<int> function) {
    if (values.Keys.Contains(function))
        return values[function];
    int result = function();
    values.Add(function, result);
    return result;
}

private static IDictionary<Func<int>,int> values = new Dictionary<Func<int>,int>();

```


## Pattern matching
Es el acto de comprobar si un conjunto de elementos siguen algún patrón determinado. Los elementos suelen ser: Tipos de variables, listas, cadenas de caracteres, tuplas, arrays, ... 
Los patrones sulene ser: secuencias o estructuras de árboles.

Ejemplo de pattern matching (mala práctica):
```csharp
static double AreaIs(Object figura) {  
	if (figura is Circulo)  
		return Math.PI * Math.Pow(((Circulo)figura).Radio, 2);
		
	if (figura is Cuadrado)  
		return Math.Pow(((Cuadrado)figura).Lado, 2);  
		
	if (figura is Rectangulo) {  
		Rectangulo rectangulo = figura as Rectangulo;  
		return rectangulo.Alto * rectangulo.Ancho;  
	}  
	
	if (figura is Triangulo) {  
		Triangulo triangulo = figura as Triangulo;  
		return triangulo.Base * triangulo.Altura / 2;  
	}  
	
	throw new ArgumentException("El parámetro no es una figura");  
}
```

La utilización de introspección para este escenario posee dos incovenientes:
* Es costosa en rendimiento en tiempo de ejecución
* Los errores no son detectados en tiempo de compilación (en tiempo de ejecución si)

**Pregunta: En C# ¿cuál es la técnica más apropiada para obtener los beneficios de pattern matching de tipos (como en el ejemplo anterior)?**
Con el polimorfismo, es decir, redefinir el método para cada tipo.


## Función de Orden Superior
Recordemos que una función de orden superior es una función que:
* O recibe una función como parámetro
* O retorna una función como resultado

Las funciones de orden superior más tipicas son:
* Filter: aplica un predicado a todos los elementos de una colección
* Map: aplica una función a todos los elementos de una colección devolviendo una nueva colección
* Reduce: aplica una función a todos los elementos de una colección, dado un orden, devolviendo un valor

Veamos ahora el código para estas tres funciones.

<details><summary>Filter</summary><br/>

Método completo
```csharp
public static IEnumerable<TDomain> Filter<TDomain>(this IEnumerable<TDomain> list, Predicate<TDomain> function)
{
	var aux = new TDomain[list.Count()];
	int i = 0;
	foreach (var a in list)
	{
		if (function(a)) {
			aux[i] = a;
			i++;
		}
	}
	Array.Resize(ref aux, i);
	return aux;
}
```

</details>