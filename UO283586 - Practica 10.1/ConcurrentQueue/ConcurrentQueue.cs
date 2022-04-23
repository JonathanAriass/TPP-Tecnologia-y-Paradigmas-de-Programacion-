using ListaEnlazada;
using System;

namespace ConcurrentQueue
{
    public class ConcurrentQueue<T>
    {

        private Lista<T> cola;

        public int NumberOfElements
        {
            get { return cola.NumberOfElements; }
        }

        public ConcurrentQueue() {
            this.cola = new Lista<T>();
        }

        public bool IsEmpty() {
            return NumberOfElements == 0;
        }

        public void Enqueue(T elem) {
            lock (cola) {
                cola.Add(elem);
            }
        }

        public T Dequeue() {
            lock (cola) {
                T aux = cola.GetElement(0);
                cola.Remove(aux);
                return aux;
            }
        }

        public T Peek() {
            lock (cola) {
                return cola.GetElement(0);
            }
        }

    }
}
