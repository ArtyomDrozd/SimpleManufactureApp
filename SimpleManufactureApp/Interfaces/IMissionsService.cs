using System.Collections.Generic;
using SimpleManufactureApp.Models;

namespace SimpleManufactureApp.Interfaces
{
    public interface IMissionsService
    {
        List<MissionModel> GetAllMissions();
        void CreateMission(MissionModel createdMission);
        void UpdateMission(int id, MissionModel updatedMission);
        void DeleteMission(int id);
    }
}
