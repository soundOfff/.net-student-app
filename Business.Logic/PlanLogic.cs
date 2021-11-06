using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class PlanLogic: BusinessLogic
    {
        private PlanAdapter _planData;

        public PlanAdapter PlanData { get { return _planData; } set { _planData = value; } }

        public PlanLogic()
        {
            _planData = new PlanAdapter();
        }

        public List<Plan> GetAll()
        {
            return _planData.GetAll();
        }

        public List<String> GetAllDistinct()
        {
            return _planData.GetAllDistinct();
        }
        public List<Plan> GetAll(int idEspecialidad)
        {
            return _planData.GetAll(idEspecialidad);
        }

        public Plan GetOne(int idPlan)
        {
            return _planData.GetOne(idPlan);
        }

        public int GetOne(string descPlan, string descEspecialidad)
        {
            return _planData.GetOne(descPlan, descEspecialidad);
        }

        public void Delete(int idPlan)
        {
            _planData.Delete(idPlan);
        }

        public void Save(Plan plan)
        {
            _planData.Save(plan);
        }
    }
}
