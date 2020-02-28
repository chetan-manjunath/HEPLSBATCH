using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Travel_schedule
{
    public class contorllerEdit
    {
        SqlConnection sqlConnectionObj;
        SqlCommand sqlCommandObj, selectCommandObj, updateCommandObj;
        SqlDataAdapter sqlDataAdapterObj;
        SqlParameter sqlParameterObj;
        DataSet dataSetObj;
        SqlParameter sqlParameterObj1;
        SqlParameter sqlParameterObj2;
        SqlParameter sqlParameterObj3;
        

        public contorllerEdit()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["TravelScheduleDB"].ConnectionString;
            sqlConnectionObj = new SqlConnection(@connectionString);
        }

        public DataSet combo4(int PlaceId)
        {
            sqlDataAdapterObj = new SqlDataAdapter();
            selectCommandObj = new SqlCommand();
            selectCommandObj.CommandText = "select EmployeeTravelDetails.TravelID,EmployeeTravelDetails.EmployeeID,EmployeeTravelDetails.ArrivalDate,EmployeeTravelDetails.DepartureDate,s.State,p1.Placename as Source,P.PlaceName as Destination from EmployeeTravelDetails, Places P,Places p1, Status s where EmployeeTravelDetails.ToPlaceID = @PlaceId and EmployeeTravelDetails.ToPlaceID = P.PlaceID and EmployeeTravelDetails.FromPlaceID = p1.PlaceID and EmployeeTravelDetails.StatusID = s.StatusID";
            selectCommandObj.Connection = sqlConnectionObj;
            sqlParameterObj = new SqlParameter("@PlaceId",PlaceId );
            selectCommandObj.Parameters.Add(sqlParameterObj);
            sqlDataAdapterObj.SelectCommand = selectCommandObj;
            dataSetObj = new DataSet();
            sqlDataAdapterObj.Fill(dataSetObj);
            return dataSetObj;
        }

        public DataSet GridViewClick(string EmployeeID,string ToPlaceName)
        {
            sqlDataAdapterObj = new SqlDataAdapter();
            selectCommandObj = new SqlCommand();
            sqlParameterObj = new SqlParameter("@employeeID", EmployeeID);
            selectCommandObj.Parameters.Add(sqlParameterObj);
            sqlParameterObj1 = new SqlParameter("@toPlaceName", ToPlaceName);
            selectCommandObj.Parameters.Add(sqlParameterObj1);

            selectCommandObj.CommandText = "select EmployeeTravelDetails.TravelID,EmployeeTravelDetails.EmployeeID,EmployeeTravelDetails.ArrivalDate,EmployeeTravelDetails.DepartureDate,s.State,p1.PlaceName as Source,P.Placename as Destination from EmployeeTravelDetails, Places P,Places p1, Status s where EmployeeTravelDetails.ToPlaceID = P.PlaceID and EmployeeTravelDetails.FromPlaceID = p1.PlaceID and EmployeeTravelDetails.StatusID = s.StatusID and EmployeeTravelDetails.EmployeeID = @employeeID and p.PlaceName = @toPlaceName";
            selectCommandObj.Connection = sqlConnectionObj;


            sqlDataAdapterObj.SelectCommand = selectCommandObj;
            dataSetObj = new DataSet();
            sqlDataAdapterObj.Fill(dataSetObj);

            return dataSetObj;
        }

        public void Update(editmodel Obj)
        {
            sqlDataAdapterObj = new SqlDataAdapter();
            updateCommandObj = new SqlCommand();
            updateCommandObj.CommandText = "update EmployeeTravelDetails set ArrivalDate=@arrivalDate,DepartureDate=@depatureDate where TravelID=@TravelID";
            updateCommandObj.Connection = sqlConnectionObj;
            sqlParameterObj2 = new SqlParameter("@arrivalDate", Convert.ToDateTime(Obj.arrivalDate));
            sqlParameterObj3 = new SqlParameter("@depatureDate", Convert.ToDateTime(Obj.depatureDate));
            sqlParameterObj = new SqlParameter("@TravelID", Obj.TravelID);
            updateCommandObj.Parameters.Add(sqlParameterObj2);
            updateCommandObj.Parameters.Add(sqlParameterObj3);
            updateCommandObj.Parameters.Add(sqlParameterObj);

            sqlDataAdapterObj.SelectCommand = selectCommandObj;

            sqlConnectionObj.Open();
            updateCommandObj.ExecuteNonQuery();
            sqlConnectionObj.Close();
        }

        public DataSet Loadplace()
        {
            sqlDataAdapterObj = new SqlDataAdapter();
            selectCommandObj = new SqlCommand();
            selectCommandObj.CommandText = "select * from Places";
            selectCommandObj.Connection = sqlConnectionObj;
            sqlDataAdapterObj.SelectCommand = selectCommandObj;
            dataSetObj = new DataSet();
            sqlDataAdapterObj.Fill(dataSetObj);
            return dataSetObj;
        }
        
    }
}
