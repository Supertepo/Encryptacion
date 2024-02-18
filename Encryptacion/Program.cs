using System.Text;

char[] chrAlfabeto = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N','Ñ',
    'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
string strCifradoFinal = "";
Console.WriteLine("Cifrado");
Console.WriteLine("");

Console.WriteLine("Ingrese la opcion (Numero) a realizar:\n" +
    "[1] Cifrar \n" +
    "[2] Descifrar\n");
int intOption = int.Parse(Console.ReadLine());
switch (intOption)
{
    case 1:
        {
            Console.WriteLine("Ingrese la palabra clave");
            string strClave = Console.ReadLine().ToUpper();

            Console.WriteLine("Ingrese el mensaje a cifrar");
            string strMensaje = strClave + Console.ReadLine().ToUpper();

            // Eliminar espacios en blanco del mensaje
            strMensaje = strMensaje.Replace(" ", "");

            // Calcular la longitud de cada fragmento
            int fragmentoLength = (int)Math.Ceiling((double)strMensaje.Length / strClave.Length);

            // Rellenar la cadena de entrada con caracteres 'X' si es necesario
            strMensaje = strMensaje.PadRight(strClave.Length * fragmentoLength, 'X');

            // Crear un array bidimensional para almacenar la matriz
            char[,] chrMensaje = new char[fragmentoLength, strClave.Length];

            // Llenar el array bidimensional con el mensaje
            int inputIndex = 0;
            for (int fila = 0; fila < fragmentoLength; fila++)
            {
                for (int columna = 0; columna < strClave.Length; columna++)
                {
                    chrMensaje[fila, columna] = strMensaje[inputIndex++];
                }
            }
            for (int i = 0; i < chrAlfabeto.Length; i++)
            {
                for (int columna = 0; columna < strClave.Length; columna++)
                {
                    if (chrMensaje[0, columna] == chrAlfabeto[i])
                    {
                        for (int j = 0; j < fragmentoLength; j++)
                        {
                            strCifradoFinal = strCifradoFinal + chrMensaje[j, columna];
                        }
                    }
                }

            }
            Console.WriteLine(strCifradoFinal);
            break;
        }

    case 2:
        {
            Console.WriteLine("Ingrese la palabra clave");
            string strClave = Console.ReadLine().ToUpper();
            Console.WriteLine("Ingrese el mensaje a descifrar");
            string strMensaje = Console.ReadLine().ToUpper();

            // Calcular la cantidad de subcadenas resultantes
            int cantidadSubcadenas = (int)Math.Ceiling((double)strMensaje.Length / strClave.Length);
            int LongitudMensaje = strMensaje.Length - strClave.Length;
            // Inicializar el array bidimensional para almacenar las subcadenas
            char[,] subcadenas = new char[cantidadSubcadenas, strClave.Length];

            int inputIndex = 0;

            // Llenar el array bidimensional con los caracteres de la cadena original
            for (int j = 0; j < strClave.Length; j++)
            {
                for (int i = 0; i < cantidadSubcadenas; i++)
                {
                    if (inputIndex < strMensaje.Length)
                    {
                        subcadenas[i, j] = strMensaje[inputIndex++];
                    }
                }
            }
            List<int> columnasCopiadas = new List<int>();
            char[] subcadenasOrden = new char[LongitudMensaje];
            int contador = 0;

            for (int i = 0; i < strClave.Length; i++)
            {
                for (int columna = 0; columna < strClave.Length; columna++)
                {
                    // Verificar si la columna ya ha sido copiada
                    if (!columnasCopiadas.Contains(columna) && subcadenas[0, columna] == strClave[i])
                    {
                        // Agregar la columna a la lista de columnas copiadas
                        columnasCopiadas.Add(columna);

                        for (int j = 1; j < cantidadSubcadenas; j++)
                        {
                            subcadenasOrden[contador++] = subcadenas[j, columna];
                        }
                    }
                }
            }

            // Obtener índices impares
            List<int> indicesImpares = new List<int>();
            for (int i = 1; i < LongitudMensaje; i += 2)
            {
                indicesImpares.Add(i);
            }

            // Obtener índices pares
            List<int> indicesPares = new List<int>();
            for (int i = 0; i < LongitudMensaje; i += 2)
            {
                indicesPares.Add(i);
            }

            // Crear cadena ordenada con impares seguidos de pares
            StringBuilder cadenaOrdenada = new StringBuilder();
            foreach (int indice in indicesPares)
            {
                cadenaOrdenada.Append(subcadenasOrden[indice]);
            }

            foreach (int indice in indicesImpares)
            {
                cadenaOrdenada.Append(subcadenasOrden[indice]);
            }

            // Imprimir cadena ordenada
            Console.WriteLine("Cadena Ordenada (Impares seguidos de Pares):");
            Console.WriteLine(cadenaOrdenada.ToString());
            break;
        }
}