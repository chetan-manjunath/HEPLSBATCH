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
    
    class ViewController
    {
        SqlConnection sqlConnectionobj;
        SqlCommand selectCommandObj;
        SqlDataAdapter sqlDataAdapterObj, sqlDataAdapterObj1;
        DataSet dataSetObj;
        SqlParameter sqlParameterObj1;
        
        public ViewController()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["TravelScheduleDB"].ConnectionString;
            sqlConnectionobj = new SqlConnection(@connectionString);
        }
        public DataSet LoadStatusIntoDropDown()
        {
            sqlDataAdapterObj = new SqlDataAdapter("select state,StatusID from Status ", sqlConnectionobj);
            dataSetObj = new DataSet();
            sqlDataAdapterObj.Fill(dataSetObj);
            return dataSetObj;
        }
        public DataSet LoadTimePeriodIntoDropDown()
        {
            sqlDataAdapterObj = new SqlDataAdapter("select distinct VisitDuration from Period ", sqlConnectionobj);
            dataSetObj = new DataSet();
            sqlDataAdapterObj.Fill(dataSetObj);
            return dataSetObj;
        }
        public  DataSet LoadPlaceIntoDropDown()
        {
            sqlDataAdapterObj = new SqlDataAdapter("select  PlaceName,PlaceID from Places ", sqlConnectionobj);
            dataSetObj = new DataSet();
            sqlDataAdapterObj.Fill(dataSetObj);
            return dataSetObj;
        }
        public DataSet ViewEmployeeTravelDetails()
        {
            sqlDataAdapterObj1 = new SqlDataAdapter();
            sqlDataAdapterObj1.SelectCommand = new SqlCommand();
            sqlDataAdapterObj1.SelectCommand.CommandText = "select TravelID,EmployeeID,ArrivalDate,DepartureDate,StatusID,FromPlaceID,ToPlaceID from EmployeeTravelDetails";

            sqlDataAdapterObj1.SelectCommand.Connection = sqlConnectionobj;

            dataSetObj = new DataSet();
            sqlDataAdapterObj1.Fill(dataSetObj);
            
            return dataSetObj;
        }
        public DataSet travelEmployee(PlacesModel obj)
        {
            sqlDataAdapterObj = new SqlDataAdapter();
            selectCommandObj = new SqlCommand();
            selectCommandObj.CommandText = "select EmployeeTravelDetails.TravelID,EmployeeTravelDetails.EmployeeID,EmployeeTravelDetails.ArrivalDate,EmployeeTravelDetails.DepartureDate,s.State,p1.Placename as Source,P.PlaceName as Destination from EmployeeTravelDetails, Places P,Places p1, Status s where EmployeeTravelDetails.ToPlaceID = @placename and EmployeeTravelDetails.ToPlaceID = P.PlaceID and EmployeeTravelDetails.FromPlaceID = p1.PlaceID and EmployeeTravelDetails.StatusID = s.StatusID";

            selectCommandObj.Connection = sqlConnectionobj;

            sqlParameterObj1 = new SqlParameter("@placename", obj.PlaceName);
            selectCommandObj.Parameters.Add(sqlParameterObj1);
            sqlDataAdapterObj.SelectCommand = selectCommandObj;
            dataSetObj = new DataSet();
            sqlDataAdapterObj.Fill(dataSetObj);
            return dataSetObj;
        }
        public DataSet localTravel(string value)
        {
            sqlDataAdapterObj = new SqlDataAdapter();
            selectCommandObj = new SqlCommand();
            selectCommandObj.CommandText = "select LocalSchedule.SerialNumber,LocalSchedule.Date,Status.State as Travel_state,l1.Place source,l2.Place destination,DriverDetails.DriverName from LocalSchedule,DriverDetails,LocalTravelOptions l1,LocalTravelOptions l2,Status where TravelID=@employeeid and DriverDetails.DriverID=LocalSchedule.DriverID and l1.LocationID=LocalSchedule.FromLocalLocationID and l2.LocationID=LocalSchedule.ToLocalLocationID and Status.StatusID=LocalSchedule.StatusID and LocalSchedule.DriverID=DriverDetails.DriverID";
            selectCommandObj.Connection = sqlConnectionobj;
            sqlParameterObj1 = new SqlParameter("@employeeid", value);
            selectCommandObj.Parameters.Add(sqlParameterObj1);
            sqlDataAdapterObj.SelectCommand = selectCommandObj;

            dataSetObj = new DataSet();
            sqlDataAdapterObj.Fill(dataSetObj);
            return dataSetObj;
        }
        public DataSet employeestate(string value)
        {
            sqlDataAdapterObj = new SqlDataAdapter();
            selectCommandObj = new SqlCommand();
            selectCommandObj.CommandText = "select EmployeeTravelDetails.TravelID,EmployeeTravelDetails.EmployeeID,EmployeeTravelDetails.ArrivalDate,EmployeeTravelDetails.DepartureDate,s.State,p1.Placename as Source,P.PlaceName as Destination from EmployeeTravelDetails, Places P,Places p1, Status s where EmployeeTravelDetails. StatusID=@state and EmployeeTravelDetails.ToPlaceID = P.PlaceID and EmployeeTravelDetails.FromPlaceID = p1.PlaceID and EmployeeTravelDetails.StatusID = s.StatusID";
            selectCommandObj.Connection = sqlConnectionobj;

            sqlParameterObj1 = new SqlParameter("@state", value);
            selectCommandObj.Parameters.Add(sqlParameterObj1);
            sqlDataAdapterObj.SelectCommand = selectCommandObj;
            dataSetObj = new DataSet();
            sqlDataAdapterObj.Fill(dataSetObj);
            return dataSetObj;
        }
        public DataSet FilterPeriod(string selectedPeriod)
        {
            sqlDataAdapterObj = new SqlDataAdapter();
            selectCommandObj = new SqlCommand();
            


            if (selectedPeriod == "Week")
            {

                selectCommandObj.CommandText = "select  EmployeeTravelDetails.TravelID, EmployeeDetails.EmployeeID,EmployeeDetails.EmployeeName,EmployeeTravelDetails.ArrivalDate,EmployeeTravelDetails.DepartureDate from EmployeeDetails,EmployeeTravelDetails where EmployeeDetails.EmployeeID=EmployeeTravelDetails.EmployeeID and EmployeeTravelDetails.ArrivalDate-GETDATE() between 0 and 7 and EmployeeTravelDetails.DepartureDate-GETDATE() between 0 and 7";
            }
            else
            {

                selectCommandObj.CommandText = "select  EmployeeTravelDetails.TravelID, EmployeeDetails.EmployeeID,EmployeeDetails.EmployeeName,EmployeeTravelDetails.ArrivalDate,EmployeeTravelDetails.DepartureDate from EmployeeDetails,EmployeeTravelDetails where EmployeeDetails.EmployeeID=EmployeeTravelDetails.EmployeeID and EmployeeTravelDetails.ArrivalDate-GETDATE() between 0 and 30 or EmployeeTravelDetails.DepartureDate-GETDATE() between 0 and 30";
            }

            selectCommandObj.Connection = sqlConnectionobj;
            sqlDataAdapterObj.SelectCommand = selectCommandObj;
            dataSetObj = new DataSet();
            sqlDataAdapterObj.Fill(dataSetObj);
            return dataSetObj;
        }
    }
}
