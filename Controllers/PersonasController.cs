using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio_1._3.Models;
using SQLite;

namespace Ejercicio_1._3.Controllers
{
    
    public class PersonasController
    {
        SQLiteAsyncConnection _connection;

        //Constructor vacio
        public PersonasController() { }

        //Conexion a la base de datos
        public async Task Init()
        {
            try
            {
                if (_connection is null)
                {
                    SQLite.SQLiteOpenFlags extensiones = SQLite.SQLiteOpenFlags.ReadWrite | SQLite.SQLiteOpenFlags.Create | SQLite.SQLiteOpenFlags.SharedCache;

                    if (string.IsNullOrEmpty(FileSystem.AppDataDirectory))
                    {
                        // Handle the case where AppDataDirectory is not set
                        return;
                    }

                    _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, "DBPersonas"), extensiones);

                    var creacion = await _connection.CreateTableAsync<Models.Persona>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Init(): {ex.Message}");
            }
        }

        //Crear metodos crud para la clase personas
        //Create
        public async Task<int> storePersona(Persona personas)
        {
            await Init();
            if (personas.Id == 0)
            {
                return await _connection.InsertAsync(personas);
            }
            else
            {
                return await _connection.UpdateAsync(personas);
            }
        }

        //Update
        public async Task<int> updatePersona(Persona persona)
        {
            await Init();
            return await _connection.UpdateAsync(persona);
        }

        //Read
        public async Task<List<Models.Persona>> getListPersons()
        {
            await Init();
            return await _connection.Table<Persona>().ToListAsync();
        }

        //Read Element
        public async Task<Models.Persona> getPersons(int pid)
        {
            await Init();
            return await _connection.Table<Persona>().Where(i => i.Id == pid).FirstOrDefaultAsync();
        }

        //Delete
        public async Task<int> deletePerson(int personId)
        {
            await Init();
            var personToDelete = await getPersons(personId);

            if (personToDelete != null)
            {
                return await _connection.DeleteAsync(personToDelete);
            }

            return 0;
        }
    }
}
