using System;

namespace TPP.Laboratory.ObjectOrientation.Lab02
{
    public class Vector
    {

        Object[] vector;
        int _size;

        public int Size
        {
            get 
            {
                return this._size;
            }
        }

        /// <summary>
        /// Constructor del vector que tiene como parametro el tamaño de este.
        /// </summary>
        /// <param name="size">Tamaño del vector a crear.</param>
        public Vector()
        {
            this.vector = new Object[100];
            _size = 0;
        }

        /// <summary>
        /// Metodo que añade un elemento al vector
        /// </summary>
        /// <param name="value">Elemento a añadir</param>
        public void Add(int value)
        {
            vector[Size] = value;
            _size++;
        }

        /// <summary>
        /// Metodo que obtiene el elemento de una posicion pasada como parametro
        /// </summary>
        /// <param name="v">Posicion del vector de la cual obtener el elemento</param>
        /// <returns></returns>
        public Object GetElement(int v)
        {
            if (Size == 0)
            {
                throw new ArgumentException("No hay elementos en el vector");
            }
            if (v < 0 || v > this.Size)
            {
                throw new ArgumentException("Indice invalido");
            }
            else 
            {
                return vector[v];
            }
        }

        /// <summary>
        /// Metodo que dada una posicion del vector cambia el valor de dicha posicion del vector
        /// </summary>
        /// <param name="v">Posicion a cambiar</param>
        /// <param name="value">Valor actualizado</param>
        public void SetElement(int v, int value)
        {
            if (Size == 0)
            {
                throw new ArgumentException("No hay elementos en el vector");
            }
            if (v < 0 || v >= Size)
            {
                throw new ArgumentException("Error");
            }
            else
            {
                vector[v] = value;
            }
        }


    }
}
