using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ListaEnlazada
{
    internal class ListEnumerator<T> : IEnumerator<T>
    {

        int index; // Indice del elemento para el Enumerator
        
        T element; // Elemento actual de la lista
        Lista<T> lista; // Lista completa que contiene los elementos


        /// <summary>
        /// Constructor del Enumerator de la lista que recibe como parametro la lista completa
        /// </summary>
        /// <param name="list">Lista completa</param>
        public ListEnumerator(Lista<T> list)
        {
            index = -1;
            this.lista = list;
            element = list.GetElement(0);
        }

        /// <summary>
        /// Propiedad que devuelve el elemento de la actual iteración
        /// </summary>
        T IEnumerator<T>.Current
        {
            get { return element; }
        }

        /// <summary>
        /// Propiedad que se debe de implementar por derivar IEnumerator (version generica)
        /// de la version mas general que devuelve Object
        /// </summary>
        object IEnumerator.Current
        {
            get { return element; }
        }

        /// <summary>
        /// Metodo que va itera hacia el proximo elemento de la lista
        /// </summary>
        /// <returns>false en caso de que no se pueda iterar, true en caso contrario</returns>
        public bool MoveNext()
        {
            if (index + 1 >= lista.NumberOfElements)
            {
                return false;
            }
            if (this.lista.GetElement((uint)index + 1) == null)
            {
                return false;
            }
            else
            {
                element = this.lista.GetElement((uint)index + 1);
                index++;
            }
            return true;
        }

        /// <summary>
        /// Metodo que resetea el Enumerator de la lista
        /// </summary>
        public void Reset()
        {
            index = -1;
            element = this.lista.GetElement(0);
        }

        public void Dispose()
        {
        }

    }
}
