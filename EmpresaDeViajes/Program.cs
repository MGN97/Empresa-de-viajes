using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaDeViajes
{
    internal class Program
    {
        public void mostrar(Cliente cli)
        {
            cli.mostrarDatos();
        }
        
    static void Main(string[] args)
        {
            // Color verde para la fuente de la consola
            Console.ForegroundColor = ConsoleColor.Green;

            DecoConsole deco = new DecoConsole();

            ConsoleKeyInfo opcion;
            string nombre, apellido, dni, nacionalidad, localidad, direccion, telefono;
            string cuit, razonSocial;
            byte edad;
            int nroCliente;
            bool esParticular, esCorporativo;
            ConsoleKeyInfo opcionCliente;
            Cliente cli = new Cliente();
            Corporativo cliCorp;
            List<Cliente> liClientes = new List<Cliente>();
            List<Corporativo> clienteCorp = new List<Corporativo> ();
            ConsoleKeyInfo opcionTipoCliente;
            ConsoleKeyInfo opcionInfo;
            ConsoleKeyInfo opcionGuardado;





            // Menu principal
            volver: // salto de goto
            do {
                Console.WriteLine(deco.b1);// Decoracion de consola
                Console.WriteLine("**************// Empresa de viajes \\**************");
                Console.WriteLine(deco.b1);// Decoracion de consola
                Console.WriteLine();// Decoracion de consola
                Console.WriteLine("Bienvenido, ingrese una de las siguientes opciones para continuar:");
                Console.WriteLine();// Decoracion de consola
                Console.WriteLine("1 - Clientes");
                Console.WriteLine("2 - Facturas");
                Console.WriteLine("3 - Paquetes");
                Console.WriteLine("Esc - Para salir");

                do {
                    opcion = Console.ReadKey(true);// Con TRUE evito que se muestre el numero de opcion elegnroClienteo
                } while (((int)opcion.KeyChar != 27) && (opcion.KeyChar < '1' || opcion.KeyChar > '3'));
                switch (opcion.KeyChar) {

                    // Submenu cliente
                    case '1':
                        Console.WriteLine();// Decoracion de consola
                        Console.WriteLine();// Decoracion de consola
                        Console.WriteLine("Eliga una de las siguientes opciones:");
                        Console.WriteLine(deco.b2);// Decoracion de consola
                        Console.WriteLine("1 - Crear un nuevo cliente");
                        Console.WriteLine("2 - Ver datos de un cliente");
                        Console.WriteLine("3 - Modificar datos de un cliente");
                        Console.WriteLine("4 - Ver listado de clientes");
                        Console.WriteLine("5 - Eliminar un cliente");
                        Console.WriteLine("Backspace - Para volver al menu principal");
                        Console.WriteLine();// Decoracion de consola
                        Console.WriteLine();// Decoracion de consola

                        do {/*
                             *  El usuario debe ingresar los numeros que aparacen en el menu para interaccionar con la consola.El "O8"
                             *  corresponde al codico ASCII de la tecla retroceso.
                             */
                           
                          opcionCliente = Console.ReadKey(true);
                        } while (((int)opcionCliente.KeyChar != 08) && (opcionCliente.KeyChar < '1' || opcionCliente.KeyChar > '5'));
                        switch (opcionCliente.KeyChar) {
                            // Menu para crear tipos de clientes

                            case '1':
                            nuevoCliente: //Salto de flujo del goto
                                Console.WriteLine("Elija que tipo de cliente desea crear:");
                                Console.WriteLine(deco.b2);// Decoracion de consola
                                Console.WriteLine("1 - Crear cliente particular");
                                Console.WriteLine("2 - Crear cliente corporativo");
                                Console.WriteLine("Backsapce - Para volver al menu principal");
                                Console.WriteLine();// Decoracion de consola
                                Console.WriteLine();// Decoracion de consola
                                do {/* El usuario debe ingresar los numeros que aparacen en el menu para interaccionar con la consola. El "O8" 
                                     * corresponde al codico ASCII de la tecla retroceso.
                                     */
                                    opcionTipoCliente = Console.ReadKey(true);
                                } while (((int)opcionTipoCliente.KeyChar != 08) && (opcionTipoCliente.KeyChar < '1' || opcionTipoCliente.KeyChar > '2'));
                                switch (opcionTipoCliente.KeyChar) {
                                    /*
                                     * Se debe hacer una estructura "if...else" en donde se analize que el usuario a crear no este creado ya.
                                     *  El nroCliente de un cliente, se debe crear y debe ser autoincremental.
                                     *  
                                     *  Acontinuacion se detalla la opcion uno, si es un nuevo cliente particular, este se construye con el contructor solo de 
                                     *  la clase cliente.
                                     *  
                                     *  ¡¡¡¡ATENCION!!! aun no captura excepciones
                                     */

                                    case '1':
                                        Console.WriteLine(deco.b1);// Decoracion de consola
                                        Console.WriteLine("***********// NUEVO CLIENTE PARTICULAR \\***********");
                                        Console.WriteLine(deco.b1);// Decoracion de consola
                                        Console.Write("> NroCliente: ");
                                        int.TryParse(Console.ReadLine(), out nroCliente);
                                        Console.WriteLine(deco.b2);// Decoracion de consola
                                        // Verifico que el numero de cliente no existe
                                        if (liClientes.Count(x => x.NroCliente == nroCliente) == 0) {


                                            esParticular = true; // Predefinido
                                            Console.WriteLine("> Particular: " + esParticular);
                                            Console.WriteLine(deco.b2);// Decoracion de consola

                                            Console.Write("> Nombre: ");
                                            nombre = Console.ReadLine();
                                            Console.WriteLine(deco.b2);// Decoracion de consola

                                            Console.Write("> Apellido: ");
                                            apellido = Console.ReadLine();
                                            Console.WriteLine(deco.b2);// Decoracion de consola

                                        nuevoIntentoEdad: //Salto de flujo del goto
                                            Console.Write("> Edad: ");
                                            try {
                                                edad = byte.Parse(Console.ReadLine());
                                                if (edad <= 18) {
                                                    Console.WriteLine();// Decoracion de consola
                                                    Console.WriteLine(deco.b2);// Decoracion de consola
                                                    Console.WriteLine("¡¡¡El cliente es menor de edad, no se le puede vender un viaje!!!");
                                                    Console.WriteLine(deco.b2);// Decoracion de consola
                                                    goto opciones; // Salta a las opciones de salida de creacion
                                                }
                                            }
                                            catch (FormatException ex) {
                                                Console.WriteLine("El valor ingresado no es un valor numerico, reintente");
                                                goto nuevoIntentoEdad; // salta e imprime la misma seccion, hasta que ingrese un numero valido
                                            }
                                            Console.WriteLine(deco.b2);// Decoracion de consola

                                            Console.Write("> DNI: ");
                                            dni = Console.ReadLine();
                                            Console.WriteLine(deco.b2);// Decoracion de consola

                                            Console.Write("> Nacionalidad: ");
                                            nacionalidad = Console.ReadLine();
                                            Console.WriteLine(deco.b2);// Decoracion de consola

                                            Console.Write("> Localidad: ");
                                            localidad = Console.ReadLine();
                                            Console.WriteLine(deco.b2);// Decoracion de consola

                                            Console.Write("> Direccion: ");
                                            direccion = Console.ReadLine();
                                            Console.WriteLine(deco.b2);// Decoracion de consola

                                            Console.Write("> Telefono: ");
                                            telefono = Console.ReadLine();
                                            Console.WriteLine(deco.b2);// Decoracion de consola

                                            cli = new Cliente(nroCliente, esParticular, nombre, apellido, edad, dni, nacionalidad, localidad, direccion, telefono);
                                            liClientes.Add(cli);
                                        }
                                        else {
                                            Console.WriteLine();// Decoracion de consola
                                            Console.WriteLine("Error: el nroCliente del cliente que intenta crear ya existe");
                                            Console.WriteLine(deco.b2);// Decoracion de consola
                                            Console.WriteLine();// Decoracion de consola
                                        }

                                    // OPCIONES DE SALIDA DE CREACION

                                    opciones://Salto de flujo del goto
                                        Console.WriteLine();// Decoracion de consola
                                        Console.WriteLine(deco.b1);// Decoracion de consola
                                        Console.WriteLine("Desea cargar otro cliente?");
                                        Console.WriteLine(deco.b1);// Decoracion de consola
                                        Console.WriteLine("y - Si");
                                        Console.WriteLine("n - No");
                                        Console.WriteLine();// Decoracion de consola
                                        do {
                                            opcionGuardado = Console.ReadKey(true);
                                        } while (((int)opcionGuardado.KeyChar != 121) && ((int)opcionGuardado.KeyChar != 110));
                                        switch (opcionGuardado.KeyChar) {
                                            case 'y':
                                                Console.WriteLine();// Decoracion de consola
                                                Console.WriteLine("Volviendo al menu de creacion de clientes...");
                                                Console.WriteLine();// Decoracion de consola
                                                goto nuevoCliente;

                                            case 'n':
                                                Console.WriteLine();// Decoracion de consola
                                                Console.WriteLine("Regresando a menu principal...");
                                                Console.WriteLine();// Decoracion de consola
                                                goto volver;
                                        }
                                        break;

                                    /*
                                     * Si se trata de crear un nuevo cliente pero que sea corporativo, este utiliza tanto el constructor de la clase corporativo que hereda
                                     * tambien el constructor de la clase cliente.
                                     * 
                                     * 
                                     */
                                    case '2':
                                        Console.WriteLine(deco.b1);// Decoracion de consola
                                        Console.WriteLine("***********// NUEVO CLIENTE CORPORATIVO \\***********");
                                        Console.WriteLine(deco.b1);// Decoracion de consola

                                        Console.Write("> NroCliente: ");
                                        int.TryParse(Console.ReadLine(), out nroCliente);
                                        Console.WriteLine(deco.b2);// Decoracion de consola
                                        // Verico que el numero de clioente no existe
                                        if (clienteCorp.Count(x => x.NroCliente == nroCliente) == 0) {

                                            esParticular = false; // Predefinido
                                            Console.WriteLine("> Particular: " + esParticular);
                                            Console.WriteLine(deco.b2);// Decoracion de consola

                                            esCorporativo = true; //Predefinido
                                            Console.WriteLine("> Corporativo: " + esCorporativo);
                                            Console.WriteLine(deco.b2);// Decoracion de consola

                                            Console.Write("> Nombre: ");
                                            nombre = Console.ReadLine();
                                            Console.WriteLine(deco.b2);// Decoracion de consola

                                            Console.Write("> Apellido: ");
                                            apellido = Console.ReadLine();
                                            Console.WriteLine(deco.b2);// Decoracion de consola

                                        nuevoIntentoEdad: //Salto de flujo del goto
                                            Console.Write("> Edad: ");
                                            try {
                                                edad = byte.Parse(Console.ReadLine());
                                                if (edad <= 18) {
                                                    Console.WriteLine();// Decoracion de consola
                                                    Console.WriteLine(deco.b2);// Decoracion de consola
                                                    Console.WriteLine("¡¡¡El cliente es menor de edad, no se le puede vender un viaje!!!");
                                                    Console.WriteLine(deco.b2);// Decoracion de consola
                                                    goto opciones2; // Salta a las opciones de salida de creacion
                                                }
                                            }
                                            catch (FormatException ex) {
                                                Console.WriteLine("El valor ingresado no es un valor numerico, reintente");
                                                goto nuevoIntentoEdad; // salta e imprime la misma seccion, hasta que ingrese un numero valido
                                            }
                                            Console.WriteLine(deco.b2);// Decoracion de consola

                                            Console.Write("> DNI: ");
                                            dni = Console.ReadLine();
                                            Console.WriteLine(deco.b2);// Decoracion de consola

                                            Console.Write("> Nacionalidad: ");
                                            nacionalidad = Console.ReadLine();
                                            Console.WriteLine(deco.b2);// Decoracion de consola

                                            Console.Write("> Localidad: ");
                                            localidad = Console.ReadLine();
                                            Console.WriteLine(deco.b2);// Decoracion de consola

                                            Console.Write("> Direccion: ");
                                            direccion = Console.ReadLine();
                                            Console.WriteLine(deco.b2);// Decoracion de consola

                                            Console.Write("> Telefono: ");
                                            telefono = Console.ReadLine();
                                            Console.WriteLine(deco.b2);// Decoracion de consola

                                            Console.Write("> CUIT: ");
                                            cuit = Console.ReadLine();
                                            Console.WriteLine(deco.b2);// Decoracion de consola

                                            Console.Write("> Razon social: ");
                                            razonSocial = Console.ReadLine();
                                            Console.WriteLine(deco.b2);// Decoracion de consola


                                            cliCorp = new Corporativo(nroCliente, esParticular, nombre, apellido, edad, dni, nacionalidad, localidad, direccion, telefono, cuit, razonSocial, esCorporativo);
                                            clienteCorp.Add(cliCorp);
                                        }
                                        else {
                                            Console.WriteLine();//Decoracion consola
                                            Console.WriteLine("Error: el numero de cliente que intenta crear ya existe");
                                            Console.WriteLine(deco.b2);// Decoracion de consola
                                            Console.WriteLine();// Decoracion de consola
                                        }

                                    //OPCIONES DE SALIDA DE CREACION
                                    opciones2://Salto de flujo del goto
                                        Console.WriteLine();//Decoracion consola
                                        Console.WriteLine(deco.b1);// Decoracion de consola
                                        Console.WriteLine("Desea cargar otro cliente?");
                                        Console.WriteLine(deco.b1);// Decoracion de consola
                                        Console.WriteLine("y - Si");
                                        Console.WriteLine("n - No");
                                        Console.WriteLine();//Decoracion consola
                                        do {
                                            opcionGuardado = Console.ReadKey(true);
                                        } while (((int)opcionGuardado.KeyChar != 121) && (opcionGuardado.KeyChar != 110));
                                        switch (opcionGuardado.KeyChar) {
                                            case 'y':
                                                Console.WriteLine();//Decoracion consola
                                                Console.WriteLine("Volviendo al menu de creacion de clientes...");
                                                Console.WriteLine();//Decoracion consola
                                                goto nuevoCliente; // redirecciona el flujo al menu de creacion de clientes

                                            case 'n':
                                                Console.WriteLine();//Decoracion consola
                                                Console.WriteLine("Regresando a menu principal...");
                                                Console.WriteLine();//Decoracion consola
                                                goto volver; // salta al menu principal
                                        }
                                        break;
                                }
                                break;



                            case '2':
                            // ERROR EN ALGUNA PARTE DEL CODIGO, NO PUEDO VISUALIZAR LA INFO DE LOS CLIENTES CON EL METODO MOSTRAR DATOS
                            infoCliente://Salto de flujo del goto
                                Console.WriteLine(deco.b1);// Decoracion de consola
                                Console.WriteLine("*********// VER INFORMACION DE CLIENTES \\********");
                                Console.WriteLine(deco.b1);// Decoracion de consola
                                Console.WriteLine();//Decoracion consola
                                Console.WriteLine("Acontinuacion elija el tipo de cliente para acceder a la informacion del mismo:");
                                Console.WriteLine(deco.b2);// Decoracion de consola
                                Console.WriteLine("1 - Cliente particular");
                                Console.WriteLine("2 - Cliente corporativo");
                                Console.WriteLine("Backspace - Para volver al menu principal");
                                Console.WriteLine();//Decoracion consola
                                Console.WriteLine();//Decoracion consola
                                do {
                                    opcionInfo = Console.ReadKey(true);
                                } while (((int)opcionInfo.KeyChar != 08) && (opcionInfo.KeyChar < '1' || opcionInfo.KeyChar > '2'));
                                switch (opcionInfo.KeyChar) {

                                    case '1': //Particular
                                        Console.WriteLine(deco.b1);// Decoracion de consola
                                        Console.WriteLine("*****************// PARTICULAR \\******************");
                                        Console.WriteLine(deco.b1);// Decoracion de consola
                                        Console.Write("Ingrese el numero de cliente: ");
                                        int.TryParse(Console.ReadLine(), out nroCliente);
                                        Console.WriteLine(deco.b2); // Decoracion de consola
                                        // Por cada elemento (x) de la lista dame el primero que su atributo sea igual a "nroCliente"
                                        cli = liClientes.Find(x => x.NroCliente == nroCliente);
                                        if (cli != null) {
                                            cli.mostrarDatos(); // No me muestra la info del cliente
                                        }
                                        else {
                                            // Me redirecciona automaticamente aqui sin mostrarme los datos del cliente
                                            Console.WriteLine(deco.b2);//Decoracion consola
                                            Console.WriteLine("¡¡¡No se encontro el cliente con numero: " + nroCliente + " !!!");
                                            Console.WriteLine(deco.b2);//Decoracion consola
                                        }
                                        Console.WriteLine();//Decoracion consola

                                        // Opciones de que quiere hacer el usuario cuando finaliza de ingrezar datos o de utilizar una funcion
                                        Console.WriteLine(deco.b1);//Decoracion consola
                                        Console.WriteLine("Desea ver la informacion de otro cliente?");
                                        Console.WriteLine(deco.b1);//Decoracion consola
                                        Console.WriteLine("y - Si");
                                        Console.WriteLine("n - No");
                                        do {
                                            opcionGuardado = Console.ReadKey(true);
                                        } while (((int)opcionGuardado.KeyChar != 121) && ((int)opcionGuardado.KeyChar != 110));
                                        switch (opcionGuardado.KeyChar) {
                                            case 'y':
                                                goto infoCliente; // Muestra nuevamnente el menu de info cliente

                                            case 'n':
                                                Console.WriteLine();//Decoracion consola
                                                Console.WriteLine("Regresando a menu principal...");
                                                Console.WriteLine();//Decoracion consola
                                                goto volver; // vuelve al menu principal
                                        }
                                        break;




                                    case '2': // Corporativo
                                        Console.WriteLine(deco.b1);//Decoracion consola
                                        Console.WriteLine("*****************// CORPORATIVO \\******************");
                                        Console.WriteLine(deco.b1);//Decoracion consola
                                        Console.Write("Ingrese el numero de cliente: ");
                                        int.TryParse(Console.ReadLine(), out nroCliente);
                                        Console.WriteLine(deco.b2);//Decoracion consola
                                        // Por cada elemento (x) de la lista dame el primero que su atributo sea igual a "nroCliente"
                                        cliCorp = clienteCorp.Find(x => x.NroCliente == nroCliente);
                                        if (cliCorp != null) {
                                            cliCorp.mostrarDatos();
                                        }
                                        else {
                                            // Me redirecciona automaticamente aqui sin mostrarme los datos del cliente
                                            Console.WriteLine(deco.b2);//Decoracion consola
                                            Console.WriteLine("¡¡¡No se encontro el cliente con numero: " + nroCliente + " !!!");
                                            Console.WriteLine(deco.b2);//Decoracion consola
                                        }
                                        Console.WriteLine();//Decoracion consola

                                        // Opciones de que quiere hacer el usuario cuando finaliza de ingrezar datos o de utilizar una funcion
                                        Console.WriteLine(deco.b1);//Decoracion consola
                                        Console.WriteLine("Desea ver la informacion de otro cliente?");
                                        Console.WriteLine(deco.b1);//Decoracion consola
                                        Console.WriteLine("y - Si");
                                        Console.WriteLine("n - No");
                                        do {
                                            opcionGuardado = Console.ReadKey(true);
                                        } while (((int)opcionGuardado.KeyChar != 121) && ((int)opcionGuardado.KeyChar != 110));
                                        switch (opcionGuardado.KeyChar) {
                                            case 'y':
                                                goto infoCliente; // Redirecciona el fluja al menu de info cliente

                                            case 'n':
                                                Console.WriteLine();//Decoracion consola
                                                Console.WriteLine("Regresando a menu principal...");
                                                Console.WriteLine();//Decoracion consola
                                                goto volver;
                                        }
                                        break;
                                }
                                break;




                            case '3':
                            nuevaEdicion://Salto de flujo del goto
                                Console.WriteLine(deco.b1);//Decoracion consola
                                Console.WriteLine("***********// MODIFICAR INFORMACION DE CLIENTES \\***********");
                                Console.WriteLine(deco.b1);//Decoracion consola
                                Console.WriteLine();//Decoracion consola
                                Console.WriteLine("Acontinuacion elija el tipo de cliente a modificar: ");
                                Console.WriteLine(deco.b2);//Decoracion consola
                                Console.WriteLine("1 -  Cliente particular");
                                Console.WriteLine("2 - Cliente corporativo");
                                Console.WriteLine("Backspace - Para volver al menu principal");
                                Console.WriteLine();//Decoracion consola
                                Console.WriteLine();//Decoracion consola
                                do {
                                    opcionTipoCliente = Console.ReadKey(true);
                                } while (((int)opcionTipoCliente.KeyChar != 08) && (opcionTipoCliente.KeyChar < '1' || opcionTipoCliente.KeyChar > '2'));
                                switch (opcionTipoCliente.KeyChar) {

                                    case '1':
                                        Console.WriteLine(deco.b1);//Decoracion consola
                                        Console.WriteLine("*****************// PARTICULAR \\******************");
                                        Console.WriteLine(deco.b1);//Decoracion consola
                                        Console.WriteLine();//Decoracion consola
                                        Console.Write("Ingrese el nroCliente del cliente a modificar: ");
                                        int.TryParse(Console.ReadLine(), out nroCliente);
                                        Console.WriteLine(deco.b2);//Decoracion consola
                                        cli = liClientes.Find(x => x.NroCliente == nroCliente);
                                        if (cli != null) {

                                            Console.Write("> Nombre: ");
                                            cli.Nombre = Console.ReadLine();
                                            Console.WriteLine(deco.b2);//Decoracion consola

                                            Console.Write("> Apellido: ");
                                            cli.Apellido = Console.ReadLine();
                                            Console.WriteLine(deco.b2);//Decoracion consola

                                        modificaEdad: // Salto del goto
                                            Console.Write("> Edad: ");
                                            try {
                                                edad = byte.Parse(Console.ReadLine());
                                                if (edad <= 18) {
                                                    Console.WriteLine();//Decoracion consola
                                                    Console.WriteLine(deco.b2);//Decoracion consola
                                                    Console.WriteLine("¡¡¡El cliente es menor de edad, no se le puede vender un viaje!!!");
                                                    Console.WriteLine(deco.b2);//Decoracion consola
                                                    goto opciones3; // Salta a las opciones de salida de case
                                                }
                                            }
                                            catch (FormatException ex) {
                                                Console.WriteLine("El valor ingresado no es un valor numerico, reintente");
                                                goto modificaEdad; // salta e imprime la misma seccion, hasta que ingrese un numero valido
                                            }
                                            Console.WriteLine(deco.b2);//Decoracion consola

                                            Console.Write("> DNI: ");
                                            cli.Dni = Console.ReadLine();
                                            Console.WriteLine(deco.b2);//Decoracion consola

                                            Console.Write("> Nacionalidad: ");
                                            cli.Nacionalidad = Console.ReadLine();
                                            Console.WriteLine(deco.b2);//Decoracion consola

                                            Console.Write("> Localidad: ");
                                            cli.Localidad = Console.ReadLine();
                                            Console.WriteLine(deco.b2);//Decoracion consola

                                            Console.Write("> Direccion: ");
                                            cli.Direccion = Console.ReadLine();
                                            Console.WriteLine(deco.b2);//Decoracion consola

                                            Console.Write("> Telefono: ");
                                            cli.Telefono = Console.ReadLine();
                                            Console.WriteLine(deco.b2);//Decoracion consola
                                        }
                                        else {
                                            Console.WriteLine(deco.b2);//Decoracion consola
                                            Console.WriteLine("¡¡¡No se encontro el cliente con numero: " + nroCliente + " !!!");
                                            Console.WriteLine(deco.b2);//Decoracion consola
                                        }
                                        Console.WriteLine();
                                    // Opciones de que quiere hacer el usuario cuando finaliza de ingrezar datos o de utilizar una funcion
                                    opciones3://Salto de flujo del goto
                                        Console.WriteLine(deco.b1);//Decoracion consola
                                        Console.WriteLine("¿Desea seguir editando?:");
                                        Console.WriteLine(deco.b1);//Decoracion consola
                                        Console.WriteLine("y - Si");
                                        Console.WriteLine("n - No");
                                        do {
                                            opcionGuardado = Console.ReadKey(true);
                                        } while (((int)opcionGuardado.KeyChar != 121) && ((int)opcionGuardado.KeyChar != 110));
                                        switch (opcionGuardado.KeyChar) {
                                            case 'y':
                                                goto nuevaEdicion; // Redirecciona el flujo al menu de modificacion de usuarios

                                            case 'n':
                                                Console.WriteLine();//Decoracion consola
                                                Console.WriteLine("Regresando a menu principal...");
                                                Console.WriteLine();//Decoracion consola
                                                goto volver; // redirecciona el flujo al menu principal

                                        }
                                        break;



                                    case '2':
                                        Console.WriteLine(deco.b1);//Decoracion consola
                                        Console.WriteLine("*****************// CORPORATIVO \\******************");
                                        Console.WriteLine(deco.b1);//Decoracion consola
                                        Console.WriteLine();//Decoracion consola
                                        Console.Write("Ingrese el nroCliente del cliente a modificar: ");
                                        int.TryParse(Console.ReadLine(), out nroCliente);
                                        Console.WriteLine(deco.b2);//Decoracion consola
                                        int.TryParse(Console.ReadLine(), out nroCliente);
                                        cliCorp = clienteCorp.Find(x => x.NroCliente == nroCliente);
                                        if (cliCorp != null) { //COMO HAGO PARA QUE TAMBIEN VERIFIQUE QUE ES UN CLIENTE COORPORATIVO, PODRIA SER CON LA VARIABLE "esCorporativo = true"

                                            Console.Write("> Nombre: ");
                                            cliCorp.Nombre = Console.ReadLine();
                                            Console.WriteLine(deco.b2);//Decoracion consola

                                            Console.Write("> Apellido: ");
                                            cliCorp.Apellido = Console.ReadLine();
                                            Console.WriteLine(deco.b2);//Decoracion consola

                                        modificaEdadCorp: //Salto de flujo del goto
                                            Console.Write("> Edad: ");
                                            try {
                                                edad = byte.Parse(Console.ReadLine());
                                                edad = byte.Parse(Console.ReadLine());
                                                if (edad <= 18) {
                                                    Console.WriteLine();//Decoracion consola
                                                    Console.WriteLine(deco.b2);//Decoracion consola
                                                    Console.WriteLine("¡¡¡El cliente es menor de edad, no se le puede vender un viaje!!!");
                                                    Console.WriteLine(deco.b2);//Decoracion consola
                                                    goto opciones4;// Salta a las opciones de salida de case
                                                }
                                            }
                                            catch (FormatException ex) {
                                                Console.WriteLine("El valor ingresado no es un valor numerico, reintente");
                                                goto modificaEdadCorp; // salta e imprime la misma seccion, hasta que ingrese un numero valido
                                            }
                                            Console.WriteLine(deco.b2);//Decoracion consola

                                            Console.Write("> DNI: ");
                                            cliCorp.Dni = Console.ReadLine();
                                            Console.WriteLine(deco.b2);//Decoracion consola

                                            Console.Write("> Nacionalidad: ");
                                            cliCorp.Nacionalidad = Console.ReadLine();
                                            Console.WriteLine(deco.b2);//Decoracion consola

                                            Console.Write("> Localidad: ");
                                            cliCorp.Localidad = Console.ReadLine();
                                            Console.WriteLine(deco.b2);//Decoracion consola

                                            Console.Write("> Direccion: ");
                                            cliCorp.Direccion = Console.ReadLine();
                                            Console.WriteLine(deco.b2);//Decoracion consola

                                            Console.Write("> Telefono: ");
                                            cliCorp.Telefono = Console.ReadLine();
                                            Console.WriteLine(deco.b2);//Decoracion consola

                                            Console.Write("> CUIT: ");
                                            cliCorp.Cuit = Console.ReadLine();
                                            Console.WriteLine(deco.b2);//Decoracion consola

                                            Console.Write("> Razon social: ");
                                            cliCorp.RazonSocial = Console.ReadLine();
                                            Console.WriteLine(deco.b2);//Decoracion consola

                                        }
                                        else {
                                            Console.WriteLine(deco.b2);//Decoracion consola
                                            Console.WriteLine("¡¡¡No se encontro el cliente con numero: " + nroCliente + " !!!");
                                            Console.WriteLine(deco.b2);//Decoracion consola
                                        }
                                        Console.WriteLine();//Decoracion consola
                                                            // Opciones de que quiere hacer el usuario cuando finaliza de ingrezar datos o de utilizar una funcion

                                    opciones4://Salto de flujo del goto
                                        Console.WriteLine(deco.b1);//Decoracion consola
                                        Console.WriteLine("¿Desea seguir editando?:");
                                        Console.WriteLine(deco.b1);//Decoracion consola
                                        Console.WriteLine("y - Si");
                                        Console.WriteLine("n - No");
                                        do {
                                            opcionGuardado = Console.ReadKey(true);
                                        } while (((int)opcionGuardado.KeyChar != 121) && ((int)opcionGuardado.KeyChar != 110));
                                        switch (opcionGuardado.KeyChar) {
                                            case 'y':
                                                goto nuevaEdicion; // redirecciona el flujo al menu de modificacion de cliente

                                            case 'n':
                                                Console.WriteLine();//Decoracion consola
                                                Console.WriteLine("Regresando a menu principal...");
                                                Console.WriteLine();//Decoracion consola
                                                goto volver; // redirecciona el flujo al menu principal

                                        }
                                        break;
                                }
                                break;





                            case '4':
                                Console.WriteLine(deco.b1);//Decoracion consola
                                Console.WriteLine("***********// OBTENER LISTA DE CLIENTES \\***********");
                                Console.WriteLine(deco.b1);//Decoracion consola
                                Console.WriteLine();//Decoracion consola
                                Console.WriteLine("Acontinuacion elija el tipo de lista de cliente que desea ver:");
                                Console.WriteLine(deco.b2);//Decoracion consola
                                Console.WriteLine("1 - Lista de clientes particulares");
                                Console.WriteLine("2 - Lista de clientes corporativos");
                                Console.WriteLine("Backspace - Para volver al menu principal");
                                Console.WriteLine();//Decoracion consola
                                Console.WriteLine();//Decoracion consola
                                do {
                                    opcionTipoCliente = Console.ReadKey(true);
                                } while (((int)opcionTipoCliente.KeyChar != 08) && (opcionTipoCliente.KeyChar < '1' || opcionTipoCliente.KeyChar > '2'));
                                switch (opcionTipoCliente.KeyChar) {

                                    // MUESTRA CLIENTES PARTICULARES
                                    // Recorre la lista de clientes particulares y muestra todos los clientes
                                    case '1':
                                    mostrarClientesParticulares: // salto de goto
                                        Console.WriteLine();//Decoracion consola
                                        Console.WriteLine("Acontinuacion se detalla toda la lista de clientes PARTICULARES registrados:");
                                        Console.WriteLine(deco.b2);//Decoracion consola
                                        Console.WriteLine();//Decoracion consola
                                        foreach (var a in liClientes) {
                                            Console.WriteLine(deco.b2);//Decoracion consola
                                            Console.WriteLine("- NroCliente: " + a.NroCliente + " || - Nombre: " + a.Nombre + " || - Apellido: " + a.Apellido +
                                                 " || - Edad: " + a.Edad);
                                            Console.WriteLine("- DNI: " + a.Dni + " || - Nacionalidad: " + a.Nacionalidad);
                                            Console.WriteLine("- Localidad: " + a.Localidad + " || - Direccion: " + a.Direccion
                                                 + " || - Telefono: " + a.Telefono);
                                            Console.WriteLine(deco.b2);//Decoracion consola
                                            Console.WriteLine();//Decoracion consola
                                        }
                                        Console.WriteLine();//Decoracion consola
                                        Console.WriteLine();//Decoracion consola
                                        // Opciones de que quiere hacer el usuario cuando finaliza de ingrezar datos o de utilizar una funcion
                                        Console.WriteLine(deco.b1);//Decoracion consola
                                        Console.WriteLine("¿Que desea hacer?:");
                                        Console.WriteLine(deco.b1);//Decoracion consola
                                        Console.WriteLine("1 - Ver Lista de clientes corporativos");
                                        Console.WriteLine("2 - Editar cliente");
                                        Console.WriteLine("Backspace - Volver al menu principal");
                                        do {
                                            opcionGuardado = Console.ReadKey(true);
                                        } while (((int)opcionGuardado.KeyChar != 08) && (opcionGuardado.KeyChar < '1' || opcionGuardado.KeyChar > '2'));
                                        switch (opcionGuardado.KeyChar) {

                                            case '1':
                                                Console.WriteLine();//Decoracion consola                                          
                                                Console.WriteLine("Mostrando la lista de clientes corporativos...");
                                                Console.WriteLine();//Decoracion consola
                                                goto mostrarClientesCorporativos; // se redirige el flujo a la seccion que muestra la lista de corporativos

                                            case '2':
                                                Console.WriteLine();//Decoracion consola                                          
                                                Console.WriteLine("Redireccionando a modificacion de cliente...");
                                                Console.WriteLine();//Decoracion consola
                                                goto nuevaEdicion; // redirecciona el flujo al menu de modificacion de cliente
                                        }
                                        break;

                                    // MUESTRA CLIENTES CORPORATIVOS
                                    // Recorre la lista de clientes corporativos y muestra todos los clientes
                                    case '2':
                                    mostrarClientesCorporativos: // salto de goto
                                        Console.WriteLine();//Decoracion consola
                                        Console.WriteLine("Acontinuacion se detalla toda la lista de clientes CORPORATIVOS registrados:");
                                        Console.WriteLine(deco.b2);//Decoracion consola
                                        Console.WriteLine();//Decoracion consola

                                        foreach (var b in clienteCorp) {
                                            Console.WriteLine(deco.b2);//Decoracion consola
                                            Console.WriteLine("- NroCliente: " + b.NroCliente + " || - Nombre: " + b.Nombre + " || - Apellido: " + b.Apellido +
                                                 " || - Edad: " + b.Edad);
                                            Console.WriteLine("- DNI: " + b.Dni + " || - Nacionalidad: " + b.Nacionalidad);
                                            Console.WriteLine("- Localidad: " + b.Localidad + " || - Direccion: " + b.Direccion
                                                 + " || - Telefono: " + b.Telefono);
                                            Console.WriteLine("- CUIT: " + b.Cuit + " || - Razon social: " + b.RazonSocial);
                                            Console.WriteLine(deco.b2);//Decoracion consola
                                            Console.WriteLine();//Decoracion consola
                                        }
                                        Console.WriteLine();//Decoracion consola
                                        Console.WriteLine();//Decoracion consola

                                        // Opciones de que quiere hacer el usuario cuando finaliza de ingrezar datos o de utilizar una funcion
                                        Console.WriteLine(deco.b1);//Decoracion consola
                                        Console.WriteLine("¿Que desea hacer?:");
                                        Console.WriteLine(deco.b1);//Decoracion consola
                                        Console.WriteLine("1 - Ver lista clientes particulares");
                                        Console.WriteLine("2 - Editar cliente");
                                        Console.WriteLine("Backspace - Para volver al menu principal");
                                        do {
                                            opcionGuardado = Console.ReadKey(true);
                                        } while (((int)opcionGuardado.KeyChar != 08) && (opcionGuardado.KeyChar < '1' || opcionGuardado.KeyChar > '2'));
                                        switch (opcionGuardado.KeyChar) {
                                            case '1':
                                                Console.WriteLine();//Decoracion consola
                                                Console.WriteLine("Mostrando la lista de clientes particulares...");
                                                Console.WriteLine();//Decoracion consola
                                                goto mostrarClientesParticulares; // Redirecciona el flujo al menu de modificacion de cliente

                                            case '2':
                                                Console.WriteLine();//Decoracion consola
                                                Console.WriteLine("Redireccionando a modificacion de cliente...");
                                                Console.WriteLine();//Decoracion consola
                                                goto nuevaEdicion;// redirecciona el flujo al menu de modificacion de cliente
                                        }
                                        break;
                                }
                                break;




                            case '5':
                            /*
                             * Codigo para eliminar a cliente por nroCliente.
                             * 
                             */
                            eliminarOtro://Salto de flujo del goto
                                Console.WriteLine(deco.b1);//Decoracion consola
                                Console.WriteLine("***********// ELIMINAR CLIENTE \\***********");
                                Console.WriteLine(deco.b1);//Decoracion consola
                                Console.WriteLine();//Decoracion consola
                                Console.WriteLine("Seleccione tipoo de cliente a eliminar:");
                                Console.WriteLine(deco.b2);//Decoracion consola
                                Console.WriteLine("1 - Particular");
                                Console.WriteLine("2 - Corporativo");
                                do {
                                    opcionTipoCliente = Console.ReadKey(true);
                                } while ((opcionTipoCliente.KeyChar < '1' || opcionTipoCliente.KeyChar > '2'));
                                switch (opcionTipoCliente.KeyChar) {

                                    case '1':
                                        Console.WriteLine();//Decoracion consola
                                        Console.Write("Ingrese nro. de cliente: ");
                                        int.TryParse(Console.ReadLine(), out nroCliente);
                                        Console.WriteLine(deco.b2);//Decoracion consola
                                        cli = liClientes.Find(x => x.NroCliente == nroCliente);
                                        if (cli != null) {
                                            Console.WriteLine();//Decoracion consola
                                            Console.WriteLine("////////¡¡¡ATENCION!!!\\\\\\\\");
                                            Console.WriteLine(deco.b2);//Decoracion consola
                                            Console.WriteLine("Se eliminará el cliente: " + nroCliente);
                                            cli.mostrarDatos();
                                            Console.WriteLine();//Decoracion consola
                                            Console.WriteLine("Esta seguro?");
                                            Console.WriteLine(deco.b2);//Decoracion consola
                                            Console.WriteLine("s - Sí");
                                            Console.WriteLine("n - No");
                                            do {
                                                opcionGuardado = Console.ReadKey(true);
                                            } while (((int)opcionGuardado.KeyChar != 121) && ((int)opcionGuardado.KeyChar != 110));

                                            switch (opcionGuardado.KeyChar) {
                                                case 's':
                                                    Console.WriteLine(); //Decoracion consola
                                                    liClientes.Remove(cli);
                                                    Console.WriteLine("Cliente eliminado existosamente.");
                                                    Console.WriteLine();//Decoracion consola
                                                    break;

                                                case 'n':
                                                    Console.WriteLine();//Decoracion consola
                                                    Console.WriteLine("Eliminacion de cliente cancelada");
                                                    Console.WriteLine();//Decoracion consola
                                                    break;
                                            }
                                        }
                                        else {
                                            Console.WriteLine(deco.b1);//Decoracion consola
                                            Console.WriteLine("No se encontro el nro. de cliente " + nroCliente + " a eliminar");
                                            Console.WriteLine(deco.b1);//Decoracion consola
                                        }
                                        // Opciones de que quiere hacer el usuario cuando finaliza de ingrezar datos o de utilizar una funcion
                                        Console.WriteLine();//Decoracion consola
                                        Console.WriteLine(deco.b1);// Decoracion de consola
                                        Console.WriteLine("Desea eliminar otro cliente?");
                                        Console.WriteLine(deco.b1);// Decoracion de consola
                                        Console.WriteLine("y - Si");
                                        Console.WriteLine("n - No");
                                        Console.WriteLine();//Decoracion consola
                                        do {
                                            opcionGuardado = Console.ReadKey(true);
                                        } while (((int)opcionGuardado.KeyChar != 121) && (opcionGuardado.KeyChar != 110));
                                        switch (opcionGuardado.KeyChar) {
                                            case 'y':
                                                Console.WriteLine();//Decoracion consola
                                                Console.WriteLine("Volviendo al menu de creacion de clientes...");
                                                Console.WriteLine();//Decoracion consola
                                                goto eliminarOtro; // redirecciona el flujo al menu de creacion de clientes

                                            case 'n':
                                                Console.WriteLine();//Decoracion consola
                                                Console.WriteLine("Regresando a menu principal...");
                                                Console.WriteLine();//Decoracion consola
                                                goto volver; // salta al menu principal
                                        }
                                        break;

                                    // Recorre la lista de clientes corporativos y muestra todos los clientes
                                    case '2':
                                        Console.WriteLine();//Decoracion consola
                                        Console.Write("Ingrese nro. de cliente: ");
                                        int.TryParse(Console.ReadLine(), out nroCliente);
                                        Console.WriteLine(deco.b2);//Decoracion consola
                                        cliCorp = clienteCorp.Find(x => x.NroCliente == nroCliente);
                                        if (cliCorp != null) {
                                            Console.WriteLine();//Decoracion consola
                                            Console.WriteLine("////////¡¡¡ATENCION!!!\\\\\\\\");
                                            Console.WriteLine(deco.b2);//Decoracion consola
                                            Console.WriteLine("Se eliminará el cliente: " + nroCliente);
                                            cli.mostrarDatos();
                                            Console.WriteLine();//Decoracion consola
                                            Console.WriteLine("Esta seguro?");
                                            Console.WriteLine(deco.b2);//Decoracion consola
                                            Console.WriteLine("s - Sí");
                                            Console.WriteLine("n - No");
                                            do {
                                                opcionGuardado = Console.ReadKey(true);
                                            } while (((int)opcionGuardado.KeyChar != 121) && ((int)opcionGuardado.KeyChar != 110));

                                            switch (opcionGuardado.KeyChar) {
                                                case 's':
                                                    Console.WriteLine(); //Decoracion consola
                                                    clienteCorp.Remove(cliCorp);
                                                    Console.WriteLine("Cliente eliminado existosamente.");
                                                    Console.WriteLine();//Decoracion consola
                                                    break;

                                                case 'n':
                                                    Console.WriteLine();//Decoracion consola
                                                    Console.WriteLine("Eliminacion de cliente cancelada");
                                                    Console.WriteLine();//Decoracion consola
                                                    break;
                                            }
                                        }
                                        else {
                                            Console.WriteLine(deco.b1);//Decoracion consola
                                            Console.WriteLine("No se encontro el nro. de cliente " + nroCliente + " a eliminar");
                                            Console.WriteLine(deco.b1);//Decoracion consola
                                        }
                                        // Opciones de que quiere hacer el usuario cuando finaliza de ingrezar datos o de utilizar una funcion
                                        Console.WriteLine();//Decoracion consola
                                        Console.WriteLine(deco.b1);// Decoracion de consola
                                        Console.WriteLine("Desea eliminar otro cliente?");
                                        Console.WriteLine(deco.b1);// Decoracion de consola
                                        Console.WriteLine("y - Si");
                                        Console.WriteLine("n - No");
                                        Console.WriteLine();//Decoracion consola
                                        do {
                                            opcionGuardado = Console.ReadKey(true);
                                        } while (((int)opcionGuardado.KeyChar != 121) && (opcionGuardado.KeyChar != 110));
                                        switch (opcionGuardado.KeyChar) {
                                            case 'y':
                                                Console.WriteLine();//Decoracion consola
                                                Console.WriteLine("Volviendo al menu de creacion de clientes...");
                                                Console.WriteLine();//Decoracion consola
                                                goto eliminarOtro; // redirecciona el flujo al menu de creacion de clientes

                                            case 'n':
                                                Console.WriteLine();//Decoracion consola
                                                Console.WriteLine("Regresando a menu principal...");
                                                Console.WriteLine();//Decoracion consola
                                                goto volver; // salta al menu principal
                                        }
                                        break;

                                } while ((int)opcionCliente.KeyChar != 08) ;
                                break; // Fin seccion de menu de clientes.
                        }break;

                    // Menu factura
                    case '2':
                        break;
                }
            } while ((int)opcion.KeyChar != 27);// Codigo ASCII del boton "Esc"
        }
    }
}
