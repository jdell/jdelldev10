using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mxply = com.mxply.net.common;
using com.mxply.net.common.Core;

namespace com.mxply.app.baseball.lib.bl.actions.license
{
    public class doSave : core.ActionBL
    {
        private model.License _license = null;
        public doSave(model.License license)
        {
            _license = license;
        }

        public new model.License execute(ICache cache)
        {
            return (model.License)base.execute(cache);
        }

        protected override object action()
        {
            try
            {
                core.Check.License(this, _license);

                using (model.baseballDataContext db = new model.baseballDataContext(this.ConnectionString))
                {
                    model.License temp = db.Licenses.Where(o => o.Id == _license.Id).SingleOrDefault();
                    if (temp == null)
                    {
                        model.LicenseCounter licenseCounter = db.LicenseCounters.FirstOrDefault();
                        if (licenseCounter == null)
                        {
                            licenseCounter = new model.LicenseCounter();
                            licenseCounter.Id = ((core.Cache)this.Cache).GetNewId();
                            licenseCounter.Number = 0;

                            db.LicenseCounters.InsertOnSubmit(licenseCounter);
                        }
                        licenseCounter.Number++;
                        _license.Number = licenseCounter.Number;

                        db.Licenses.InsertOnSubmit(_license);
                    }
                    else
                    {
                        temp.Date = _license.Date;
                        temp.FederationId = _license.FederationId;
                        temp.LicenseTypeId = _license.LicenseTypeId;
                        temp.Number = _license.Number;
                        temp.PersonId = _license.PersonId;
                    }
                    db.SubmitChanges();
                }

                return _license;
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
