using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.mxply.app.baseball.lib.Test
{
    class Program
    {
        static lib.bl.core.Cache cache;
        static void Main(string[] args)
        {
            cache = new bl.core.Cache();
            cache.InitializeApp();

            RemoveAll(false);
            ShowAll();
            Insert();
            ShowAll();

            cache.FinalizeApp();
        }

        private static void Insert()
        {
            #region Federation
            Console.WriteLine("*********** Federation ************");
            lib.bl.actions.federation.doSave doSaveFederation;
            for (int ifederation = 0; ifederation < 2; ifederation++)
            {
                model.Federation federation = new model.Federation();
                federation.Id = Guid.NewGuid();
                federation.Name = string.Format("Federation {0:0}", ifederation);
                federation.Active = true;

                doSaveFederation = new bl.actions.federation.doSave(federation);
                federation = doSaveFederation.execute(cache);

                Console.WriteLine(string.Format("Inserted Id:{0} - Name:{1}", federation.Id, federation.ToString()));
                
                #region Club
                Console.WriteLine("*********** Club ************");
                lib.bl.actions.club.doSave doSaveClub;
                for (int iclub = 0; iclub < 2; iclub++)
                {
                    model.Club club = new model.Club();
                    club.Id = Guid.NewGuid();
                    club.Name = string.Format("Club {0:0}{1:0}", ifederation, iclub);
                    club.FederationId = federation.Id;
                    club.Active = true;

                    doSaveClub = new bl.actions.club.doSave(club);
                    doSaveClub.execute(cache);

                    Console.WriteLine(string.Format("Inserted Id:{0} - Name:{1}", club.Id, club.ToString()));

                    #region Team
                    Console.WriteLine("*********** Team ************");
                    lib.bl.actions.team.doSave doSaveTeam;
                    for (int iteam = 0; iteam < 2; iteam++)
                    {
                        model.Team team = new model.Team();
                        team.Id = Guid.NewGuid();
                        team.Name = string.Format("Team {0:0}{1:0}{2:0}", ifederation, iclub, iteam);
                        team.ClubId = club.Id;
                        team.Active = true;

                        doSaveTeam = new bl.actions.team.doSave(team);
                        doSaveTeam.execute(cache);

                        Console.WriteLine(string.Format("Inserted Id:{0} - Name:{1}", team.Id, team.ToString()));
                        
                        #region Person
                        Console.WriteLine("*********** Person ************");
                        lib.bl.actions.person.doSave doSavePerson;
                        for (int iperson = 0; iperson < 2; iperson++)
                        {
                            model.Person person = new model.Person();
                            person.Id = Guid.NewGuid();
                            person.FirstName =  string.Format("firstName fn{0:0}{1:0}{2:0}{3:0}", ifederation, iclub, iteam, iperson);
                            person.LastName = string.Format("LastName ln{0:0}{1:0}{2:0}{3:0}", ifederation, iclub, iteam, iperson);
                            person.Active = true;

                            doSavePerson = new bl.actions.person.doSave(person);
                            doSavePerson.execute(cache);

                            Console.WriteLine(string.Format("Inserted Id:{0} - Name:{1}", person.Id, person.ToString()));
                        }
                        #endregion  

                    }
                    #endregion  
                }
                #endregion            
            }
            #endregion

            ShowPromptInfo();
        }

        private static void ShowAll()
        {
            #region Federation
            Console.WriteLine("*********** Federation ************");
            lib.bl.actions.federation.doGetAll doGetAllFederation = new bl.actions.federation.doGetAll();
            foreach (model.Federation federation in doGetAllFederation.execute(cache))
            {
                Console.WriteLine(string.Format("Get Id:{0} - Name:{1}", federation.Id, federation.ToString()));
            } 
            #endregion

            #region ChampionshipType
            Console.WriteLine("*********** ChampionshipType ************");
            lib.bl.actions.championshiptype.doGetAll doGetAllChampionshipType = new bl.actions.championshiptype.doGetAll();
            foreach (model.ChampionshipType championshipType in doGetAllChampionshipType.execute(cache))
            {
                Console.WriteLine(string.Format("Get Id:{0} - Name:{1}", championshipType.Id, championshipType.ToString()));
            } 
            #endregion

            #region MatchStatus
            Console.WriteLine("*********** MatchStatus ************");
            lib.bl.actions.matchstatus.doGetAll doGetAllMatchStatus = new bl.actions.matchstatus.doGetAll();
            foreach (model.MatchStatus matchstatus in doGetAllMatchStatus.execute(cache))
            {
                Console.WriteLine(string.Format("Get Id:{0} - Name:{1}", matchstatus.Id, matchstatus.ToString()));
            }
            #endregion

            #region LicenseType
            Console.WriteLine("*********** LicenseType ************");
            lib.bl.actions.licensetype.doGetAll doGetAllLicenseType = new bl.actions.licensetype.doGetAll();
            foreach (model.LicenseType licenseType in doGetAllLicenseType.execute(cache))
            {
                Console.WriteLine(string.Format("Get Id:{0} - Name:{1}", licenseType.Id, licenseType.ToString()));
            }
            #endregion

            #region MovementType
            Console.WriteLine("*********** MovementType ************");
            lib.bl.actions.movementtype.doGetAll doGetAllMovementType = new bl.actions.movementtype.doGetAll();
            foreach (model.MovementType movementType in doGetAllMovementType.execute(cache))
            {
                Console.WriteLine(string.Format("Get Id:{0} - Name:{1}", movementType.Id, movementType.ToString()));
            }
            #endregion

            #region Position
            Console.WriteLine("*********** Position ************");
            lib.bl.actions.position.doGetAll doGetAllPosition = new bl.actions.position.doGetAll();
            foreach (model.Position licenseType in doGetAllPosition.execute(cache))
            {
                Console.WriteLine(string.Format("Get Id:{0} - Name:{1}", licenseType.Id, licenseType.ToString()));
            }
            #endregion

            #region Club
            Console.WriteLine("*********** Club ************");
            lib.bl.actions.club.doGetAll doGetAllClub = new bl.actions.club.doGetAll();
            foreach (model.Club licenseType in doGetAllClub.execute(cache))
            {
                Console.WriteLine(string.Format("Get Id:{0} - Name:{1}", licenseType.Id, licenseType.ToString()));
            }
            #endregion

            #region Team
            Console.WriteLine("*********** Team ************");
            lib.bl.actions.team.doGetAll doGetAllTeam = new bl.actions.team.doGetAll();
            foreach (model.Team licenseType in doGetAllTeam.execute(cache))
            {
                Console.WriteLine(string.Format("Get Id:{0} - Name:{1}", licenseType.Id, licenseType.ToString()));
            }
            #endregion

            ShowPromptInfo();
        }

        private static void RemoveAll(bool keepEven)
        {
            int i;

            #region Federation
            Console.WriteLine("*********** Federation ************");
            lib.bl.actions.federation.doGetAll doGetAllFederation = new bl.actions.federation.doGetAll();
            lib.bl.actions.federation.doDelete doDeleteFederation;
            i = 0;
            foreach (model.Federation federation in doGetAllFederation.execute(cache))
            {
                if (i % 2 != 0 || !keepEven)
                {
                    doDeleteFederation = new bl.actions.federation.doDelete(federation);
                    doDeleteFederation.execute(cache);
                    Console.WriteLine(string.Format("Removed Id:{0} - Name:{1}", federation.Id, federation.ToString()));
                }
                else
                {
                    Console.WriteLine(string.Format("Kept Even Id:{0} - Name:{1}", federation.Id, federation.ToString()));
                }
                i++;
            }
            #endregion

            #region Club
            Console.WriteLine("*********** Club ************");
            lib.bl.actions.club.doGetAll doGetAllClub = new bl.actions.club.doGetAll();
            lib.bl.actions.club.doDelete doDeleteClub;
            i = 0;
            foreach (model.Club club in doGetAllClub.execute(cache))
            {
                if (i % 2 != 0 || !keepEven)
                {
                    doDeleteClub = new bl.actions.club.doDelete(club);
                    doDeleteClub.execute(cache);
                    Console.WriteLine(string.Format("Removed Id:{0} - Name:{1}", club.Id, club.ToString()));
                }
                else
                {
                    Console.WriteLine(string.Format("Kept Even Id:{0} - Name:{1}", club.Id, club.ToString()));
                }
                i++;
            }
            #endregion

            #region Team
            Console.WriteLine("*********** Team ************");
            lib.bl.actions.team.doGetAll doGetAllTeam = new bl.actions.team.doGetAll();
            lib.bl.actions.team.doDelete doDeleteTeam;
            i = 0;
            foreach (model.Team team in doGetAllTeam.execute(cache))
            {
                if (i % 2 != 0 || !keepEven)
                {
                    doDeleteTeam = new bl.actions.team.doDelete(team);
                    doDeleteTeam.execute(cache);
                    Console.WriteLine(string.Format("Removed Id:{0} - Name:{1}", team.Id, team.ToString()));
                }
                else
                {
                    Console.WriteLine(string.Format("Kept Even Id:{0} - Name:{1}", team.Id, team.ToString()));
                }
                i++;
            }
            #endregion

            ShowPromptInfo();
        }
        
        private static void ShowPromptInfo()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
    }
}
