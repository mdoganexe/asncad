using AscadWeb.Core.DTOs;
using AscadWeb.Core.Models;

namespace AscadWeb.Core.Interfaces;

public interface IBuildingTemplateService
{
    List<string> GetAvailableBuildingTypes();
    BuildingTemplateResult ApplyTemplate(BuildingTemplateRequest request);
}
