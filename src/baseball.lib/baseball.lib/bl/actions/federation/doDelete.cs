using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.mxply.net.common.Core;

namespace com.mxply.app.baseball.lib.bl.actions.federation
{
    public class doDelete : core.ActionBL
    {
        private model.Federation _federation = null;
        public doDelete(model.Federation federation)
        {
            _federation = federation;
        }


        public new model.Federation execute(ICache cache)
        {
            return (model.Federation)base.execute(cache);
        }

        protected override object action()
        {
            try
            {
                core.Check.Federation(this, _federation);

                using (model.baseballDataContext db = new model.baseballDataContext(this.ConnectionString))
                {
                    model.Federation temp = db.Federations.SingleOrDefault(o => o.Id == _federation.Id);
                    if (temp != null)
                    {
                        //db.Federations.DeleteOnSubmit(temp);
                        temp.Active = false;
                        db.SubmitChanges();
                    }
                }

                return _federation;
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
