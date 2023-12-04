using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._1_practico_matricez
{
    class Vector
    {
        //--------------------------------------------
        const int MAX = 50;
        private int[] v;
        private int n;

        // CONSTRUCTOR---------------------------------
        public Vector()
        {
            n = 0;
            v = new int[MAX];
        }

        // CARGAR--------------------------------------
        public void Cargar(int n1, int a, int b)
        {
            Random r = new Random();
            int i;
            n = n1;
            for (i = 1; i <= n; i++)
            {
                v[i] = r.Next(a, b);
            }
        }

        public void Cargar(int ele)
        {
            n++;
            v[n] = ele;
        }

        // DESCARGAR-----------------------------------
        public string Descargar()
        {
            string s = "";
            int i;
            for (i = 1; i <= n; i++)
            {
                s = s + v[i] + " | ";
            }
            return s;
        }

        // AUXILIARES------------------------
        // BUSQUEDA SECUENCIAL-----------------------------------
        public bool SeEncuentra(int nbus)
        {
            int i = 1;
            bool b = false;
            while ((i <= n) && (b == false))
            {
                if (v[i] == nbus)
                {
                    b = true;
                }
                i++;
            }
            return b;
        }

        // ORDENAMIENTO X INTERCAMBIO---------------------------
        public void Inter(int p1, int p2)
        {
            int aux;
            aux = v[p1];
            v[p1] = v[p2];
            v[p2] = aux;
        }
        public void OrdXInter()
        {
            int i, j;
            for (i = 1; i <= n - 1; i++)
            {
                for (j = i + 1; j <= n; j++)
                {
                    if (v[j] < v[i])
                    {
                        Inter(j, i);
                    }
                }
            }
        }

        // ERROR POR RANGO-----------------------------------------------
        public string FueraDeRango()
        {
            string ms = "INGRESE UN VALOR DENTRO DEL RANGO";
            return ms;
        }
        public int RangoMax()
        {
            int rango = n;
            return rango;
        }

        public string Ordenar()
        {
            string ms = "POR FAVOR ORDENE EL VECTOR PRIMERO";
            return ms;
        }

        public bool VerifOrden()
        {
            int i = 1;
            bool b = true;
            while ((i < n) && (b == true))
            {
                if (!(v[i] <= v[i + 1]))
                {
                    b = false;
                }
                i++;
            }
            return b;
        }

        //-------------------EJERCICIOS DEL PRÁCTICO-------------------
        //-------------------------------------------------------------

        // PARTE 1-------------------------------------

        // EJERCICIO 1------------------------
        public void Fibo(int ne)
        {
            int x, y, z;
            n = ne;
            x = -1; y = 1;
            for (int i = n; i >= 1; i--)
            {
                z = x + y;
                v[i] = z;
                x = y; y = z;
            }
        }

        // EJERCICIO 2-----------------   
        public int PosSubM()
        {
            int pos, subm;
            pos = 0;
            for (int i = 1; i <= n; i++)
            {
                subm = v[i] % i;
                if (subm == 0)
                {
                    pos++;
                }
            }
            return pos;
        }

        // EJERCICIO 3------------------------
        public int PosMultM(int m)
        {
            int pos, mayor;
            mayor = 0;
            for (int i = 1; i <= n / 2; i++)
            {
                pos = i * m;
                if (v[pos] > mayor)
                {
                    mayor = v[pos];
                }
            }
            return mayor;
        }

        // EJERCICIO 4---------------------------
        public double MediaPosMult(int m)
        {
            int pos, suma, naux;
            double media;
            suma = 0; naux = 0;
            for (int i = 1; i <= n / 2; i++)
            {
                pos = i * m;
                suma = suma + v[pos];
                if (pos <= n)
                {
                    naux++;
                }
            }
            media = (double)suma / (double)naux;
            return media;
        }

        // EJERCICIO 5---------------------------------
        public void SelecPyNP(Vector r1, Vector r2)
        {
            NEnt na = new NEnt();
            for (int i = 1; i <= n; i++)
            {
                na.cargar(v[i]);
                if (na.verifpri())
                {
                    r1.Cargar(v[i]);
                }
                else
                {
                    r2.Cargar(v[i]);
                }
            }
        }

        // EJERCICIO 6------------------------
        public void InvertirV()
        {
            int naux = n;
            for (int i = 1; i <= n / 2; i++)
            {
                int aux;
                aux = v[i];
                v[i] = v[naux];
                v[naux] = aux;
                naux--;
            }
        }

        // EJERCICIO 7----------------------------
        public bool TodosIguales()
        {
            int i = 2;
            bool b = true;
            while ((i <= n) && (b == true))
            {
                if (!(v[1] == v[i]))
                {
                    b = false;
                }
                i++;
            }
            return b;
        }

        // EJERCICIO 8-------------------------------------        
        public void Intersec(Vector ve, Vector r)
        {
            for (int i = 1; i <= n; i++)
            {
                if (ve.SeEncuentra(v[i]))
                {
                    r.Cargar(v[i]);
                }
            }
        }

        // EJERCICIO 9---------------------------------
        public void UnionEle(Vector ve, Vector vr)
        {
            for (int i = 1; i <= n; i++)
            {
                vr.Cargar(v[i]);
            }
            for (int i = 1; i <= ve.n; i++)
            {
                if (!(vr.SeEncuentra(ve.v[i])))
                {
                    vr.Cargar(ve.v[i]);
                }
            }
        }

        // EJERCICIO 10-------------------------------
        public bool EstaOrdenado(int a, int b)
        {
            int i = a;
            bool bandera = true;
            while ((i < b) && (bandera == true))
            {
                if (!(v[i] <= v[i + 1]))
                {
                    bandera = false;
                }
                i++;
            }
            return bandera;
        }

        // PARTE 2-------------------------------------

        // EJERCICIO 1---------------------------------
        public void InserVPos(Vector y, int p)
        {
            int d, i;
            d = n; i = 1;
            while (d >= p)
            {
                v[d + y.n] = v[d];
                d--;
            }
            for (i = 1; i <= y.n; i++)
            {
                v[p] = y.v[i];
                n++; p++;
            }
        }

        // EJERCICIO 2---------------------------------
        public void ElimElePos(int a, int b)
        {
            int i, aux;
            i = a; aux = b;
            while ((i <= b) && (aux <= n))
            {
                aux++;
                v[i] = v[aux];
                i++;
            }
            n = n - b + (a - 1);
        }

        // EJERCICIO 3---------------------------------
        public void DuplicarEle()
        {
            int aux, c;
            aux = n + n;
            for (int i = n; i <= 1; i--)
            {
                c = 1;
                while (c <= 2)
                {
                    v[aux] = v[i];
                    aux--; c++;
                }
            }
            n = n + n;
        }

        // EJERCICIO 4---------------------------------
        public void OrdBurbuja(int a, int b)
        {
            int t, d;
            for (t = b; t > a; t--)
            {
                for (d = a; d < t; d++)
                {
                    if (v[d] > v[d + 1])
                    {
                        Inter(d, d + 1);
                    }
                }
            }
        }

        // EJERCICIO 5---------------------------------        
        public int EleMenosRep(int a, int b)
        {
            int menorfrec, elemenosrep;
            menorfrec = 51; elemenosrep = 51;
            for (int i = 1; i <= n; i++)
            {
                int cont = 0;
                for (int j = 1; j <= n; j++)
                {
                    if (v[i] == v[j])
                    {
                        cont++;
                    }
                }
                if (cont < menorfrec)
                {
                    menorfrec = cont;
                    elemenosrep = v[i];
                }
            }
            return elemenosrep;
        }

        // EJERCICIO 6---------------------------------
        public void FrecDistAB(Vector e, Vector f, int a, int b)
        {
            int i, c, ele, frec;
            i = a; c = 0;
            while (i <= b)
            {
                ele = v[i]; frec = 0;
                while (ele == v[i])
                {
                    i++; frec++;
                }
                c++;
                e.v[c] = ele; f.v[c] = frec;
            }
            e.n = c; f.n = c;
        }


        // EJERCICIO 7---------------------------------
        public void segCyNC()
        {
            int d, p;
            NEnt n1 = new NEnt();
            NEnt n2 = new NEnt();
            for (p = 1; p <= n - 1; p++)
            {
                for (d = 1 + p; d <= n; d++)
                {
                    if ((n1.EsCapicua(v[d]) && !n2.EsCapicua(v[p])) ||
                            (n1.EsCapicua(v[d]) && n2.EsCapicua(v[p]) && (v[d] < v[p])) ||
                            (!n1.EsCapicua(v[d]) && !n2.EsCapicua(v[p]) && (v[d] < v[p])))
                    {
                        Inter(d, p);
                    }

                }
            }
        }

        // EJERCICIO 8---------------------------------

        public void IntercalarPyNPord(int a, int b)
        {
            int p, d;
            NEnt n1 = new NEnt();
            NEnt n2 = new NEnt();
            bool bandera = true;
            for (p = a; p < b; p++)
            {
                if (bandera)
                {
                    for (d = p + 1; d <= b; d++)
                    {
                        n1.cargar(v[d]); n2.cargar(v[p]);
                        if (n1.verifpri() && !n2.verifpri() ||
                            n1.verifpri() && n2.verifpri() && v[d] < v[p] ||
                            !n1.verifpri() && !n2.verifpri() && v[d] < v[p])
                        {
                            Inter(d, p);
                        }
                    }
                }
                else
                {
                    for (d = p + 1; d <= b; d++)
                    {
                        n1.cargar(v[d]); n2.cargar(v[p]);
                        if (!n1.verifpri() && n2.verifpri() ||
                            !n1.verifpri() && !n2.verifpri() && v[d] < v[p] ||
                            n1.verifpri() && n2.verifpri() && v[d] < v[p])
                        {
                            Inter(d, p);
                        }
                    }
                }
                bandera = !bandera;
            }
        }
        public void IntercalarParyNoParord(int a, int b)
        {
            int p, d;
            NEnt n1 = new NEnt();
            NEnt n2 = new NEnt();
            bool bandera = true;
            for (p = a; p < b; p++)
            {
                if (bandera)
                {
                    for (d = p + 1; d <= b; d++)
                    {
                        n1.cargar(v[d]); n2.cargar(v[p]);
                        if (n1.verifpar() && !n2.verifpar() ||
                            n1.verifpar() && n2.verifpar() && v[d] < v[p] ||
                            !n1.verifpar() && !n2.verifpar() && v[d] < v[p])
                        {
                            Inter(d, p);
                        }
                    }
                }
                else
                {
                    for (d = p + 1; d <= b; d++)
                    {
                        n1.cargar(v[d]); n2.cargar(v[p]);
                        if (!n1.verifpar() && n2.verifpar() ||
                            !n1.verifpar() && !n2.verifpar() && v[d] < v[p] ||
                            n1.verifpar() && n2.verifpar() && v[d] < v[p])
                        {
                            Inter(d, p);
                        }
                    }
                }
                bandera = !bandera;
            }
        }
        public void IntercalarfiboNOfibo(int a, int b)
        {
            int p, d;
            NEnt n1 = new NEnt();
            NEnt n2 = new NEnt();
            bool bandera = true;
            for (p = a; p < b; p++)
            {
                if (bandera)
                {
                    for (d = p + 1; d <= b; d++)
                    {
                        n1.cargar(v[d]); n2.cargar(v[p]);
                        if (n1.VerifFibo() && !n2.VerifFibo() ||
                            n1.VerifFibo() && n2.VerifFibo() && v[d] < v[p] ||
                            !n1.VerifFibo() && !n2.VerifFibo() && v[d] < v[p])
                        {
                            Inter(d, p);
                        }
                    }
                }
                else
                {
                    for (d = p + 1; d <= b; d++)
                    {
                        n1.cargar(v[d]); n2.cargar(v[p]);
                        if (!n1.VerifFibo() && n2.VerifFibo() ||
                            !n1.VerifFibo() && !n2.VerifFibo() && v[d] < v[p] ||
                            n1.VerifFibo() && n2.VerifFibo() && v[d] < v[p])
                        {
                            Inter(d, p);
                        }
                    }
                }
                bandera = !bandera;
            }
        }
        public void segmentarParyNoParord(int a, int b)
        {
            int p, d;
            NEnt n1 = new NEnt();
            NEnt n2 = new NEnt();
            for (p = a; p < b; p++)
                for (d = p + 1; d <= b; d++)
                {
                    n1.cargar(v[d]); n2.cargar(v[p]);
                    if (n1.verifpar() && !n2.verifpar() ||
                        n1.verifpar() && n2.verifpar() && v[d] < v[p] ||
                        !n1.verifpar() && !n2.verifpar() && v[d] < v[p])
                        Inter(d, p);
            }
        }
        public void segmentarfiboNofibo(int a, int b)
        {
            int p, d;
            NEnt n1 = new NEnt();
            NEnt n2 = new NEnt();
            for (p = a; p < b; p++)
                for (d = p + 1; d <= b; d++)
                {
                    n1.cargar(v[d]); n2.cargar(v[p]);
                    if (n1.VerifFibo() && !n2.VerifFibo() ||
                        n1.VerifFibo() && n2.VerifFibo() && v[d] < v[p] ||
                        !n1.VerifFibo() && !n2.VerifFibo() && v[d] < v[p])
                        Inter(d, p);
                }
        }
    }
}