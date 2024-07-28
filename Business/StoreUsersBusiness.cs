using Domain;
using System;

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
                data.setQuery("INSERT INTO StoreUsers (Email, Pass, Name, Surname, StoreId) VALUES (@StoreUser, @Pass, @Name, @Surname, @StoreId)");
                data.setParam("@Email", user.email);
                data.setParam("@Pass", user.password);
                data.setParam("@Name", user.name);
                data.setParam("@Surname", user.surname);
                data.setParam("@Adress", user.adress);
                data.setParam("@City", user.city);
                data.setParam("@StoreId", user.storeId);

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
                data.setQuery("UPDATE StoreUsers SET Email = @Email, Name = @Name, Surname = @Surname, Adress = @Adress, City =  @City WHERE Id = @Id");
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
                data.setQuery("DELETE StoreUsers WHERE Id = @Id");
                data.setParam("@Id", user.id);
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
                data.setQuery("SELECT Id, Email, User FROM StoreUsers WHERE Email = @Email AND Pass = @Pass");
                data.setParam("@Email", user.email);
                data.setParam("@Pass", user.password);
                data.executeAction();

                if (data.Reader.Read())
                {
                    user.id = (int)data.Reader["Id"];
                    if (!(data.Reader["Name"] is DBNull))
                        user.name = (string)data.Reader["Name"];
                    if (!(data.Reader["Surname"] is DBNull))
                        user.surname = (string)data.Reader["Surname"];

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
