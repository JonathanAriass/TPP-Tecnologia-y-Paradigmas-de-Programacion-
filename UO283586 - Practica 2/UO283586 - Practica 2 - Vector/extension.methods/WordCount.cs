using System;
using System.Text;
using System.Text.RegularExpressions;

namespace TPP.Laboratory.ObjectOrientation.Lab02 {

    static class StringExtesion {

        // Se crea una clase estatico
        // Se crea un metodo estatico
        // Se pasa this como parametro

        static public uint CountWords(this string str) {
            // static type of var?
            //var se puede usar por la inferencia de tipos. IMPORTANTE NO ES DINAMICO
            var lines = Regex.Split(str, "\r|\n|[.]|[,]|[ ]");

            uint numberOfWords = 0;
            foreach (var line in lines)
                if (!String.IsNullOrEmpty(line) && !String.IsNullOrWhiteSpace(line))
                    numberOfWords++;
            return numberOfWords;
        }

    }


}
