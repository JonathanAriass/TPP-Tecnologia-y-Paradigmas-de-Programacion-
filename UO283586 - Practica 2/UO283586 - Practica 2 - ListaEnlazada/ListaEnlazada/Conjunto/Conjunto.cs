using System;
using System.Text;

namespace ConjuntoLista
{
    public class Conjunto
    {
        Node _lead; //  Cabeza del conjunto
        int _numberOfElements; // Numero de elemtos del conjunto

        /// <summary>
        /// Propiedad de campos del numero de elementos del conjunto
        /// </summary>
        public int NumberOfElements
        {
            get
            {
                return this._numberOfElements;
            }
        }

        /// <summary>
        /// Constructor del conjutno que inicializara el campo <em>_lead</em> a null y el
        /// <em>_numberOfElements</em> a 0.
        /// </summary>
        public Conjunto()
        {
            _lead = null;
        }

        /// <summary>
        /// Metodo que comprueba si el conjunto esta vacio.
        /// </summary>
        /// <returns></returns>
        private bool IsConjuntoEmpty()
        {
            return NumberOfElements == 0;
        }

        /// <summary>
        /// Metodo que añade un nodo al final del conjunto
        /// </summary>
        /// <param name="node">Nodo a añadir al conjunto</param>
        public bool AddNode(Object node)
        {
            if (node == null)
            {
                Console.WriteLine("El elemento a añadir es incorrecto.");
                return false;
            }
            if (IsConjuntoEmpty())
            {
                _lead = new Node(node);
                _numberOfElements++;
#if DEBUG
                Console.WriteLine("Añadiendo nodo: " + node);
#endif

                return false;
            }
            else
            {
                if (Contains(node))
                {
                    Console.WriteLine("El elemento ya esta en el conjunto.");
                    return false;
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

                    return true;
                }
            }
        }

        /// <summary>
        /// Metodo que añade un nodo en un indice pasado como parametro.
        /// </summary>
        /// <param name="node">Nodo a añadir al conjunto</param>
        /// <param name="index">Indice (posicion) donde añadir el nodo</param>
        public bool AddNode(Object node, uint index)
        {
            if (node == null)
            {
                Console.WriteLine("El elemento a añadir es incorrecto.");
                return false;
            }
            if (IsConjuntoEmpty())
            {
                _lead = new Node(node);
                _numberOfElements++;
#if DEBUG
                Console.WriteLine("Añadiendo nodo: " + node + ", en posicion: " + 1);
#endif

                return false;
            }
            else if (index >= _numberOfElements)
            {
                Console.WriteLine("El indice indicado no es alcanzable.");
                return false;
            }
            else
            {
                if (Contains(node))
                {
                    Console.WriteLine("El elemento ya esta en el conjunto.");
                    return false;
                }
                else
                {
                    if (index == 0)
                    {
                        Node copy = _lead;
                        _lead = new Node(node);
                        _lead.NextNode = copy;
                        _numberOfElements++;
                        return true;
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

                        return true;
                    }
                }
            }
        }

        /// <summary>
        /// Metodo que elimina en nodo del conjunto pasando el campo <em>_data</em> del
        /// nodo a eliminar, de esta manera se podra encontrar el nodo en el conjunto y asi
        /// poder eliminarlo.
        /// </summary>
        /// <param name="node">Campo <em>_data</em> del nodo a eliminar.</param>
        public bool Remove(Object node)
        {
            if (node == null)
            {
                Console.WriteLine("El elemento a eliminar es invalido.");
                return false;
            }
            if (IsConjuntoEmpty())
            {
                return false;
            }

            if (_lead.Data.Equals(node))
            {
                _lead = _lead.NextNode;
                _numberOfElements--;
                Console.WriteLine("Eliminando el nodo cabeza del conjunto.");
                return true;
            }

            Node aux = _lead;
            while (aux.NextNode != null)
            {
                if (aux.NextNode.Data.Equals(node))
                {
                    aux.NextNode = aux.NextNode.NextNode;
                    _numberOfElements--;
                    Console.WriteLine("Eliminando el nodo, " + node + " del conjunto.");
                    return true;
                }

                aux = aux.NextNode;
            }

            Console.WriteLine("El nodo: " + node + ", no existe en el conjunto.");
            return false;
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
        /// Metodo que comprueba si un elemento pasado como parametro esta
        /// en el conjunto.
        /// </summary>
        /// <param name="node">Elemento a comprobar si existe en el conjunto.</param>
        /// <returns>true o false, dependiendo de si esta en el conjunto o no respectivamente</returns>
        public bool Contains(Object node)
        {
            Node aux = _lead;
            for (int i = 1; i <= NumberOfElements; i++)
            {
                if (aux.Data.Equals(node))
                {
                    return true;
                }
                aux = aux.NextNode;

            }
            return false;
        }

        /// <summary>
        /// Metodo que imprime el conjunto con el siguiente formato:
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
            if (IsConjuntoEmpty())
            {
                Console.WriteLine("Conjunto vacio.");
                return "";
            }

            StringBuilder sb = new StringBuilder();

            Node actual = _lead;

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
        /// Operador que permite añadir un elemento a un conjunto.
        /// </summary>
        /// <param name="c">Conjunto al que añadir</param>
        /// <param name="node">Elemento a añadir</param>
        /// <returns>true en caso de que se añada correctamente, false en caso contrario</returns>
        public static bool operator +(Conjunto c, Object node)
        {
            return c.AddNode(node);
        }


        /// <summary>
        /// Operador que permite eliminar un elemento a un conjunto
        /// </summary>
        /// <param name="c">Conjunto del que eliminar</param>
        /// <param name="node">Elemento a eliminar</param>
        /// <returns>true en caso de que se elimine correctamente, false en caso contrario</returns>
        public static bool operator -(Conjunto c, Object node)
        {
            return c.Remove(node);
        }


        /// <summary>
        /// Operador que busca un elemento del conjunto pasando el indice
        /// </summary>
        /// <param name="index">Indice del conjunto del que obtener el elemento</param>
        /// <returns>Elemento encontrado en el conjunto</returns>
        public Object this[uint index]
        {
            get { return this.GetElement(index); }
        }


        /// <summary>
        /// Metodo que hace la union de conjuntos
        /// </summary>
        /// <param name="c2">Conjunto del cual obtener los elementos para hacer la union</param>
        /// <returns>Conjunto final despues de hacer la union de conjuntos</returns>
        public Conjunto UnionConjuntos(Conjunto c2)
        {
            for (uint i = 0; i < c2.NumberOfElements; i++)
            {
                if (!this.Contains(c2.GetElement(i)))
                {
                    this.AddNode(c2.GetElement(i));
                }
            }

            return this;
        }


        /// <summary>
        /// Operador que hace la union de conjuntos
        /// </summary>
        /// <param name="c1">Conjunto 1</param>
        /// <param name="c2">Conjunto 2</param>
        /// <returns>Conjunto resultado de hacer la union de conjuntos</returns>
        public static Conjunto operator |(Conjunto c1, Conjunto c2)
        {
            return c1.UnionConjuntos(c2);
        }


        /// <summary>
        /// Metodo que calcula la interseccion de conjuntos
        /// </summary>
        /// <param name="c2">Conjunto al que aplicar la interseccion</param>
        /// <returns>Conjunto resultado despues de hacer la interseccion</returns>
        public Conjunto InterseccionConjuntos(Conjunto c2)
        {
            Conjunto aux = new Conjunto();
            for (uint i = 0; i < c2.NumberOfElements; i++)
            {
                if (this.Contains(c2.GetElement(i)))
                {
                    aux.AddNode(c2.GetElement(i));
                }
            }
            return aux;
        }


        /// <summary>
        /// Operador que realiza la interseccion de conjuntos
        /// </summary>
        /// <param name="c1">Conjunto 1</param>
        /// <param name="c2">Conjunto 2</param>
        /// <returns>Conjunto resultado despues de hacer la interseccion de conjuntos</returns>
        public static Conjunto operator &(Conjunto c1, Conjunto c2)
        {
            return c1.InterseccionConjuntos(c2);
        }


        /// <summary>
        /// Metodo que calcula la diferencia de conjuntos
        /// </summary>
        /// <param name="c2">Conjunto al que aplicar la diferencia</param>
        /// <returns>Conjunto resultado de aplicar la diferencia de conjuntos</returns>
        public Conjunto DiferenciaConjuntos(Conjunto c2)
        {
            Conjunto aux = new Conjunto();
            for (uint i = 0; i < c2.NumberOfElements; i++)
            {
                if (!this.Contains(c2.GetElement(i)))
                {
                    aux.AddNode(c2.GetElement(i));
                }
            }
            return aux;
        }

        
        /// <summary>
        /// Operador que realiza la diferencia de conjuntos
        /// </summary>
        /// <param name="c1">Conjunto 1</param>
        /// <param name="c2">Conjunto 2</param>
        /// <returns>Conjunto despues de realizar la diferencia de conjuntos</returns>
        public static Conjunto operator -(Conjunto c1, Conjunto c2)
        {
            return c1.DiferenciaConjuntos(c2);
        }

        public static bool operator ^(Conjunto c1, object node)
        {
            return c1.Contains(node); 
        }
    }
}
