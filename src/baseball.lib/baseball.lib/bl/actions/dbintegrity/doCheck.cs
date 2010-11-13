using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mxply = com.mxply.net.common;
using com.mxply.net.common.Core;

namespace com.mxply.app.baseball.lib.bl.actions.dbintegrity
{
    internal class doCheck : core.ActionBL
    {
        public new bool execute(BaseCache cache)
        {
            return (bool)base.execute(cache);
        }

        protected override object action()
        {
            try
            {
                using (model.baseballDataContext db = new model.baseballDataContext(this.ConnectionString))
                {
                    #region ChampionshipType
                    foreach (Enum item in Enum.GetValues(typeof(common.enums.ChampionshipType)))
                    {
                        if (db.ChampionshipTypes.Where(o => o.InternalId == Convert.ToByte(item)).Count() == 0)
                        {
                            model.ChampionshipType championShipType = new model.ChampionshipType()
                            {
                                Id = Guid.NewGuid(),
                                InternalId = Convert.ToByte(item),
                                Description = Mxply.Helpers.AttributeHelper.GetDescription(item)
                            };

                            db.ChampionshipTypes.InsertOnSubmit(championShipType);
                        }
                    }
                    #endregion

                    #region MatchStatus
                    foreach (Enum item in Enum.GetValues(typeof(common.enums.MatchStatus)))
                    {
                        if (db.MatchStatus.Where(o => o.InternalId == Convert.ToByte(item)).Count() == 0)
                        {
                            model.MatchStatus championShipType = new model.MatchStatus()
                            {
                                Id = Guid.NewGuid(),
                                InternalId = Convert.ToByte(item),
                                Description = Mxply.Helpers.AttributeHelper.GetDescription(item)
                            };

                            db.MatchStatus.InsertOnSubmit(championShipType);
                        }
                    }
                    #endregion

                    #region LicenseType
                    foreach (Enum item in Enum.GetValues(typeof(common.enums.LicenseType)))
                    {
                        if (db.LicenseTypes.Where(o => o.InternalId == Convert.ToByte(item)).Count() == 0)
                        {
                            model.LicenseType licenseType = new model.LicenseType()
                            {
                                Id = Guid.NewGuid(),
                                InternalId = Convert.ToByte(item),
                                Description = Mxply.Helpers.AttributeHelper.GetDescription(item)
                            };

                            db.LicenseTypes.InsertOnSubmit(licenseType);
                        }
                    }
                    #endregion

                    #region MovementType
                    foreach (Enum item in Enum.GetValues(typeof(common.enums.MovementType)))
                    {
                        if (db.MovementTypes.Where(o => o.InternalId == Convert.ToByte(item)).Count() == 0)
                        {
                            model.MovementType movementType = new model.MovementType()
                            {
                                Id = Guid.NewGuid(),
                                InternalId = Convert.ToByte(item),
                                Description = Mxply.Helpers.AttributeHelper.GetDescription(item)
                            };

                            db.MovementTypes.InsertOnSubmit(movementType);
                        }
                    }
                    #endregion

                    #region Position
                    foreach (Enum item in Enum.GetValues(typeof(common.enums.Position)))
                    {
                        if (db.Positions.Where(o => o.InternalId == Convert.ToByte(item)).Count() == 0)
                        {
                            model.Position movementType = new model.Position()
                            {
                                Id = Guid.NewGuid(),
                                InternalId = Convert.ToByte(item),
                                Description = Mxply.Helpers.AttributeHelper.GetDescription(item)
                            };

                            db.Positions.InsertOnSubmit(movementType);
                        }
                    }
                    #endregion

                    db.SubmitChanges();
                }

                return true;
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
