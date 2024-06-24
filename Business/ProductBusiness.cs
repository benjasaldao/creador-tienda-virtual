using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Business
{
    public class ProductBusiness
    {
        private DataAccess data;

        public ProductBusiness() {
            data = new DataAccess();
        }

        /// <summary>
        /// Creates a new product register in the db
        /// </summary>
        /// <param name="product"></param>
        /// <returns>True if it was created successfully</returns>
        public bool create(Product product)
        {
            try
            {
                data.setProcedure("spCreateProduct");
                data.setParam("@code", product.code);
                data.setParam("@name", product.name);
                data.setParam("@description", product.description);
                data.setParam("@idCategory", product.category.id);
                data.setParam("@price", product.price);
                data.setParam("@unit", product.storeId);
                data.setParam("@stock", product.stock);
                data.setParam("@storeId", product.storeId);

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
        /// List all the products of a given store
        /// </summary>
        /// <param name="store"></param>
        /// <returns>A list of products</returns>
        public List<Product> list(int storeId) {
            List<Product> list = new List<Product>();
            try
            {
                data.setProcedure("spListProducts");
                data.setParam("@storeId", storeId);

                data.executeAction();

                while (data.Reader.Read())
                {
                    Product product = new Product();

                    product.id = (int)data.Reader["id"];
                    product.code = (string)data.Reader["code"];
                    product.name = (string)data.Reader["name"];
                    product.description = (string)data.Reader["description"];
                    product.price = (int)data.Reader["price"];
                    product.unit = (string)data.Reader["unit"];
                    product.storeId = (int)data.Reader["storeId"];
                    product.stock = (int)data.Reader["stock"];
                    product.state = (bool)data.Reader["state"];

                    product.category = new Category((int)data.Reader["idCategorie"], (string)data.Reader["category"]);

                    list.Add(product);
                }

                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { data.closeConnection();}

        }

        /// <summary>
        /// Gets one product with the given id
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="storeId"></param>
        /// <returns>A product or an empty product if it doesnt find any with the given id</returns>
        public Product getOne(int productId, int storeId)
        {
            try
            {
                Product product = new Product();
                data.setProcedure("spGetOneProduct");
                data.setParam("@id", productId);
                data.setParam("@storeId", storeId);
                data.executeAction();

                if(data.Reader.Read())
                {
                    product.id = (int)data.Reader["id"];
                    product.code = (string)data.Reader["code"];
                    product.name = (string)data.Reader["name"];
                    product.description = (string)data.Reader["description"];
                    product.price = (int)data.Reader["price"];
                    product.unit = (string)data.Reader["unit"];
                    product.storeId = (int)data.Reader["storeId"];
                    product.stock = (int)data.Reader["stock"];
                    product.state = (bool)data.Reader["state"];

                    product.category = new Category((int)data.Reader["idCategorie"], (string)data.Reader["category"]);
                }

                return product;
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
        /// Updates a product register in the database
        /// </summary>
        /// <param name="product"></param>
        /// <returns>TRUE if it was updated successfully</returns>
        public bool update(Product product) {
            try
            {
                data.setProcedure("spUpdateProduct");
                data.setParam("@id", product.id);
                data.setParam("@code", product.code);
                data.setParam("@name", product.name);
                data.setParam("@description", product.description);
                data.setParam("@idCategory", product.category.id);
                data.setParam("@price", product.price);
                data.setParam("@unit", product.storeId);
                data.setParam("@stock", product.stock);

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
        /// Deletes a product register from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns>TRUE if it was deleted successfully</returns>
        public bool delete(int id)
        {
            try
            {
                data.setProcedure("spDeleteProduct");
                data.setParam("@id", id);

                data.executeAction();
                return true;
            }
            catch (Exception ex)
            { 
                throw ex;
            }
            finally { data.closeConnection(); }
        }

        // Favorites

        /// <summary>
        /// Gets all the products saved as favorites by a storeUser
        /// </summary>
        /// <param name="storeUserId"></param>
        /// <returns>A list of products</returns>
        public List<Product> getFavorites(int storeUserId) {  
            List<Product> favorites = new List<Product>();
            try
            {
                data.setProcedure("spListFavorites");
                data.setParam("@storeUserId", storeUserId);
                data.executeRead();

                while (data.Reader.Read())
                {
                    Product product = new Product();

                    product.id = (int)data.Reader["id"];
                    product.code = (string)data.Reader["code"];
                    product.name = (string)data.Reader["name"];
                    product.description = (string)data.Reader["description"];
                    product.price = (int)data.Reader["price"];
                    product.unit = (string)data.Reader["unit"];
                    product.storeId = (int)data.Reader["storeId"];
                    product.stock = (int)data.Reader["stock"];
                    product.state = (bool)data.Reader["state"];

                    product.category = new Category((int)data.Reader["idCategorie"], (string)data.Reader["category"]);

                    favorites.Add(product);
                }

                return favorites;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { data.closeConnection(); }

        }
        
        /// <summary>
        /// Creates a favorite register in the database
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="user"></param>
        /// <returns>TRUE if it was created successfully</returns>
        public bool createFavorite(int productId, StoreUser user)
        {
            try
            {
                data.setProcedure("spCreateFavorite");
                data.setParam("@productId", productId);
                data.setParam("@storeUserId", user.id);
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
        /// Deletes a favorite register from the db by the given product and user id
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="userId"></param>
        /// <returns>TRUE if it was deleted successfully</returns>
        public bool deleteFavorite(int productId, int userId)
        {
            try
            {
                data.setQuery("spDeleteFavorite");
                data.setParam("@storeUserId", userId);
                data.setParam("@productId", productId);

                data.executeAction();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { data.closeConnection(); }
        }

        public bool isFavorite(int productId, int userId)
        {
            try
            {
                data.setQuery("select storeUserId, productId from FAVORITES where storeUserId = @storeUserId and productId = @productId");
                data.setParam("@storeUserId", userId);
                data.setParam("@productId", productId);

                data.executeRead();

                if (data.Reader.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { data.closeConnection(); }
        }

    }
}
