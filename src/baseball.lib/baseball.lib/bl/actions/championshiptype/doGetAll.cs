using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.mxply.net.common.Core;

namespace com.mxply.app.baseball.lib.bl.actions.championshiptype
{
    public class doGetAll : core.ActionBL<List<model.ChampionshipType>>
    {
        public doGetAll()
        {
        }

        protected override List<model.ChampionshipType> action()
        {
            try
            {
                List<model.ChampionshipType> res = new List<model.ChampionshipType>();
                using (model.baseballDataContext db = new model.baseballDataContext(this.ConnectionString))
                {
                    res = db.ChampionshipTypes.OrderBy(o => o.Description).ToList<model.ChampionshipType>();
                }

                return res;
            }
            catch (exceptions.BaseballException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
