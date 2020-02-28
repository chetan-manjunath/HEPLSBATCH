using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace Travel_schedule
{
    class controllerlogin
    {
        SqlConnection connectionObj;
        SqlDataAdapter dataAdapterObj, adapterObj1;
        SqlCommand selectCommand;
        SqlParameter parameterObj, parameterObj1;
        DataSet dataSetObj;

        public controllerlogin()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["TravelScheduleDB"].ConnectionString;
            connectionObj = new SqlConnection(@connectionString);
        }
        public void validateLogin(loginModel Obj)
        {
            try
            {
                dataAdapterObj = new SqlDataAdapter();
                selectCommand = new SqlCommand();
                parameterObj = new SqlParameter("@Password", Obj.Password);
                selectCommand.Parameters.Add(parameterObj);

                parameterObj1 = new SqlParameter("@Username", Obj.UserName);
                selectCommand.Parameters.Add(parameterObj1);
                selectCommand.CommandText = "select count(UserName) from LoginCredentials where UserName=@Username and Password=@Password";
                selectCommand.Connection = connectionObj;
                dataAdapterObj.SelectCommand = selectCommand;
                dataSetObj = new DataSet();
                dataAdapterObj.Fill(dataSetObj);


                var LoginStatus = (int)dataSetObj.Tables[0].Rows[0][0];
                if (LoginStatus <= 0)
                {
                    throw new LoginFailureException("Incorrect Password... Please try again");
                }
            }
            catch (LoginFailureException e)
            {

                throw new LoginFailureException(e.Message);
            }

            catch (Exception e)
            {

                throw new LoginFailureException("Select  a valid user name please dont enter");
            }

        }
        public DataSet LoadUsernames()
        {

            adapterObj1 = new SqlDataAdapter("select UserName from LoginCredentials", connectionObj);
            dataSetObj = new DataSet();
            adapterObj1.Fill(dataSetObj);

            return dataSetObj;

        }

    }
}

