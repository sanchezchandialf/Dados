using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dados
{

    class Dados {

        public int r1 { get; set; }
        public int r2 { get; set; }

        public int resultado(int n1, int n2)
        {
            Random random = new Random();
            r1 = random.Next(1, 7);
            r2 = random.Next(1, 7);
            return r1 + r2;
        }


    }


    class Persona
    {
        public string nombre { get; set; }
        public int capital = 1000;

        public Persona() { }

        public Persona(ref string nombre)
        {
            this.nombre = nombre;
            this.capital = 1000;
        }
    }


    class Casino
    {
        public int pozo = 10000;


        public Casino(int pozo)
        {
            this.pozo = pozo;
        }

        public static void crearmesa()
        {

        }

        public static bool comprobaciones(ref Persona p1)
        {
            bool resul = false;
            if (p1.capital > 0)
            {
                resul = true;
            }
            return resul;
        }

        public static void juego(Casino casino)
        {
           
            Console.WriteLine("Bienvenido al casino!!");
            Thread.Sleep(2000);
            string nom1;
            string nom2;
            do
            {
                Console.WriteLine("ingrese nombre");
                nom1 = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(nom1));
            Thread.Sleep(2000);
            do
            {
                Console.WriteLine("ingrese nombre");
                nom2 = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(nom2));
            Persona persona = new Persona(ref nom1);
            Persona persona2 = new Persona(ref nom2);
            Console.WriteLine("Bienvenidos" + nom1 + nom2);
            /*
            -compruebo que tengan plata
            -compruebo que puedan realizar la apuesta que desean
                apuesta realizada- capital
            -compruebo que el casino puede realizar la apuesta que desean hacer 
             
            */
            Console.WriteLine("el jugador puede realiziar tres tipos de jugadas  ");
            Thread.Sleep(2000);
            Console.WriteLine(" 1.Moderado: 1/2");
            Console.WriteLine(" 2.Ariesgado: 2/5");
            Console.WriteLine(" 3.Deesesperado:4/15");

            if (comprobaciones(ref persona) && comprobaciones(ref persona2))
            {
                Console.WriteLine("tienen plata para jugar ");
                Console.WriteLine(nom1 + "que desea realizar ");
                Int32.TryParse(Console.ReadLine(), out int respuesta);
                Console.WriteLine(nom2 + "que desea realizar");
                Int32.TryParse(Console.ReadLine(), out int respuesta2);
                bool seguir= true;
                do
                {
                    if (casino.pozo > persona.capital * 2 && casino.pozo > persona.capital * 5 && casino.pozo > persona2.capital * 15 && casino.pozo > persona2.capital * 2 && casino.pozo > persona2.capital * 5 && casino.pozo > persona2.capital * 15) { }
                    {
                        comprobacionapuesta(ref persona, respuesta);
                        comprobacionapuesta(ref persona, respuesta2);
                        Console.WriteLine("ingrese el numero que cree que va a salir "+nom1 );
                        Int32.TryParse(Console.ReadLine(), out int re);
                        Console.WriteLine("ingrese el numero que cree que va a salir "+  nom2);
                        Int32.TryParse(Console.ReadLine(), out int re2);
                        Tirardado(re, re2, persona, persona2, respuesta, respuesta2, casino);
                        Console.WriteLine("Desea seguir jugando" + nom1 + "?");
                        Int32.TryParse(Console.ReadLine(), out int r);
                        Console.WriteLine("Desea seguir jugando" + nom2 + "?");
                        Int32.TryParse(Console.ReadLine(), out int r2);
                        if (r == 1 && r2 == 1)
                        {
                            Console.WriteLine("SIGAN PARTICIPANDO");
                        }
                        else seguir = false;

                    }
                } while (seguir);
               


            }
            else Console.WriteLine("no puede juegar");


        }
        public static void Tirardado(int n1, int n2, Persona persona1, Persona persona2, int resp, int res2,Casino casino)
        {

            Dados dado = new Dados();
             int resultado=dado.resultado(n1 ,n2);
            if(n1==resultado && resp ==1)
            {
                persona1.capital += persona1.capital;
                casino.pozo =casino.pozo-( persona1.capital*2);
                Console.WriteLine("felicidades por ganar jugador 1");
            }
            if(n1==resultado && resp == 2)
            {
                persona1.capital += persona1.capital*5;
                casino.pozo = casino.pozo - (persona1.capital * 5);
                Console.WriteLine("felicidades por ganar jugador 1");

            }
            if (n1 == resultado && resp == 3)
            {
                persona1.capital += persona1.capital * 15;
                casino.pozo = casino.pozo - (persona1.capital * 15);
                Console.WriteLine("felicidades por ganar jugador 1");

            }
            if (n2 == resultado && res2 == 1)
            {
                persona2.capital += persona2.capital;
                casino.pozo = casino.pozo - (persona1.capital * 2);
                Console.WriteLine("felicidades por ganar jugador 2");

            }
            if (n2 == resultado && res2 == 2)
            {
                persona2.capital += persona2.capital;
                casino.pozo = casino.pozo - (persona1.capital * 5);
                Console.WriteLine("felicidades por ganar jugador 2");

            }
            if (n2 == resultado && res2 == 3)
            {
                persona2.capital += persona2.capital;
                casino.pozo = casino.pozo - (persona1.capital * 15);
                Console.WriteLine("felicidades por ganar jugador 2");

            }
            if (n1 != resultado)
            {
                Console.WriteLine("siga participando jugador 1");
            }
            if (n2 != resultado)
            {
                Console.WriteLine("Siga participando jugador  2");
            }


        }
       
        public static void comprobacionapuesta(ref Persona persona, int respuesta)
        {
            switch (respuesta)
            {
                case 1:
                    int monto = persona.capital - persona.capital;
                    if (monto >= 0)
                    {
                        Console.WriteLine("puede hacer la operacion");
                    }
                    else {
                        Console.WriteLine("No puede apostar");
                            break; }
                    break;
                case 2:
                    monto = persona.capital - persona.capital*2;
                    if (monto >= 0)
                    {
                        Console.WriteLine("puede hacer la operacion");
                    }
                    else { Console.WriteLine("No puede apostar");

                        break;
                    };
                    break;
                case 3:
                    monto = persona.capital - persona.capital*4;
                    if (monto >= 0)
                    {
                        Console.WriteLine("puede hacer la operacion");
                    }
                    else {
                        Console.WriteLine("No puede apostar");
                            break;
                            };
                    break;


            }
        }
        public static void Main(string[] args)
        {
            Casino casino = new Casino(1000);
            juego(casino);
        }


    } 

    
    
       
    
  
}
