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
            ConsoleKeyInfo confirma;




        // Menu principal
        volver:
            do {
                Console.WriteLine("===================================================");
                Console.WriteLine("**************// Empresa de viajes \\**************");
                Console.WriteLine("===================================================");
                Console.WriteLine();
                Console.WriteLine("BienvennroClienteo ingrese una de las siguientes opciones para continuar:");
                Console.WriteLine();
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
                        Console.WriteLine("Eliga una de las siguientes opciones:");
                        Console.WriteLine("1 - Crear un nuevo cliente");
                        Console.WriteLine("2 - Ver datos de un cliente");
                        Console.WriteLine("3 - Modificar datos de un cliente");
                        Console.WriteLine("4 - Ver listado de clientes");
                        Console.WriteLine("5 - Eliminar un cliente");
                        Console.WriteLine("Backspace - Para volver hacia atras");
                        do {/*
                             *  El usuario debe ingresar los numeros que aparacen en el menu para interaccionar con la consola.El "O8"
                             *  corresponde al codico ASCII de la tecla retroceso.
                             */
                           
                          opcionCliente = Console.ReadKey(true);
                        } while (((int)opcionCliente.KeyChar != 08) && (opcionCliente.KeyChar < '1' || opcionCliente.KeyChar > '5'));
                        switch (opcionCliente.KeyChar) {
                            // Menu para crear tipos de clientes

                            case '1':
                            nuevoCliente:
                                Console.WriteLine("1 - Crear cliente particular");
                                Console.WriteLine("2 - Crear cliente corporativo");
                                do {/* El usuario debe ingresar los numeros que aparacen en el menu para interaccionar con la consola. El "O8" 
                                     * corresponde al codico ASCII de la tecla retroceso.
                                     */
                                    opcionTipoCliente = Console.ReadKey(true);
                                } while (opcionTipoCliente.KeyChar < '1' || opcionTipoCliente.KeyChar > '2');
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
                                        Console.WriteLine("***********// NUEVO CLIENTE PARTICULAR \\***********");
                                        Console.WriteLine("nroCliente:");
                                        int.TryParse(Console.ReadLine(), out nroCliente);
                                        // Verifico que el numero de cliente no existe
                                        if (liClientes.Count(x => x.NroCliente == nroCliente) == 0) {

                                            Console.WriteLine("Particular: true"); // imprime "particular : true"
                                            esParticular = true;

                                            Console.WriteLine("Nombre:");
                                            nombre = Console.ReadLine();

                                            Console.WriteLine("Apellido:");
                                            apellido = Console.ReadLine();

                                            Console.WriteLine("Edad:");
                                            edad = byte.Parse(Console.ReadLine());

                                            Console.WriteLine("DNI:");
                                            dni = Console.ReadLine();

                                            Console.WriteLine("Nacionalidad:");
                                            nacionalidad = Console.ReadLine();

                                            Console.WriteLine("Localidad:");
                                            localidad = Console.ReadLine();

                                            Console.WriteLine("Direccion:");
                                            direccion = Console.ReadLine();

                                            Console.WriteLine("Telefono:");
                                            telefono = Console.ReadLine();

                                            cli = new Cliente(nroCliente, esParticular, nombre, apellido, edad, dni, nacionalidad, localidad, direccion, telefono);
                                            liClientes.Add(cli);
                                        }
                                        else {
                                            Console.WriteLine("Error: el nroCliente del cliente que intenta crear ya existe");
                                        }

                                        // OPCIONES DE SALIDA DE CREACION
                                        Console.WriteLine("Desea cargar otro cliente?");
                                        Console.WriteLine("y - Si");
                                        Console.WriteLine("n - No");
                                        do {
                                            opcionGuardado = Console.ReadKey(true);
                                        } while (((int)opcionGuardado.KeyChar != 121) && ((int)opcionGuardado.KeyChar != 110));
                                        switch (opcionGuardado.KeyChar) {
                                            case 'y':
                                                Console.WriteLine("Volviendo al menu de creacion de clientes...");
                                                goto nuevoCliente;

                                            case 'n':
                                                Console.WriteLine("Regresando a menu principal...");
                                                goto volver;
                                        }
                                        break;

                                    /*
                                     * Si se trata de crear un nuevo cliente pero que sea corporativo, este utiliza tanto el constructor de la clase corporativo que hereda
                                     * tambien el constructor de la clase cliente.
                                     * 
                                     * Tambien se debe crear una estructura "if...else" que me diga si el cliente que se trata de crear 
                                     * ya existe.
                                     * 
                                     * ¡¡¡¡ATENCION!!! aun no captura excepciones
                                     * 
                                     */
                                    case '2':
                                        Console.WriteLine("***********// NUEVO CLIENTE CORPORATIVO \\***********");

                                        Console.WriteLine("nroCliente:");
                                        int.TryParse(Console.ReadLine(), out nroCliente);
                                        // Verico que el numero de clioente no existe
                                        if (clienteCorp.Count(x => x.NroCliente == nroCliente) == 0) {

                                            //QUITAR
                                            Console.WriteLine("Particular: false"); // imprime "Corporativo : true"
                                            bool.TryParse(Console.ReadLine(), out esParticular);

                                            //QUITAR
                                            Console.WriteLine("Corporativo:"); // imprime "Corporativo : true"
                                            bool.TryParse(Console.ReadLine(), out esCorporativo);

                                            Console.WriteLine("Nombre:");
                                            nombre = Console.ReadLine();

                                            Console.WriteLine("Apellido:");
                                            apellido = Console.ReadLine();

                                            Console.WriteLine("Edad:");
                                            edad = byte.Parse(Console.ReadLine());

                                            Console.WriteLine("DNI del cliente");
                                            dni = Console.ReadLine();

                                            Console.WriteLine("Nacionalidad:");
                                            nacionalidad = Console.ReadLine();

                                            Console.WriteLine("Localidad:");
                                            localidad = Console.ReadLine();

                                            Console.WriteLine("Direccion:");
                                            direccion = Console.ReadLine();

                                            Console.WriteLine("Telefono:");
                                            telefono = Console.ReadLine();

                                            Console.WriteLine("CUIT:");
                                            cuit = Console.ReadLine();

                                            Console.WriteLine("Razon social:");
                                            razonSocial = Console.ReadLine();


                                            cliCorp = new Corporativo(nroCliente, esParticular, nombre, apellido, edad, dni, nacionalidad, localidad, direccion, telefono, cuit, razonSocial, esCorporativo);
                                            clienteCorp.Add(cliCorp);
                                        }
                                        else {
                                            Console.WriteLine("Error: el nroCliente del cliente que intenta crear ya existe");
                                        }

                                        //OPCIONES DE SALIDA DE CREACION
                                        Console.WriteLine("Desea cargar otro cliente?");
                                        Console.WriteLine("y - Si");
                                        Console.WriteLine("n - No");
                                        do {
                                            opcionGuardado = Console.ReadKey(true);
                                        } while (((int)opcionGuardado.KeyChar != 121) && (opcionGuardado.KeyChar != 110));
                                        switch (opcionGuardado.KeyChar) {
                                            case 'y':
                                                Console.WriteLine("Volviendo al menu de creacion de clientes...");
                                                goto nuevoCliente;

                                            case 'n':
                                                Console.WriteLine("Regresando a menu principal...");
                                                goto volver;

                                        }
                                        break;
                                }
                                break;

                            case '2':
                            // ERROR EN ALGUNA PARTE DEL CODIGO, NO PUEDO VISUALIZAR LA INFO DE LOS CLIENTES CON EL METODO MOSTRAR DATOS
                            infoCliente:
                                Console.WriteLine("***********//* VER INFORMACION DE CLIENTES \\***********");
                                Console.WriteLine();
                                Console.WriteLine("Acontinuacion elija el tipo de cliente para acceder a la informacion del mismo:");
                                Console.WriteLine("1 -  Cliente particular");
                                Console.WriteLine("2 - Cliente corporativo");
                                do {
                                    opcionInfo = Console.ReadKey(true);
                                } while ((opcionInfo.KeyChar < '1' || opcionInfo.KeyChar > '2'));
                                switch (opcionInfo.KeyChar) {

                                    case '1': //Particular
                                        Console.WriteLine("----- PARTICULAR -----");
                                        Console.WriteLine("Ingrese nroCliente del cliente:");
                                        int.TryParse(Console.ReadLine(), out nroCliente);
                                        // Por cada elemento (x) de la lista dame el primero que su atributo sea igual a "nroCliente"
                                        cli = liClientes.Find(x => x.NroCliente == nroCliente);
                                        if (cli != null) {
                                            cli.mostrarDatos(); // No me muestra la info del cliente
                                        }
                                        else {
                                            // Me redirecciona automaticamente aqui sin mostrarme los datos del cliente
                                            Console.WriteLine("No se encontro el cliente con ID: " + nroCliente);
                                        }

                                        //OPCIONES DE SALIDA DE "VISTA DE INFORMACION"
                                        Console.WriteLine("Desea ver la informacion de otro cliente?");
                                        Console.WriteLine("y - Si");
                                        Console.WriteLine("n - No");
                                        do {
                                            opcionGuardado = Console.ReadKey(true);
                                        } while (((int)opcionGuardado.KeyChar != 121) && ((int)opcionGuardado.KeyChar != 110));
                                        switch (opcionGuardado.KeyChar) {
                                            case 'y':
                                                goto infoCliente;

                                            case 'n':
                                                Console.WriteLine("Regresando a menu principal...");
                                                goto volver;
                                        }
                                        break;


                                    case '2': // Corporativo
                                        Console.WriteLine("----- CORPORATIVO ----");
                                        Console.WriteLine("Ingrese nroCliente del cliente:");
                                        int.TryParse(Console.ReadLine(), out nroCliente);
                                        cliCorp = clienteCorp.Find(x => x.NroCliente == nroCliente);
                                        if (cliCorp != null) {
                                            cliCorp.mostrarDatos();
                                        }
                                        else {
                                            // Me redirecciona automaticamente aqui sin mostrarme los datos del cliente
                                            Console.WriteLine("No se encontro el cliente con ID: " + nroCliente);
                                        }

                                        //OPCIONES DE SALIDA DE "VISTA DE INFORMACION"
                                        Console.WriteLine("Desea ver la informacion de otro cliente?");
                                        Console.WriteLine("y - Si");
                                        Console.WriteLine("n - No");
                                        do {
                                            opcionGuardado = Console.ReadKey(true);
                                        } while (((int)opcionGuardado.KeyChar != 121) && ((int)opcionGuardado.KeyChar != 110));
                                        switch (opcionGuardado.KeyChar) {
                                            case 'y':
                                                goto infoCliente;

                                            case 'n':
                                                Console.WriteLine("Regresando a menu principal...");
                                                goto volver;
                                        }
                                        break;
                                }
                                break;
                            case '3':

                            /*
                             * Codigo a generar para modificar los datos de un cliente
                             * 
                             * 
                             * Tambien tiene que tener la opcion de volver hacia atras para modificar otro cliente.
                             * 
                             * antes de volver a atras o guardar cambios, se debe confirmar con dos opciones, una para
                             * guardar cambios y otra para cancelar los mismos.
                             * 
                             */

                            nuevaEdicion:
                                Console.WriteLine("***********// MODIFICAR INFORMACION DE CLIENTES \\***********");
                                Console.WriteLine();
                                Console.WriteLine("Acontinuacion elija el tipo de cliente a modificar:");
                                Console.WriteLine("1 -  Cliente particular");
                                Console.WriteLine("2 - Cliente corporativo");
                                do {
                                    opcionTipoCliente = Console.ReadKey(true);
                                } while ((opcionTipoCliente.KeyChar < '1' || opcionTipoCliente.KeyChar > '2'));
                                switch (opcionTipoCliente.KeyChar) {

                                    case '1':

                                        Console.WriteLine("Ingrese el nroCliente del cliente a modificar:");
                                        Console.WriteLine("----- PARTICULAR -----");
                                        Console.WriteLine("Ingrese nroCliente del cliente:");
                                        int.TryParse(Console.ReadLine(), out nroCliente);
                                        cli = liClientes.Find(x => x.NroCliente == nroCliente);
                                        if (cli != null) {

                                            Console.WriteLine("Nombre:");
                                            cli.Nombre = Console.ReadLine();

                                            Console.WriteLine("Apellido:");
                                            cli.Apellido = Console.ReadLine();

                                            Console.WriteLine("Edad:");
                                            cli.Edad = byte.Parse(Console.ReadLine());

                                            Console.WriteLine("DNI:");
                                            cli.Dni = Console.ReadLine();

                                            Console.WriteLine("Nacionalidad:");
                                            cli.Nacionalidad = Console.ReadLine();

                                            Console.WriteLine("Localidad:");
                                            cli.Localidad = Console.ReadLine();

                                            Console.WriteLine("Direccion:");
                                            cli.Direccion = Console.ReadLine();

                                            Console.WriteLine("Telefono:");
                                            cli.Telefono = Console.ReadLine();
                                        }
                                        else {
                                            Console.WriteLine("No se encontro el nro. de cliente: " + nroCliente);
                                        }
                                        // se le pregunta al usuario si desea seguir editando, si no desea se lo devuelve al menu principal
                                        Console.WriteLine("¿Desea seguir editando?:");
                                        Console.WriteLine("y - Si");
                                        Console.WriteLine("n - No");
                                        do {
                                            opcionGuardado = Console.ReadKey(true);
                                        } while (((int)opcionGuardado.KeyChar != 121) && ((int)opcionGuardado.KeyChar != 110));
                                        switch (opcionGuardado.KeyChar) {
                                            case 'y':
                                                goto nuevaEdicion;

                                            case 'n':
                                                Console.WriteLine("Regresando a menu principal...");
                                                goto volver;

                                        }
                                        break;

                                    case '2':
                                        Console.WriteLine("----- CORPORATIVO ----");
                                        Console.WriteLine("Ingrese nroCliente del cliente:");
                                        int.TryParse(Console.ReadLine(), out nroCliente);
                                        cliCorp = clienteCorp.Find(x => x.NroCliente == nroCliente);
                                        if (cliCorp != null) {

                                            Console.WriteLine("Nombre:");
                                            cliCorp.Nombre = Console.ReadLine();

                                            Console.WriteLine("Apellido:");
                                            cliCorp.Apellido = Console.ReadLine();

                                            Console.WriteLine("Edad:");
                                            cliCorp.Edad = byte.Parse(Console.ReadLine());

                                            Console.WriteLine("DNI:");
                                            cliCorp.Dni = Console.ReadLine();

                                            Console.WriteLine("Nacionalidad:");
                                            cliCorp.Nacionalidad = Console.ReadLine();

                                            Console.WriteLine("Localidad:");
                                            cliCorp.Localidad = Console.ReadLine();

                                            Console.WriteLine("Direccion:");
                                            cliCorp.Direccion = Console.ReadLine();

                                            Console.WriteLine("Telefono:");
                                            cliCorp.Telefono = Console.ReadLine();

                                            Console.WriteLine("CUIT:");
                                            cliCorp.Cuit = Console.ReadLine();

                                            Console.WriteLine("Razon social:");
                                            cliCorp.RazonSocial = Console.ReadLine();

                                        }
                                        else {
                                            Console.WriteLine("No se encontro el nro. de cliente: " + nroCliente);
                                        }
                                        // se le pregunta al usuario si desea seguir editando, si no desea se lo devuelve al menu principal
                                        Console.WriteLine("¿Desea seguir editando?:");
                                        Console.WriteLine("y - Si");
                                        Console.WriteLine("n - No");
                                        do {
                                            opcionGuardado = Console.ReadKey(true);
                                        } while (((int)opcionGuardado.KeyChar != 121) && ((int)opcionGuardado.KeyChar != 110));
                                        switch (opcionGuardado.KeyChar) {
                                            case 'y':
                                                goto nuevaEdicion;

                                            case 'n':
                                                Console.WriteLine("Regresando a menu principal...");
                                                goto volver;

                                        }
                                        break;
                                }
                                break;

                            case '4':
                                Console.WriteLine("***********// OBTENER LISTA DE CLIENTES \\***********");
                                Console.WriteLine();
                                Console.WriteLine("Acontinuacion elija el tipo de lista de cliente que desea ver:");
                                Console.WriteLine("1 - Lista de clientes particulares");
                                Console.WriteLine("2 - Lista de clientes corporativos");
                                do {
                                    opcionTipoCliente = Console.ReadKey(true);
                                } while ((opcionTipoCliente.KeyChar < '1' || opcionTipoCliente.KeyChar > '2'));
                                switch (opcionTipoCliente.KeyChar) {

                                    // Recorre la lista de clientes particulares y muestra todos los clientes
                                    case '1':
                                        Console.WriteLine("Acontinuacion se detalla toda la lista de clientes PARTICULARES registrados:");
                                        foreach (var a in liClientes) {
                                            Console.WriteLine("Nombre: " + a.Nombre + " // " + "apellido: " + a.Apellido + " // " +
                                                 "Edad: " + a.Edad + " // " + "DNI: " + a.Dni + " // " + "nacionalidad: " + a.Nacionalidad
                                                 + " // " + "localidad: " + a.Localidad + " // " + "Direccion: " + a.Direccion + " // "
                                                 + "Telefono: " + a.Telefono);
                                        }
                                        Console.WriteLine("¿Que desea hacer?:");
                                        Console.WriteLine("e - Editar cliente");
                                        Console.WriteLine("n - Volver al menu principal");
                                        do {
                                            opcionGuardado = Console.ReadKey(true);
                                        } while (((int)opcionGuardado.KeyChar != 110) && ((int)opcionGuardado.KeyChar < 101));
                                        switch (opcionGuardado.KeyChar) {
                                            case 'e':
                                                Console.WriteLine("Redireccionando a modificacion de clientes...");
                                                goto nuevaEdicion;

                                            case 'n':
                                                Console.WriteLine("Regresando a menu principal...");
                                                goto volver;
                                                break;
                                        }
                                        break;

                                    // Recorre la lista de clientes corporativos y muestra todos los clientes
                                    case '2':
                                        Console.WriteLine("Acontinuacion se detalla toda la lista de clientes CORPORATIVOS registrados:");
                                        foreach (var b in clienteCorp) {
                                            Console.WriteLine("Nombre: " + b.Nombre + " // " + "apellido: " + b.Apellido + " // " +
                                                 "Edad: " + b.Edad + " // " + "DNI: " + b.Dni + " // " + "nacionalidad: " + b.Nacionalidad
                                                 + " // " + "localidad: " + b.Localidad + " // " + "Direccion: " + b.Direccion + " // "
                                                 + "Telefono: " + b.Telefono + " // " + "CUIT: " + b.Cuit + " // " + "Razon social: " + b.RazonSocial);
                                        }
                                        Console.WriteLine("¿Que desea hacer?:");
                                        Console.WriteLine("e - Editar cliente");
                                        Console.WriteLine("n - Volver al menu principal");
                                        do {
                                            opcionGuardado = Console.ReadKey(true);
                                        } while (((int)opcionGuardado.KeyChar != 110) && ((int)opcionGuardado.KeyChar < 101));
                                        switch (opcionGuardado.KeyChar) {
                                            case 'e':
                                                Console.WriteLine("Redireccionando a modificacion de clientes...");
                                                goto nuevaEdicion;

                                            case 'n':
                                                Console.WriteLine("Regresando a menu principal...");
                                                goto volver;
                                                break;
                                        }

                                        break;
                                }
                                break;

                            case '5':
                                /*
                                 * Codigo para eliminar a cliente por nroCliente.
                                 * 
                                 * Debe haber una confirmacion para la elimin acion del usuario con un mensaje de salnroClientea 
                                 * para ambas opciones a elegir.
                                 * 
                                 */
                                eliminarOtro:
                                Console.WriteLine("***********// ELIMINAR CLIENTE \\***********");
                                Console.WriteLine("Seleccione tipoo de cliente a eliminar:");
                                Console.WriteLine("1 - Particular");
                                Console.WriteLine("1 - Corporativo");
                                do {
                                    opcionTipoCliente = Console.ReadKey(true);
                                } while ((opcionTipoCliente.KeyChar < '1' || opcionTipoCliente.KeyChar > '2'));
                                switch (opcionTipoCliente.KeyChar) {

                                    case '1':
                                        Console.WriteLine("Ingrese nro. de cliente:");
                                        int.TryParse(Console.ReadLine(), out nroCliente);
                                        cli = liClientes.Find(x => x.NroCliente == nroCliente);
                                        if (cli != null) {
                                            Console.WriteLine("¡¡¡ATENCION!!!:");
                                            Console.WriteLine("Se eliminará el cliente:");
                                            cli.mostrarDatos();
                                            Console.WriteLine("Esta seguro?");
                                            Console.WriteLine("s - Sí");
                                            Console.WriteLine("n - No");
                                            do {
                                                opcionGuardado = Console.ReadKey(true);
                                            } while (((int)opcionGuardado.KeyChar != 121) && ((int)opcionGuardado.KeyChar != 110));

                                            switch (opcionGuardado.KeyChar) {
                                                case 's':
                                                    liClientes.Remove(cli);
                                                    Console.WriteLine("Cliente eliminado existosamente.");
                                                    break;

                                                case 'n':
                                                    Console.WriteLine("Eliminacion de cliente cancelada");
                                                    break;
                                            }

                                           
                                        } else {
                                            Console.WriteLine("No se encontro el nro. de cliente " + nroCliente + " a eliminar");
                                        }
                                            Console.WriteLine("¿Que desea hacer ahora?:");
                                            Console.WriteLine("1 - Eliminar otro cliente");
                                            Console.WriteLine("n - Volver al menu principal");
                                            do {
                                                opcionGuardado = Console.ReadKey(true);
                                            } while (((int)opcionGuardado.KeyChar != 110) && (opcionGuardado.KeyChar < '1'));
                                            switch (opcionGuardado.KeyChar) {
                                                case '1':
                                                    Console.WriteLine("Procediendo a la eliminacion de otro cliente...");
                                                    goto eliminarOtro;

                                                case 'n':
                                                    Console.WriteLine("Regresando a menu principal...");
                                                    goto volver;

                                            }
                                        break;

                                    // Recorre la lista de clientes corporativos y muestra todos los clientes
                                    case '2':
                                        Console.WriteLine("Ingrese nro. de cliente:");
                                        int.TryParse(Console.ReadLine(), out nroCliente);
                                        cliCorp = clienteCorp.Find(x => x.NroCliente == nroCliente);
                                        if (cliCorp != null) {
                                            Console.WriteLine("¡¡¡ATENCION!!!:");
                                            Console.WriteLine("Se eliminará el cliente:");
                                            cli.mostrarDatos();
                                            Console.WriteLine("Esta seguro?");
                                            Console.WriteLine("s - Sí");
                                            Console.WriteLine("n - No");
                                            do {
                                                opcionGuardado = Console.ReadKey(true);
                                            } while (((int)opcionGuardado.KeyChar != 121) && ((int)opcionGuardado.KeyChar != 110));

                                            switch (opcionGuardado.KeyChar) {
                                                case 's':
                                                    clienteCorp.Remove(cliCorp);
                                                    Console.WriteLine("Cliente eliminado existosamente.");
                                                    break;

                                                case 'n':
                                                    Console.WriteLine("Eliminacion de cliente cancelada");
                                                    break;
                                            }
                                        }
                                        else {
                                            Console.WriteLine("No se encontro el nro. de cliente " + nroCliente + " a eliminar");
                                        }
                                        Console.WriteLine("¿Que desea hacer ahora?:");
                                            Console.WriteLine("1 - Eliminar otro cliente");
                                            Console.WriteLine("n - Volver al menu principal");
                                            do {
                                                opcionGuardado = Console.ReadKey(true);
                                            } while (((int)opcionGuardado.KeyChar != 110) && (opcionGuardado.KeyChar < '1'));
                                            switch (opcionGuardado.KeyChar) {
                                                case '1':
                                                    Console.WriteLine("Procediendo a la eliminacion de otro cliente...");
                                                    goto eliminarOtro;

                                                case 'n':
                                                    Console.WriteLine("Regresando a menu principal...");
                                                    goto volver;
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
