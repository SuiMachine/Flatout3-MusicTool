using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSTDictionary
{
    public class OSTs
    {
        public Dictionary<string, FileInfo> Flatout1 = new Dictionary<string, FileInfo>();
        public Dictionary<string, FileInfo> Flatout2 = new Dictionary<string, FileInfo>();
        public Dictionary<string, FileInfo> Flatout3 = new Dictionary<string, FileInfo>();

        public List<string> Flatout1List = new List<string>();
        public List<string> Flatout2List = new List<string>();
        public List<string> Flatout3List = new List<string>();

        public List<string> MenuMusic = new List<string>();
        public List<string> SuiMenuMusic = new List<string>();
        public List<string> InGameMusic = new List<string>();
        public List<string> SuiInGameMusic = new List<string>();

        public List<FileInfo> UserPicksMenu = new List<FileInfo>();
        public List<FileInfo> UserPicksRace = new List<FileInfo>();
        public List<FileInfo> UserPicksStunt = new List<FileInfo>();

        public OSTs()
        {
            //I probably should have add this when initializing, but I didn't, so here you go
            //CheatRegex - , new FileInfo\(\"(\w|\s|\d)+\", \"(\w|\s|\d)+"\)
            #region Flatout1
            Flatout1.Add("04_Flat.ogg", new FileInfo("Central Supply chain", "FlatOut"));
            Flatout1.Add("01_Adren.ogg", new FileInfo("Adrenaline", "Adrenaline"));
            Flatout1.Add("18_Amp1.ogg", new FileInfo("Amplifire", "Drown Together"));
            Flatout1.Add("13_Subro.ogg", new FileInfo("Subroc", "Close The Windows"));
            Flatout1.Add("03_Ready.ogg", new FileInfo("Central Supply Chain", "Are you ready"));
            Flatout1.Add("17_Full2.ogg", new FileInfo("Full Diesel", "No Man\'s Land"));
            Flatout1.Add("09_Burni.ogg", new FileInfo("No Connection", "Burnin\'"));
            Flatout1.Add("14_Whit.ogg", new FileInfo("Whitmore", "Nine Bar Blues"));
            Flatout1.Add("02_Dead.ogg", new FileInfo("Adrenaline", "Dead Inside"));
            Flatout1.Add("19_Amp2.ogg", new FileInfo("Amplifire", "Heartless"));
            Flatout1.Add("15_April.ogg", new FileInfo("The April Tears", "Little Baby Is Coming"));
            Flatout1.Add("23_hiss.ogg", new FileInfo("The Hiss", "Back On The Radio"));
            Flatout1.Add("06_Alive.ogg", new FileInfo("Circa", "Alive!"));
            Flatout1.Add("11_LTHTL.ogg", new FileInfo("No Connection", "Love To Hate To Love"));
            Flatout1.Add("16_Full1.ogg", new FileInfo("Full Diesel", "King of Defeat"));
            Flatout1.Add("08_Tick.ogg", new FileInfo("Deponeye", "Tick Tock"));
            Flatout1.Add("10_Ameri.ogg", new FileInfo("No Connection", "Living American"));
            Flatout1.Add("22_lab.ogg", new FileInfo("LAB", "Beat The Boys"));
            Flatout1.Add("20_Amp3.ogg", new FileInfo("Amplifire", "Perfect Goodbyes"));
            Flatout1.Add("27_barb2.ogg", new FileInfo("Killer Barbies", "Down The Street"));
            Flatout1.Add("05_Ever.ogg", new FileInfo("Central Supply Chain", "The Ever Lasting"));
            Flatout1.Add("07_Anger.ogg", new FileInfo("Deponeye", "Anger Management 101"));
            Flatout1.Add("21_Splat.ogg", new FileInfo("Splatterheads", "Fish Biscuit"));
            Flatout1.Add("24_blue.ogg", new FileInfo("Agent Blue", "Something Else"));
            Flatout1.Add("25_kid.ogg", new FileInfo("Kid Symphony", "Hands On The Money"));
            Flatout1.Add("26_barb1.ogg", new FileInfo("Killer Barbies", "Baby With Two Head"));
            Flatout1.Add("28_tokyo.ogg", new FileInfo("Tokyo Dragons", "Teenage Screamers"));

            foreach (string element in Flatout1.Keys)
                Flatout1List.Add("data/music/flatout1/" + element);
            #endregion
            #region Flatout2
            Flatout2.Add("01.ogg", new FileInfo("The Chelsea Smiles", "Nowhere Ride"));
            Flatout2.Add("02.ogg", new FileInfo("Alkaline Trio", "Fall Victim"));
            Flatout2.Add("03.ogg", new FileInfo("Papa Roach", "Blood Brothers"));
            Flatout2.Add("04.ogg", new FileInfo("Supergrass", "Road To Rouen"));
            Flatout2.Add("05.ogg", new FileInfo("Alkaline Trio", "Mercy Me"));
            Flatout2.Add("06.ogg", new FileInfo("Nickelback", "Believe It or Not"));
            Flatout2.Add("07.ogg", new FileInfo("Megadeth", "Symphony of Destruction"));
            Flatout2.Add("08.ogg", new FileInfo("Yellowcard", "Rough Landing Holly"));
            Flatout2.Add("09.ogg", new FileInfo("Yellowcard", "Breathing"));
            Flatout2.Add("10.ogg", new FileInfo("Zebrahead", "Lobotomy for Dummies"));
            Flatout2.Add("11.ogg", new FileInfo("Rise Against", "Give It All"));
            //12 is missing
            Flatout2.Add("13.ogg", new FileInfo("Papa Roach", "Not Listening"));
            Flatout2.Add("14.ogg", new FileInfo("Underoath", "Reinventing Your Exit"));
            Flatout2.Add("15.ogg", new FileInfo("Fall Out Boy", "7 Minutes In Heaven"));
            Flatout2.Add("16.ogg", new FileInfo("Supergrass", "Richard III"));
            Flatout2.Add("17.ogg", new FileInfo("Nickelback", "Flat On the Floor"));
            Flatout2.Add("18.ogg", new FileInfo("Rob Zombie", "Feel So Numb"));
            Flatout2.Add("19.ogg", new FileInfo("Rob Zombie", "Demon Speeding"));
            Flatout2.Add("20.ogg", new FileInfo("Wolfmother", "Pyramid"));
            Flatout2.Add("21.ogg", new FileInfo("Wolfmother", "Dimension"));
            Flatout2.Add("22.ogg", new FileInfo("Fall Out Boy", "Snitches, and Talkers Get..."));
            //23 is missing
            Flatout2.Add("24.ogg", new FileInfo("The Vines", "Don't Listen To The Radio"));
            //Tracks 25-34 are played in stunt mode and they have radio filter added on top
            Flatout2.Add("35.ogg", new FileInfo("Audioslave", "Man Or Animal"));
            Flatout2.Add("36.ogg", new FileInfo("Audioslave", "Your Time Has Come"));

            foreach (string element in Flatout2.Keys)
                Flatout2List.Add("data/music/flatout2/" + element);
            #endregion
            #region Flatout3
            Flatout3.Add("32Leaves_Waiting.ogg", new FileInfo("32 Leaves", "Waiting"));
            Flatout3.Add("ArtOfDying_YouDontKnowMe.ogg", new FileInfo("Art Of Dying", "You Don't Know Me"));
            Flatout3.Add("AStaticLullaby_HangEmHigh.ogg", new FileInfo("A Static Lullaby", "Hang'Em High"));
            Flatout3.Add("DeadPoetic_Narcotic.ogg", new FileInfo("Dead Poetic", "Narcotic"));
            Flatout3.Add("EverythingAtOnce_BoysOnTheHill.ogg", new FileInfo("Everything At Once", "Boys On The Hill"));
            Flatout3.Add("Hypnogaja_TheyDontCareClean.ogg", new FileInfo("Hypnogaja", "They Don't Care"));
            Flatout3.Add("Kazzer_FueledByAdrenaline.ogg", new FileInfo("Kazzer", "Fueled By Adrenaline"));
            Flatout3.Add("LunaHalo_ImAlright.ogg", new FileInfo("Luna Halo", "I'm Alright"));
            Flatout3.Add("Manafest_WannaKnowYou.ogg", new FileInfo("Manafest", "Wanna Know You"));
            Flatout3.Add("NoConnection_FeedTheMachine.ogg", new FileInfo("No Connection", "Feed The Machine"));
            Flatout3.Add("NoConnection_TheLastRevolution.ogg", new FileInfo("No Connection", "The Last Revolution"));
            Flatout3.Add("Opshop_NothingCanWait.ogg", new FileInfo("Opshop", "Nothing Can Wait"));
            Flatout3.Add("PointDefiance_UnionOfNothing.ogg", new FileInfo("Point Defiance", "Union of Nothing"));
            Flatout3.Add("RiverboatGamblers_TrueCrime.ogg", new FileInfo("The Riverboat Gamblers", "True Crime"));
            Flatout3.Add("Sasquatch_BelieveIt.ogg", new FileInfo("Sasquatch", "Believe It"));
            Flatout3.Add("Supermercado_DitchKitty.ogg", new FileInfo("Supermercado", "Ditch Kitty"));
            Flatout3.Add("TheClassicCrime_BlistersAndCoffee.ogg", new FileInfo("The Classic Crime", "Blisters and Coffee"));
            Flatout3.Add("TheSleeping_ListenClose.ogg", new FileInfo("The Sleeping", "Listen Close"));
            Flatout3.Add("TheWhiteHeat_ThisIsMyLife.ogg", new FileInfo("The White Heat", "This Is My Life"));
            Flatout3.Add("ThisIsMenace_CoverGirlMonument.ogg", new FileInfo("This Is Menace", "Cover Girl Monument"));
            foreach (string element in Flatout3.Keys)
                Flatout3List.Add("data/music/" + element);
            #endregion
            
            #region MenuMusic
            //Flatout 1
            MenuMusic.Add("data/music/flatout1/04_Flat.ogg");
            MenuMusic.Add("data/music/flatout1/03_Ready.ogg");
            MenuMusic.Add("data/music/flatout1/15_April.ogg");
            MenuMusic.Add("data/music/flatout1/05_Ever.ogg");

            //Flatout 2
            MenuMusic.Add("data/music/flatout2/04.ogg");
            MenuMusic.Add("data/music/flatout2/06.ogg");
            MenuMusic.Add("data/music/flatout2/07.ogg");
            MenuMusic.Add("data/music/flatout2/14.ogg");
            MenuMusic.Add("data/music/flatout2/24.ogg");

            //Flatout 3
            MenuMusic.Add("data/Music/32Leaves_Waiting.ogg");
            MenuMusic.Add("data/Music/EverythingAtOnce_BoysOnTheHill.ogg");
            MenuMusic.Add("data/Music/Hypnogaja_TheyDontCareClean.ogg");
            MenuMusic.Add("data/Music/Opshop_NothingCanWait.ogg");
            MenuMusic.Add("data/Music/PointDefiance_UnionOfNothing.ogg");
            #endregion
            #region InGameMusic
            //Flatout 1
            InGameMusic.Add("data/music/flatout1/01_Adren.ogg");
            InGameMusic.Add("data/music/flatout1/18_Amp1.ogg");
            InGameMusic.Add("data/music/flatout1/13_Subro.ogg");
            InGameMusic.Add("data/music/flatout1/03_Ready.ogg");
            InGameMusic.Add("data/music/flatout1/17_Full2.ogg");
            InGameMusic.Add("data/music/flatout1/09_Burni.ogg");
            InGameMusic.Add("data/music/flatout1/14_Whit.ogg");
            InGameMusic.Add("data/music/flatout1/02_Dead.ogg");
            InGameMusic.Add("data/music/flatout1/19_Amp2.ogg");
            InGameMusic.Add("data/music/flatout1/15_April.ogg");
            InGameMusic.Add("data/music/flatout1/23_hiss.ogg");
            InGameMusic.Add("data/music/flatout1/06_Alive.ogg");
            InGameMusic.Add("data/music/flatout1/11_LTHTL.ogg");
            InGameMusic.Add("data/music/flatout1/16_Full1.ogg");
            InGameMusic.Add("data/music/flatout1/08_Tick.ogg");
            InGameMusic.Add("data/music/flatout1/10_Ameri.ogg");
            InGameMusic.Add("data/music/flatout1/22_lab.ogg");
            InGameMusic.Add("data/music/flatout1/20_Amp3.ogg");
            InGameMusic.Add("data/music/flatout1/27_barb2.ogg");
            InGameMusic.Add("data/music/flatout1/05_Ever.ogg");
            InGameMusic.Add("data/music/flatout1/07_Anger.ogg");
            InGameMusic.Add("data/music/flatout1/21_Splat.ogg");
            InGameMusic.Add("data/music/flatout1/24_blue.ogg");
            InGameMusic.Add("data/music/flatout1/25_kid.ogg");
            InGameMusic.Add("data/music/flatout1/26_barb1.ogg");
            InGameMusic.Add("data/music/flatout1/28_tokyo.ogg");

            //Flatout 2
            InGameMusic.Add("data/music/flatout2/01.ogg");
            InGameMusic.Add("data/music/flatout2/02.ogg");
            InGameMusic.Add("data/music/flatout2/03.ogg");
            InGameMusic.Add("data/music/flatout2/05.ogg");
            InGameMusic.Add("data/music/flatout2/06.ogg");
            InGameMusic.Add("data/music/flatout2/07.ogg");
            InGameMusic.Add("data/music/flatout2/08.ogg");
            InGameMusic.Add("data/music/flatout2/09.ogg");
            InGameMusic.Add("data/music/flatout2/10.ogg");
            InGameMusic.Add("data/music/flatout2/11.ogg");
            InGameMusic.Add("data/music/flatout2/13.ogg");
            InGameMusic.Add("data/music/flatout2/14.ogg");
            InGameMusic.Add("data/music/flatout2/15.ogg");
            InGameMusic.Add("data/music/flatout2/16.ogg");
            InGameMusic.Add("data/music/flatout2/17.ogg");
            InGameMusic.Add("data/music/flatout2/18.ogg");
            InGameMusic.Add("data/music/flatout2/19.ogg");
            InGameMusic.Add("data/music/flatout2/20.ogg");
            InGameMusic.Add("data/music/flatout2/21.ogg");
            InGameMusic.Add("data/music/flatout2/22.ogg");
            InGameMusic.Add("data/music/flatout2/35.ogg");
            InGameMusic.Add("data/music/flatout2/36.ogg");

            //Flatout 3
            InGameMusic.Add("data/Music/ArtOfDying_YouDontKnowMe.ogg");
            InGameMusic.Add("data/Music/AStaticLullaby_HangEmHigh.ogg");
            InGameMusic.Add("data/Music/DeadPoetic_Narcotic.ogg");
            InGameMusic.Add("data/Music/Hypnogaja_TheyDontCareClean.ogg");
            InGameMusic.Add("data/Music/Kazzer_FueledByAdrenaline.ogg");
            InGameMusic.Add("data/Music/LunaHalo_ImAlright.ogg");
            InGameMusic.Add("data/Music/Manafest_WannaKnowYou.ogg");
            InGameMusic.Add("data/Music/NoConnection_FeedTheMachine.ogg");
            InGameMusic.Add("data/Music/NoConnection_TheLastRevolution.ogg");
            InGameMusic.Add("data/Music/RiverboatGamblers_TrueCrime.ogg");
            InGameMusic.Add("data/Music/Sasquatch_BelieveIt.ogg");
            InGameMusic.Add("data/Music/Supermercado_DitchKitty.ogg");
            InGameMusic.Add("data/Music/TheClassicCrime_BlistersAndCoffee.ogg");
            InGameMusic.Add("data/Music/TheSleeping_ListenClose.ogg");
            InGameMusic.Add("data/Music/TheWhiteHeat_ThisIsMyLife.ogg");
            InGameMusic.Add("data/Music/ThisIsMenace_CoverGirlMonument.ogg");
            #endregion

            #region SuiMenuMusic
            //Flatout 1
            SuiMenuMusic.Add("data/music/flatout1/04_Flat.ogg");
            SuiMenuMusic.Add("data/music/flatout1/05_Ever.ogg");

            //Flatout 2
            SuiMenuMusic.Add("data/music/flatout2/01.ogg");
            SuiMenuMusic.Add("data/music/flatout2/04.ogg");
            SuiMenuMusic.Add("data/music/flatout2/06.ogg");
            SuiMenuMusic.Add("data/music/flatout2/07.ogg");
            SuiMenuMusic.Add("data/music/flatout2/14.ogg");
            SuiMenuMusic.Add("data/music/flatout2/24.ogg");


            //Flatout 3
            SuiMenuMusic.Add("data/Music/32Leaves_Waiting.ogg");
            SuiMenuMusic.Add("data/Music/Hypnogaja_TheyDontCareClean.ogg");
            SuiMenuMusic.Add("data/Music/Opshop_NothingCanWait.ogg");
            SuiMenuMusic.Add("data/Music/PointDefiance_UnionOfNothing.ogg");
            #endregion
            #region SuiInGameMusic
            //Flatout 1
            SuiInGameMusic.Add("data/music/flatout1/18_Amp1.ogg");
            SuiInGameMusic.Add("data/music/flatout1/17_Full2.ogg");
            SuiInGameMusic.Add("data/music/flatout1/09_Burni.ogg");
            SuiInGameMusic.Add("data/music/flatout1/19_Amp2.ogg");
            SuiInGameMusic.Add("data/music/flatout1/11_LTHTL.ogg");
            SuiInGameMusic.Add("data/music/flatout1/16_Full1.ogg");
            SuiInGameMusic.Add("data/music/flatout1/10_Ameri.ogg");
            SuiInGameMusic.Add("data/music/flatout1/22_lab.ogg");
            SuiInGameMusic.Add("data/music/flatout1/20_Amp3.ogg");
            SuiInGameMusic.Add("data/music/flatout1/24_blue.ogg");

            //Flatout 2
            SuiInGameMusic.Add("data/music/flatout2/01.ogg");
            SuiInGameMusic.Add("data/music/flatout2/03.ogg");
            SuiInGameMusic.Add("data/music/flatout2/06.ogg");
            SuiInGameMusic.Add("data/music/flatout2/07.ogg");
            SuiInGameMusic.Add("data/music/flatout2/08.ogg");
            SuiInGameMusic.Add("data/music/flatout2/09.ogg");
            SuiInGameMusic.Add("data/music/flatout2/11.ogg");
            SuiInGameMusic.Add("data/music/flatout2/13.ogg");
            SuiInGameMusic.Add("data/music/flatout2/14.ogg");
            SuiInGameMusic.Add("data/music/flatout2/15.ogg");
            SuiInGameMusic.Add("data/music/flatout2/17.ogg");
            SuiInGameMusic.Add("data/music/flatout2/18.ogg");
            SuiInGameMusic.Add("data/music/flatout2/19.ogg");
            SuiInGameMusic.Add("data/music/flatout2/35.ogg");
            SuiInGameMusic.Add("data/music/flatout2/36.ogg");


            //Flatout 3
            SuiInGameMusic.Add("data/Music/Hypnogaja_TheyDontCareClean.ogg");
            SuiInGameMusic.Add("data/Music/NoConnection_TheLastRevolution.ogg");
            #endregion
        }

        internal bool checkIfContains(List<string> picks, Dictionary<string, FileInfo> soundtrackDictionary, string additionalString, string song, string artist)
        {
            if (soundtrackDictionary.Values.Any(info => info.artist == artist && info.song == song))
            {
                var dictionaryItem = soundtrackDictionary.First(pair => pair.Value.artist == artist && pair.Value.song == song);
                string key = dictionaryItem.Key.ToLower();
                if(additionalString != "")
                {
                    if (picks.Any(songOnTheList => songOnTheList.ToLower().Contains(key) && songOnTheList.ToLower().Contains(additionalString.ToLower())))
                        return true;
                    else
                        return false;
                }
                else
                {
                    if (picks.Any(songOnTheList => songOnTheList.ToLower().Contains(key) && !songOnTheList.ToLower().Contains("flatout1") && !songOnTheList.ToLower().Contains("flatout2")))
                        return true;
                    else
                        return false;
                }

            }
            else
                return false;
        }

        internal string getRelativeFilePath(string song, string artist)
        {
            song = song.ToLower();
            artist = artist.ToLower();

            foreach(KeyValuePair<string, FileInfo> element in Flatout1)
            {
                string cSong = element.Value.song.ToLower();
                string cArtist = element.Value.artist.ToLower();

                if(cSong == song && cArtist == artist)
                {
                    return "data/music/flatout1/" + element.Key;
                }
            }

            foreach (KeyValuePair<string, FileInfo> element in Flatout2)
            {
                string cSong = element.Value.song.ToLower();
                string cArtist = element.Value.artist.ToLower();

                if (cSong == song && cArtist == artist)
                {
                    return "data/music/flatout2/" + element.Key;
                }
            }

            foreach (KeyValuePair<string, FileInfo> element in Flatout3)
            {
                string cSong = element.Value.song.ToLower();
                string cArtist = element.Value.artist.ToLower();

                if (cSong == song && cArtist == artist)
                {
                    return "data/music/" + element.Key;
                }
            }

            return "";
        }
    }

    public class FileInfo
    {
        public string artist { get; set; }
        public string song { get; set; }


        public FileInfo(string artist, string song)
        {
            this.artist = artist;
            this.song = song;
        }
    }
}
