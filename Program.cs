using System;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Juego JJJJ = new Juego();
            JJJJ.MostrarPantalla1();
            Console.ReadKey();
            Console.Clear();
            JJJJ.IngresarUsuario();
            Nivel A = new Nivel();
            do
            {
                Console.Clear();
                A.RecorrerMapa();
                A.Movimientos();
                A.Enemigo();
            }
            while (!A.AlPerder && !A.AlGanar);
            Console.ReadKey();
        }
    }
}

namespace ConsoleApplication1
{
    class Juego
    {
        private string nombre;
        private string usuario;
        private Nivel nivel1 = new Nivel();

        public Juego()
        {
            this.nombre = "LEGEND OF ARTHUR";
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public void MostrarPantalla1()
        {
            Console.WriteLine("========================================================================");
            Console.WriteLine("================== LEGEND OF ARTHUR ====================================");
            Console.WriteLine("========================================================================");
            Console.WriteLine("\nNuestra historia comienza con Arthur la princesa que tiene como su mejor amigo de la infancia a Thiago");
            Console.WriteLine("el cual es fanático de Sanson. Un día el gran villano Brian se despertó con ganas de");
            Console.WriteLine("secuestrar a Arthur para así conocer el paradero del tesoro perdido.\n");
            Console.WriteLine("¡TÚ MISIÓN ES RESCATARLO!\n");
            Console.WriteLine("Ingresa tu nombre de usuario: ");
            usuario = Console.ReadLine();
        }

        public void IngresarUsuario()
        {
            Console.WriteLine("Ingrese su nombre de usuario:");
            usuario = Console.ReadLine();
        }

        public void PantallaDelJuego()
        {
            while (!nivel1.AlPerder && !nivel1.AlGanar)
            {
                Console.Clear();
                nivel1.RecorrerMapa();
                nivel1.Movimientos();
                nivel1.Enemigo();
            }
        }
    }
}

namespace ConsoleApplication1
{
    class Nivel
    {
        private char[,] mapa;
        private bool llave = false;
        private bool cofre = false;
        private char personaje;
        private bool salida = false;

        private int fila = 8;
        private int columna = 1;

        public bool AlPerder = false;
        public bool AlGanar = false;

        private char enemigo;
        private int fila_enemigo = 5;
        private int columna_enemigo = 6;

        public void PantallaMuerte()
        {
            Console.Clear();
            Console.WriteLine("FIN DEL JUEGO\nTU HAS MUERTO");
        }

        public void PantallaVictoria()
        {
            Console.WriteLine("¡TU HAS GANADO!\nCOMPLETASTE EL NIVEL A LA PERFECCIÓN!\nFELICIDADES PIBE");
        }

        public char[,] Mapa1
        {
            get { return mapa; }
            set { mapa = value; }
        }

        public bool Llave
        {
            get { return llave; }
            set { llave = value; }
        }

        public bool Cofre
        {
            get { return cofre; }
            set { cofre = value; }
        }

        public Nivel()
        {
            Mapa();
            this.llave = false;
            this.cofre = false;
            this.personaje = '╦';
            this.salida = false;
            this.enemigo = 'Ü';
        }

        public void Mapa()
        {
            mapa = new char[,] {
                { '■', '■', '■', '■', '■', '■', '■', '■', '■', '■', '■', '■', '■', '■', '■', '■' },
                { '■', 'Ð', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '■', '£', ' ', ' ', ' ', ' ', '■' },
                { '■', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '■', ' ', ' ', ' ', ' ', ' ', '■' },
                { '■', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '■', '■', '■', '■', '■', ' ', '■' },
                { '■', '■', ' ', ' ', ' ', ' ', ' ', 'Ü', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '■' },
                { '■', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '■' },
                { '■', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '■', '■', '■', '■', ' ', ' ', '■' },
                { '■', ' ', ' ', '■', ' ', ' ', ' ', ' ', ' ', '■', ' ', ' ', ' ', '■', ' ', '■' },
                { '■', '╦', ' ', '■', ' ', ' ', ' ', ' ', ' ', '■', '»', ' ', ' ', ' ', ' ', '■' },
                { '■', '■', '■', '■', '■', '■', '■', '■', '■', '■', '■', '■', '■', '■', '■', '■' }
            };
        }

        public void RecorrerMapa()
        {
            for (int i = 0; i < mapa.GetLength(0); i++)
            {
                for (int j = 0; j < mapa.GetLength(1); j++)
                {
                    Console.Write(mapa[i, j]);
                }
                Console.WriteLine();
            }
        }

        public void Movimientos()
        {
            Console.WriteLine("╦ = PERSONAJE PRINCIPAL | Ü = ENEMIGO | £ = LLAVE | Ð = COFRE | » = SALIDA");
            Console.WriteLine("w = ARRIBA | s = ABAJO | d = DERECHA | a = IZQUIERDA");

            ConsoleKeyInfo boton = Console.ReadKey();

            if (boton.KeyChar == 'w' && mapa[fila - 1, columna] != '■')
            {
                MoverPersonaje(fila - 1, columna);
            }

            if (boton.KeyChar == 's' && mapa[fila + 1, columna] != '■')
            {
                MoverPersonaje(fila + 1, columna);
            }

            if (boton.KeyChar == 'a' && mapa[fila, columna - 1] != '■')
            {
                MoverPersonaje(fila, columna - 1);
            }

            if (boton.KeyChar == 'd' && mapa[fila, columna + 1] != '■')
            {
                MoverPersonaje(fila, columna + 1);
            }
        }

        private void MoverPersonaje(int nuevaFila, int nuevaColumna)
        {
            if (mapa[nuevaFila, nuevaColumna] == '£')
            {
                llave = true;
                mapa[nuevaFila, nuevaColumna] = ' ';
            }
            else if (mapa[nuevaFila, nuevaColumna] == 'Ð' && llave)
            {
                cofre = true;
                mapa[nuevaFila, nuevaColumna] = ' ';
            }
            else if (mapa[nuevaFila, nuevaColumna] == '»' && cofre)
            {
                mapa[nuevaFila, nuevaColumna] = ' ';
                salida = true;
                AlGanar = true;
                Console.Clear();
                PantallaVictoria();
            }
            else if (mapa[nuevaFila, nuevaColumna] == 'Ü')
            {
                mapa[nuevaFila, nuevaColumna] = ' ';
                AlPerder = true;
                Console.Clear();
                PantallaMuerte();
            }

            if (mapa[nuevaFila, nuevaColumna] == ' ')
            {
                mapa[fila, columna] = ' ';
                mapa[nuevaFila, nuevaColumna] = personaje;
                fila = nuevaFila;
                columna = nuevaColumna;
            }
        }

        public void Enemigo()
        {
            Random r = new Random();
            int movimiento = r.Next(1, 5);
            mapa[fila_enemigo, columna_enemigo] = ' ';

            switch (movimiento)
            {
                case 1:
                    MoverEnemigo(fila_enemigo - 1, columna_enemigo);
                    break;
                case 2:
                    MoverEnemigo(fila_enemigo + 1, columna_enemigo);
                    break;
                case 3:
                    MoverEnemigo(fila_enemigo, columna_enemigo - 1);
                    break;
                case 4:
                    MoverEnemigo(fila_enemigo, columna_enemigo + 1);
                    break;
            }
        }

        private void MoverEnemigo(int nuevaFila, int nuevaColumna)
        {
            if (mapa[nuevaFila, nuevaColumna] != '■' && mapa[nuevaFila, nuevaColumna] != 'Ð' && mapa[nuevaFila, nuevaColumna] != '£' && mapa[nuevaFila, nuevaColumna] != '»')
            {
                if (mapa[nuevaFila, nuevaColumna] == '╦')
                {
                    mapa[nuevaFila, nuevaColumna] = ' ';
                    AlPerder = true;
                    Console.Clear();
                    PantallaMuerte();
                }
                else
                {
                    mapa[nuevaFila, nuevaColumna] = 'Ü';
                    fila_enemigo = nuevaFila;
                    columna_enemigo = nuevaColumna;
                }
            }
        }
    }
}