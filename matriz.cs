using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._1_practico_matricez
{
    class matriz
    {
        const int maxf=60;
        const int maxc=60;
        private int[,]x;
        private int f, c;
        public matriz()
        {
            f = 0;c = 0;
            x = new int[maxf, maxc];
        }
        public void cargar(int nf,int nc,int a,int b)
        {
            f = nf;c = nc;
            Random r = new Random();
            for (int i = 1; i <= f; i++)
                for (int j = 1; j <= c; j++)
                    x[i, j] = r.Next(a, b + 1);
        }
        public string descargar()
        {
            string s = "";
            for (int i = 1; i <= f; i++)
            {
                for (int j = 1; j <= c; j++)
                    s = s + x[i, j] + "\x0009";
                s = s + "\x000d" + "\x000a";
            }
            return s;
        }
        public double ej1acumprimos()
        {
            int pf, pc; double acu = 0;
            NEnt n = new NEnt();
            bool b = true;
            for (pf = f; pf >= 1; pf--)
                for (pc = c; pc >= 1; pc--) 
                {
                    n.cargar(x[pf, pc]);
                    if (b)
                    {
                        if (n.verifpri())
                            acu = acu - Math.Sqrt(x[pf, pc]);    
                    }
                    else
                    {
                        if (n.verifpri())
                            acu = acu + Math.Sqrt(x[pf, pc]);
                    }
                    b = !b;  
                }
            return acu;
        }
        //frecuencia de un numero
        public int frecuencia(int ele)
        {
            int f1, c1, fr;
            fr = 0;
            for (f1 = 1; f1 <= f; f1++)
                for (c1 = 1; c1 <= c; c1++)
                {
                    if (x[f1, c1] == ele)
                        fr++;
                }
            return fr;
        }
        public int ej2elemnorepcont()
        {
            int f1, c1, s;
            s = 0;
            for (f1 = 1; f1 <= f; f1++)
                for (c1 = 1; c1 <= c; c1++)
                    if (frecuencia(x[f1, c1])==1)
                        s++;
            return s;
        }
        //busqueda secuencial
        public bool busqsec(int ele)
        {
            bool b = false;
            int c1 = 1;
            while (c1 <= c && (b == false))
            {
                int f1 = 1;
                while (f1 <= f && (b == false))
                {
                    if (x[f1, c1] == ele)
                        b = true;
                    f1++;
                }
                c1++;
            }
            return b;
        }
        public bool ej3xsubdex2(matriz m2)
        {
            bool b = true;
            int ele, f2, c2;
            for (f2 = 1; f2 <= f; f2++)
            {
                for (c2 = 1; c2 <= c; c2++)
                {
                    ele = x[f2, c2];
                    if (!(m2.busqsec(ele)))
                    {
                        b = false;
                        break;
                    }
                }
            }
            return b;
        }
        public void intercambio(int a, int b, int c, int d)
        {
            int aux = x[a, b];
            x[a, b] = x[c, d];
            x[c, d] = aux;
        }
        public int cantprimosfil(int nf)
        {
            NEnt n = new NEnt();
            int i,s=0;
            for (i = 1; i <= c; i++)
            {
                n.cargar(x[nf, i]);
                if (n.verifpri())
                    s++;
            }
            return s;
        }
        public void interfils(int f1, int f2)
        {
            for (int c1 = 1; c1 <= c; c1++)
                intercambio(f1, c1, f2, c1);
        }
        public void ej4interfilsmayprim()
        {
            int p, d;
            for (p = 1; p <= f - 1; p++)
                for (d = p + 1; d <= f; d++)
                    if (cantprimosfil(p) > cantprimosfil(d))
                        interfils(d, p);
        }
        public void ej5ordporfrecuencia()
        {
            int i;
            for (int c1 = c; c1 >= 1; c1--)
                for (int f1 = 1; f1 <= f; f1++)
                    for (int cd1 = c1; cd1 >= 1; cd1--)
                    {
                        if (cd1 == c1)
                            i = f1;
                        else
                            i = 1;
                        for (int fd1 = i; fd1 <= f; fd1++)
                        {
                            if (frecuencia(x[f1, c1]) < frecuencia(x[fd1, cd1]) || 
                               frecuencia(x[f1, c1]) == frecuencia(x[fd1, cd1]) && x[fd1, cd1] >= x[f1, c1])
                                intercambio(f1, c1, fd1, cd1);
                        }
                    }
        }
        public void ej6intercalarfibo()
        {
            int pf, pc, df,dc, idc; bool b = true;
            NEnt n1 = new NEnt();
            NEnt n2 = new NEnt();
            for (pf = f; pf >= 1; pf--)
                for (pc = 1; pc <= c; pc++)
                {
                    if(b)
                    for (df = pf; df >= 1; df--)
                        {
                            if (df == pf)
                                idc = pc;
                            else
                                idc = 1;
                            for (dc = idc; dc <= c; dc++)
                            {
                                n1.cargar(x[df, dc]);
                                n2.cargar(x[pf, pc]);
                                if (n1.VerifFibo() && !n2.VerifFibo() ||
                                  n1.VerifFibo() && n2.VerifFibo() && x[df, dc] < x[pf, pc] ||
                                  !n1.VerifFibo() && !n2.VerifFibo() && x[df, dc] < x[pf, pc])
                                    intercambio(df, dc, pf, pc);
                            }
                        }
                    else
                        for (df = pf; df >= 1; df--)
                        {
                            if (df == pf)
                                idc = pc;
                            else
                                idc = 1;
                            for (dc = idc; dc <= c; dc++)
                            {
                                n1.cargar(x[df, dc]);
                                n2.cargar(x[pf, pc]);
                                if (!n1.VerifFibo() && n2.VerifFibo() ||
                                  !n1.VerifFibo() && !n2.VerifFibo() && x[df, dc] < x[pf, pc] ||
                                  n1.VerifFibo() && n2.VerifFibo() && x[df, dc] < x[pf, pc])
                                    intercambio(df, dc, pf, pc);
                            }
                        }
                    b = !b;
                }
        }
        public void ej7ordenarTSD1()
        {
            int pf, pc, df, dc, ic;
            for (pf = 1; pf <= f; pf++)
                for (pc = pf + 1; pc <= c; pc++)
                    for (df = pf; df <= f; df++)
                    {
                        if (pf == df)
                            ic = pc;
                        else
                            ic = df + 1;
                        for (dc = ic; dc <= c; dc++)
                        {
                            if (x[df, dc] < x[pf, pc])
                                intercambio(pf, pc, df, dc);
                        }
                    }
        }
        public void ej8segmTIDparimpar()
        {
            int i;
            NEnt n1 = new NEnt(); NEnt n2 = new NEnt();
            for (int c1 = 2; c1 <= c; c1++)
                for (int f1 = f; f1 >= f - (c1 - 2); f1--)
                    for (int c2 = 2; c2 <= c; c2++)
                    {
                        if (c2 == c1)
                            i = f1;
                        else
                            i = f;
                        for (int f2 = i; f2 >= f - (c2 - 2); f2--)
                        {
                            n1.cargar(x[f2, c2]); n2.cargar(x[f1, c1]);
                            if ((!n1.verifpar() && n2.verifpar())||
                                (n1.verifpar() && n2.verifpar() && x[f2, c2] >= x[f1, c1])||
                                (!n1.verifpar() && !n2.verifpar() && x[f2, c2] >= x[f1, c1]))
                                intercambio(f1, c1, f2, c2);
                        }
                    }
        }
        public void ej9orddiagonaSECdesc()
        {
            int fp, fd;
            for (fp = 1; fp < f; fp++)
                for (fd = fp + 1; fd <= f; fd++)
                    if (x[fd, f - fd + 1] < x[fp, f - fp + 1])
                        intercambio(fd, f - fd + 1, fp, f - fp + 1);
        }
        public int mayfil(int nf)
        {
            int i, may;
            may = 0;
            for (i = c; i >=c-nf+1 ; i--)
            {
                if (x[nf, i] > may)
                    may = x[nf, i];
            }
            return may;
        }
        public void ej10mayfils()
        {
            int f1;
            for (f1 = 1; f1 <= f; f1++)
                x[f1, c + 1] = mayfil(f1);
            c++;
        }
    }
}
