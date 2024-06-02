using AutoMapper;
using AvaliacaoPW.Application.Dtos;
using AvaliacaoPW.Application.Interfaces;
using AvaliacaoPW.Domain.Entities;
using AvaliacaoPW.Domain.Exceptions;
using AvaliacaoPW.Domain.Interfaces;
using AvaliacaoPW.Domain.Pagination;

namespace AvaliacaoPW.Application.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public EmployeeService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<EmployeeDto> GetById(int id)
    {
        Employee employee = await _unitOfWork.EmployeeRepository.GetById(id);
        return _mapper.Map<EmployeeDto>(employee);
    }
    public async Task<IEnumerable<EmployeeDto>> GetAll()
    {
        IEnumerable<Employee> employees = await _unitOfWork.EmployeeRepository.GetAll();
        return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
    }
    public async Task<PageList<EmployeeDto>> GetPaginated(PageParams pageParams)
    {
        var employeePage = await _unitOfWork.EmployeeRepository.GetPaginated(pageParams);
        if (employeePage == null) return null;
        var employeePageDtos = _mapper.Map<IEnumerable<EmployeeDto>>(employeePage.Items);
        return new PageList<EmployeeDto>(employeePageDtos.ToList(), employeePage.TotalCount, employeePage.CurrentPage, employeePage.PageSize);
    }
    public async Task<EmployeeDto> Create(EmployeeDto model)
    {
        Employee employee = _mapper.Map<Employee>(model);
        _unitOfWork.EmployeeRepository.Add(employee);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<EmployeeDto>(employee);
    }
    public async Task<EmployeeDto> Update(EmployeeDto model)
    {
        Employee employee = await _unitOfWork.EmployeeRepository.GetById(model.Id);
        if(employee is null)
        {
            throw new AvaliacaoPWException("Funcionario não encontrado");
        }
        _mapper.Map(model, employee);
        _unitOfWork.EmployeeRepository.Update(employee);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<EmployeeDto>(employee);
    }
    public async Task<EmployeeDto> Delete(int id)
    {
        Employee employee = await _unitOfWork.EmployeeRepository.GetById(id);
        if(employee is null)
        {
            throw new AvaliacaoPWException("Funcionario não encontrado");
        }
        employee.SetActive(false);
        _unitOfWork.EmployeeRepository.Update(employee);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<EmployeeDto>(employee);
    }
}
