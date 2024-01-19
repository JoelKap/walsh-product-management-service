using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Walsh.Product.Management.Service.Dal.Contracts;
using Walsh.Product.Management.Service.Dal.DTO;
using Walsh.Product.Management.Service.Model;
using Walsh.Product.Management.Service.Shared.CustomExceptions;

namespace Walsh.Product.Management.Service.Dal.Implimentations
{
    public class ProductReviewDataAccess: IProductReviewDataAccess
    {
        private readonly WalshDbContext _walshContext;
        private readonly IMapper _mapper;
        public ProductReviewDataAccess(WalshDbContext walshContext)
        {
            _walshContext = walshContext;
            _mapper = Mappings.MappingProfile.MapperConfiguration();
        }

        public async Task<ProductReviewModel> CreateProductReviewAsync(ProductReviewModel model)
        {
            model.IsDeleted = false;
            model.CreatedAt = DateTime.Now; 
            model.UpdateAt = DateTime.Now;

            var productDto = _mapper.Map<ProductReviewModel, ProductReview>(model);

            _walshContext.ProductReviews.Add(productDto);

            try
            {
                await _walshContext.SaveChangesAsync();
                model.ReviewId = productDto.ReviewId;
                return model;
            }
            catch (DbUpdateException ex)
            {
                throw new UpdateFailedException("Failed to update product.", ex);
            }
        }
          
        public async Task<ProductReviewModel> GetProductReviewAsync(int productId)
        {
            try
            {
                var reviewDto = await _walshContext.ProductReviews.FirstOrDefaultAsync(product => product.ProductId == productId);

                if (reviewDto is null) return null;

                return _mapper.Map<DTO.ProductReview, ProductReviewModel>(reviewDto);
            }
            catch (Exception)
            {

                throw new NotFoundException($"Product with ID {productId} not found.");
            }
        }

        public async Task<ProductReviewModel> UpdateProductReviewAsync(ProductReviewModel model)
        {
            var reviewDto = _walshContext.ProductReviews.FirstOrDefault(product => product.ProductId == model.ProductId);

            if (reviewDto == null)
            {
                throw new NotFoundException($"Product with ID {model.ProductId} not found.");
            }

            _mapper.Map<ProductReviewModel, ProductReview>(model, reviewDto);

            try
            {
                await _walshContext.SaveChangesAsync();
                return model;
            }
            catch (Exception ex)
            {
                throw new UpdateFailedException("Failed to update product.", ex);
            }
        } 
    }
}
