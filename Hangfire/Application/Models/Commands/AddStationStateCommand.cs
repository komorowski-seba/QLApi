using Application.Interfaces;
using Application.Models.Dto;

namespace Application.Models.Commands;

public class AddStationStateCommand : INotification
{
    public AirTestDto AirTest { get; set; }
}