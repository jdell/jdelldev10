using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.mxply.app.baseball.lib.bl.core
{
    public class Cache:com.mxply.net.common.Core.BaseCache
    {
        public override bool InitializeApp()
        {
            try
            {
                CheckDBIntegrity();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool FinalizeApp()
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        protected override bool CheckDBIntegrity()
        {
            try
            {
                actions.dbintegrity.doCheck doCheck = new actions.dbintegrity.doCheck();

                return doCheck.execute(this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Guid GetNewId()
        {
            return Guid.NewGuid();
        }
        public bool IsEmpty(Guid id)
        {
            return id.Equals(Guid.Empty);
        }

        public void ClearDB()
        {
            actions.dbintegrity.doClearAll doClearAll = new actions.dbintegrity.doClearAll();
            doClearAll.execute(this);
        }
    }
}
