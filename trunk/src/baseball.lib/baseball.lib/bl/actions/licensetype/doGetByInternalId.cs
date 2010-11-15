using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.mxply.net.common.Core;

namespace com.mxply.app.baseball.lib.bl.actions.licensetype
{
    public class doGetByInternalId : core.ActionBL
    {
        common.enums.LicenseType _internalId;
        public doGetByInternalId(common.enums.LicenseType internalId)
        {
            _internalId = internalId;
        }


        public new model.LicenseType execute(ICache cache)
        {
            return (model.LicenseType)base.execute(cache);
        }

        protected override object action()
        {
            try
            {
                model.LicenseType res = null;
                using (model.baseballDataContext db = new model.baseballDataContext(this.ConnectionString))
                {
                    res = db.LicenseTypes.Where(o => o.InternalId == model.LicenseType.Convert(_internalId)).FirstOrDefault();
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
