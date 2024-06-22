using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public List<Category> list(string filter = "")
        {
            try
            {
                List<Category> list = new List<Category>();

                data.setProcedure("spListCategories");
                if (filter != "")
                {
                    data.setParam("@query", filter);
                }
                data.executeAction();

                while (data.Reader.Read())
                {
                    Category category = new Category();

                    category.id = (int)data.Reader["id"];
                    category.description = (string)data.Reader["description"];
                    category.imageUrl = (string)data.Reader["imageUrl"];
                    category.state = (bool)data.Reader["state"];
                    category.storeId = (int)data.Reader["storeId"];

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
        /// Get only one category register wih the id number given
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
                data.setProcedure("spGetOneCategory");
                data.setParam("@id", id);
                data.executeAction();

                if (data.Reader.Read())
                {
                    category.id = (int)data.Reader["id"];
                    category.description = (string)data.Reader["description"];
                    category.imageUrl = (string)data.Reader["imageUrl"];
                    category.state = (bool)data.Reader["state"];
                    category.storeId = (int)data.Reader["storeId"];
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
                data.setProcedure("spUpdateCategory");
                data.setParam("@id", category.id);
                data.setParam("@description", category.description);
                data.setParam("@imageUrl", category.imageUrl);

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
        /// <param name="store"></param>
        /// <returns>TRUE if it was created successfully</returns>
        public bool create(Category category, Store store)
        {
            try
            {
                data.setProcedure("spCreateCategory");
                data.setParam("@description", category.description);
                data.setParam("@imageUrl", category.imageUrl);
                data.setParam("@storeId", store.id);

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
                data.setProcedure("spDeleteCategory");
                data.setParam("@id", category.id);
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
