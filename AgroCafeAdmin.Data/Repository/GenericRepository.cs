using AgroCafeAdmin.Core.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection;
using System.Xml.Linq;

namespace AgroCafeAdmin.Data.Repository
{

    public abstract class GenericRepository
    {
        protected readonly DbContext _context;

        protected GenericRepository(DbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Ejecuta un SP y devuelve una lista de objetos mapeados automáticamente.
        /// </summary>
        protected virtual async Task<SpResult<List<T>>> ExecuteListAsync<T>(string storedProcedure, Dictionary<string, object> parameters = null) where T : class, new()
        {
            var result = new SpResult<List<T>> { Data = new List<T>() };

            try
            {
                // Usamos la conexión gestionada por EF Core
                var connection = _context.Database.GetDbConnection() as SqlConnection;
                if (connection.State != ConnectionState.Open) await connection.OpenAsync();

                using (var command = new SqlCommand(storedProcedure, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 180;

                    // Parámetros de entrada
                    AddParameters(command, parameters);

                    // Parámetros de salida estándar
                    var outputError = new SqlParameter("@oError", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    var outputMensaje = new SqlParameter("@oMensaje", SqlDbType.VarChar, 500) { Direction = ParameterDirection.Output };
                    command.Parameters.Add(outputError);
                    command.Parameters.Add(outputMensaje);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            result.Data.Add(MapReaderToEntity<T>(reader));
                        }
                    }

                    // Procesar errores del SP
                    ProcessOutputParameters(outputError, outputMensaje, result);
                }
            }
            catch (Exception ex)
            {
                HandleException(result, ex);
            }

            return result;
        }

        /// <summary>
        /// Ejecuta un SP y devuelve un solo objeto.
        /// </summary>
        protected virtual async Task<SpResult<T>> ExecuteSingleAsync<T>(string storedProcedure, Dictionary<string, object> parameters = null) where T : class, new()
        {
            var result = new SpResult<T>();
            var listResult = await ExecuteListAsync<T>(storedProcedure, parameters);

            result.Success = listResult.Success;
            result.Mensaje = listResult.Mensaje;
            result.Error = listResult.Error;
            result.Data = listResult.Data.FirstOrDefault();

            return result;
        }

        // --- MÉTODOS PRIVADOS DE APOYO ---

        private void AddParameters(SqlCommand command, Dictionary<string, object> parameters)
        {
            if (parameters == null) return;
            foreach (var param in parameters)
            {
                var value = param.Value;
                var sqlParam = new SqlParameter(param.Key, value ?? DBNull.Value);

                // Soporte automático para XML
                if (value is XDocument || (value is string s && s.StartsWith("<")))
                {
                    sqlParam.SqlDbType = SqlDbType.Xml;
                }

                command.Parameters.Add(sqlParam);
            }
        }

        private void ProcessOutputParameters<T>(SqlParameter errorParam, SqlParameter mensajeParam, SpResult<T> result)
        {
            int errorCode = (errorParam.Value != DBNull.Value) ? Convert.ToInt32(errorParam.Value) : 0;
            string mensaje = (mensajeParam.Value != DBNull.Value) ? mensajeParam.Value.ToString() : "OK";

            result.Success = errorCode == 0;
            result.Error = errorCode;
            result.Mensaje = mensaje.Replace("SQLERROR:", "");
        }

        private void HandleException<T>(SpResult<T> result, Exception ex)
        {
            result.Success = false;
            result.Error = -1;
            result.Mensaje = $"Error en repositorio: {ex.Message}";
        }

        private T MapReaderToEntity<T>(SqlDataReader reader) where T : class, new()
        {
            var entity = new T();
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            for (int i = 0; i < reader.FieldCount; i++)
            {
                var property = properties.FirstOrDefault(p => p.Name.Equals(reader.GetName(i), StringComparison.OrdinalIgnoreCase));
                if (property != null && !reader.IsDBNull(i))
                {
                    property.SetValue(entity, Convert.ChangeType(reader.GetValue(i), property.PropertyType));
                }
            }
            return entity;
        }
    }
}
