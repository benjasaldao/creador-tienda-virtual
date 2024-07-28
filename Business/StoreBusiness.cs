using Domain;
using System;
using System.Collections.Generic;


namespace Business
{
    public class StoreBusiness
    {
        private DataAccess data;

        public StoreBusiness() {
            data = new DataAccess();
        }

        /// <summary>
        /// Creates a new store register in the database
        /// </summary>
        /// <param name="store"></param>
        /// <param name="user"></param>
        /// <returns>TRUE if it was created sucessfully</returns>
        public bool create(Store store, User user)
        {
            try
            {
                data.setQuery("INSERT INTO Stores (Name, Description, LogoUrl, UserId) VALUES (@Name, @Description, @LogoUrl, @UserId)");
                data.setParam("@Name", store.name);
                data.setParam("@Description", store.description);
                data.setParam("@UserId", user.id);
                data.setParam("@LogoUrl", store.logoUrl);
                data.executeAction();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            } finally
            {
                data.closeConnection();
            }
        }

        /// <summary>
        /// List all the stores asociated to a user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>a list of stores</returns>
        public List<Store> listByUser(int userId)
        {
            try
            {
                List<Store> list = new List<Store>();

                data.setQuery("SELECT Id, Description, Name, UserId, State FROM Stores WHERE UserId = @UserId");
                data.setParam("@UserId", userId);
                data.executeRead();

                while (data.Reader.Read())
                {
                    Store store = new Store();

                    store.id = (int)data.Reader["Id"];
                    if (!(data.Reader["Description"] is DBNull))
                        store.description = (String)data.Reader["Description"];
                    if (!(data.Reader["Name"] is DBNull))
                        store.name = (String)data.Reader["Name"];
                    if (!(data.Reader["LogoUrl"] is DBNull))
                        store.logoUrl = (String)data.Reader["LogoUrl"];
                    store.userId = (int)data.Reader["UserId"];
                    store.state = (bool)data.Reader["State"];

                    list.Add(store);
                }
            
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            } finally { data.closeConnection(); }
        }

        /// <summary>
        /// updates a store register
        /// </summary>
        /// <param name="store"></param>
        /// <returns>TRUE if it was successfully updated</returns>
        public bool update(Store store)
        {
            try
            {
                data.setQuery("UPDATE Stores SET Name = @Name, Description = @Description, LogoUrl = @LogoUrl WHERE Id = @StoreId");
                data.setParam("@Name", store.name);
                data.setParam("@LogoUrl", store.logoUrl);
                data.setParam("@Description", store.description);
                data.setParam("@StoreId", store.id);
              
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
        /// Deletes a given store register in the database
        /// </summary>
        /// <param name="store"></param>
        /// <returns>TRUE if it was deleted successfully</returns>
        public bool delete(Store store)
        {
            try
            {
                data.setQuery("DELETE Stores WHERE Id = @Id");
                data.setParam("@Id", store.id);
                data.executeAction();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { data.closeConnection(); }
        }

    }
}
