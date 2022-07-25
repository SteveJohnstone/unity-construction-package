using System.Collections.Generic;

namespace SteveJstone
{
    public interface IBuildMenuView
    {
        public void Refresh(IList<StrategyGame.BuildingCategory> categories, IList<StrategyGame.Building> buildings);
    }
}