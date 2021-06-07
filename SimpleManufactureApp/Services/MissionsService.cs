using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FluentValidation.Results;
using SimpleManufactureApp.Data;
using SimpleManufactureApp.Interfaces;
using SimpleManufactureApp.Models;
using SimpleManufactureApp.Validators;

namespace SimpleManufactureApp.Services
{
    internal class MissionsService : IMissionsService
    {
        public List<MissionModel> GetAllMissions()
        {
            using (var context = new ManufactureDbContext())
            {
                var missions = context.Missions.ToList();
                return missions;
            }
        }

        public void CreateMission(MissionModel createdMission)
        {
            using (var context = new ManufactureDbContext())
            {
                var result = new ValidationResult();

                if (result.IsValid == false)
                {
                    foreach (var failure in result.Errors)
                    {
                        Console.WriteLine($"{failure.ErrorMessage}");
                    }
                    return;;
                }

                context.Missions.Add(createdMission);
                context.SaveChanges();
            }
        }

        public void UpdateMission(int id, MissionModel updatedMission)
        {
            using (var context = new ManufactureDbContext())
            {
                var validator = new MissionValidator();
                var result = validator.Validate(updatedMission);
                updatedMission.MissionId = id;

                if (result.IsValid == false)
                {
                    foreach (var failure in result.Errors)
                    {
                        Console.WriteLine($"{failure.ErrorMessage}");
                    }
                    return;
                }

                context.Entry(updatedMission).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteMission(int id)
        {
            using (var context = new ManufactureDbContext())
            {
                var mission = context.Missions.Find(id);
                context.Missions.Remove(mission ?? throw new InvalidOperationException());
                context.SaveChanges();
            }
        }
    }
}
