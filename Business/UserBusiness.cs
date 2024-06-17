using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Business
{
    public class UserBusiness
    {
        private DataAccess data;

        public UserBusiness()
        {
            data = new DataAccess();
        }

        /// <summary>
        /// Creates a new user in the database
        /// </summary>
        /// <param name="user"></param>
        /// <returns>TRUE if it was created successfully</returns>
        public bool register(User user)
        {
            try
            {
                data.setProcedure("spCreateUser");
                data.setParam("@email", user.email);
                data.setParam("@pass", user.password);
                data.setParam("@name", user.name);
                data.setParam("@surname", user.surname);

                data.executeAction();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                data.closeConnection();
            }
        }


        /// <summary>
        /// Updates email, name and surname of the given user
        /// </summary>
        /// <param name="user"></param>
        /// <returns>
        /// TRUE if it was successfully updated,
        /// thows an exception if not            
        /// </returns>
        public bool update(User user)
        {
            try
            {
                data.setProcedure("spUpdateUser");
                data.setParam("@email", user.email);
                data.setParam("@name", user.name);
                data.setParam("@surname", user.surname);
                data.setParam("@id", user.id);

                data.executeAction();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { data.closeConnection(); }
        }

        /// <summary>
        /// Deletes an user from the database
        /// </summary>
        /// <param name="user"></param>
        /// <returns>TRUE if correctly deleted,
        /// throws an exception if not
        /// </returns>
        public bool delete(User user)
        {
            try
            {
                data.setProcedure("spDeleteUser");
                data.setParam("@id", user.id);
                data.executeAction();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                data.closeConnection();
            }
        }

        /// <summary>
        /// Log in an user with his email and password 
        /// </summary>
        /// <param name="user"></param>
        /// <returns>TRUE if password and email are correct</returns>
        public bool login(User user)
        {
            try
            {
                data.setProcedure("spUserLogin");
                data.setParam("@email", user.email);
                data.setParam("@password", user.password);
                data.executeAction();

                if (data.Reader.Read())
                {
                    user.id = (int)data.Reader["id"];
                    if (!(data.Reader["name"] is DBNull))
                        user.name = (string)data.Reader["name"];
                    if (!(data.Reader["surname"] is DBNull))
                        user.surname = (string)data.Reader["surname"];

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            } finally { 
                data.closeConnection(); 
            }

        }
    }
}
