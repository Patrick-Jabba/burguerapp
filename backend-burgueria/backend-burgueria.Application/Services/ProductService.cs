﻿using backend_burgueria.Domain.Interfaces.Repositories;
using backend_burgueria.Domain.Interfaces.Services;
using backend_burgueria.Models;

namespace backend_burgueria.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void CreateProduct(Product product)
        {
            _productRepository.Create(product);
        }

        public void UpdateProduct(Product product)
        {
            _productRepository.Update(product);
        }

        public void DeleteProduct(int id)
        {
            _productRepository.Delete(id);
        }

        public IEnumerable<Product> GetAllProduct()
        {
            return _productRepository.GetAll();
        }

        public Product GetProductById(int id)
        {
            return _productRepository.GetById(id);
        }

        public IEnumerable<Product> GetProductByName(string name)
        {
            return _productRepository.GetAll().Where(x => x.Name.Contains(name));
        }
    }
}
