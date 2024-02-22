using System.Text;

char[] chrAlfabeto = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N','Ñ',
    'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
string strCifradoFinal = "";
Console.WriteLine("Cifrado");
Console.WriteLine("");
char Repeticion;
int intOption;

do
{
    Console.WriteLine("Ingrese la opcion (Numero) a realizar:\n" +
        "[1] Cifrar \n" +
        "[2] Descifrar\n");
    intOption = int.Parse(Console.ReadLine());
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
                string strMensajeCifrado = Console.ReadLine().ToUpper();

                // Calcular la longitud de cada fragmento
                int fragmentoLength = (int)Math.Ceiling((double)strMensajeCifrado.Length / strClave.Length);

                // Crear un array bidimensional para almacenar el mensaje cifrado
                char[,] chrMensajeCifrado = new char[fragmentoLength, strClave.Length];

                // Llenar el array bidimensional con el mensaje cifrado
                int inputIndex = 0;
                for (int columna = 0; columna < strClave.Length; columna++)
                {
                    for (int fila = 0; fila < fragmentoLength; fila++)
                    {
                        //condition ? consequent : alternative
                        chrMensajeCifrado[fila, columna] = (inputIndex < strMensajeCifrado.Length) ? strMensajeCifrado[inputIndex++] : 'X';
                    }
                }
                // llenar con x automaticamente al descifrar 
                //importante

                // Crear un array para almacenar el orden de las letras de la palabra clave
                char[] ordenPalabraClave = new char[strClave.Length];
                ordenPalabraClave = strClave.ToCharArray();

                // Crear un nuevo array bidimensional para almacenar el mensaje descifrado
                char[,] chrMensajeDescifrado = new char[fragmentoLength, strClave.Length];

                // Llenar el array bidimensional con el mensaje descifrado

                List<int> columnasCopiadas = new List<int>();

                for (int chrClave = 0; chrClave < strClave.Length; chrClave++)
                {
                    for (int columna = 0; columna < strClave.Length; columna++)
                    {
                        // Verificar si la columna ya ha sido copiada
                        if (!columnasCopiadas.Contains(columna) && ordenPalabraClave[chrClave] == chrMensajeCifrado[0, columna])
                        {
                            // Agregar la columna a la lista de columnas copiadas
                            columnasCopiadas.Add(columna);

                            // Copiar la columna en la matriz descifrada
                            for (int fila = 1; fila < fragmentoLength; fila++)
                            {
                                Console.WriteLine(" letra a ingresar {0} en la fila {1} columna{2}", chrMensajeCifrado[fila, columna], fila, chrClave);
                                chrMensajeDescifrado[fila, chrClave] = chrMensajeCifrado[fila, columna];
                            }
                            // Una vez copiada la columna, salir del bucle interno
                            break;
                        }
                    }
                }
                for (int fila = 0; fila < fragmentoLength; fila++)
                {
                    for (int columna = 0; columna < strClave.Length; columna++)
                    {
                        Console.Write(chrMensajeDescifrado[fila, columna] + " ");
                    }
                    Console.WriteLine(); // Salto de línea al final de cada fila
                }

                // Imprimir el mensaje descifrado
                Console.WriteLine("Mensaje Descifrado:");
                for (int fila = 0; fila < fragmentoLength; fila++)
                {
                    for (int columna = 0; columna < strClave.Length; columna++)
                    {
                        Console.Write(chrMensajeDescifrado[fila, columna]);
                    }
                }
                break;
            }
        default:
            {
                Console.WriteLine("NO EXISTE");
                break;
            }

    }
    Console.ReadKey();
    Console.WriteLine("Desea hacer otra opcion \n S / N");
    Repeticion = char.Parse(Console.ReadLine().ToUpper());
    Console.Clear();

} while (Repeticion == 'S');