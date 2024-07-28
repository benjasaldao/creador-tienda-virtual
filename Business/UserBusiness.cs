using System;
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
                data.setQuery("INSERT INTO Users (Email, Pass, Name, Surname) VALUES (@Email, @Pass, @Name, @Surname)");
                data.setParam("@Email", user.email);
                data.setParam("@Pass", user.password);
                data.setParam("@Name", user.name);
                data.setParam("@Surname", user.surname);

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
                data.setQuery("UPDATE Users SET Email = @Email, Name = @Name, Surname = @Surname WHERE Id = @Id");
                data.setParam("@Email", user.email);
                data.setParam("@Name", user.name);
                data.setParam("@Surname", user.surname);
                data.setParam("@Id", user.id);

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
                data.setQuery("DELETE Users WHERE Id = @Id");
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
        public bool login(User user)
        {
            try
            {
                data.setQuery("SELECT Email, Password FROM Users WHERE Email = @Email AND Password = @Password");
                data.setParam("@Email", user.email);
                data.setParam("@Password", user.password);
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
            } finally { 
                data.closeConnection(); 
            }

        }
    }
}
