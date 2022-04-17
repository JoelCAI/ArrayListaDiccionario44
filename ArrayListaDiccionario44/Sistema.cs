using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayListaDiccionario44
{
    public class Sistema
    {
        private List<UsuarioAdministrador> _usuarioAdministador;

       
        public Sistema()
        {
            this._usuarioAdministador = new List<UsuarioAdministrador>();
            
        }

		public void MostrarUsuario  ()
		{
			Console.Clear();
			Console.WriteLine("\n Usuario(s) Administrador(es):");
			Console.WriteLine(" #\tRegistro\tNombre");
			for (int i = 0; i < this._usuarioAdministador.Count; i++)
			{

				Console.Write(" " + (i + 1));
				Console.Write("\t");
				Console.Write(_usuarioAdministador[i].Registro);
				Console.Write("\t\t");
				Console.Write(_usuarioAdministador[i].Nombre);
				Console.Write("\n");


			}

		}

		

		public void RemoverUsuarioAdministrador(int pos)
        {
            this._usuarioAdministador.RemoveAt(pos);
        }

		public int BuscarUsuarioAdministradorNombre(string nombre)
		{
			for (int i = 0; i < this._usuarioAdministador.Count; i++)
			{
				if (this._usuarioAdministador[i].Nombre == nombre)
				{
					return i;
				}
			}
			return -1;
		}

		public int BuscarUsuarioAdministradorRegistro(int registro)
		{
			for (int i = 0; i < this._usuarioAdministador.Count; i++)
			{
				if (this._usuarioAdministador[i].Registro == registro)
				{
					return i;
				}
			}
			return -1;
		}

		public void EliminarUsuarioNombre()
		{
			string opcion;
			string nombre;
			int posUsuarioA;
			

			Console.Clear();
			opcion = Validador.ValidarSioNo("\n Desea Eliminar un Usuario?");
			if (opcion == "SI")
			{

				MostrarUsuario();
				nombre = Validador.ValidarStringNoVacioUsuarioClave("\n Ingrese el Nombre del Usuario");
				posUsuarioA = (BuscarUsuarioAdministradorNombre(nombre));
				
				if (posUsuarioA != -1 )
				{
					MostrarUsuario();
					Console.WriteLine("\n El Usuario *" + nombre + "* existe");
					opcion = Validador.ValidarSioNo("\n Desea eliminar este Usuario?");

					if (opcion == "SI")
					{
						if (posUsuarioA != -1)
						{
							RemoverUsuarioAdministrador(posUsuarioA);
							MostrarUsuario();
							Console.WriteLine("\n El Usuario Administrador se eliminó con Éxito");
							Validador.VolverMenu();

						}

					}
					else
					{
						MostrarUsuario();
						Console.WriteLine("\n No se hizo ningún cambio");
						Validador.VolverMenu();
					}

				}
				else
				{
					MostrarUsuario();
					Console.WriteLine("\n No existe un Usuario con el código *" + nombre + "*. ");
					Validador.VolverMenu();
				}

			}
			else
			{
				MostrarUsuario();
				Console.WriteLine("\n Como puede verificar no se hizo ningún cambio");
				Validador.VolverMenu();

			}

		}

		public void EliminarUsuarioID()
		{
			string opcion;
			int nombre;
			int posUsuarioA;
			

			Console.Clear();
			opcion = Validador.ValidarSioNo("\n Desea Eliminar un Usuario?");
			if (opcion == "SI")
			{

				MostrarUsuario();
				nombre = Validador.PedirIntRegistro("\n Ingrese el ID del Usuario");
				
				posUsuarioA = (BuscarUsuarioAdministradorRegistro(nombre));

				if (posUsuarioA != -1)
				{
					MostrarUsuario();
					Console.WriteLine("\n El Usuario *" + nombre + "* existe");
					opcion = Validador.ValidarSioNo("\n Desea eliminar este Usuario?");

					if (opcion == "SI")
					{
						if (posUsuarioA != -1)
						{
							RemoverUsuarioAdministrador(posUsuarioA);
							MostrarUsuario();
							Console.WriteLine("\n El Usuario Administrador se eliminó con Éxito");
							Validador.VolverMenu();

						}

					}
					else
					{
						MostrarUsuario();
						Console.WriteLine("\n No se hizo ningún cambio");
						Validador.VolverMenu();
					}

				}
				else
				{
					MostrarUsuario();
					Console.WriteLine("\n No existe un Usuario con el código *" + nombre + "*. ");
					Validador.VolverMenu();
				}

			}
			else
			{
				MostrarUsuario();
				Console.WriteLine("\n Como puede verificar no se hizo ningún cambio");
				Validador.VolverMenu();

			}

		}

		public void AddUsuarioAdministrador(UsuarioAdministrador usuario)
		{
			this._usuarioAdministador.Add(usuario);
		}

		public void MenuPrincipal()
		{
			Validador.Bienvenida();
			
			int opcion;
			string nombre;
			
			int posUsuarioA;
			
			/* Para crear los objetos (Los Usuarios que tendran acceso a las listas) */
			UsuarioAdministrador uA;
			
			do
			{
				Console.Clear();
				opcion = Validador.PedirIntMenu("\n Menú de Registro de nuevas Personas: " +
									   "\n [1] Dar de Alta una Persona." +
									   "\n [2] Dar de baja por número de ID de la Persona." +
									   "\n [3] Dar de baja por nombre de la Persona." +
									   "\n [4] Mostrar la(s) Persona(s)." +
									   "\n [5] Salir del Sistema.", 1, 5);
				switch (opcion)
				{
					/* Aqui vamos a validar que el usuario exista */
					case 1:
						Console.Clear();
						nombre = Validador.ValidarStringNoVacioUsuarioClave("\n\n Ingrese el Nombre de la Persona a crear: ");
						posUsuarioA = BuscarUsuarioAdministradorNombre(nombre);
						
						/* Si esto se cumple puedo crear un Usuario Repositor */
						if (posUsuarioA == -1 )
						{
							
							/* Creo el nuevo usuario */
							uA = new UsuarioAdministrador(nombre);
							/* Lo agrego a la lista de Repositores */
							_usuarioAdministador.Add(uA);
							Console.Clear();
							Console.WriteLine("\n Alta *" + nombre + "* se ha creado exitósamente" +
											  "\n\n Presione cualquier tecla para volver al Menú");
							Console.ReadKey();
						}
						else
						{
							Console.WriteLine("\n El Usuario *" + nombre + "* ya Existe " +
												  "\n Vuelva a intentarlo con un nombre Diferente");
							Validador.VolverMenu();
						}
						break;
					case 2:
						EliminarUsuarioID();
						break;
					case 3:
						EliminarUsuarioNombre();
						break;
					case 4:
						Console.Clear();
						MostrarUsuario();
						Validador.VolverMenu();
						break;
				}

			} while (opcion != 5);
			Validador.Despedida();

		}

        public void Iniciar()
        {
            MenuPrincipal();
        }

    }
}
