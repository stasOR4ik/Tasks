using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MusicSite
{
    public class StorageProcedure
    {
        private SqlConnection connection;
        private SqlCommand command;

        public StorageProcedure()
        {
            connection = new SqlConnection("Server =.\\SQLEXPRESS;Database=MusicDB;Trusted_Connection=True");
            connection.Open();
            command = new SqlCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = connection;
        }

        public SqlDataReader TableAlbumsTakingBySingerId(int singerId)
        {
            SqlDataReader reader;
            command.CommandText = "AlbumsListBySingerId";
            SqlParameter parameterSingerId = new SqlParameter("@singerId", singerId);
            command.Parameters.Add(parameterSingerId);
            reader = command.ExecuteReader();
            //if (reader.HasRows)
            //{
            //    Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));

            //    while (reader.Read())
            //    {
            //        int id = reader.GetInt32(0);
            //        string name = reader.GetString(1);
            //        int singerid = reader.GetInt32(2);
            //    }
            //}
            return reader;
        }

        public SqlDataReader TableSongsTakingBySingerId(int singerId)
        {
            SqlDataReader reader;
            command.CommandText = "SongsListBySingerId";
            SqlParameter parameterSingerId = new SqlParameter("@singerId", singerId);
            command.Parameters.Add(parameterSingerId);
            reader = command.ExecuteReader();
            return reader;
        }

        public SqlDataReader TableSongsTakingByAlbumId(int albumId)
        {
            SqlDataReader reader;
            command.CommandText = "SongsListByAlbumId";
            SqlParameter parameterSingerId = new SqlParameter("@albumId", albumId);
            command.Parameters.Add(parameterSingerId);
            reader = command.ExecuteReader();
            return reader;
        }
    }
}
