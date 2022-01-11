using Application.Interfaces;
using Application.Models.Dto;

namespace Application.Models.Commands;

public class AddProvinceCommand : INotification
{
    public ProvinceDto Province { get; set; }
}