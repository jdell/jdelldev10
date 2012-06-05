using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.mxply.net.common.Core;

namespace com.mxply.app.baseball.lib.bl.actions.license
{
    public class doDelete : core.ActionBL<model.License>
    {
        private model.License _license = null;
        public doDelete(model.License license)
        {
            _license = license;
        }

        protected override model.License action()
        {
            try
            {
                //core.Check.License(this, _license);

                using (model.baseballDataContext db = new model.baseballDataContext(this.ConnectionString))
                {
                    model.License temp = db.Licenses.SingleOrDefault(o => o.Id == _license.Id);
                    if (temp != null)
                    {
                        //db.Licenses.DeleteOnSubmit(temp);
                        //temp.Active = false;
                        db.SubmitChanges();
                    }
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
