using System;
using System.Collections.Generic;
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
                data.setQuery("INSERT INTO Products (Code, Name, Description, CategoryId, Price, Stock, StoreId) VALUES (@Code, @Name, @Description, @CategoryId, @Price, @Stock, @StoreId)");
                data.setParam("@Code", product.code);
                data.setParam("@Name", product.name);
                data.setParam("@Description", product.description);
                data.setParam("@IdCategory", product.category.id);
                data.setParam("@Price", product.price);
                data.setParam("@Stock", product.stock);
                data.setParam("@StoreId", product.storeId);

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
                data.setQuery("SELECT Id, Code, Name, Description, Price, Unit, StoreId, Stock, State FROM Products WHERE StoreId = @StoreId");
                data.setParam("@StoreId", storeId);

                data.executeRead();

                while (data.Reader.Read())
                {
                    Product product = new Product();

                    product.id = (int)data.Reader["Id"];
                    product.code = (string)data.Reader["Code"];
                    product.name = (string)data.Reader["Name"];
                    product.description = (string)data.Reader["Description"];
                    product.price = (int)data.Reader["Price"];
                    product.unit = (string)data.Reader["Unit"];
                    product.storeId = (int)data.Reader["StoreId"];
                    product.stock = (int)data.Reader["Stock"];
                    product.state = (bool)data.Reader["State"];

                    product.category = new Category((int)data.Reader["CategoryId"], (string)data.Reader["category"]);

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
        public Product getOne(int productId)
        {
            try
            {
                Product product = new Product();
                data.setQuery("SELECT Id, Code, Name, Description, Price, Unit, StoreId, Stock, State FROM Products WHERE Id = @Id");
                data.setParam("@Id", productId);
                data.executeRead();

                if(data.Reader.Read())
                {
                    product.id = (int)data.Reader["Id"];
                    product.code = (string)data.Reader["Code"];
                    product.name = (string)data.Reader["Name"];
                    product.description = (string)data.Reader["Description"];
                    product.price = (int)data.Reader["Price"];
                    product.unit = (string)data.Reader["Unit"];
                    product.storeId = (int)data.Reader["StoreId"];
                    product.stock = (int)data.Reader["Stock"];
                    product.state = (bool)data.Reader["State"];

                    product.category = new Category((int)data.Reader["CategoryId"], (string)data.Reader["category"]);
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
                data.setQuery("UPDATE Products SET Code = @Code, Name = @Name, Description = @Description, CategoryId = @CategoryId, Price = @Price, Stock = @Stock WHERE Id = @Id");
                data.setParam("@Id", product.id);
                data.setParam("@Code", product.code);
                data.setParam("@Name", product.name);
                data.setParam("@Description", product.description);
                data.setParam("@CategoryId", product.category.id);
                data.setParam("@Price", product.price);
                data.setParam("@Stock", product.stock);

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
                data.setQuery("DELETE Products WHERE Id = @Id");
                data.setParam("@Id", id);

                data.executeAction();
                return true;
            }
            catch (Exception ex)
            { 
                throw ex;
            }
            finally { data.closeConnection(); }
        }

        // FAVORITES

        /// <summary>
        /// Gets all the products saved as favorites by a storeUser
        /// </summary>
        /// <param name="storeUserId"></param>
        /// <returns>A list of products</returns>
        public List<Product> getFavorites(int storeUserId) {  
            List<Product> favorites = new List<Product>();
            try
            {
                data.setQuery("SELECT P.Id, Code, P.Name, Description, Price, P.StoreId, Stock, P.State FROM Products P INNER JOIN Favorites F ON P.Id = F.ProductId INNER JOIN StoreUsers SU ON F.StoreUserId = SU.Id");
                data.setParam("@storeUserId", storeUserId);
                data.executeRead();

                while (data.Reader.Read())
                {
                    Product product = new Product();

                    product.id = (int)data.Reader["Id"];
                    product.code = (string)data.Reader["Code"];
                    product.name = (string)data.Reader["Name"];
                    product.description = (string)data.Reader["Description"];
                    product.price = (int)data.Reader["Price"];
                    product.unit = (string)data.Reader["Unit"];
                    product.storeId = (int)data.Reader["StoreId"];
                    product.stock = (int)data.Reader["Stock"];
                    product.state = (bool)data.Reader["State"];

                    product.category = new Category((int)data.Reader["CategoryId"], (string)data.Reader["category"]);

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
                data.setQuery("INSERT INTO Favorites (ProductId, StoreUserId, StoreId) VALUES (@ProductId, @StoreUserId, @StoreId)");
                data.setParam("@ProductId", productId);
                data.setParam("@StoreUserId", user.id);
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
        /// Deletes a favorite register from the db by the given product and user id
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="userId"></param>
        /// <returns>TRUE if it was deleted successfully</returns>
        public bool deleteFavorite(int productId, int userId)
        {
            try
            {
                data.setQuery("DELETE Favorites WHERE StoreUserId = @StoreUserId AND ProductId = @ProductId");
                data.setParam("@StoreUserId", userId);
                data.setParam("@ProductId", productId);

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
        /// Checks in the DB if a product is a favorite from a user
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="userId"></param>
        /// <returns>TRUE if a register is founded</returns>
        public bool isFavorite(int productId, int userId)
        {
            try
            {
                data.setQuery("SELECT StoreUserId, ProductId FROM Favorites WHERE StoreUserId = @StoreUserId AND ProductId = @ProductId");
                data.setParam("@StoreUserId", userId);
                data.setParam("@ProductId", productId);

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

        // IMAGES

        /// <summary>
        /// Add an image to a product
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="imageUrl"></param>
        /// <returns>true if it was added successfully</returns>
        public bool addImage(int productId, string imageUrl)
        {
            try
            {
                data.setQuery("INSERT INTO ProductsImages (ProductId, ImageUrl) VALUES (@ProductId, @ImageUrl)");
                data.setParam("@ProductId", productId);
                data.setParam("@ImageUrl", imageUrl);

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
        /// Deletes an image of a given product
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="imageUrl"></param>
        /// <returns>true if it was deleted successfully</returns>
        public bool deleteImage(int productId, string imageUrl)
        {
            try
            {
                data.setQuery("DELETE ProductsImages WHERE ProductId = @ProductId AND ImageUrl LIKE @ImageUrl");
                data.setParam("@ProductId", productId);
                data.setParam("@ImageUrl", imageUrl);

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
