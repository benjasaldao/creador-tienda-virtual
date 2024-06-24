using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class StoreUsersBusiness
    {
        DataAccess data;

        public StoreUsersBusiness() {
            data = new DataAccess();
        }

        /// <summary>
        /// Creates a new storeUser in the database
        /// </summary>
        /// <param name="user"></param>
        /// <returns>TRUE if it was created successfully</returns>
        public bool register(StoreUser user)
        {
            try
            {
                data.setProcedure("spCreateStoreUser");
                data.setParam("@email", user.email);
                data.setParam("@pass", user.password);
                data.setParam("@name", user.name);
                data.setParam("@surname", user.surname);
                data.setParam("@adress", user.adress);
                data.setParam("@city", user.city);
                data.setParam("@storeId", user.storeId);

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
        public bool update(StoreUser user)
        {
            try
            {
                data.setProcedure("spUpdateStoreUser");
                data.setParam("@email", user.email);
                data.setParam("@name", user.name);
                data.setParam("@surname", user.surname);
                data.setParam("@id", user.id);
                data.setParam("@adress", user.adress);
                data.setParam("@city", user.city);

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
        public bool delete(StoreUser user)
        {
            try
            {
                data.setProcedure("spDeleteStoreUser");
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
        public bool login(StoreUser user)
        {
            try
            {
                data.setProcedure("spStoreUserLogin");
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
            }
            finally
            {
                data.closeConnection();
            }

        }
    }
}
