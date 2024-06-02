using AutoMapper;
using AvaliacaoPW.Application.Dtos;
using AvaliacaoPW.Application.Interfaces;
using AvaliacaoPW.Domain.Entities;
using AvaliacaoPW.Domain.Exceptions;
using AvaliacaoPW.Domain.Interfaces;
using AvaliacaoPW.Domain.Pagination;

namespace AvaliacaoPW.Application.Services;

public class ProductService : IProductService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public ProductService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<ProductDto> GetById(int id)
    {
        Product product = await _unitOfWork.ProductRepository.GetById(id);
        return _mapper.Map<ProductDto>(product);
    }

    public async Task<IEnumerable<ProductDto>> GetAll()
    {
        IEnumerable<Product> products = await _unitOfWork.ProductRepository.GetAll();
        return _mapper.Map<IEnumerable<ProductDto>>(products);
    }
    public async Task<PageList<ProductDto>> GetPaginated(PageParams pageParams)
    {
        var productPage = await _unitOfWork.ProductRepository.GetPaginated(pageParams);
        if (productPage == null) return null;
        var productPageDtos = _mapper.Map<IEnumerable<ProductDto>>(productPage.Items);
        return new PageList<ProductDto>(productPageDtos.ToList(), productPage.TotalCount, productPage.CurrentPage, productPage.PageSize);
    }
    public async Task<ProductDto> Create(ProductDto model)
    {
        Product product = _mapper.Map<Product>(model);
        _unitOfWork.ProductRepository.Add(product);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<ProductDto>(product);

    }
    public async Task<ProductDto> Update(ProductDto model)
    {
        Product product = await _unitOfWork.ProductRepository.GetById(model.Id);
        if (product is null)
        {
            throw new AvaliacaoPWException("Produto não encontrado");
        }
        _mapper.Map(model, product);
        _unitOfWork.ProductRepository.Update(product);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<ProductDto>(product);
    }
    public async Task<ProductDto> Delete(int id)
    {
        Product product = await _unitOfWork.ProductRepository.GetById(id);
        if (product is null)
        {
            throw new AvaliacaoPWException("Produto não encontrado");
        }
        product.SetActive(false);
        _unitOfWork.ProductRepository.Update(product);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<ProductDto>(product);
    }
}

