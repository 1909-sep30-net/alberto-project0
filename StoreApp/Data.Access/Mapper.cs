﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Library;
using Data.Access.Entities;

namespace Data.Access
{
    public static class Mapper
    {
        public static Business.Library.Customer MapCustomer(Entities.Customers customer)
        {
            return new Business.Library.Customer(customer.FirstName, customer.LastName)
            {
                ID = customer.Id
            };
        }

        public static Entities.Customers MapCustomer(Business.Library.Customer customer)
        {
            return new Entities.Customers
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName

            };
        }

        public static Business.Library.Location MapLocation(Entities.Locations location)
        {
            return new Business.Library.Location(location.Name)
            {
                ID = location.Id
            };

        }

        public static Entities.Locations MapLocation(Business.Library.Location location)
        {
            return new Entities.Locations
            {
                Id = location.ID,
                Name = location.LocationName,
                Inventory = location.Inventory.Select(Mapper.MapInv).ToList()
            };
        }

        public static Entities.Products MapProduct(Business.Library.Product product)
        {
            return new Entities.Products
            {
                Description = product.Description,
                Name = product.Name,
                Price = product.Price,
                Id = product.ID


            };
        }

        public static Business.Library.Product MapProduct(Entities.Products product)
        {
            if(product == null)
            {
                throw new ArgumentException("It's NULLLLLL");
            }
            return new Business.Library.Product(product.Name, product.Description, product.Price)
            {
                ID = product.Id
            };
        }

        public static Business.Library.Order MapOrder(Entities.Orders order)
        {
            return new Business.Library.Order(MapLocation(order.Location), MapCustomer(order.Customer))
            {
                ID = order.Id,
                Total = order.Total

            };
        }

        public static Entities.Orders MapOrder(Business.Library.Order order)
        {
            Entities.Customers customer = MapCustomer(order.OCustomer);
            Entities.Locations location = MapLocation(order.OLocation);

            return new Entities.Orders
            {
                Customer = customer,
                Location = location,
                CustomerId = customer.Id,
                LocationId = location.Id,
                CreatedAt = order.Date,
                Id = order.ID,
                Total = order.Total,
            };
        }

        public static Business.Library.OrderDetails MapOrderDetails(Entities.OrderDetails order)
        {
           
            return new Business.Library.OrderDetails
            {
                ID = order.OrderId,
                Order = MapOrder(order.Order),
                Product = MapProduct(order.Product),
                order_id = order.OrderId,
                product_id = order.ProductId,
                Quantity = order.Quantity
            };
        }

        public static Entities.OrderDetails MapOrderDetails(Business.Library.OrderDetails order)
        {
            return new Entities.OrderDetails
            {
                //Order = MapOrder(order.Order),
                //Product = MapProduct(order.Product),
                //OrderDetailId = order.ID,
                OrderId = order.Order.ID,
                ProductId = order.Product.ID,
                Quantity = order.Quantity

            };
        }

        public static Entities.Inventory MapInv(Business.Library.Inventory inventory)
        {

            return new Entities.Inventory
            {

                Id = inventory.ID,
                LocationId = inventory.location_id,
                ProductId = inventory.product_id,
                Quantity = inventory.quantity
            };
        }

        public static Business.Library.Inventory MapInv(Entities.Inventory inventory)
        {
            Product p = MapProduct(inventory.Product);

            return new Business.Library.Inventory
            {
                ID = inventory.Id,
                location_id = inventory.LocationId,
                product_id = inventory.ProductId,
                quantity = inventory.Quantity,
                Product = p,
                Location = MapLocation(inventory.Location)
               

            };
        }
    }
}
