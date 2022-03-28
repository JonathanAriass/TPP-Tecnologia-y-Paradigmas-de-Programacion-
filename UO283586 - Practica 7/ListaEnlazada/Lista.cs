using System;
using System.Text;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ListaEnlazada
{
    /// <summary>
    /// Clase que representa una lista enlazada simple que almacena nodos de tipo T
    /// Esta clase contiene 4 metodos principales:
    /// <li>AddNode()</li>
    /// <li>RemoveNode()</li>
    /// <li>GetNode()</li>
    /// <li>Print()</li>
    /// </summary>
    public class Lista<T> : IEnumerable<T>
    {

        Node<T> _lead; //  Cabeza de la lista
        int _numberOfElements; // Numero de elemtos de la lista

        /// <summary>
        /// Propiedad de campos del numero de elementos de la lista
        /// </summary>
        public int NumberOfElements
        {
            get
            {
                return this._numberOfElements;
            }
        }

        /// <summary>
        /// Constructor de la lista que inicilizara el campo <em>_lead</em> a null y el
        /// <em>_numberOfElements</em> a 0.
        /// </summary>
        public Lista()
        {
            _lead = null;
            Invariant();
        }

        /// <summary>
        /// Metodo que comprueba si la lista esta vacia.
        /// </summary>
        /// <returns></returns>
        private bool IsListEmpty()
        {
            return NumberOfElements == 0;
        }

        /// <summary>
        /// Metodo que añade un nodo al final de la lista
        /// </summary>
        /// <param name="node">Nodo a añadir a la lista</param>
        public void Add(T node)
        {
            Invariant();
            int previousNumberOfElements = NumberOfElements;

            if (node == null)
            {
                Console.WriteLine("El elemento a añadir es incorrecto.");
                throw new ArgumentException("El valor es invalido");
            }
            if (IsListEmpty())
            {
                _lead = new Node<T>(node);
                _numberOfElements++;
#if DEBUG
                Console.WriteLine("Añadiendo nodo: " + node);
#endif
            }
            else
            {
                Node<T> aux = _lead;
                while (aux.NextNode != null)
                {
                    aux = aux.NextNode;
                }
                aux.NextNode = new Node<T>(node);
                _numberOfElements++;
#if DEBUG
                Console.WriteLine("Añadiendo nodo: " + node);
#endif
            }

            Debug.Assert(_lead != null);
            Debug.Assert(NumberOfElements != 0);
            Debug.Assert((previousNumberOfElements + 1) == NumberOfElements);

            Invariant();
        }

        /// <summary>
        /// Metodo que añade un nodo en un indice pasado como parametro.
        /// </summary>
        /// <param name="node">Nodo a añadir a la lista</param>
        /// <param name="index">Indice (posicion) donde añadir el nodo</param>
        public void Add(T node, uint index)
        {
            Invariant();
            int previousNumberOfElements = NumberOfElements;

            if (node == null)
            {
                Console.WriteLine("El elemento a añadir es incorrecto.");
                throw new ArgumentException("El valor es invalido");
            }
            if (IsListEmpty())
            {
                _lead = new Node<T>(node);
                _numberOfElements++;
#if DEBUG
                Console.WriteLine("Añadiendo nodo: " + node + ", en posicion: " + 1);
#endif
            }
            else if (index >= _numberOfElements)
            {
                Console.WriteLine("El indice indicado no es alcanzable.");
                throw new ArgumentException("Indice invalido, fuera del rango");
            }
            else
            {
                if (index == 0)
                {
                    Node<T> copy = _lead;
                    _lead = new Node<T>(node);
                    _lead.NextNode = copy;
                    _numberOfElements++;
                }
                else
                {
                    Node<T> aux = _lead;
                    for (int i = 1; i < index; i++)
                    {
                        aux = aux.NextNode;
                    }
                    Node<T> copy = aux.NextNode;
                    aux.NextNode = new Node<T>(node);
                    aux.NextNode.NextNode = copy;
                    _numberOfElements++;
#if DEBUG
                    Console.WriteLine("Añadiendo nodo: " + node + ", en posicion: " + index);
#endif
                }
            }

            Debug.Assert(_lead != null);
            Debug.Assert(NumberOfElements != 0);
            Debug.Assert((previousNumberOfElements + 1) == NumberOfElements);

            Invariant();
        }

        /// <summary>
        /// Metodo que elimina en nodo de la lista pasando el campo <em>_data</em> del
        /// nodo a eliminar, de esta manera se podra encontrar el nodo en la lista y asi
        /// poder eliminarlo.
        /// </summary>
        /// <param name="node">Campo <em>_data</em> del nodo a eliminar.</param>
        public void Remove(T node)
        {
            Invariant();
            if (node == null)
            {
                Console.WriteLine("El elemento a eliminar es invalido.");
                throw new ArgumentException("El elemento a eliminar es invalido");
            }
            if (IsListEmpty())
            {
                throw new InvalidOperationException("No se puede eliminar, ya que no hay nada en la lista");
            }

            int previosuNumberOfElements = this.NumberOfElements;

            if (_lead.Data.Equals(node))
            {
                _lead = _lead.NextNode;
                _numberOfElements--;
                //Console.WriteLine("Eliminando el nodo cabeza de la lista.");
                Debug.Assert((previosuNumberOfElements - 1) == _numberOfElements);
                Invariant();
                return;
            }

            Node<T> aux = _lead;
            while (aux.NextNode != null)
            {
                if (aux.NextNode.Data.Equals(node))
                {
                    aux.NextNode = aux.NextNode.NextNode;
                    _numberOfElements--;
                    //Console.WriteLine("Eliminando el nodo, " + node + " de la lista.");

                    Debug.Assert((previosuNumberOfElements - 1) == _numberOfElements);
                    Invariant();
                    return;
                }

                aux = aux.NextNode;
            }

            Console.WriteLine("El elemento: " + node + ", no existe en el stack.");
            Invariant();
        }

        /// <summary>
        /// Metodo que devuelve el nodo que se encuentra en el indice (posicion) 
        /// pasado como parametro.
        /// </summary>
        /// <param name="index">Indice (posicion) del nodo a obtener.</param>
        /// <returns></returns>
        public T GetElement(uint index)
        {
            Invariant();
            int previosuNumberOfElements = this.NumberOfElements;

            if (IsListEmpty())
            {
                throw new InvalidOperationException("Lista vacia, no hay elementos que obtener");
            }

            if (index >= _numberOfElements)
            {
                Console.WriteLine("La posicion no existe.");
                throw new ArgumentException("La posicion introducida es invalida");
            }
            else
            {
                Node<T> aux = _lead;
                for (int i = 1; i <= index; i++)
                {
                    aux = aux.NextNode;
                }
                T res = aux.Data;
                Debug.Assert(NumberOfElements == previosuNumberOfElements);
                Debug.Assert(_lead != null);
                Invariant();
                return res;
            }
        }

        /// <summary>
        /// Metodo que comprueba si un elemento de la lista pasado como parametro esta
        /// en la lista.
        /// </summary>
        /// <param name="node">Elemento a comprobar si existe en la lista.</param>
        /// <returns>true o false, dependiendo de si esta en la lista o no respectivamente</returns>
        public bool Contains(T node)
        {
            Invariant();
            if (node == null)
            {
                throw new ArgumentException("Valor invalido");
            }
            if (IsListEmpty())
            {
                throw new InvalidOperationException("Lista vacia, no hay nada que buscar");
            }

            int previosuNumberOfElements = this.NumberOfElements;

            Node<T> aux = _lead;

            for (int i = 1; i <= NumberOfElements; i++)
            {
                if (aux.Data.Equals(node))
                {
                    Debug.Assert(NumberOfElements == previosuNumberOfElements);
                    Debug.Assert(_lead != null);
                    Invariant();
                    return true;
                }
                aux = aux.NextNode;

            }
            Debug.Assert(NumberOfElements == previosuNumberOfElements);
            Debug.Assert(_lead != null);
            Invariant();
            return false;
        }

        /// <summary>
        /// Metodo que imprime la lista con el siguiente formato:
        /// _data - _data - _data
        /// </summary>
        public void Print()
        {
            Console.WriteLine(this.ToString());
        }

        /// <summary>
        /// Metodo ToString que devuelve una cadena con la informacion almacenada en la lista.
        /// Se utiliza el StringBuilder para crear dicha cadena.
        /// </summary>
        /// <returns>Cadena con la informacion de la lista.</returns>
        public override String ToString()
        {
            if (IsListEmpty())
            {
                Console.WriteLine("Lista vacia.");
                return "";
            }

            StringBuilder sb = new StringBuilder();

            Node<T> actual = _lead;

            sb.Insert(0, actual.Data);

            while (actual.NextNode != null)
            {
                sb.AppendFormat(" - {0}", actual.NextNode.Data.ToString());
                actual = actual.NextNode;
            }

            Console.WriteLine("\n");

            return sb.ToString();
        }

        /// <summary>
        /// Invariante de la clase List, en la que se comprueba que el numero de elementos siempre tiene
        /// que estar en el rango [0, n] y que si hay algun elemento almacenado en la lista, la cabeza de la
        /// lista no sea null.
        /// </summary>
        private void Invariant()
        {
            Debug.Assert(NumberOfElements >= 0);
            Debug.Assert(NumberOfElements > 0 ? _lead != null : _lead == null);
        }

        /// <summary>
        /// Implementacion de la interfaz de IEnumerable que implementa la clase Lista.
        /// </summary>
        /// <returns>Devuelve el IEnumerator correspondiente</returns>
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new ListEnumerator<T>(this);
        }

        /// <summary>
        /// Implementacion de la interfaz de IEnumerable mas general
        /// </summary>
        /// <returns>El IEnumerator general</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new ListEnumerator<T>(this);
        }


        /*public static T Find<T>(IEnumerable<T> lista, Predicate<T> function)
        {
            foreach (var a in lista)
            {
                if (function(a))
                {
                    return a;
                }
            }
            return default(T);
        }

        public static IEnumerable<TDomain> Filter<TDomain>(IEnumerable<TDomain> list, Predicate<TDomain> function)
        {
            var aux = new TDomain[list.Count()];
            int i = 0;

            foreach (var a in list)
            {
                if (function(a))
                {
                    aux[i] = a;
                    i++;
                }
            }
            Array.Resize(ref aux, i);
            return aux;
        }


        // Reduce sin semilla
        public static TCD Reduce<TD, TCD>(IEnumerable<TD> list, Func<TCD, TD, TCD> func)
        {
            var acc = default(TCD);
            foreach (TD obj in list)
            {
                acc = func(acc, obj);
            }

            return acc;
        }

        // Con semilla
        public static TCD Reduce<TD, TCD>(IEnumerable<TD> list, Func<TCD, TD, TCD> func, TCD acc = default(TCD))
        {
            foreach (TD obj in list)
            {
                acc = func(acc, obj);
            }

            return acc;
        }

        public static IEnumerable<TCD> Map<TD, TCD>(IEnumerable<TD> list, Func<TD, TCD> func)
        {
            IList<TCD> res = new List<TCD>();
            foreach (TD obj in list)
            {
                res.Add(func(obj));
            }
            return res;
        }

        public static void ForEach<T>(IEnumerable<T> lista, Action<T> accion)
        {
            foreach (T i in lista)
            {
                accion(i);
            }
        }

        public static IEnumerable<T> Invert<T>(IEnumerable<T> lista)
        {
            T[] aux = new T[lista.Count()];

            var i = 0;
            foreach (T obj in lista)
            {
                aux[i] = obj;
                i++;
            }

            IList<T> res = new List<T>();

            for (int j = aux.Length - 1; j >= 0; j--)
            {
                res.Add(aux[j]);
            }

            return res;
        }*/

    }
}
