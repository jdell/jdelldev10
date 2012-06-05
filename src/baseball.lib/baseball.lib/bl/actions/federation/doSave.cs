using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mxply = com.mxply.net.common;
using com.mxply.net.common.Core;

namespace com.mxply.app.baseball.lib.bl.actions.federation
{
    public class doSave : core.ActionBL<model.Federation>
    {
        private model.Federation _federation = null;
        public doSave(model.Federation federation)
        {
            _federation = federation;
        }

        protected override model.Federation action()
        {
            try
            {
                //core.Check.Federation(this, _federation);

                using (model.baseballDataContext db = new model.baseballDataContext(this.ConnectionString))
                {
                    model.Federation temp = db.Federations.Where(o => o.Id == _federation.Id).SingleOrDefault();
                    if (temp == null)
                    {
                        _federation.Active = true;
                        db.Federations.InsertOnSubmit(_federation);
                    }
                    else
                    {
                        temp.Name = _federation.Name;
                    }

                    db.SubmitChanges();
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
