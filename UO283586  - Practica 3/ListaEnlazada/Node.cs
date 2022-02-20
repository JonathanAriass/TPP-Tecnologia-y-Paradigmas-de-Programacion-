using System;
using System.Collections.Generic;
using System.Text;

namespace ListaEnlazada
{
    /// <summary>
    /// Clase que representa un nodo que almacena informacion de tipo Object y la referencia
    /// a otro nodo.
    /// Esta clase se usará en la clase <em>List.cs</em> donde se implementa una lista
    /// enlazada simple de estos nodos.
    /// </summary>
    internal class Node
    {

        Object data; // Campo que contiene el valor del nodo
        Node nextNode; // Campo que contiene la referencia al proximo nodo

        /// <summary>
        /// Constructor del nodo que tiene un parametro <em>value</em> de tipo Object,
        /// que se pasara al campo <em>data</em>.
        /// </summary>
        /// <param name="value">Parametro que contiene el valor de tipo Object a pasar al campo data.</param>
        public Node(Object value)
        {
            this.data = value;
            this.nextNode = null;
        }
        /// <summary>
        /// Constructor del nodo que a parte del parametro <em>value</em> tiene un parametro <em>nextOne</em>
        /// que es un <em>Node</em> que se pasara al campo <em>nextNode</em>.
        /// </summary>
        /// <param name="value">Parametro que contiene el valor de tipo Object a pasar al campo data.</param>
        /// <param name="nextOne">Parametro que es un Nodo a pasar al campo nextNode.</param>
        public Node(Object value, Node nextOne)
        {
            this.data = value;
            this.nextNode = nextOne;
        }

        /// <summary>
        /// Propiedad que representa la referencia al siguiente Nodo de la lista
        /// </summary>
        public Node NextNode
        {
            get
            {
                return this.nextNode;
            }
            internal set
            {
                nextNode = value;
            }
        }

        /// <summary>
        /// Propiedad que representa la informacion almacenada en el Nodo
        /// </summary>
        public Object Data
        {
            get
            {
                return this.data;
            }
        }

    }
}
