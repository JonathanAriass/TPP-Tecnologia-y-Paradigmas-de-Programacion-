using System;
using System.Text;
using System.Diagnostics;

using ListaEnlazada;

namespace TPP.Laboratory.ObjectOrientation.Lab03 {

    public class Stack {

        List lista;
        uint _maxNumberOfElements;

        public static void Main() {

            Stack stack = new Stack(5);
            try
            {
                stack.Push(3);
                stack.Push(7);
                stack.Push(6);
                stack.Push(1);
                //stack.Push(null);
                stack.Push(9);
                Console.WriteLine($"Stack: {stack}\n");
                stack.Pop();
                stack.Push(2);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex2)
            {
                Console.WriteLine(ex2.Message);
            }

        }

        /// <summary>
        /// Constructor del stack, se comprueba que el numero maximo de elementos pasado
        /// como parametro sea mayor que 0.
        /// 
        /// Se iniciaiza la lista que almacena la informacion del Stack
        /// </summary>
        /// <param name="maxNumberOfElements">Numero maximo de elementos</param>
        public Stack(uint maxNumberOfElements)
        {
            if (maxNumberOfElements == 0)
            {
                throw new ArgumentException("Numero maximo de elementos ilogico.");
            }
            lista = new List();
            this._maxNumberOfElements = maxNumberOfElements;
            Debug.Assert(this.IsEmpty);
            Invariant();
        }

        /// <summary>
        /// Metodo que almacena un dato en el Stack introduciendolo en la lista.
        /// 
        /// Se usa programacion por contrato por lo que se comprueban varias cosas,
        /// como por ejemplo que el elemento pasado como parametro no sea null o que si el Stack
        /// esta lleno no se pueda introducir mas datos.
        /// </summary>
        /// <param name="elemento"></param>
        public void Push(Object elemento)
        {
            Invariant();
            if (this.IsFull)
            {
                throw new InvalidOperationException("El stack ya esta lleno.");
            }
            if (elemento == null)
            {
                throw new ArgumentException("El elemento no puede ser null.");
            }
            int previousStackLength = lista.NumberOfElements;

            this.lista.AddNode(elemento);

            Debug.Assert(!this.IsEmpty);
            Debug.Assert(this.lista.NumberOfElements == (previousStackLength + 1));
            Invariant();
        }

        /// <summary>
        /// Metodo que devuelve la posicion LiFo(Last In First Out) a obtener en el metodo Pop(),
        /// de esta forma tenemos una alta cohesion en el metodo Pop().
        /// </summary>
        /// <returns>Posicion mas alta del Stack para asi poder acceder a los elementos de la lista</returns>
        private uint GetLifoPos()
        {
            uint aux = 0;
            if (lista.NumberOfElements > 0)
            {
                aux = (uint) lista.NumberOfElements - 1;
            }

            return aux;
        }

        /// <summary>
        /// Metodo que obtiene el elemento mas alto de la pila, es decir el ultimo que se introdujo.
        /// 
        /// Como en el caso del metodo Push() en este metodo tambien se usa la programacion por contratos,
        /// comprobando que si la lista esta vacia no se pueda obtener nada ya que es ilogico.
        /// </summary>
        /// <returns>Informacion almacenada en la posicion mas elevada del Stack</returns>
        public Object Pop()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException("No hay nada en el stack (imposible hacer pop)");
            }

            Object res = this.lista.GetElement(GetLifoPos());
            this.lista.Remove(res);

            Debug.Assert(!this.IsFull);
            Debug.Assert(res != null);

            return res;
        }

        /// <summary>
        /// Invariante de la clase, en este caso se comprueba que el numero de elementos almacenados en la lista
        /// no supere el numero maximo de elementos del Stack. Y tambien se comprueba que la lista no este llena y vacia a la vez.
        /// </summary>
        private void Invariant()
        {
            Debug.Assert(this.lista.NumberOfElements <= _maxNumberOfElements);
            Debug.Assert(!(IsEmpty && IsFull));
        }

        /// <summary>
        /// Metodo ToString() de la clase Stack
        /// </summary>
        /// <returns>Cadena con la informacion del Stack</returns>
        public override string ToString()
        {
            return this.lista.ToString();
        }

        public bool IsEmpty
        {
            get 
            {
                return lista.NumberOfElements == 0;
            }
        }

        public bool IsFull
        {
            get
            {
                return lista.NumberOfElements == _maxNumberOfElements;
            }
        }

        /**
         * Una invariante seria que la lista no puede estar vacia y llena a la vez
         * 
         * En el caso del constructor del stack una precondicion seria que el numerodeelementos no sea igual aa 0
         * En el caso del constructor del stack una postcondicion seria que la propiedad IsEmpty devuelva true
         * 
         * En el caso del push una precondicion seria que el elemento sea valido y el stack no este llena
         *      - En caso de que alguna precondicion se diese se deberia de lanzar una excepcion
         * En el caso del push una postcondicion seria que no este vacia
         *  
         * En el caso del pop una precondicion seria mirar el estado del stack  (lista no vacia)
         * En el caso del push una postcondicion seria que la lista no siga llena y que el elemento que obtienes no sea null
         * 
         * En el caso de las propiedades no se hacen precondiciones ni postcondiciones, ya que no hay seters
         * 
         * -------------------
         * EJERCICIO EXTRA   -
         * -------------------
         * Abrir el codigo de algorithms y poner un breakpoint viendo que hace.
         * 
         * 
         */
    }

}