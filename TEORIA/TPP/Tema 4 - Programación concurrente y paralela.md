# Tema 4 - Programación concurrente y paralela
## Ley de Moore
Es una ley empírica que dice: *El número de transistores por unidad de superficie en circuitos integrados se duplica cada 24 meses, sin encarecer su precio*

## Arquitecturas
En las arquitecturas actuales solemos disponer de multinúcleos, siendo estos núcleos los que se amplian en lugar de la frecuencia de reloj. Ofrecen computación paralela no sólo a nivel de proceso, sino también a nivel de hilo. Estas arquitecturas poseen una memoria compartida, para la cual cada procesador contará con una privada.

## Programación concurrente
El paralelismo es un caso particular de la concurrencia, en que las tareas se ejecutan de forma paralela (simultaneamente, **no simulada**).

El paralelismo enfatiza la división de un problema en partes más pequeñas.
La concurriencia enfatiza la interacción entre tareas.

Un proceso es un programa en ejecución que consta de instrucciones, estado de ejecución y valores de datos en ejecución.

Un hilo es una parte de un proceso, pudiendo denominarlo como una tarea de un proceso que puede ejecutarse concurrentemente, compartiendo la memoria del proceso, con el resto de sus hilos. Cada hilo deberá de tener un contador de programa, pila de ejecución y el valor de los registros.

## Paralelización de Algoritmos
Existen dos escenarios típicos de paralelización:
* Paralelización de tareas: Tareas independientes pueden ser ejecutadas concurrentemente (generar hashes ficheros, encriptar cadenas, generar thumbnails ficheros).
* Paralelización de datos: Ejecutar una misma tarea que computa porciones de los mismos datos (un texto de un libro para encontrar palabras).

Existe un modelo híbrido de los dos anteriores denominado pipeline. Sincronizamos la salida de una tarea como la entrada de la siguiente (terminal de linux con *ls | grep*).

## Creación explícita de hilos
Podemos hacer uso de la clase Thread (System.Threading) para encapsular un hilo de ejecución de forma explícita. Veamos un ejemplo:
```csharp
Thread hilo = new Thead(delegado);
hilo.Name = "Hilo secundario";
Treah.CurrentThread.Name = "Hilo principal";
hilo.Priority = ThreadPriority.BelowNormal;
hilo.Start(); // Se lanza el hilo secundario
```

Ahora vamos a paralelizar un problema por datos: calcular el módulo de un vector de n dimensiones. Para resolver este problema vamos a usar la técnica de master/worker, por lo tanto necesitamos crear esas clases.

<details>
<summary>Clase Master.cs</summary>

```csharp
public class Master {
        private short[] vector;
        private int numberOfThreads;

        public Master(short[] vector, int numberOfThreads) {
            if (numberOfThreads < 1 || numberOfThreads > vector.Length)
                throw new ArgumentException("The number of threads must be lower or equal to the elements of the vector");
            this.vector = vector;
            this.numberOfThreads = numberOfThreads;
        }
        
        public double ComputeModulus() {
            // * Workers are created
            Worker[] workers = new Worker[this.numberOfThreads];
            int elementsPerThread = this.vector.Length/numberOfThreads;
            for(int i=0; i < this.numberOfThreads; i++) {
                workers[i] = new Worker(this.vector,  i*elementsPerThread, (i<this.numberOfThreads-1) ? (i+1)*elementsPerThread-1: this.vector.Length-1);
			}
            Thread[] threads = new Thread[workers.Length];
            for(int i=0;i<workers.Length;i++) {
                threads[i] = new Thread(workers[i].Compute); // we create the threads
                threads[i].Name = "Vector modulus worker " + (i+1); // we name then (optional)
                threads[i].Priority = ThreadPriority.Normal; // we assign them a priority (optional)
                threads[i].Start();   // we start their execution
            }
            foreach (Thread thread in threads)
                thread.Join();
            long result = 0;
            foreach (Worker worker in workers)
                result += worker.Result;
            return Math.Sqrt(result);
        }
    }
```

</details>

<details>
<summary>Clase Worker.cs</summary>

```csharp
internal class Worker {
        private short[] vector;
        private int fromIndex, toIndex;
        private long result;

        internal long Result {
            get { return this.result; }
        }

        internal Worker(short[] vector, int fromIndex, int toIndex) {
            this.vector = vector;
            this.fromIndex = fromIndex;
            this.toIndex = toIndex;
        }
        
        internal void Compute() {
            this.result = 0;
            for(int i= this.fromIndex; i<=this.toIndex; i++)
                this.result += this.vector[i] * this.vector[i];
        }
    }
```

</details>


<details>
<summary>Clase Main.cs</summary>

```csharp
public class VectorModulusProgram {

        static void Main(string[] args) {
            short[] vector = CreateRandomVector(100000, -100, 100);

            double result = 0;
            foreach (short element in vector)
                result += element * element;
            Console.WriteLine($"Result: {Math.Sqrt(result)}");

            // * Computation with four threads
            master = new Master(vector, 4);
            before = DateTime.Now;
            result = master.ComputeModulus();
            after = DateTime.Now;
            Console.WriteLine("The result obtained with four threads is: {0:N2}.", result);
            Console.WriteLine("Elapsed time: {0:N0} ticks.",
                (after - before).Ticks);
        }

        public static short[] CreateRandomVector(int numberOfElements, short lowest, short greatest) {
            short[] vector = new short[numberOfElements];
            Random random = new Random();
            for (int i = 0; i < numberOfElements; i++)
                vector[i] = (short)random.Next(lowest, greatest + 1);
            return vector;
        }

    }
```
</details>

Podemos por tanto hacer un diagrama de la solución a este problema con varios hilos de ejecución:
![Master/Worker](Master-Worker.png)

