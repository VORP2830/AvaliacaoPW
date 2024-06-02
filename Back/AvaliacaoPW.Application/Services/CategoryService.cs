using AutoMapper;
using AvaliacaoPW.Application.Dtos;
using AvaliacaoPW.Application.Interfaces;
using AvaliacaoPW.Domain.Entities;
using AvaliacaoPW.Domain.Exceptions;
using AvaliacaoPW.Domain.Interfaces;
using AvaliacaoPW.Domain.Pagination;

namespace AvaliacaoPW.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public CategoryService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<CategoryDto> GetById(int id)
    {
        Category category = await _unitOfWork.CategoryRepository.GetById(id);
        return _mapper.Map<CategoryDto>(category);
    }

    public async Task<IEnumerable<CategoryDto>> GetAll()
    {
        IEnumerable<Category> categories = await _unitOfWork.CategoryRepository.GetAll();
        return _mapper.Map<IEnumerable<CategoryDto>>(categories);
    }
    public async Task<PageList<CategoryDto>> GetPaginated(PageParams pageParams)
    {
        var categoryPage = await _unitOfWork.CategoryRepository.GetPaginated(pageParams);
        if (categoryPage == null) return null;
        var categoryPageDtos = _mapper.Map<IEnumerable<CategoryDto>>(categoryPage.Items);
        return new PageList<CategoryDto>(categoryPageDtos.ToList(), categoryPage.TotalCount, categoryPage.CurrentPage, categoryPage.PageSize);
    }
    public async Task<CategoryDto> Create(CategoryDto model)
    {
        Category category = _mapper.Map<Category>(model);
        _unitOfWork.CategoryRepository.Add(category);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<CategoryDto>(category);

    }
    public async Task<CategoryDto> Update(CategoryDto model)
    {
        Category category = await _unitOfWork.CategoryRepository.GetById(model.Id);
        if (category is null)
        {
            throw new AvaliacaoPWException("Categoria não encontrado");
        }
        _mapper.Map(model, category);
        _unitOfWork.CategoryRepository.Update(category);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<CategoryDto>(category);
    }
    public async Task<CategoryDto> Delete(int id)
    {
        Category category = await _unitOfWork.CategoryRepository.GetById(id);
        if (category is null)
        {
            throw new AvaliacaoPWException("Categoria não encontrado");
        }
        category.SetActive(false);
        _unitOfWork.CategoryRepository.Update(category);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<CategoryDto>(category);
    }
}
