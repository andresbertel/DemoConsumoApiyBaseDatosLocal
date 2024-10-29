using BaseLocalesG2.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLocalesG2.Data
{
    public class PersonaDataBase
    {
        private readonly SQLiteAsyncConnection database;

        public PersonaDataBase(string ruta)
        {
            database = new SQLiteAsyncConnection(ruta);
            database.CreateTableAsync<Persona>().Wait();
        }

        public async Task<List<Persona>> GetPersonas()
        {
            return await database.Table<Persona>().ToListAsync();
        }

        public async Task<Persona> GetOnePersonas(int id)
        {
            return await database.Table<Persona>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> DeletePersona(Persona persona)
        {
            return await database.DeleteAsync(persona);
        }

        public async Task<int> GuardarPersona(Persona persona)
        {
            return await database.InsertAsync(persona);
        }

        public async Task<int> ActualizarPersona(Persona persona)
        {
            return await database.UpdateAsync(persona);
        }

    }
}
