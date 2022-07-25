using System.Collections.Generic;

namespace SteveJstone
{
    public interface IBuildMenuView
    {
        public void Refresh(IList<BuildingCategory> categories, IList<BuildingDefinition> buildings);
    }
}