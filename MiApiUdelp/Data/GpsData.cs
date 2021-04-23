using MiApiUdelp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MiApiUdelp.Data
{
    public class GpsData
    {
        public static int gpsDataAdd(EntityGpsData values)
        {
            int answer;
            SqlParameter[] parameters = new SqlParameter[4];
            parameters[0] = new SqlParameter("@androidId", values.androidId);
            parameters[1] = new SqlParameter("@latitude", values.latitude);
            parameters[2] = new SqlParameter("@longitude", values.longitude);
            parameters[3] = new SqlParameter("@battery", values.battery);

            ParametersDataBaseHelper dataBaseHelperValues = new ParametersDataBaseHelper()
            {
                storedProcedureName = "GPS_DATA_A",
                parameters = parameters
            };

            answer = DataBaseHelper.executeQueryInt(dataBaseHelperValues);

            return answer;
        }

        public static int gpsDataDelete(EntityGpsData values)
        {
            int answer;
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@id", values.id);

            ParametersDataBaseHelper dataBaseHelperValues = new ParametersDataBaseHelper()
            {
                storedProcedureName = "GPS_DATA_D",
                parameters = parameters
            };

            answer = DataBaseHelper.executeQueryInt(dataBaseHelperValues);

            return answer;
        }

        public static int gpsDataUpdate(EntityGpsData values)
        {
            int answer;
            SqlParameter[] parameters = new SqlParameter[5];

            parameters[0] = new SqlParameter("@id", values.id);
            parameters[1] = new SqlParameter("@androidId", values.androidId);
            parameters[2] = new SqlParameter("@latitude", values.latitude);
            parameters[3] = new SqlParameter("@longitude", values.longitude);
            parameters[4] = new SqlParameter("@battery", values.battery);

            ParametersDataBaseHelper dataBaseHelperValues = new ParametersDataBaseHelper()
            {
                storedProcedureName = "GPS_DATA_U",
                parameters = parameters
            };

            answer = DataBaseHelper.executeQueryInt(dataBaseHelperValues);

            return answer;

        }

        public static DataSet gpsDataGetOne(EntityGpsData values)
        {
            DataSet answer = null;
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@id", values.id);

            ParametersDataBaseHelper dataBaseHelperValues = new ParametersDataBaseHelper()
            {
                storedProcedureName = "GPS_DATA_GO",
                parameters = parameters
            };

            answer = DataBaseHelper.executeQueryDatasSet(dataBaseHelperValues);

            return answer;
        }

        public static DataSet gpsDataGetAll()
        {
            DataSet answer = null;
            SqlParameter[] parameters = new SqlParameter[0];

            ParametersDataBaseHelper dataBaseHelperValues = new ParametersDataBaseHelper()
            {
                storedProcedureName = "GPS_DATA_GA",
                parameters = parameters
            };

            answer = DataBaseHelper.executeQueryDatasSet(dataBaseHelperValues);

            return answer;
        }

    }
}