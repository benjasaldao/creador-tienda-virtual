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
    }
}
