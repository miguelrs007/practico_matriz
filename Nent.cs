using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._1_practico_matricez
{
    class NEnt
    {
        private int n;
        public NEnt()
        {
            n = 0;
        }
        public void cargar(int dato)
        {
            n = dato;
        }
        public int get()
        {
            return n;
        }
        public bool verifpri()
        {
            int  r, c;
            c = 0;
            for (int i = 1; i <= n; i++)
            {
                r = n % i;
                if (r == 0)
                    c++;
            }
            return (c == 2);
        }
        public bool verifpar()
        {
            return (n % 2 == 0);
        }
        public bool VerifFibo()
        {
            int a, b, c;
            a = 0; b = 1;
            c = -1;
            while (a < n)
            {
                a = b + c;
                c = b;
                b = a;
            }
            return (a == n);
        }
        // VERIFICAR SI CAPICUA
        public bool EsCapicua(int num)
        {
            int numreverso, numoriginal;
            numreverso = 0; numoriginal = num;
            while (num > 0)
            {
                int digito = num % 10;
                numreverso = (numreverso * 10) + digito;
                num = num / 10;
            }
            return (numoriginal == numreverso);
        }
    }
}