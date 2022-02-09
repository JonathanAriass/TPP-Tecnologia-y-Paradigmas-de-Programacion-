using System;

namespace ListaEnlazada
{
    /// <summary>
    /// Clase que representa una lista enlazada simple que almacena nodos de tipo Object
    /// Esta clase contiene 4 metodos principales:
    /// <li>AddNode()</li>
    /// <li>RemoveNode()</li>
    /// <li>GetNode()</li>
    /// <li>Print()</li>
    /// </summary>
    public class List
    {

        Node _lead; //  Cabeza de la lista
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
        public List()
        {
            _lead = null;
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
        public void AddNode(Object node)
        {
            if (node == null)
            {
                Console.WriteLine("El elemento a añadir es incorrecto.");
                return;
            }
            if (IsListEmpty())
            {
                _lead = new Node(node);
                _numberOfElements++;
#if DEBUG
                Console.WriteLine("Añadiendo nodo: " + node);
#endif
            }
            else
            {
                Node aux = _lead;
                while (aux.NextNode != null)
                {
                    aux = aux.NextNode;
                }
                aux.NextNode = new Node(node);
                _numberOfElements++;
#if DEBUG
                Console.WriteLine("Añadiendo nodo: " + node);
#endif
            }
        }

        /// <summary>
        /// Metodo que añade un nodo en un indice pasado como parametro.
        /// </summary>
        /// <param name="node">Nodo a añadir a la lista</param>
        /// <param name="index">Indice (posicion) donde añadir el nodo</param>
        public void AddNode(Object node, uint index)
        {
            if (node == null)
            {
                Console.WriteLine("El elemento a añadir es incorrecto.");
                return;
            }
            if (index >= _numberOfElements)
            {
                Console.WriteLine("El indice indicado no es alcanzable.");
                return;
            }
            if (IsListEmpty())
            {
                _lead = new Node(node);
                _numberOfElements++;
#if DEBUG
                Console.WriteLine("Añadiendo nodo: " + node + ", en posicion: " + 1);
#endif
            }
            if (index == 0)
            {
                Node copy = _lead;
                _lead = new Node(node);
                _lead.NextNode = copy;
                _numberOfElements++;
            }
            else
            {
                Node aux = _lead;
                for (int i = 1; i < index; i++)
                {
                    aux = aux.NextNode;
                }
                Node copy = aux.NextNode;
                aux.NextNode = new Node(node);
                aux.NextNode.NextNode = copy;
                _numberOfElements++;
#if DEBUG
                Console.WriteLine("Añadiendo nodo: " + node + ", en posicion: " + index);
#endif

            }
        }

        /// <summary>
        /// Metodo que elimina en nodo de la lista pasando el campo <em>_data</em> del
        /// nodo a eliminar, de esta manera se podra encontrar el nodo en la lista y asi
        /// poder eliminarlo.
        /// </summary>
        /// <param name="node">Campo <em>_data</em> del nodo a eliminar.</param>
        public void Remove(Object node)
        {
            if (node == null)
            {
                Console.WriteLine("El elemento a eliminar es invalido.");
                return;
            }
            if (IsListEmpty())
            {
                return;
            }

            if (_lead.Data == node)
            {
                _lead = _lead.NextNode;
                _numberOfElements--;
                Console.WriteLine("Eliminando el nodo cabeza de la lista.");
                return;
            }

            Node aux = _lead;
            while (aux.NextNode != null)
            {
                if (aux.NextNode.Data == node)
                {
                    aux.NextNode = aux.NextNode.NextNode;
                    _numberOfElements--;
                    Console.WriteLine("Eliminando el nodo, " + node + " de la lista.");
                    return;
                }

                aux = aux.NextNode;
            }

            Console.WriteLine("El nodo: " + node + ", no existe en la lista.");
        }

        /// <summary>
        /// Metodo que devuelve el nodo que se encuentra en el indice (posicion) 
        /// pasado como parametro.
        /// </summary>
        /// <param name="index">Indice (posicion) del nodo a obtener.</param>
        /// <returns></returns>
        public Object GetElement(uint index)
        {
            if (index >= _numberOfElements)
            {
                Console.WriteLine("La posicion no existe.");
                return -1;
            }
            else
            {
                Node aux = _lead;
                for (int i = 1; i <= index; i++)
                {
                    aux = aux.NextNode;
                }
                Object res = aux.Data;
                return res;
            }
        }

        /// <summary>
        /// Metodo que imprime la lista con el siguiente formato:
        /// _data - _data - _data
        /// </summary>
        public void Print()
        {
            if (IsListEmpty())
            {
                Console.WriteLine("Lista vacia.");
                return;
            }

            Node actual = _lead;

            Console.Write(actual.Data);

            while (actual.NextNode != null)
            {
                Console.Write(" - " + actual.NextNode.Data);
                actual = actual.NextNode;
            }

            Console.WriteLine("\n");
        }

    }
}
