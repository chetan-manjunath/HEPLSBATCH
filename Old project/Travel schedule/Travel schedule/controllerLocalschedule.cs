using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Travel_schedule
{
    public class controllerLocalschedule
    {
        SqlConnection sqlConnectionObj;
        SqlCommand sqlCommandObj, selectCommandObj, updateCommandObj;
        SqlDataAdapter sqlDataAdapterObj;
        SqlParameter sqlParameterObj, sqlParameterObj1;
        DataSet dataSetObj;
        public controllerLocalschedule()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["TravelScheduleDB"].ConnectionString;
            sqlConnectionObj = new SqlConnection(@connectionString);
        }
        public void DateTimeClick(int SerialNumber, DateTime time)
        {
            sqlDataAdapterObj = new SqlDataAdapter();
            updateCommandObj = new SqlCommand();
            updateCommandObj.CommandText = "update LocalSchedule set Date=@depatureDate where SerialNumber=@TravelID";
            updateCommandObj.Connection = sqlConnectionObj;
            sqlParameterObj1 = new SqlParameter("@depatureDate", Convert.ToDateTime(time));
            sqlParameterObj = new SqlParameter("@TravelID", SerialNumber);
            updateCommandObj.Parameters.Add(sqlParameterObj);
            updateCommandObj.Parameters.Add(sqlParameterObj1);
            sqlDataAdapterObj.SelectCommand = updateCommandObj;
            sqlConnectionObj.Open();
            updateCommandObj.ExecuteNonQuery();
            sqlConnectionObj.Close();
        }
        public void Button5Click(int DriverID, int SerialNumber)
        {
            sqlDataAdapterObj = new SqlDataAdapter();
            updateCommandObj = new SqlCommand();
            sqlParameterObj = new SqlParameter("@Id", DriverID);
            sqlParameterObj1 = new SqlParameter("@slno", SerialNumber);
            updateCommandObj.Parameters.Add(sqlParameterObj);
            updateCommandObj.Parameters.Add(sqlParameterObj1);
            updateCommandObj.CommandText = "update LocalSchedule set DriverID = @Id where SerialNumber=@slno";
            updateCommandObj.Connection = sqlConnectionObj;
            sqlConnectionObj.Open();
            updateCommandObj.ExecuteNonQuery();
            sqlConnectionObj.Close();
        }
        public void Button4Click(int toLocation, int SerialNumber)
        {
            sqlDataAdapterObj = new SqlDataAdapter();
            updateCommandObj = new SqlCommand();
            sqlParameterObj = new SqlParameter("@Id", toLocation);
            sqlParameterObj1 = new SqlParameter("@slno", SerialNumber);
            updateCommandObj.Parameters.Add(sqlParameterObj);
            updateCommandObj.Parameters.Add(sqlParameterObj1);
            updateCommandObj.CommandText = "update LocalSchedule set ToLocalLocationID = @Id where SerialNumber=@slno";
            updateCommandObj.Connection = sqlConnectionObj;
            sqlConnectionObj.Open();
            updateCommandObj.ExecuteNonQuery();
            sqlConnectionObj.Close();
        }
        public void Button1Click(int fromLocation, int SerialNumber)
        {
            sqlDataAdapterObj = new SqlDataAdapter();
            updateCommandObj = new SqlCommand();
            sqlParameterObj = new SqlParameter("@Id", fromLocation);
            sqlParameterObj1 = new SqlParameter("@slno", SerialNumber);
            updateCommandObj.Parameters.Add(sqlParameterObj);
            updateCommandObj.Parameters.Add(sqlParameterObj1);
            updateCommandObj.CommandText = "update LocalSchedule set FromLocalLocationID = @Id where SerialNumber=@slno";
            updateCommandObj.Connection = sqlConnectionObj;
            sqlConnectionObj.Open();
            updateCommandObj.ExecuteNonQuery();
            sqlConnectionObj.Close();
        }
        public void Button2Click(int StatusID, int SerialNumber)
        {
            
            sqlDataAdapterObj = new SqlDataAdapter();
            updateCommandObj = new SqlCommand();
            sqlParameterObj = new SqlParameter("@Id", StatusID);
            sqlParameterObj1 = new SqlParameter("@slno", SerialNumber);
            updateCommandObj.Parameters.Add(sqlParameterObj);
            updateCommandObj.Parameters.Add(sqlParameterObj1);
            updateCommandObj.CommandText = "update LocalSchedule set StatusID = @Id where SerialNumber=@slno";
            updateCommandObj.Connection = sqlConnectionObj;
            sqlConnectionObj.Open();
            updateCommandObj.ExecuteNonQuery();
            sqlConnectionObj.Close();
        }
        public DataSet Scheduledetails(int id)
        {
            sqlDataAdapterObj = new SqlDataAdapter();
            selectCommandObj = new SqlCommand();
            selectCommandObj.CommandText = "SELECT LocalSchedule.SerialNumber,LocalSchedule.TravelID,LocalSchedule.Date,Status.State as Travel_State,l.Place as source ,l1.Place as  destination,LocalSchedule.DriverID from LocalSchedule,LocalTravelOptions l, LocalTravelOptions l1 ,Status where l.LocationID = LocalSchedule.FromLocalLocationID and l1.LocationID = LocalSchedule.ToLocalLocationID and LocalSchedule.TravelID = @Id and LocalSchedule.StatusID = Status.StatusID";
            selectCommandObj.Connection = sqlConnectionObj;
            sqlParameterObj = new SqlParameter("@Id", id);
            selectCommandObj.Parameters.Add(sqlParameterObj);
            sqlDataAdapterObj.SelectCommand = selectCommandObj;
            dataSetObj = new DataSet();
            sqlDataAdapterObj.Fill(dataSetObj);
            return dataSetObj;
        }
        public DataSet loadFromLocation()
        {
            sqlDataAdapterObj = new SqlDataAdapter();
            selectCommandObj = new SqlCommand();
            selectCommandObj.CommandText = "select LocationID,Place from LocalTravelOptions";
            selectCommandObj.Connection = sqlConnectionObj;
            sqlDataAdapterObj.SelectCommand = selectCommandObj;
            dataSetObj = new DataSet();
            sqlDataAdapterObj.Fill(dataSetObj);
            return dataSetObj;
        }
        public DataSet loadToLocation()
        {
            sqlDataAdapterObj = new SqlDataAdapter();
            selectCommandObj = new SqlCommand();
            selectCommandObj.CommandText = "select LocationID,Place from LocalTravelOptions";
            selectCommandObj.Connection = sqlConnectionObj;
            sqlDataAdapterObj.SelectCommand = selectCommandObj;
            dataSetObj = new DataSet();
            sqlDataAdapterObj.Fill(dataSetObj);
            return dataSetObj;
        }
        public DataSet loadStatus()
        {
            sqlDataAdapterObj = new SqlDataAdapter();
            selectCommandObj = new SqlCommand();
            selectCommandObj.CommandText = "select StatusID,State from Status ";
            selectCommandObj.Connection = sqlConnectionObj;
            sqlDataAdapterObj.SelectCommand = selectCommandObj;
            dataSetObj = new DataSet();
            sqlDataAdapterObj.Fill(dataSetObj);
            return dataSetObj;
        }
        public DataSet loadDriver()
        {
            sqlDataAdapterObj = new SqlDataAdapter();
            selectCommandObj = new SqlCommand();
            selectCommandObj.CommandText = "select DriverID,DriverName from DriverDetails ";
            selectCommandObj.Connection = sqlConnectionObj;
            sqlDataAdapterObj.SelectCommand = selectCommandObj;
            dataSetObj = new DataSet();
            sqlDataAdapterObj.Fill(dataSetObj);
            return dataSetObj;
        }
        public DataSet placeFromValidation(int Id)
        {
            sqlDataAdapterObj = new SqlDataAdapter();
            selectCommandObj = new SqlCommand();
            selectCommandObj.CommandText = "select LocationID,Place from LocalTravelOptions where @Id != LocationID ";
            sqlParameterObj = new SqlParameter("@Id", Id);
            selectCommandObj.Parameters.Add(sqlParameterObj);
            selectCommandObj.Connection = sqlConnectionObj;
            sqlDataAdapterObj.SelectCommand = selectCommandObj;
            dataSetObj = new DataSet();
            sqlDataAdapterObj.Fill(dataSetObj);
            return dataSetObj;
        }
        public DataSet placeToValidation(int ID)
        {
            sqlDataAdapterObj = new SqlDataAdapter();
            selectCommandObj = new SqlCommand();
            selectCommandObj.CommandText = "select LocationID,Place from LocalTravelOptions where @Id != LocationID ";
            sqlParameterObj = new SqlParameter("@Id",ID);
            selectCommandObj.Parameters.Add(sqlParameterObj);
            selectCommandObj.Connection = sqlConnectionObj;
            sqlDataAdapterObj.SelectCommand = selectCommandObj;
            dataSetObj = new DataSet();
            sqlDataAdapterObj.Fill(dataSetObj);
            return dataSetObj;
        }
    }
}

