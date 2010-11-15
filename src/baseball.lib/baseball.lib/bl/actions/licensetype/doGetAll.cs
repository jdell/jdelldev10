﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.mxply.net.common.Core;

namespace com.mxply.app.baseball.lib.bl.actions.licensetype
{
    public class doGetAll : core.ActionBL
    {
        public doGetAll()
        {
        }


        public new List<model.LicenseType> execute(ICache cache)
        {
            return (List<model.LicenseType>)base.execute(cache);
        }

        protected override object action()
        {
            try
            {
                List<model.LicenseType> res = new List<model.LicenseType>();
                using (model.baseballDataContext db = new model.baseballDataContext(this.ConnectionString))
                {
                    res = db.LicenseTypes.OrderBy(o => o.Description).ToList<model.LicenseType>();
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
