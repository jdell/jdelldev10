using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.mxply.net.common.Core;

namespace com.mxply.app.baseball.lib.bl.actions.team
{
    public class doGetAll : core.ActionBL<List<model.Team>>
    {
        common.enums.LicenseType _licenseType;
        model.Federation _federation;
        public doGetAll(common.enums.LicenseType licenseType)
        {
            _licenseType = licenseType;
            _federation = null;
        }
        public doGetAll(model.Federation federation, common.enums.LicenseType licenseType)
        {
            _licenseType = licenseType;
            _federation = federation;
        }

        protected override List<model.Team> action()
        {
            try
            {
                List<model.Team> res = new List<model.Team>();
                using (model.baseballDataContext db = new model.baseballDataContext(this.ConnectionString))
                {
                    var query = from t in db.Teams
                                where t.Active && (_federation==null || _federation.Id==t.FederationId) && t.LicenseTypeId ==
                                (
                                  from lc in db.LicenseTypes
                                  where lc.InternalId == model.LicenseType.Convert(_licenseType)
                                  select lc.Id
                                ).FirstOrDefault()
                                select t;
                    res = query.OrderBy(o => o.Name).ToList<model.Team>();
                    //res = db.Teams.Where(o => o.Active).OrderBy(o => o.Name).ToList<model.Team>();
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
