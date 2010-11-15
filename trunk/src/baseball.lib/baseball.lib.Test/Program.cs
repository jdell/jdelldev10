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
            try
            {
                cache = new bl.core.Cache();
                cache.InitializeApp();

                RemoveAll(false);
                //ShowAll();
                //Insert();
                //ShowAll();
                CreateRealExample();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex.Message);
                ShowWaitingPrompt();
            }
            finally
            {
                cache.FinalizeApp();
            }

        }

        private static void Insert()
        {
            //#region Federation
            //Console.WriteLine("*********** Federation ************");
            //lib.bl.actions.federation.doSave doSaveFederation;
            //for (int ifederation = 0; ifederation < 2; ifederation++)
            //{
            //    model.Federation federation = new model.Federation();
            //    federation.Id = Guid.NewGuid();
            //    federation.Name = string.Format("Federation {0:0}", ifederation);
            //    federation.Active = true;

            //    doSaveFederation = new bl.actions.federation.doSave(federation);
            //    federation = doSaveFederation.execute(cache);

            //    Console.WriteLine(string.Format("Inserted Id:{0} - Name:{1}", federation.Id, federation.ToString()));
                
            //    #region Club
            //    Console.WriteLine("*********** Club ************");
            //    lib.bl.actions.club.doSave doSaveClub;
            //    for (int iclub = 0; iclub < 2; iclub++)
            //    {
            //        model.Club club = new model.Club();
            //        club.Id = Guid.NewGuid();
            //        club.Name = string.Format("Club {0:0}{1:0}", ifederation, iclub);
            //        club.FederationId = federation.Id;
            //        club.Active = true;

            //        doSaveClub = new bl.actions.club.doSave(club);
            //        doSaveClub.execute(cache);

            //        Console.WriteLine(string.Format("Inserted Id:{0} - Name:{1}", club.Id, club.ToString()));

            //        #region Team
            //        Console.WriteLine("*********** Team ************");
            //        lib.bl.actions.team.doSave doSaveTeam;
            //        for (int iteam = 0; iteam < 2; iteam++)
            //        {
            //            model.Team team = new model.Team();
            //            team.Id = Guid.NewGuid();
            //            team.Name = string.Format("Team {0:0}{1:0}{2:0}", ifederation, iclub, iteam);
            //            team.ClubId = club.Id;
            //            team.Active = true;

            //            doSaveTeam = new bl.actions.team.doSave(team);
            //            doSaveTeam.execute(cache);

            //            Console.WriteLine(string.Format("Inserted Id:{0} - Name:{1}", team.Id, team.ToString()));
                        
            //            #region Person
            //            Console.WriteLine("*********** Person ************");
            //            lib.bl.actions.person.doSave doSavePerson;
            //            for (int iperson = 0; iperson < 2; iperson++)
            //            {
            //                model.Person person = new model.Person();
            //                person.Id = Guid.NewGuid();
            //                person.FirstName =  string.Format("firstName fn{0:0}{1:0}{2:0}{3:0}", ifederation, iclub, iteam, iperson);
            //                person.LastName = string.Format("LastName ln{0:0}{1:0}{2:0}{3:0}", ifederation, iclub, iteam, iperson);
            //                person.Active = true;

            //                doSavePerson = new bl.actions.person.doSave(person);
            //                doSavePerson.execute(cache);

            //                Console.WriteLine(string.Format("Inserted Id:{0} - Name:{1}", person.Id, person.ToString()));
            //            }
            //            #endregion  

            //        }
            //        #endregion  
            //    }
            //    #endregion            
            //}
            //#endregion

            ShowWaitingPrompt();
        }

        private static void ShowAll()
        {
            //#region Federation
            //Console.WriteLine("*********** Federation ************");
            //lib.bl.actions.federation.doGetAll doGetAllFederation = new bl.actions.federation.doGetAll();
            //foreach (model.Federation federation in doGetAllFederation.execute(cache))
            //{
            //    Console.WriteLine(string.Format("Get Id:{0} - Name:{1}", federation.Id, federation.ToString()));
            //} 
            //#endregion

            //#region ChampionshipType
            //Console.WriteLine("*********** ChampionshipType ************");
            //lib.bl.actions.championshiptype.doGetAll doGetAllChampionshipType = new bl.actions.championshiptype.doGetAll();
            //foreach (model.ChampionshipType championshipType in doGetAllChampionshipType.execute(cache))
            //{
            //    Console.WriteLine(string.Format("Get Id:{0} - Name:{1}", championshipType.Id, championshipType.ToString()));
            //} 
            //#endregion

            //#region MatchStatus
            //Console.WriteLine("*********** MatchStatus ************");
            //lib.bl.actions.matchstatus.doGetAll doGetAllMatchStatus = new bl.actions.matchstatus.doGetAll();
            //foreach (model.MatchStatus matchstatus in doGetAllMatchStatus.execute(cache))
            //{
            //    Console.WriteLine(string.Format("Get Id:{0} - Name:{1}", matchstatus.Id, matchstatus.ToString()));
            //}
            //#endregion

            //#region LicenseType
            //Console.WriteLine("*********** LicenseType ************");
            //lib.bl.actions.licensetype.doGetAll doGetAllLicenseType = new bl.actions.licensetype.doGetAll();
            //foreach (model.LicenseType licenseType in doGetAllLicenseType.execute(cache))
            //{
            //    Console.WriteLine(string.Format("Get Id:{0} - Name:{1}", licenseType.Id, licenseType.ToString()));
            //}
            //#endregion

            //#region MovementType
            //Console.WriteLine("*********** MovementType ************");
            //lib.bl.actions.movementtype.doGetAll doGetAllMovementType = new bl.actions.movementtype.doGetAll();
            //foreach (model.MovementType movementType in doGetAllMovementType.execute(cache))
            //{
            //    Console.WriteLine(string.Format("Get Id:{0} - Name:{1}", movementType.Id, movementType.ToString()));
            //}
            //#endregion

            //#region Position
            //Console.WriteLine("*********** Position ************");
            //lib.bl.actions.position.doGetAll doGetAllPosition = new bl.actions.position.doGetAll();
            //foreach (model.Position licenseType in doGetAllPosition.execute(cache))
            //{
            //    Console.WriteLine(string.Format("Get Id:{0} - Name:{1}", licenseType.Id, licenseType.ToString()));
            //}
            //#endregion

            //#region Club
            //Console.WriteLine("*********** Club ************");
            //lib.bl.actions.club.doGetAll doGetAllClub = new bl.actions.club.doGetAll();
            //foreach (model.Club licenseType in doGetAllClub.execute(cache))
            //{
            //    Console.WriteLine(string.Format("Get Id:{0} - Name:{1}", licenseType.Id, licenseType.ToString()));
            //}
            //#endregion

            //#region Team
            //Console.WriteLine("*********** Team ************");
            //lib.bl.actions.team.doGetAll doGetAllTeam = new bl.actions.team.doGetAll();
            //foreach (model.Team licenseType in doGetAllTeam.execute(cache))
            //{
            //    Console.WriteLine(string.Format("Get Id:{0} - Name:{1}", licenseType.Id, licenseType.ToString()));
            //}
            //#endregion

            ShowWaitingPrompt();
        }

        private static void RemoveAll(bool keepEven)
        {
            cache.ClearDB();
            ShowWaitingPrompt();
        }
        
        private static void ShowWaitingPrompt()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        private static void CreateRealExample()
        {
            lib.bl.actions.stadium.doSave doSaveStadium = null;
            model.Stadium stadium = null;

            lib.bl.actions.federation.doSave doSaveFederation = null;
            model.Federation federation = null;

            lib.bl.actions.club.doSave doSaveClub = null;
            model.Club club = null;

            lib.bl.actions.team.doSave doSaveTeam = null;
            model.Team team = null;

            lib.bl.actions.licensetype.doGetByInternalId doGetLicenseType = null;

            lib.bl.actions.license.doSave doSaveLicense = null;
            model.License license = null;


            #region Stadiums

            stadium = new model.Stadium();
            stadium.Id = cache.GetNewId();
            stadium.Name = "Acea da Ma";
            stadium.Address = new model.Address();
            stadium.Address.Id = cache.GetNewId();
            stadium.Address.City = "O Burgo";
            stadium.Address.Country = "España";
            stadium.Address.State = "Galicia";
            stadium.Address.Street = "Haceadama";
            stadium.Address.ZipCode = "12345";
            doSaveStadium = new bl.actions.stadium.doSave(stadium);
            doSaveStadium.execute(cache);
            //Console.WriteLine(stadium.ToString());
            //Console.WriteLine(stadium.Address.ToString());

            stadium = new model.Stadium();
            stadium.Name = "Estadio Lugo";
            stadium.Address = new model.Address();
            stadium.Address.Id = cache.GetNewId();
            stadium.Address.City = "Lugo";
            stadium.Address.Country = "España";
            stadium.Address.State = "Galicia";
            stadium.Address.Street = "lucense";
            stadium.Address.ZipCode = "54321";
            doSaveStadium = new bl.actions.stadium.doSave(stadium);
            doSaveStadium.execute(cache);
            //Console.WriteLine(stadium.ToString());
            //Console.WriteLine(stadium.Address.ToString());
            
            #endregion
            
            #region Federations

            federation = new model.Federation();
            federation.Id = cache.GetNewId();
            federation.Name = "Federación Gallega de Baseball y Softball";
            federation.Address = new model.Address();
            federation.Address.Id = cache.GetNewId();
            federation.Address.City = "A Coruña";
            federation.Address.Country = "España";
            federation.Address.State = "Galicia";
            federation.Address.Street = "Elviña 2da Fase, Suite 114";
            federation.Address.ZipCode = "15005";
            doSaveFederation = new bl.actions.federation.doSave(federation);
            doSaveFederation.execute(cache);
            //Console.WriteLine(federation.ToString());
            //Console.WriteLine(federation.Address.ToString());

            #region Clubs

            //Type Federativos
            club = new model.Club();
            club.Id = cache.GetNewId();
            club.Name = "Federativos";
            club.Address = new model.Address();
            club.Address.Id = cache.GetNewId();
            club.Address.City = "";
            club.Address.Country = "España";
            club.Address.State = "";
            club.Address.Street = "";
            club.Address.ZipCode = "";
            doSaveClub = new bl.actions.club.doSave(club);
            doSaveClub.execute(cache);
            //Console.WriteLine(club.ToString());
            //Console.WriteLine(club.Address.ToString());

            team = new model.Team();
            team.Id = cache.GetNewId();
            team.ClubId = club.Id;
            team.FederationId = federation.Id;
            team.Name = "Arbitros";
            doGetLicenseType = new bl.actions.licensetype.doGetByInternalId(common.enums.LicenseType.Umpire);
            team.LicenseTypeId = doGetLicenseType.execute(cache).Id;
            doSaveTeam = new bl.actions.team.doSave(team);
            doSaveTeam.execute(cache);
            //Console.WriteLine(team.ToString());

            license = new model.License();
            license.Id = cache.GetNewId();
            license.Date = DateTime.Now;
            license.TeamId = team.Id;
            license.FederationId = federation.Id;
            license.LicenseTypeId = team.LicenseTypeId;
            license.Person = new model.Person();
            license.Person.Id = cache.GetNewId();
            license.Person.FirstName = "Rafael";
            license.Person.LastName = "Nion";
            license.Person.Address = new model.Address();
            license.Person.Address.Id = cache.GetNewId();
            license.Person.Address.State = federation.Address.State;
            license.Person.Address.Street = "";
            license.Person.Address.ZipCode = "";
            license.Person.Address.City = federation.Address.City;
            license.Person.Address.Country = federation.Address.Country;
            doSaveLicense = new bl.actions.license.doSave(license);
            doSaveLicense.execute(cache);
            //Console.WriteLine(license.ToString());
            //Console.WriteLine(license.Person.ToString());

            license = new model.License();
            license.Id = cache.GetNewId();
            license.Date = DateTime.Now;
            license.TeamId = team.Id;
            license.FederationId = federation.Id;
            license.LicenseTypeId = team.LicenseTypeId;
            license.Person = new model.Person();
            license.Person.Id = cache.GetNewId();
            license.Person.FirstName = "Amaury";
            license.Person.LastName = "Cubano";
            license.Person.Address = new model.Address();
            license.Person.Address.Id = cache.GetNewId();
            license.Person.Address.State = federation.Address.State;
            license.Person.Address.Street = "";
            license.Person.Address.ZipCode = "";
            license.Person.Address.City = federation.Address.City;
            license.Person.Address.Country = federation.Address.Country;
            doSaveLicense = new bl.actions.license.doSave(license);
            doSaveLicense.execute(cache);
            //Console.WriteLine(license.ToString());
            //Console.WriteLine(license.Person.ToString());


            team = new model.Team();
            team.Id = cache.GetNewId();
            team.ClubId = club.Id;
            team.FederationId = federation.Id;
            team.Name = "Anotadores";
            doGetLicenseType = new bl.actions.licensetype.doGetByInternalId(common.enums.LicenseType.ScoreTaker);
            team.LicenseTypeId = doGetLicenseType.execute(cache).Id;
            doSaveTeam = new bl.actions.team.doSave(team);
            doSaveTeam.execute(cache);
            //Console.WriteLine(team.ToString());

            license = new model.License();
            license.Id = cache.GetNewId();
            license.Date = DateTime.Now;
            license.TeamId = team.Id;
            license.FederationId = federation.Id;
            license.LicenseTypeId = team.LicenseTypeId;
            license.Person = new model.Person();
            license.Person.Id = cache.GetNewId();
            license.Person.FirstName = "Cristina";
            license.Person.LastName = "Ramos";
            license.Person.Address = new model.Address();
            license.Person.Address.Id = cache.GetNewId();
            license.Person.Address.State = federation.Address.State;
            license.Person.Address.Street = "";
            license.Person.Address.ZipCode = "";
            license.Person.Address.City = federation.Address.City;
            license.Person.Address.Country = federation.Address.Country;
            doSaveLicense = new bl.actions.license.doSave(license);
            doSaveLicense.execute(cache);
            //Console.WriteLine(license.ToString());
            //Console.WriteLine(license.Person.ToString());
            
            license = new model.License();
            license.Id = cache.GetNewId();
            license.Date = DateTime.Now;
            license.TeamId = team.Id;
            license.FederationId = federation.Id;
            license.LicenseTypeId = team.LicenseTypeId;
            license.Person = new model.Person();
            license.Person.Id = cache.GetNewId();
            license.Person.FirstName = "Joel";
            license.Person.LastName = "Castro";
            license.Person.Address = new model.Address();
            license.Person.Address.Id = cache.GetNewId();
            license.Person.Address.State = federation.Address.State;
            license.Person.Address.Street = "";
            license.Person.Address.ZipCode = "";
            license.Person.Address.City = federation.Address.City;
            license.Person.Address.Country = federation.Address.Country;
            doSaveLicense = new bl.actions.license.doSave(license);
            doSaveLicense.execute(cache);
            //Console.WriteLine(license.ToString());
            //Console.WriteLine(license.Person.ToString());

            //Type Players
            club = new model.Club();
            club.Id = cache.GetNewId();
            club.Name = "Club de Baseball Karbo";
            club.Address = new model.Address();
            club.Address.Id = cache.GetNewId();
            club.Address.City = "A Coruña";
            club.Address.Country = "España";
            club.Address.State = "Galicia";
            club.Address.Street = "Calle Europa 117, 3er Piso";
            club.Address.ZipCode = "15001";
            doSaveClub = new bl.actions.club.doSave(club);
            doSaveClub.execute(cache);
            //Console.WriteLine(club.ToString());
            //Console.WriteLine(club.Address.ToString());

            team = new model.Team();
            team.Id = cache.GetNewId();
            team.ClubId = club.Id;
            team.FederationId = federation.Id;
            team.Name = "Karbo";
            doGetLicenseType = new bl.actions.licensetype.doGetByInternalId(common.enums.LicenseType.Player);
            team.LicenseTypeId = doGetLicenseType.execute(cache).Id;
            doSaveTeam = new bl.actions.team.doSave(team);
            doSaveTeam.execute(cache);
            //Console.WriteLine(team.ToString());

            for (int i = 0; i < 15; i++)
            {
                license = CreateRandomPlayerLicense(team, federation);
                doSaveLicense = new bl.actions.license.doSave(license);
                doSaveLicense.execute(cache);
                //Console.WriteLine(license.ToString());
                //Console.WriteLine(license.Person.ToString());
            }

            club = new model.Club();
            club.Id = cache.GetNewId();
            club.Name = "Club Baseball Cambre";
            club.Address = new model.Address();
            club.Address.Id = cache.GetNewId();
            club.Address.City = "Cambre";
            club.Address.Country = "España";
            club.Address.State = "Galicia";
            club.Address.Street = "Calle LejosLejos 1234";
            club.Address.ZipCode = "43214";
            doSaveClub = new bl.actions.club.doSave(club);
            doSaveClub.execute(cache);
            //Console.WriteLine(club.ToString());
            //Console.WriteLine(club.Address.ToString());

            team = new model.Team();
            team.Id = cache.GetNewId();
            team.ClubId = club.Id;
            team.FederationId = federation.Id;
            team.Name = "Baseball Cambre";
            doGetLicenseType = new bl.actions.licensetype.doGetByInternalId(common.enums.LicenseType.Player);
            team.LicenseTypeId = doGetLicenseType.execute(cache).Id;
            doSaveTeam = new bl.actions.team.doSave(team);
            doSaveTeam.execute(cache);
            //Console.WriteLine(team.ToString());

            for (int i = 0; i < 15; i++)
            {
                license = CreateRandomPlayerLicense(team, federation);
                doSaveLicense = new bl.actions.license.doSave(license);
                doSaveLicense.execute(cache);
                //Console.WriteLine(license.ToString());
                //Console.WriteLine(license.Person.ToString());
            }

            club = new model.Club();
            club.Id = cache.GetNewId();
            club.Name = "Halcones Baseball Club";
            club.Address = new model.Address();
            club.Address.Id = cache.GetNewId();
            club.Address.City = "Vigo";
            club.Address.Country = "España";
            club.Address.State = "Galicia";
            club.Address.Street = "Calle EnVigo 23, 1er Piso";
            club.Address.ZipCode = "87654";
            doSaveClub = new bl.actions.club.doSave(club);
            doSaveClub.execute(cache);
            //Console.WriteLine(club.ToString());
            //Console.WriteLine(club.Address.ToString());

            team = new model.Team();
            team.Id = cache.GetNewId();
            team.ClubId = club.Id;
            team.FederationId = federation.Id;
            team.Name = "Halcones";
            doGetLicenseType = new bl.actions.licensetype.doGetByInternalId(common.enums.LicenseType.Player);
            team.LicenseTypeId = doGetLicenseType.execute(cache).Id;
            doSaveTeam = new bl.actions.team.doSave(team);
            doSaveTeam.execute(cache);
            //Console.WriteLine(team.ToString());

            for (int i = 0; i < 15; i++)
            {
                license = CreateRandomPlayerLicense(team, federation);
                doSaveLicense = new bl.actions.license.doSave(license);
                doSaveLicense.execute(cache);
                //Console.WriteLine(license.ToString());
                //Console.WriteLine(license.Person.ToString());
            }

            #endregion

            federation = new model.Federation();
            federation.Id = cache.GetNewId();
            federation.Name = "Federación Asturiana de Baseball y Softball";
            federation.Address = new model.Address();
            federation.Address.Id = cache.GetNewId();
            federation.Address.City = "Gijón";
            federation.Address.Country = "España";
            federation.Address.State = "Asturias";
            federation.Address.Street = "El Llano 123, 2do Derecho";
            federation.Address.ZipCode = "23067";
            doSaveFederation = new bl.actions.federation.doSave(federation);
            doSaveFederation.execute(cache);
            //Console.WriteLine(federation.ToString());
            //Console.WriteLine(federation.Address.ToString());

            #region Clubs

            club = new model.Club();
            club.Id = cache.GetNewId();
            club.Name = "El Llano Club de Baseball";
            club.Address = new model.Address();
            club.Address.Id = cache.GetNewId();
            club.Address.City = "Gijon";
            club.Address.Country = "España";
            club.Address.State = "Asturias";
            club.Address.Street = "Calle llana";
            club.Address.ZipCode = "23067";
            doSaveClub = new bl.actions.club.doSave(club);
            doSaveClub.execute(cache);
            //Console.WriteLine(club.ToString());
            //Console.WriteLine(club.Address.ToString());

            team = new model.Team();
            team.Id = cache.GetNewId();
            team.ClubId = club.Id;
            team.FederationId = federation.Id;
            team.Name = "El Llano";
            doGetLicenseType = new bl.actions.licensetype.doGetByInternalId(common.enums.LicenseType.Player);
            team.LicenseTypeId = doGetLicenseType.execute(cache).Id;
            doSaveTeam = new bl.actions.team.doSave(team);
            doSaveTeam.execute(cache);
            //Console.WriteLine(team.ToString());

            for (int i = 0; i < 15; i++)
            {
                license = CreateRandomPlayerLicense(team, federation);
                doSaveLicense = new bl.actions.license.doSave(license);
                doSaveLicense.execute(cache);
                //Console.WriteLine(license.ToString());
                //Console.WriteLine(license.Person.ToString());
            }


            club = new model.Club();
            club.Id = cache.GetNewId();
            club.Name = "Otro Equipo Asturiano";
            club.Address = new model.Address();
            club.Address.Id = cache.GetNewId();
            club.Address.City = "Oviedo";
            club.Address.Country = "España";
            club.Address.State = "Asturias";
            club.Address.Street = "Calle meseta";
            club.Address.ZipCode = "23067";
            doSaveClub = new bl.actions.club.doSave(club);
            doSaveClub.execute(cache);
            //Console.WriteLine(club.ToString());
            //Console.WriteLine(club.Address.ToString());

            team = new model.Team();
            team.Id = cache.GetNewId();
            team.ClubId = club.Id;
            team.FederationId = federation.Id;
            team.Name = "Otro Llano";
            doGetLicenseType = new bl.actions.licensetype.doGetByInternalId(common.enums.LicenseType.Player);
            team.LicenseTypeId = doGetLicenseType.execute(cache).Id;
            doSaveTeam = new bl.actions.team.doSave(team);
            doSaveTeam.execute(cache);
            //Console.WriteLine(team.ToString());

            for (int i = 0; i < 15; i++)
            {
                license = CreateRandomPlayerLicense(team, federation);
                doSaveLicense = new bl.actions.license.doSave(license);
                doSaveLicense.execute(cache);
                //Console.WriteLine(license.ToString());
                //Console.WriteLine(license.Person.ToString());
            }

            #endregion
            
            #endregion

            #region Championships
            lib.bl.actions.championship.doGenerateMatchs doGenerateMatchs = null;
            List<model.Match> Matches = null;

            lib.bl.actions.championship.doSave doSaveChampionship = null;
            model.Championship championship = null;

            lib.bl.actions.championshiptype.doGetByInternalId doGetChampionshipType = null;
            model.ChampionshipType championshiptype = null;

            lib.bl.actions.federation.doGetAll doGetAllFederations = new bl.actions.federation.doGetAll();
            List<model.Federation> Federations = doGetAllFederations.execute(cache);

            lib.bl.actions.team.doGetAll doGetAllTeams = null;
            int federationindex;
            List<model.Team> Teams;
            Random random = new Random(DateTime.Now.Millisecond);

            championship = new model.Championship();
            championship.Id = cache.GetNewId();
            doGetChampionshipType = new bl.actions.championshiptype.doGetByInternalId(common.enums.ChampionshipType.Tournament);
            championshiptype = doGetChampionshipType.execute(cache);
            championship.ChampionshipTypeId = championshiptype.Id;
            championship.Name = string.Format("{0} {1}", championshiptype.ToString(), random.Next(9));

            federationindex = random.Next(Federations.Count - 1);
            federationindex = 0;
            championship.ChampionshipOrganizers.Add
                (
                    new model.ChampionshipOrganizer()
                    {
                        ChampionshipId = championship.Id,
                        FederationId = Federations[federationindex].Id
                    }
                );

            doGetAllTeams = new bl.actions.team.doGetAll(Federations[federationindex], common.enums.LicenseType.Player);
            Teams = doGetAllTeams.execute(cache);
            foreach (model.Team item in Teams)
            {
                championship.ChampionshipTeams.Add(new model.ChampionshipTeam() { ChampionshipId = championship.Id, TeamId = item.Id  }); 
            }

            doSaveChampionship = new bl.actions.championship.doSave(championship);
            doSaveChampionship.execute(cache);
            Console.WriteLine(championship.ToString());

            doGenerateMatchs = new bl.actions.championship.doGenerateMatchs(championship, DateTime.Now);
            Matches = doGenerateMatchs.execute(cache);
            foreach (model.Match item in Matches)
            {
                Console.WriteLine(string.Format("Match {0} vs {1}", item.HomeClubId, item.GuestClubId));
            }
            ShowWaitingPrompt();

            championship = new model.Championship();
            championship.Id = cache.GetNewId();
            doGetChampionshipType = new bl.actions.championshiptype.doGetByInternalId(common.enums.ChampionshipType.League);
            championshiptype = doGetChampionshipType.execute(cache);
            championship.ChampionshipTypeId = championshiptype.Id;
            championship.Name = string.Format("{0} {1}", championshiptype.ToString(), random.Next(9));

            federationindex = random.Next(Federations.Count - 1);
            federationindex = 1;
            championship.ChampionshipOrganizers.Add
                (
                    new model.ChampionshipOrganizer()
                    {
                        ChampionshipId = championship.Id,
                        FederationId = Federations[federationindex].Id
                    }
                );

            doGetAllTeams = new bl.actions.team.doGetAll(Federations[federationindex], common.enums.LicenseType.Player);
            Teams = doGetAllTeams.execute(cache);
            foreach (model.Team item in Teams)
            {
                championship.ChampionshipTeams.Add(new model.ChampionshipTeam() { ChampionshipId = championship.Id, TeamId = item.Id });
            }

            doSaveChampionship = new bl.actions.championship.doSave(championship);
            doSaveChampionship.execute(cache);
            Console.WriteLine(championship.ToString());


            doGenerateMatchs = new bl.actions.championship.doGenerateMatchs(championship, DateTime.Now);
            Matches = doGenerateMatchs.execute(cache);
            foreach (model.Match item in Matches)
            {
                Console.WriteLine(string.Format("Match {0} vs {1}", item.HomeClubId, item.GuestClubId));
            }
            #endregion

            ShowWaitingPrompt();
        }

        private static model.License CreateRandomPlayerLicense(model.Team team, model.Federation federation)
        {
            model.License license = null;
            Random randomGenerator = new Random(DateTime.Now.Millisecond);
            int randomNumber = randomGenerator.Next(99);

            license = new model.License();
            license.Id = cache.GetNewId();
            license.Date = DateTime.Now;
            license.TeamId = team.Id;
            license.FederationId = team.FederationId;
            license.LicenseTypeId = team.LicenseTypeId;
            license.TeamId = team.Id;
            license.Person = new model.Person();
            license.Person.Id = cache.GetNewId();
            license.Person.FirstName = String.Format("Player {0:00}", randomNumber);
            license.Person.LastName = team.Name;
            license.Person.Address = new model.Address();
            license.Person.Address.Id = cache.GetNewId();
            license.Person.Address.State = federation.Address.State;
            license.Person.Address.Street = "";
            license.Person.Address.ZipCode = "";
            license.Person.Address.City = federation.Address.City;
            license.Person.Address.Country = federation.Address.Country;

            return license;
        }
    }
}
