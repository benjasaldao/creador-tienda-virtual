using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                data.setProcedure("spCreateStore");
                data.setParam("@name", store.name);
                data.setParam("@description", store.description);
                data.setParam("@userId", user.id);
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
        /// Creates a new store register in the database
        /// </summary>
        /// <param name="store"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool create(Store store, int id)
        {
            try
            {
                data.setProcedure("spCreateStore");
                data.setParam("@name", store.name);
                data.setParam("@description", store.description);
                data.setParam("@userId", id);
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
        /// List all the stores asociated to a user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>a list of stores</returns>
        public List<Store> listByUser(int userId)
        {
            try
            {
                List<Store> list = new List<Store>();

                data.setProcedure("spListStoresByUser");
                data.setParam("@userId", userId);
                data.executeAction();

                while (data.Reader.Read())
                {
                    Store store = new Store();

                    store.id = (int)data.Reader["id"];
                    if (!(data.Reader["description"] is DBNull))
                        store.description = (String)data.Reader["description"];
                    if (!(data.Reader["name"] is DBNull))
                        store.name = (String)data.Reader["name"];
                    store.userId = (int)data.Reader["userId"];
                    store.state = (bool)data.Reader["state"];

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
                data.setProcedure("spUpdateStore");
                data.setParam("@name", store.name);
                data.setParam("@description", store.description);
                data.setParam("@id", store.id);
              
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
                data.setProcedure("spDeleteStore");
                data.setParam("@id", store.id);
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
