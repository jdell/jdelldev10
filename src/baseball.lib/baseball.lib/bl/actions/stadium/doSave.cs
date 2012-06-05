using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mxply = com.mxply.net.common;
using com.mxply.net.common.Core;

namespace com.mxply.app.baseball.lib.bl.actions.stadium
{
    public class doSave : core.ActionBL<model.Stadium>
    {
        private model.Stadium _stadium = null;
        public doSave(model.Stadium stadium)
        {
            _stadium = stadium;
        }

        protected override model.Stadium action()
        {
            try
            {
                //core.Check.Stadium(this, _stadium);

                using (model.baseballDataContext db = new model.baseballDataContext(this.ConnectionString))
                {
                    model.Stadium temp = db.Stadiums.Where(o => o.Id == _stadium.Id).SingleOrDefault();
                    if (temp == null)
                    {
                        db.Stadiums.InsertOnSubmit(_stadium);
                    }
                    else
                    {
                        temp.Name = _stadium.Name;
                        temp.AddressId = _stadium.AddressId;
                    }

                    db.SubmitChanges();
                }

                return _stadium;
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
