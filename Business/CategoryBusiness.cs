using System;
using System.Collections.Generic;
using Domain;

namespace Business
{
    public class CategoryBusiness
    {

        private DataAccess data;

        public CategoryBusiness()
        {
            data = new DataAccess();
        }

        /// <summary>
        /// list all the category registers it found in the db
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>Returns a list with category objects or an empty list if it doesnt found any register</returns>
        public List<Category> list(int storeId)
        {
            try
            {
                List<Category> list = new List<Category>();

                data.setQuery("SELECT Id, Description, ImageUrl, State, StoreId FROM Categories WHERE StoreId = @StoreId");

                data.setParam("@StoreId", storeId);

                data.executeRead();

                while (data.Reader.Read())
                {
                    Category category = new Category();

                    category.id = (int)data.Reader["Id"];
                    category.description = (string)data.Reader["Description"];
                    category.imageUrl = (string)data.Reader["ImageUrl"];
                    category.state = (bool)data.Reader["State"];
                    category.storeId = (int)data.Reader["StoreId"];

                    list.Add(category);
                }

                return list;


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
        /// Search for one register in the DB
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// A category with an id or an empty category object if it doesnt find any
        /// </returns>
        public Category getOne(int id)
        {
            try
            {
                Category category = new Category();
                data.setQuery("SELECT Id, Description, ImageUrl, State, StoreId FROM Categories WHERE Id = @Id");
                data.setParam("@Id", id);
                data.executeRead();

                if (data.Reader.Read())
                {
                    category.id = (int)data.Reader["Id"];
                    category.description = (string)data.Reader["Description"];
                    category.imageUrl = (string)data.Reader["ImageUrl"];
                    category.state = (bool)data.Reader["State"];
                    category.storeId = (int)data.Reader["StoreId"];
                }

                return category;
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
        /// Replaces a category register with the given category object 
        /// </summary>
        /// <param name="category"></param>
        /// <returns>TRUE if it was updated successfully</returns>
        public bool update(Category category)
        {
            try
            {
                data.setQuery("UPDATE Categories SET Description = @Description, ImageUrl = @ImageUrl WHERE Id = @Id");
                data.setParam("@Id", category.id);
                data.setParam("@Description", category.description);
                data.setParam("@ImageUrl", category.imageUrl);

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
        /// Creates a new category register in the database 
        /// with the given store id
        /// </summary>
        /// <param name="category"></param>
        /// <returns>TRUE if it was created successfully</returns>
        public bool create(Category category)
        {
            try
            {
                data.setQuery("INSERT INTO Categories (Description, ImageUrl, StoreId) VALUES (@Description, @ImageUrl, @StoreId)");
                data.setParam("@Description", category.description);
                data.setParam("@ImageUrl", category.imageUrl);
                data.setParam("@StoreId", category.storeId);

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
        /// Deletes a given category register from the database
        /// </summary>
        /// <param name="category"></param>
        /// <returns>
        /// TRUE if it was correctly deleted
        /// </returns>
        public bool delete(Category category)
        {
            try
            {
                data.setQuery("DELETE Categories WHERE Id = @Id");
                data.setParam("@Id", category.id);
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
