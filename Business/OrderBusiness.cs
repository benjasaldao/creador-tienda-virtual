using Domain;
using System;
using System.Collections.Generic;

namespace Business
{
    public class OrderBusiness
    {
        private DataAccess data;

        public OrderBusiness()
        {
            data = new DataAccess();
        }

        /// <summary>
        /// Creates an order register in the DB
        /// </summary>
        /// <param name="order"></param>
        /// <param name="products"></param>
        /// <returns>TRUE if it was created successfully</returns>
        public bool create(Order order, List<Product> products)
        {
            try
            {
                data.setQuery("INSERT INTO Orders (StoreUserId, StoreId, Comment) VALUES (@StoreUserId, @StoreId, @Comment)");
                data.setParam("@StoreUserId", order.storeUserId);
                data.setParam("@StoreId", order.storeId);
                data.setParam("@Comment", order.comment);
                
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
            };
        }

        /// <summary>
        /// Deletes a order register from the DB
        /// </summary>
        /// <param name="order"></param>
        /// <returns>TRUE if it was deleted successfully</returns>
        public bool delete(Order order)
        {
            try
            {
                data.setQuery("DELETE Orders WHERE Id = @Id");
                data.setParam("@Id", order.id);

                data.executeAction();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { data.closeConnection(); };
        }

        /// <summary>
        /// List all the orders from a store
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns>A list of orders</returns>
        public List<Order> listAll(int storeId)
        {
            try
            {
                data.setQuery("SELECT Id, StoreUserId, StoreId, Comment, Paid, Canceled FROM Orders WHERE StoreId = @StoreId");
                data.setParam("@StoreId", storeId);

                data.executeRead();
                List<Order> list = new List<Order>();
                while (data.Reader.Read())
                {
                    Order order = new Order();

                    order.id = (int)data.Reader["Id"];
                    order.storeUserId = (int)data.Reader["StoreUserId"];
                    order.storeId = (int)data.Reader["StoreId"];
                    order.comment = (string)data.Reader["Comment"];
                    order.paid = (bool)data.Reader["Paid"];
                    order.canceled = (bool)data.Reader["Canceled"];

                    list.Add(order);
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
        /// List orders by an user Id
        /// </summary>
        /// <param name="storeUserId"></param>
        /// <returns>A list of orders</returns>
        public List<Order> listByUser(int storeUserId)
        {
            try
            {
                data.setQuery("SELECT Id, StoreUserId, StoreId, Comment, Paid, Canceled FROM Orders WHERE StoreUserId = @StoreUserId");
                data.setParam("@StoreUserId", storeUserId);

                data.executeRead();
                List<Order> list = new List<Order>();
                while (data.Reader.Read())
                {
                    Order order = new Order();

                    order.id = (int)data.Reader["Id"];
                    order.storeUserId = (int)data.Reader["StoreUserId"];
                    order.storeId = (int)data.Reader["StoreId"];
                    order.comment = (string)data.Reader["Comment"];
                    order.paid = (bool)data.Reader["Paid"];
                    order.canceled = (bool)data.Reader["Canceled"];

                    list.Add(order);
                }

                return list;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { data.closeConnection(); }
        }

        /// <summary>
        /// Adds a product to an order
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="orderId"></param>
        /// <param name="amount"></param>
        /// <returns>True if it was added successfully</returns>
        public bool addProduct(int productId, int orderId, int amount)
        {
            try
            {
                data.setQuery("INSERT INTO [Oders.Products] (OrderId, ProductId, Amount) VALUES (@OrderId, @ProductId, @Amount)");
                data.setParam("@OrderId", orderId);
                data.setParam("@ProductId", productId);
                data.setParam("@Amount", amount);

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
        /// Removes a product from a order
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public bool deleteProduct(int productId, int orderId)
        {
            try
            {
                data.setQuery("DELETE [Orders.Products] WHERE ProductId = @ProductId AND OrderId = @OrderId");
                data.setParam("@ProductId", productId);
                data.setParam("@OrderId", orderId);

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
    

    }
}
