using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PokedexC_sharp
{
    class Conexion
    {
        public MySqlConnection conexion;

        public Conexion()
        {
            conexion = new MySqlConnection("Server = 127.0.0.1; Database = listapokemons; Uid = root; Pwd =; Port=3306");
        }

        public DataTable getPokemonPorId(int id)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT * FROM pokemon where id = '" + id + "'", conexion);
                MySqlDataReader resultado = consulta.ExecuteReader();
                DataTable pokemons = new DataTable();
                pokemons.Load(resultado);
                conexion.Close();
                return pokemons;
            }
            catch (MySqlException e)
            {
                throw e;
            }

        }

        public DataTable getTodosPokemons()
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT * FROM pokemon", conexion);
                MySqlDataReader resultado = consulta.ExecuteReader();
                DataTable pokemons = new DataTable();
                pokemons.Load(resultado);
                conexion.Close();
                return pokemons;
            }
            catch (MySqlException e)
            {
                throw e;
            }

        }

        public String actualizaPokemon(String id, String dato)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta = new MySqlCommand("UPDATE pokemon set nombre = '" + dato + "' WHERE  id ='" + id + "'", conexion);
                MySqlDataReader resultado = consulta.ExecuteReader();
                String mensaje;
                if (resultado.RecordsAffected == 1)
                {
                    mensaje = "Actualizado Correctamente";
                }
                else
                {
                    mensaje = "Error al actualizar el nombre del pokemon";
                }
                conexion.Close();
                return mensaje;
            }
            catch (MySqlException e)
            {
                throw e;
            }

        }

    }
}