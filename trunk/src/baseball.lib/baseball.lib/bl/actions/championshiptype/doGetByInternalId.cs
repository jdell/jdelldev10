using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.mxply.net.common.Core;

namespace com.mxply.app.baseball.lib.bl.actions.championshiptype
{
    public class doGetByInternalId : core.ActionBL<model.ChampionshipType>
    {
        common.enums.ChampionshipType _internalId;
        public doGetByInternalId(common.enums.ChampionshipType internalId)
        {
            _internalId = internalId;
        }

        protected override model.ChampionshipType action()
        {
            try
            {
                model.ChampionshipType res = null;
                using (model.baseballDataContext db = new model.baseballDataContext(this.ConnectionString))
                {
                    res = db.ChampionshipTypes.Where(o => o.InternalId == model.ChampionshipType.Convert(_internalId)).FirstOrDefault();
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
