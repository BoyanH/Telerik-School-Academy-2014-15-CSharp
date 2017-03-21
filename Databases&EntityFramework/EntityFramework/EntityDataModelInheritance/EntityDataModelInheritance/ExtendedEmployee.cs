using System;
using System.Data.Linq;
using System.Linq;


namespace EntityDataModelInheritance
{
    public partial class Employee
    {
        public EntitySet<Territory> CorrespondingTerritories
        {
            get
            {
                var terrAsEntity = new EntitySet<Territory>();
                terrAsEntity.AddRange(this.Territories);
                return terrAsEntity;
            }
        }
    }
}
