using AutoMapper;
using AvaliacaoPW.Application.Dtos;
using AvaliacaoPW.Application.Interfaces;
using AvaliacaoPW.Domain.Entities;
using AvaliacaoPW.Domain.Exceptions;
using AvaliacaoPW.Domain.Interfaces;
using AvaliacaoPW.Domain.Pagination;

namespace AvaliacaoPW.Application.Services;
public class SupplierService : ISupplierService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public SupplierService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<SupplierDto> GetById(int id)
    {
        Supplier supplier = await _unitOfWork.SupplierRepository.GetById(id);
        return _mapper.Map<SupplierDto>(supplier);
    }
    public async Task<IEnumerable<SupplierDto>> GetAll()
    {
        IEnumerable<Supplier> suppliers = await _unitOfWork.SupplierRepository.GetAll();
        return _mapper.Map<IEnumerable<SupplierDto>>(suppliers);
    }
    public async Task<PageList<SupplierDto>> GetPaginated(PageParams pageParams)
    {
        var supplierPage = await _unitOfWork.SupplierRepository.GetPaginated(pageParams);
        if (supplierPage == null) return null;
        var supplierPageDtos = _mapper.Map<IEnumerable<SupplierDto>>(supplierPage.Items);
        return new PageList<SupplierDto>(supplierPageDtos.ToList(), supplierPage.TotalCount, supplierPage.CurrentPage, supplierPage.PageSize);
    }
    public async Task<SupplierDto> Create(SupplierDto model)
    {
        Supplier supplier = _mapper.Map<Supplier>(model);
        _unitOfWork.SupplierRepository.Add(supplier);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<SupplierDto>(supplier);
    }
    public async Task<SupplierDto> Update(SupplierDto model)
    {
        Supplier supplier = await _unitOfWork.SupplierRepository.GetById(model.Id);
        if (supplier is null)
        {
            throw new AvaliacaoPWException("Fornecedor não encontrado");
        }
        _unitOfWork.SupplierRepository.Update(supplier);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<SupplierDto>(supplier);
    }
    public async Task<SupplierDto> Delete(int id)
    {
        Supplier supplier = await _unitOfWork.SupplierRepository.GetById(id);
        if (supplier is null)
        {
            throw new AvaliacaoPWException("Fornecedor não encontrado");
        }
        supplier.SetActive(false);
        _unitOfWork.SupplierRepository.Update(supplier);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<SupplierDto>(supplier);
    }
}
