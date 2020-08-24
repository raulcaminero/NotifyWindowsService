using NotifyAuthenticationHandler.Contracts;
using NotifyAuthenticationHandler.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace NotifyAuthenticationHandler.Helpers
{
    /// <summary>
    /// Represents the interaction between OnBase and AdmBalanceo's app.
    /// </summary>
    public sealed class OnBaseInteractionHandler
    {
        private readonly SqlConnection _sqlConnection;
        SqlDataAdapter adapter;
        private DataTable dataTable = new DataTable();
        private const string SpcExecCommand = "EXEC [AdmBalanceo_OB_ILP].[dbo].[GetLoggedUsers]";
        private HashSet<OnBaseUserBasicInformation> _usersWithAssignation = new HashSet<OnBaseUserBasicInformation>();

        /// <summary>
        /// Initializes a new instance of the <see cref="T:NotifyAuthenticationHandler.Helpers.OnBaseInteractionHandler"></see> class with the given connection string.
        /// </summary>
        /// <param name="connectionString">Represents the connection string used for this interaction.</param>
        public OnBaseInteractionHandler(string connectionString)
            => _sqlConnection = new SqlConnection(connectionString);

        /// <summary>
        /// Represents an implementation of <see cref="ILogger"/>.
        /// </summary>
        public ILogger LoggerAdapter { get; set; }

        /// <summary>
        /// Assigns a solicitude to an user when this one log into OnBase for the first time in a day.
        /// </summary>
        /// <param name="queue">Represents a work queue.</param>
        /// <param name="workingStoredProcedure">Represents the stored procedure used for getting the need information for a assignation.</param>
        public void AssignSolicitudeToAnUser(string queue, string workingStoredProcedure)
        {
            var expirationDate = DateTime.Now.Date.AddDays(1);
            try
            {
                _sqlConnection.Open();
                var sqlCommand = new SqlCommand(SpcExecCommand, _sqlConnection);

                // create data adapter
                adapter = new SqlDataAdapter(sqlCommand);
                // this will query your database and return the result to your datatable
                adapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    var user = new OnBaseUserBasicInformation
                    {
                        LastLogOn = DateTime.Parse(row["lastlogon"].ToString().Trim()),
                        UserGroupName = row["usergroupname"].ToString().Trim(),
                        Username = row["username"].ToString().Trim(),
                        Usernum = row["userid"].ToString()
                    };

                    if (user.Username != null)
                    {
                        var client = new AdmBalanceoILP.OBILPClient();
                        string requestNumber = client.AsignarSolicitud(usuario: user.Username, etapa: user.UserGroupName, cola: queue);

                        LoggerAdapter.LogEvent($"Success assignation for: {requestNumber}, for user {user.Username}");

                        var sqlCommand2 = new SqlCommand($"EXEC [AdmBalanceo_OB_ILP].[dbo].[DeleteLoggedUsers] {Int32.Parse(user.Usernum)}", _sqlConnection);
                        int rowsDeleted = sqlCommand2.ExecuteNonQuery();

                        LoggerAdapter.LogEvent($"Row deleted: {rowsDeleted}");
                    }
                }

                _sqlConnection.Close();
                adapter.Dispose();

            }
            catch (Exception e)
            {
                _sqlConnection.Close();
                adapter.Dispose();

                LoggerAdapter.LogError($"There was an error trying to assign a \"Solicitud\" to an user.\n Error message: {e.Message}\n StackTrace: {e.StackTrace}");
            }
            finally
            {
                _sqlConnection.Close();
                adapter.Dispose();

            }
        }
    }
}
