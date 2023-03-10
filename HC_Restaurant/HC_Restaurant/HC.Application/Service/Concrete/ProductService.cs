using AutoMapper;
using Hc.Application.Extensions;
using Hc.Application.Models.DTO;
using Hc.Application.Models.VM;
using HC.Application.Service.Interface;
using HC.Domain.Concrete;
using HC.Domain.Enums;
using HC.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace HC.Application.Service.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<string> Create(CreateProductDTO model)
        {
            var product = _mapper.Map<Product>(model);

            var result = await _unitOfWork.ProductRepository.Any(x => x.ProductName == product.ProductName);
            if (result)
            {
                return "This Product already exists";
            }

            //ImageUploader imageUploader = new ImageUploader();
            //var imageResult = imageUploader.IsValid(model.Image);
            //if (imageResult)
            //{
            //    using var image = Image.Load(model.Image.OpenReadStream());
            //    //image.Mutate(x => x.Resize(200, 200));
            //    image.Save("wwwroot/Content/images/products/" + product.ProductName + imageUploader.GetExtension());
            //    product.ImagePath = ("/Content/images/products/" + product.ProductName + imageUploader.GetExtension());

            //    await _unitOfWork.ProductRepository.Add(product);

            //    return "Product added!";
            //}


            return "Please choise a image!";
        }

        public async Task<string> Delete(Guid id)
        {
            await _unitOfWork.ProductRepository.Delete(id);

            return "Product deleted!";
        }

        public async Task<UpdateProductDTO> GetById(Guid id)
        {
            var product = await _unitOfWork.ProductRepository.GetFilteredFirstOrDefault(selector: x => new ProductVM
            {
                ID = x.ID,
                ProductName = x.ProductName,
                Description = x.Description,
                ImagePath = x.ImagePath,
                UnitPrice = x.UnitPrice,
                UnitsInStock = x.UnitInStock,
                CategoryID = x.CategoryID,
                CategoryName = x.Category.CategoryName

            },
            expression: x => x.ID == id);

            var model = _mapper.Map<UpdateProductDTO>(product);

            return model;
        }

        public async Task<List<ProductVM>> GetDefaultProducts()
        {
            var productList = await _unitOfWork.ProductRepository.GetFilteredFirstOrDefaults(x => new ProductVM
            {
                ID = x.ID,
                ProductName = x.ProductName,
                Description = x.Description,
                UnitPrice = x.UnitPrice,
                UnitsInStock = x.UnitInStock,
                ImagePath = x.ImagePath,
                Status = x.Status,
                CategoryID = x.CategoryID,
                CategoryName = x.Category.CategoryName
            },
            expression: x => x.Status != Domain.Enums.Status.Deleted);

            return productList;
        }

        public async Task<List<ProductVM>> GetProducts()
        {
            var productList = await _unitOfWork.ProductRepository.GetFilteredFirstOrDefaults(x => new ProductVM
            {
                ID = x.ID,
                ProductName = x.ProductName,
                Description = x.Description,
                UnitPrice = x.UnitPrice,
                UnitsInStock = x.UnitInStock,
                ImagePath = x.ImagePath,
                CategoryName = x.Category.CategoryName,
                Status = x.Status
            },
            expression: x => x.Status == Domain.Enums.Status.Active || x.Status == Domain.Enums.Status.Updated || x.Status == Domain.Enums.Status.Deleted);

            return productList;
        }

        public async Task<List<ProductVM>> GetProductsByCategory(Guid? subCategoryId)
        {
            var productList = await _unitOfWork.ProductRepository.GetFilteredFirstOrDefaults(x => new ProductVM
            {
                ID = x.ID,
                ProductName = x.ProductName,
                Description = x.Description,
                UnitPrice = x.UnitPrice,
                UnitsInStock = x.UnitInStock,
                ImagePath = x.ImagePath,
                CategoryName = x.Category.CategoryName,
                Status = x.Status
            },
            expression: x => x.CategoryID == subCategoryId && x.Status != Domain.Enums.Status.Deleted,
            orderBy: x => x.OrderBy(z => z.UnitPrice)
            );

            return productList;
        }

        public async Task<string> Update(UpdateProductDTO model)
        {
            var product = _mapper.Map<Product>(model);

            //ImageUploader imageUploader = new ImageUploader();
            //var imageResult = imageUploader.IsValid(model.Image);
            //if (imageResult)
            //{
            //    using var image = Image.Load(model.Image.OpenReadStream());
            //    //image.Mutate(x => x.Resize(150, 150));
            //    image.Save("wwwroot/Content/images/products/" + product.ProductName + imageUploader.GetExtension());
            //    product.ImagePath = ("/Content/images/products/" + product.ProductName + imageUploader.GetExtension());
            //}

            await _unitOfWork.ProductRepository.Update(product);

            return "Product updated!";
        }
    }
}
