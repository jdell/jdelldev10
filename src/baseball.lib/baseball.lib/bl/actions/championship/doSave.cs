using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mxply = com.mxply.net.common;
using com.mxply.net.common.Core;

namespace com.mxply.app.baseball.lib.bl.actions.championship
{
    public class doSave : core.ActionBL<model.Championship>
    {
        private model.Championship _championship = null;
        public doSave(model.Championship championship)
        {
            _championship = championship;
        }
        
        protected override model.Championship action()
        {
            try
            {
                //core.Check.Championship(this, _championship);

                using (model.baseballDataContext db = new model.baseballDataContext(this.ConnectionString))
                {
                    model.Championship temp = db.Championships.Where(o => o.Id == _championship.Id).SingleOrDefault();
                    if (temp == null)
                    {
                        _championship.Active = true;
                        db.Championships.InsertOnSubmit(_championship);
                    }
                    else
                    {
                        temp.Active = _championship.Active;
                        temp.ChampionshipTypeId = _championship.ChampionshipTypeId;
                        temp.Name = _championship.Name;
                    }

                    db.SubmitChanges();
                }

                return _championship;
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
