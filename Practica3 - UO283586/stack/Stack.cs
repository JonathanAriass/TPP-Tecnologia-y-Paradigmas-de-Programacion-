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

        public Stack(uint maxNumberOfElements)
        {
            if (maxNumberOfElements == 0)
            {
                throw new ArgumentException("Numero maximo de elementos ilogico.");
            }
            lista = new List();
            this._maxNumberOfElements = maxNumberOfElements;
            Debug.Assert(this.IsEmpty);
        }

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


        public Object Pop()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException("No hay nada en el stack (imposible hacer pop)");
            }

            Object res = this.lista.GetElement(0);
            this.lista.Remove(res);

            Debug.Assert(!this.IsFull);
            Debug.Assert(res != null);

            return res;
        }

        public int GetSize()
        {
            return this.lista.NumberOfElements;
        }


        private void Invariant()
        {
            Debug.Assert(this.GetSize() <= _maxNumberOfElements);
        }

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
         * Pillar el codigo de algorithms y poner un breakpoint viendo que hace.
         * 
         * 
         */
    }

}