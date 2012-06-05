using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.mxply.net.common.Core;

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

                Result<bool> res = doCheck.execute(this);
                if (res.Success)
                    return res.Value;
                else
                    throw res.Error.InnerException;
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
