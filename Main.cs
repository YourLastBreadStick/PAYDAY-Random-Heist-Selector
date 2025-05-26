using System.DirectoryServices.ActiveDirectory;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace PaydayFranchiseRandomHeistSelecter
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        List<string> OldAvailablity = [];
        List<string> CurrentAvailability = [];
        int previousHeist = -1;
        string previousHeistName;
        Random random = new();
        int numRowsHeist = 8;
        int numRowsCon = 4;
        int numRowsMethod = 1;
        int sortMethod = 0;
        int theme = 1;

        //pocket wikis
        string[] PD2n3MethodOrderInfo =
        {
            "Loud",
            "Hybrid",
            "Stealth"
        };
        string[] PDTHHeistReleaseOrder =
        {
            "First World Bank",
            "Heat Street",
            "Panic Room",
            "Green Bridge",
            "Diamond Heist",
            "Slaughterhouse",
            "Counterfeit",
            "Undercover",
            "No Mercy"
        };
        string[] PD2ContractorReleaseOrder =
        {
            "Vlad",
            "Bain",
            "Hector",
            "Event",
            "The Elephant",
            "The Dentist",
            "The Butcher",
            "Classic",
            "Locke",
            "Jimmy",
            "Hoxton",
            "The Continental",
            "Jiu Feng",
            "Shayu",
            "Gemma McShay",
            "Blaine Keegan"
        };
        string[] PD2HeistReleaseOrder =
        {
            "Four Stores",
            "Jewelry Store",
            "Ukrainian Job",
            "Mallcrasher",
            "Bank Heist: Cash",
            "Bank Heist: Deposit",
            "Bank Heist: Gold",
            "Bank Heist: Random",
            "Nightclub",
            "Watchdogs",
            "Firestarters",
            "Big Oil",
            "Framing Frame",
            "Rats",
            "Diamond Store",
            "Safe House Nightmare",
            "Transport: Crossroads",
            "Transport: Downtown",
            "Transport: Harbor",
            "Transport: Park",
            "Transport: Underpass",
            "Transport: Train Heist",
            "GO Bank",
            "Election Day",
            "Shadow Raid",
            "The Big Bank",
            "Hotline Miami",
            "Art Gallery",
            "Hoxton Breakout",
            "White Xmas",
            "The Diamond",
            "The Bomb: Dockyard",
            "The Bomb: Forest",
            "Cook Off",
            "Car Shop",
            "Hoxton Revenge",
            "Meltdown",
            "The Alesso Heist",
            "Golden Grin Casino",
            "Aftershock",
            "First World Bank",
            "Slaughterhouse",
            "Lab Rats",
            "Beneath the Mountain",
            "Birth of Sky",
            "Santa's Workshop",
            "Goat Simulator",
            "Counterfeit",
            "Undercover",
            "Murky Station",
            "Boiling Point",
            "The Biker Heist",
            "Safe House Raid",
            "Panic Room",
            "Prison Nightmare",
            "Stealing Xmas",
            "Scarface Mansion",
            "Brooklyn 10-10",
            "The Yacht Heist",
            "Heat Street",
            "Green Bridge",
            "Alaskan Deal",
            "Diamond Heist",
            "Cursed Kill Room",
            "Reservoir Dogs Heist",
            "Brooklyn Bank",
            "Breakin' Feds",
            "Henry's Rock",
            "Shacklethorne Auction",
            "Hell's Island",
            "No Mercy",
            "The White House",
            "Border Crossing",
            "Border Crystals",
            "San Martín Bank",
            "Breakfast In Tijuana",
            "Buluc's Mansion",
            "Dragon Heist",
            "The Ukrainian Prisoner",
            "Black Cat",
            "Mountain Master",
            "Midland Ranch",
            "Lost In Transit",
            "Hostile Takeover",
            "Crude Awakening"
        };
        string[] PD3ContractorReleaseOrder =
        {
            "Shade",
            "Shayu",
            "The Butcher",
            "Vlad",
            "Beckett",
            "Mac",
            "Blaine Keegan",
            "Locke"
        };
        string[] PD3HeistReleaseOrder =
        {
            "No Rest For The Wicked",
            "Road Rage",
            "Dirty Ice",
            "Rock The Cradle",
            "Under The Surphaze",
            "Gold & Sharke",
            "99 Boxes",
            "Touch The Sky",
            "Turbid Station",
            "Cook Off",
            "Syntax Error",
            "Boys In Blue",
            "Houston Breakout",
            "Diamond District",
            "Fear & Greed",
            "First World Bank",
            "Party Powder"
        };


        private void Form1_Load(object sender, EventArgs e)
        {
            ClearResult();
            CalculateTabControlSize(tbcMain);
            txtNumRowsHeist.Text = "8";
            txtNumRowsCon.Text = "4";
            txtNumRowsMethod.Text = "1";
            tabGame.Select();
            cboSortMethod.Items.Add("Least to most recently added");
            cboSortMethod.Items.Add("Most to least recently added");
            cboSortMethod.Items.Add("Alphabetical");
            cboSortMethod.Items.Add("Reverse alphabetical");
            cboSortMethod.SelectedIndex = 0;
            cboTheme.Items.Add("Light");
            cboTheme.Items.Add("Dark");
            cboTheme.Items.Add("Crime.net");
            cboTheme.SelectedIndex = 1;
            Theme();
            rdoPD2.Checked = true;
            foreach (TabPage tabPage in tbcMain.TabPages)
            {
                foreach (Control control in tabPage.Controls)
                {
                    if (control is CheckBox checkBox)
                    {
                        checkBox.Checked = true;
                    }
                }
            }
        }

        private void btnRoll_Click(object sender, EventArgs e)
        {
            int generatedHeist;
            CurrentAvailability.Clear();
            if (rdoPDTH.Checked)
            {
                //adding all the heists
                for (int i = 0; i <= PDTHHeistReleaseOrder.Length; i++)
                {
                    switch (i)
                    {
                        case 0:
                            if (chkPDTHFirstWorldBank.Checked == true)
                            {
                                CurrentAvailability.Add("First World Bank");
                            }
                            break;
                        case 1:
                            if (chkPDTHHeatStreet.Checked == true)
                            {
                                CurrentAvailability.Add("Heat Street");
                            }
                            break;
                        case 2:
                            if (chkPDTHPanicRoom.Checked == true)
                            {
                                CurrentAvailability.Add("Panic Room");
                            }
                            break;
                        case 3:
                            if (chkPDTHGreenBridge.Checked == true)
                            {
                                CurrentAvailability.Add("Green Bridge");
                            }
                            break;
                        case 4:
                            if (chkPDTHDiamondHeist.Checked == true)
                            {
                                CurrentAvailability.Add("Diamond Heist");
                            }
                            break;
                        case 5:
                            if (chkPDTHSlaughterhouse.Checked == true)
                            {
                                CurrentAvailability.Add("Slaughterhouse");
                            }
                            break;
                        case 6:
                            if (chkPDTHCounterfeit.Checked == true)
                            {
                                CurrentAvailability.Add("Counterfeit");
                            }
                            break;
                        case 7:
                            if (chkPDTHUndercover.Checked == true)
                            {
                                CurrentAvailability.Add("Undercover");
                            }
                            break;
                        case 8:
                            if (chkPDTHNoMercy.Checked == true)
                            {
                                CurrentAvailability.Add("No Mercy");
                            }
                            break;
                    }
                }
                if (CurrentAvailability.Count >= 2)
                {
                    if (!CurrentAvailability.SequenceEqual(OldAvailablity)) // if the the previous roll and the current roll dont have the same selection of heists
                    {
                        generatedHeist = random.Next(0, CurrentAvailability.Count);
                        lblHeist.Text = CurrentAvailability[generatedHeist];
                        previousHeist = generatedHeist;
                        OldAvailablity = CurrentAvailability;
                    }
                    else if (CurrentAvailability.SequenceEqual(OldAvailablity)) // if the the previous roll and the current roll have the same selection of heists
                    {
                        do
                        {
                            generatedHeist = random.Next(0, CurrentAvailability.Count);
                        } while (generatedHeist == previousHeist);
                        lblHeist.Text = CurrentAvailability[generatedHeist];
                        previousHeist = generatedHeist;
                    }
                }
                else
                {
                    lblHeist.Text = "Please have at least 2 heists selected";
                }
            }
            if (rdoPD2.Checked)
            {
                for (int i = 0; i <= PD2HeistReleaseOrder.Length; i++)
                {
                    switch (i)
                    {
                        case 0:
                            if (chkPD2Aftershock.Checked == true)
                            {
                                CurrentAvailability.Add("Aftershock");
                            }
                            break;
                        case 1:
                            if (chkPD2AlaskanDeal.Checked == true)
                            {
                                CurrentAvailability.Add("Alaskan Deal");
                            }
                            break;
                        case 2:
                            if (chkPD2ArtGallery.Checked == true)
                            {
                                CurrentAvailability.Add("Art Gallery");
                            }
                            break;
                        case 3:
                            if (chkPD2BankHeistCash.Checked == true)
                            {
                                CurrentAvailability.Add("Bank Heist: Cash");
                            }
                            break;
                        case 4:
                            if (chkPD2BankHeistDeposit.Checked == true)
                            {
                                CurrentAvailability.Add("Bank Heist: Deposit");
                            }
                            break;
                        case 5:
                            if (chkPD2BankHeistGold.Checked == true)
                            {
                                CurrentAvailability.Add("Bank Heist: Gold");
                            }
                            break;
                        case 6:
                            if (chkPD2BankHeistRandom.Checked == true)
                            {
                                CurrentAvailability.Add("Bank Heist: Random");
                            }
                            break;
                        case 7:
                            if (chkPD2BeneathTheMountain.Checked == true)
                            {
                                CurrentAvailability.Add("Beneath the Mountain");
                            }
                            break;
                        case 8:
                            if (chkPD2BigOil.Checked == true)
                            {
                                CurrentAvailability.Add("Big Oil");
                            }
                            break;
                        case 9:
                            if (chkPD2BirthOfSky.Checked == true)
                            {
                                CurrentAvailability.Add("Birth of Sky");
                            }
                            break;
                        case 10:
                            if (chkPD2BlackCat.Checked == true)
                            {
                                CurrentAvailability.Add("Black Cat");
                            }
                            break;
                        case 11:
                            if (chkPD2BoilingPoint.Checked == true)
                            {
                                CurrentAvailability.Add("Boiling Point");
                            }
                            break;
                        case 12:
                            if (chkPD2BorderCrossing.Checked == true)
                            {
                                CurrentAvailability.Add("Border Crossing");
                            }
                            break;
                        case 13:
                            if (chkPD2BorderCrystals.Checked == true)
                            {
                                CurrentAvailability.Add("Border Crystals");
                            }
                            break;
                        case 14:
                            if (chkPD2BreakfastInTijuana.Checked == true)
                            {
                                CurrentAvailability.Add("Breakfast in Tijuana");
                            }
                            break;
                        case 15:
                            if (chkPD2BreakinFeds.Checked == true)
                            {
                                CurrentAvailability.Add("Breakin' Feds");
                            }
                            break;
                        case 16:
                            if (chkPD2Brooklyn1010.Checked == true)
                            {
                                CurrentAvailability.Add("Brooklyn 10-10");
                            }
                            break;
                        case 17:
                            if (chkPD2BrooklynBank.Checked == true)
                            {
                                CurrentAvailability.Add("Brooklyn Bank");
                            }
                            break;
                        case 18:
                            if (chkPD2BulucsMansion.Checked == true)
                            {
                                CurrentAvailability.Add("Buluc's Mansion");
                            }
                            break;
                        case 19:
                            if (chkPD2CarShop.Checked == true)
                            {
                                CurrentAvailability.Add("Car Shop");
                            }
                            break;
                        case 20:
                            if (chkPD2CookOff.Checked == true)
                            {
                                CurrentAvailability.Add("Cook Off");
                            }
                            break;
                        case 21:
                            if (chkPD2Counterfeit.Checked == true)
                            {
                                CurrentAvailability.Add("Counterfeit");
                            }
                            break;
                        case 22:
                            if (chkPD2CrudeAwakening.Checked == true)
                            {
                                CurrentAvailability.Add("Crude Awakening");
                            }
                            break;
                        case 23:
                            if (chkPD2CursedKillRoom.Checked == true)
                            {
                                CurrentAvailability.Add("Cursed Kill Room");
                            }
                            break;
                        case 24:
                            if (chkPD2DiamondHeist.Checked == true)
                            {
                                CurrentAvailability.Add("Diamond Heist");
                            }
                            break;
                        case 25:
                            if (chkPD2DiamondStore.Checked == true)
                            {
                                CurrentAvailability.Add("Diamond Store");
                            }
                            break;
                        case 26:
                            if (chkPD2DragonHeist.Checked == true)
                            {
                                CurrentAvailability.Add("Dragon Heist");
                            }
                            break;
                        case 27:
                            if (chkPD2ElectionDay.Checked == true)
                            {
                                CurrentAvailability.Add("Election Day");
                            }
                            break;
                        case 28:
                            if (chkPD2Firestarter.Checked == true)
                            {
                                CurrentAvailability.Add("Firestarter");
                            }
                            break;
                        case 29:
                            if (chkPD2FirstWorldBank.Checked == true)
                            {
                                CurrentAvailability.Add("First World Bank");
                            }
                            break;
                        case 30:
                            if (chkPD2FourStores.Checked == true)
                            {
                                CurrentAvailability.Add("Four Stores");
                            }
                            break;
                        case 31:
                            if (chkPD2FramingFrame.Checked == true)
                            {
                                CurrentAvailability.Add("Framing Frame");
                            }
                            break;
                        case 32:
                            if (chkPD2GoatSimulator.Checked == true)
                            {
                                CurrentAvailability.Add("Goat Simulator");
                            }
                            break;
                        case 33:
                            if (chkPD2GOBank.Checked == true)
                            {
                                CurrentAvailability.Add("GO Bank");
                            }
                            break;
                        case 34:
                            if (chkPD2GoldenGrinCasino.Checked == true)
                            {
                                CurrentAvailability.Add("Golden Grin Casino");
                            }
                            break;
                        case 35:
                            if (chkPD2GreenBridge.Checked == true)
                            {
                                CurrentAvailability.Add("Green Bridge");
                            }
                            break;
                        case 36:
                            if (chkPD2HeatStreet.Checked == true)
                            {
                                CurrentAvailability.Add("Heat Street");
                            }
                            break;
                        case 37:
                            if (chkPD2HellsIsland.Checked == true)
                            {
                                CurrentAvailability.Add("Hell's Island");
                            }
                            break;
                        case 38:
                            if (chkPD2HenrysRock.Checked == true)
                            {
                                CurrentAvailability.Add("Henry's Rock");
                            }
                            break;
                        case 39:
                            if (chkPD2HostileTakeover.Checked == true)
                            {
                                CurrentAvailability.Add("Hostile Takeover");
                            }
                            break;
                        case 40:
                            if (chkPD2HotlineMiami.Checked == true)
                            {
                                CurrentAvailability.Add("Hotline Miami");
                            }
                            break;
                        case 41:
                            if (chkPD2HoxtonBreakout.Checked == true)
                            {
                                CurrentAvailability.Add("Hoxton Breakout");
                            }
                            break;
                        case 42:
                            if (chkPD2HoxtonRevenge.Checked == true)
                            {
                                CurrentAvailability.Add("Hoxton Revenge");
                            }
                            break;
                        case 43:
                            if (chkPD2JewelryStore.Checked == true)
                            {
                                CurrentAvailability.Add("Jewelry Store");
                            }
                            break;
                        case 44:
                            if (chkPD2LabRats.Checked == true)
                            {
                                CurrentAvailability.Add("Lab Rats");
                            }
                            break;
                        case 45:
                            if (chkPD2LostInTransit.Checked == true)
                            {
                                CurrentAvailability.Add("Lost In Transit");
                            }
                            break;
                        case 46:
                            if (chkPD2Mallcrasher.Checked == true)
                            {
                                CurrentAvailability.Add("Mallcrasher");
                            }
                            break;
                        case 47:
                            if (chkPD2Meltdown.Checked == true)
                            {
                                CurrentAvailability.Add("Meltdown");
                            }
                            break;
                        case 48:
                            if (chkPD2MidlandRanch.Checked == true)
                            {
                                CurrentAvailability.Add("Midland Ranch");
                            }
                            break;
                        case 49:
                            if (chkPD2MountainMaster.Checked == true)
                            {
                                CurrentAvailability.Add("Mountain Master");
                            }
                            break;
                        case 50:
                            if (chkPD2MurkyStation.Checked == true)
                            {
                                CurrentAvailability.Add("Murky Station");
                            }
                            break;
                        case 51:
                            if (chkPD2Nightclub.Checked == true)
                            {
                                CurrentAvailability.Add("Nightclub");
                            }
                            break;
                        case 52:
                            if (chkPD2NoMercy.Checked == true)
                            {
                                CurrentAvailability.Add("No Mercy");
                            }
                            break;
                        case 53:
                            if (chkPD2PanicRoom.Checked == true)
                            {
                                CurrentAvailability.Add("Panic Room");
                            }
                            break;
                        case 54:
                            if (chkPD2PrisonNightmare.Checked == true)
                            {
                                CurrentAvailability.Add("Prison Nightmare");
                            }
                            break;
                        case 55:
                            if (chkPD2Rats.Checked == true)
                            {
                                CurrentAvailability.Add("Rats");
                            }
                            break;
                        case 56:
                            if (chkPD2ReservoirDogsHeist.Checked == true)
                            {
                                CurrentAvailability.Add("Reservoir Dogs Heist");
                            }
                            break;
                        case 57:
                            if (chkPD2SafeHouseNightmare.Checked == true)
                            {
                                CurrentAvailability.Add("Safe House Nightmare");
                            }
                            break;
                        case 58:
                            if (chkPD2SafeHouseRaid.Checked == true)
                            {
                                CurrentAvailability.Add("Safe House Raid");
                            }
                            break;
                        case 59:
                            if (chkPD2SanMartinBank.Checked == true)
                            {
                                CurrentAvailability.Add("San Martín Bank");
                            }
                            break;
                        case 60:
                            if (chkPD2SantasWorkshop.Checked == true)
                            {
                                CurrentAvailability.Add("Santa's Workshop");
                            }
                            break;
                        case 61:
                            if (chkPD2ScarfaceMansion.Checked == true)
                            {
                                CurrentAvailability.Add("Scarface Mansion");
                            }
                            break;
                        case 62:
                            if (chkPD2ShacklethorneAuction.Checked == true)
                            {
                                CurrentAvailability.Add("Shacklethorne Auction");
                            }
                            break;
                        case 63:
                            if (chkPD2ShadowRaid.Checked == true)
                            {
                                CurrentAvailability.Add("Shadow Raid");
                            }
                            break;
                        case 64:
                            if (chkPD2Slaughterhouse.Checked == true)
                            {
                                CurrentAvailability.Add("Slaughterhouse");
                            }
                            break;
                        case 65:
                            if (chkPD2StealingXmas.Checked == true)
                            {
                                CurrentAvailability.Add("Stealing Xmas");
                            }
                            break;
                        case 66:
                            if (chkPD2TheAlessoHeist.Checked == true)
                            {
                                CurrentAvailability.Add("The Alesso Heist");
                            }
                            break;
                        case 67:
                            if (chkPD2TheBigBank.Checked == true)
                            {
                                CurrentAvailability.Add("The Big Bank");
                            }
                            break;
                        case 68:
                            if (chkPD2TheBikerHeist.Checked == true)
                            {
                                CurrentAvailability.Add("The Biker Heist");
                            }
                            break;
                        case 69:
                            if (chkPD2TheBombDockyard.Checked == true)
                            {
                                CurrentAvailability.Add("The Bomb: Dockyard");
                            }
                            break;
                        case 70:
                            if (chkPD2TheBombForest.Checked == true)
                            {
                                CurrentAvailability.Add("The Bomb: Forest");
                            }
                            break;
                        case 71:
                            if (chkPD2TheDiamond.Checked == true)
                            {
                                CurrentAvailability.Add("The Diamond");
                            }
                            break;
                        case 72:
                            if (chkPD2TheUkrainianPrisoner.Checked == true)
                            {
                                CurrentAvailability.Add("The Ukrainian Prisoner");
                            }
                            break;
                        case 73:
                            if (chkPD2TheWhiteHouse.Checked == true)
                            {
                                CurrentAvailability.Add("The White House");
                            }
                            break;
                        case 74:
                            if (chkPD2TheYachtHeist.Checked == true)
                            {
                                CurrentAvailability.Add("The Yacht Heist");
                            }
                            break;
                        case 75:
                            if (chkPD2TransportCrossroads.Checked == true)
                            {
                                CurrentAvailability.Add("Transport: Crossroads");
                            }
                            break;
                        case 76:
                            if (chkPD2TransportDowntown.Checked == true)
                            {
                                CurrentAvailability.Add("Transport: Downtown");
                            }
                            break;
                        case 77:
                            if (chkPD2TransportHarbor.Checked == true)
                            {
                                CurrentAvailability.Add("Transport: Harbor");
                            }
                            break;
                        case 78:
                            if (chkPD2TransportPark.Checked == true)
                            {
                                CurrentAvailability.Add("Transport: Park");
                            }
                            break;
                        case 79:
                            if (chkPD2TransportTrainHeist.Checked == true)
                            {
                                CurrentAvailability.Add("Transport: Train Heist");
                            }
                            break;
                        case 80:
                            if (chkPD2TransportUnderpass.Checked == true)
                            {
                                CurrentAvailability.Add("Transport: Underpass");
                            }
                            break;
                        case 81:
                            if (chkPD2UkrainianJob.Checked == true)
                            {
                                CurrentAvailability.Add("Ukrainian Job");
                            }
                            break;
                        case 82:
                            if (chkPD2Undercover.Checked == true)
                            {
                                CurrentAvailability.Add("Undercover");
                            }
                            break;
                        case 83:
                            if (chkPD2Watchdogs.Checked == true)
                            {
                                CurrentAvailability.Add("Watchdogs");
                            }
                            break;
                        case 84:
                            if (chkPD2WhiteXmas.Checked == true)
                            {
                                CurrentAvailability.Add("White Xmas");
                            }
                            break;
                    }
                }
                if (CurrentAvailability.Count >= 2)
                {
                    if (!CurrentAvailability.SequenceEqual(OldAvailablity)) // if the the previous roll and the current roll dont have the same selection of heists
                    {
                        generatedHeist = random.Next(0, CurrentAvailability.Count);
                        lblHeist.Text = CurrentAvailability[generatedHeist];
                        previousHeist = generatedHeist;
                        OldAvailablity = CurrentAvailability;
                    }
                    else if (CurrentAvailability.SequenceEqual(OldAvailablity)) // if the the previous roll and the current roll have the same selection of heists
                    {
                        do
                        {
                            generatedHeist = random.Next(0, CurrentAvailability.Count);
                        } while (generatedHeist == previousHeist);
                        lblHeist.Text = CurrentAvailability[generatedHeist];
                        previousHeist = generatedHeist;
                    }
                }
                else
                {
                    lblHeist.Text = "Please have at least 2 heists selected";
                }
            }
            if (rdoPD3.Checked)
            {
                //adding all the heists
                for (int i = 0; i <= PD3HeistReleaseOrder.Length; i++)
                {
                    switch (i)
                    {
                        case 0:
                            if (chkPD3NoRestForTheWicked.Checked == true)
                            {
                                CurrentAvailability.Add("No Rest For The Wicked");
                            }
                            break;
                        case 1:
                            if (chkPD3RoadRage.Checked == true)
                            {
                                CurrentAvailability.Add("Road Rage");
                            }
                            break;
                        case 2:
                            if (chkPD3DirtyIce.Checked == true)
                            {
                                CurrentAvailability.Add("Dirty Ice");
                            }
                            break;
                        case 3:
                            if (chkPD3RockTheCradle.Checked == true)
                            {
                                CurrentAvailability.Add("Rock The Cradle");
                            }
                            break;
                        case 4:
                            if (chkPD3UnderTheSurphaze.Checked == true)
                            {
                                CurrentAvailability.Add("Under The Surphaze");
                            }
                            break;
                        case 5:
                            if (chkPD3GoldNSharke.Checked == true)
                            {
                                CurrentAvailability.Add("Gold && Sharke");
                            }
                            break;
                        case 6:
                            if (chkPD399Boxes.Checked == true)
                            {
                                CurrentAvailability.Add("99 Boxes");
                            }
                            break;
                        case 7:
                            if (chkPD3TouchTheSky.Checked == true)
                            {
                                CurrentAvailability.Add("Touch The Sky");
                            }
                            break;
                        case 8:
                            if (chkPD3TurbidStation.Checked == true)
                            {
                                CurrentAvailability.Add("Turbid Station");
                            }
                            break;
                        case 9:
                            if (chkPD3CookOff.Checked == true)
                            {
                                CurrentAvailability.Add("Cook Off");
                            }
                            break;
                        case 10:
                            if (chkPD3SyntaxError.Checked == true)
                            {
                                CurrentAvailability.Add("Syntax Error");
                            }
                            break;
                        case 11:
                            if (chkPD3BoysInBlue.Checked == true)
                            {
                                CurrentAvailability.Add("Boys In Blue");
                            }
                            break;
                        case 12:
                            if (chkPD3HoustonBreakout.Checked == true)
                            {
                                CurrentAvailability.Add("Houston Breakout");
                            }
                            break;
                        case 13:
                            if (chkPD3DiamondDistrict.Checked == true)
                            {
                                CurrentAvailability.Add("Diamond District");
                            }
                            break;
                        case 14:
                            if (chkPD3FearNGreed.Checked == true)
                            {
                                CurrentAvailability.Add("Fear & Greed");
                            }
                            break;
                        case 15:
                            if (chkPD3FirstWorldBank.Checked == true)
                            {
                                CurrentAvailability.Add("First World Bank");
                            }
                            break;
                        case 16:
                            if (chkPD3PartyPowder.Checked == true)
                            {
                                CurrentAvailability.Add("Party Powder");
                            }
                            break;
                    }
                }
                if (CurrentAvailability.Count >= 2)
                {
                    if (!CurrentAvailability.SequenceEqual(OldAvailablity)) // if the the previous roll and the current roll dont have the same selection of heists
                    {
                        generatedHeist = random.Next(0, CurrentAvailability.Count);
                        lblHeist.Text = CurrentAvailability[generatedHeist];
                        previousHeist = generatedHeist;
                        OldAvailablity = CurrentAvailability;
                    }
                    else if (CurrentAvailability.SequenceEqual(OldAvailablity)) // if the the previous roll and the current roll have the same selection of heists
                    {
                        do
                        {
                            generatedHeist = random.Next(0, CurrentAvailability.Count);
                        } while (generatedHeist == previousHeist);
                        lblHeist.Text = CurrentAvailability[generatedHeist];
                        previousHeist = generatedHeist;
                    }
                }
                else
                {
                    lblHeist.Text = "Please have at least 2 heists selected";
                }
            }
        }
        private void ClearResult()
        {
            lblHeist.Text = "Roll for a heist";
        }
        private void ClearResult(object sender, EventArgs e)
        {
            ClearResult();
        }

        private void btnApplyChanges_Click(object sender, EventArgs e)
        {
            if (Validator.IsValidInt(txtNumRowsHeist.Text) == "" && Validator.IsValidInt(txtNumRowsCon.Text) == "" && Validator.IsValidInt(txtNumRowsMethod.Text) == "")
            {
                numRowsHeist = Convert.ToInt32(txtNumRowsHeist.Text);
                if (rdoPDTH.Checked && numRowsHeist > 9)
                {
                    numRowsHeist = 9;
                }
                else if (rdoPD2.Checked && numRowsHeist > 84)
                {
                    numRowsHeist = 84;
                }
                else if (rdoPD3.Checked && numRowsHeist > 16)
                {
                    numRowsHeist = 16;
                }
                numRowsCon = Convert.ToInt32(txtNumRowsCon.Text);
                if (rdoPD2.Checked && numRowsCon > 15)
                {
                    numRowsCon = 15;
                }
                if (rdoPD3.Checked && numRowsCon > 8)
                {
                    numRowsCon = 8;
                }
                numRowsMethod = Convert.ToInt32(txtNumRowsMethod.Text);
                if (rdoPD2.Checked && numRowsMethod > 3)
                {
                    numRowsMethod = 3;
                }
                if (rdoPD3.Checked && numRowsMethod > 3)
                {
                    numRowsMethod = 3;
                }
                txtNumRowsHeist.Text = numRowsHeist.ToString();
                txtNumRowsCon.Text = numRowsCon.ToString();
                txtNumRowsMethod.Text = numRowsMethod.ToString();
                sortMethod = cboSortMethod.SelectedIndex;
                theme = cboTheme.SelectedIndex;
                Theme();
            }
            else
            {
                MessageBox.Show($"{Validator.IsValidInt(txtNumRowsHeist.Text)}", "Warning");
            }
        }
        private void Cancel()
        {
            txtNumRowsHeist.Text = numRowsHeist.ToString();
            txtNumRowsCon.Text = numRowsCon.ToString();
            txtNumRowsMethod.Text = numRowsMethod.ToString();
            cboSortMethod.SelectedIndex = sortMethod;
            cboTheme.SelectedIndex = theme;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }
        public void TabControlSize(object sender, EventArgs e)
        {
            Cancel();
            Layout();
            CalculateTabControlSize(tbcMain);
        }
        public void CalculateTabControlSize(TabControl tabControl)
        {
            int minWidth = 0;
            int minHeight = 0;
            foreach (Control control in tabControl.SelectedTab.Controls)
            {
                if (!control.Visible)
                    continue;
                int controlRight = control.Left + control.Width;
                int controlBottom = control.Top + control.Height;
                minWidth = Math.Max(minWidth, controlRight);
                minHeight = Math.Max(minHeight, controlBottom);
            }
            int tabHeadersWidth = tabControl.TabCount * tabControl.ItemSize.Width;
            minHeight += tabControl.ItemSize.Height + tabControl.Padding.X + tabControl.Padding.Y;
            minWidth = Math.Max(minWidth, tabHeadersWidth + tabControl.Padding.X + tabControl.Padding.Y);
            minHeight += tabControl.ItemSize.Height + tabControl.Padding.Y;
            minWidth += tabControl.Padding.X;
            tabControl.Size = new Size(minWidth + 12, minHeight);
        }
        private void Theme()
        {
            if (theme == 0) //light mode
            {
                this.BackgroundImage = null;
                this.BackColor = System.Drawing.ColorTranslator.FromHtml("#F4F5F7");
                foreach (Control control in this.Controls)
                {
                    ExtendTheme(control, "#FFFFFF", "#2C2F33");
                }
                lblHeist.BackColor = System.Drawing.ColorTranslator.FromHtml("#F4F5F7");
                this.Icon = null;
            }
            if (theme == 1) //dark mode
            {
                this.BackgroundImage = null;
                this.BackColor = System.Drawing.ColorTranslator.FromHtml("#1E1F22");
                foreach (Control control in this.Controls)
                {
                    ExtendTheme(control, "#2A2B2F", "#F0F0F0");
                }
                lblHeist.BackColor = System.Drawing.ColorTranslator.FromHtml("#1E1F22");
            }
            if (theme == 2) //crime.net mode
            {
                this.BackgroundImage = Image.FromFile("crimenet.jpg");
                this.BackgroundImageLayout = ImageLayout.Stretch;
                foreach (Control control in this.Controls)
                {
                    ExtendTheme(control, "#22719D", "#FFFFFF");
                }
                lblHeist.BackColor = Color.Transparent;
            }
        }
        private void ExtendTheme(Control control, string main, string second)
        {
            control.BackColor = System.Drawing.ColorTranslator.FromHtml(main);
            control.ForeColor = System.Drawing.ColorTranslator.FromHtml(second);
            foreach (Control subControl in control.Controls)
            {
                ExtendTheme(subControl, main, second);
            }
        }
        public void Layout() //does math to figure out the positons and visiblity of all element on each tab. done whenever the tab is switched
        {
            List<Point> controlPositionsHeists = new();
            List<Point> controlPositionsContractors = new();
            List<Point> controlPositionsMethods = new();
            foreach (Control control in tabHeist.Controls)
            {
                control.Visible = false;
            }
            if (rdoPDTH.Checked)
            {
                lblIndivHeists.Location = new Point(6, 3);
                //conversion
                var heists = new List<string>();

                for (int i = 0; i < PDTHHeistReleaseOrder.GetLength(0); i++)
                {
                    string name = PDTHHeistReleaseOrder[i];
                    heists.Add(name);
                }
                //math
                int startX = lblIndivHeists.Location.X;
                int startY = lblIndivHeists.Location.Y + 18;
                int spacingX = 118;
                int spacingY = 25;
                int numCols = (int)Math.Ceiling((double)heists.Count / numRowsHeist);
                int index = 0;
                for (int col = 0; col < numCols; col++)
                {
                    for (int row = 0; row < numRowsHeist; row++)
                    {
                        if (index >= heists.Count)
                            break;

                        int x = startX + col * spacingX;
                        int y = startY + row * spacingY;

                        controlPositionsHeists.Add(new Point(x, y));
                        index++;
                    }
                }
                //movement
                if (sortMethod == 0)
                {
                    chkPDTHFirstWorldBank.Location = controlPositionsHeists[0];
                    chkPDTHHeatStreet.Location = controlPositionsHeists[1];
                    chkPDTHPanicRoom.Location = controlPositionsHeists[2];
                    chkPDTHGreenBridge.Location = controlPositionsHeists[3];
                    chkPDTHDiamondHeist.Location = controlPositionsHeists[4];
                    chkPDTHSlaughterhouse.Location = controlPositionsHeists[5];
                    chkPDTHCounterfeit.Location = controlPositionsHeists[6];
                    chkPDTHUndercover.Location = controlPositionsHeists[7];
                    chkPDTHNoMercy.Location = controlPositionsHeists[8];
                }
                if (sortMethod == 1)
                {
                    chkPDTHNoMercy.Location = controlPositionsHeists[0];
                    chkPDTHUndercover.Location = controlPositionsHeists[1];
                    chkPDTHCounterfeit.Location = controlPositionsHeists[2];
                    chkPDTHSlaughterhouse.Location = controlPositionsHeists[3];
                    chkPDTHDiamondHeist.Location = controlPositionsHeists[4];
                    chkPDTHGreenBridge.Location = controlPositionsHeists[5];
                    chkPDTHPanicRoom.Location = controlPositionsHeists[6];
                    chkPDTHHeatStreet.Location = controlPositionsHeists[7];
                    chkPDTHFirstWorldBank.Location = controlPositionsHeists[8];
                }
                if (sortMethod == 2)
                {
                    chkPDTHCounterfeit.Location = controlPositionsHeists[0];
                    chkPDTHDiamondHeist.Location = controlPositionsHeists[1];
                    chkPDTHFirstWorldBank.Location = controlPositionsHeists[2];
                    chkPDTHGreenBridge.Location = controlPositionsHeists[3];
                    chkPDTHHeatStreet.Location = controlPositionsHeists[4];
                    chkPDTHNoMercy.Location = controlPositionsHeists[5];
                    chkPDTHPanicRoom.Location = controlPositionsHeists[6];
                    chkPDTHSlaughterhouse.Location = controlPositionsHeists[7];
                    chkPDTHUndercover.Location = controlPositionsHeists[8];
                }
                if (sortMethod == 3)
                {
                    chkPDTHUndercover.Location = controlPositionsHeists[0];
                    chkPDTHSlaughterhouse.Location = controlPositionsHeists[1];
                    chkPDTHPanicRoom.Location = controlPositionsHeists[2];
                    chkPDTHNoMercy.Location = controlPositionsHeists[3];
                    chkPDTHHeatStreet.Location = controlPositionsHeists[4];
                    chkPDTHGreenBridge.Location = controlPositionsHeists[5];
                    chkPDTHFirstWorldBank.Location = controlPositionsHeists[6];
                    chkPDTHDiamondHeist.Location = controlPositionsHeists[7];
                    chkPDTHCounterfeit.Location = controlPositionsHeists[8];
                }
                //visible
                lblIndivHeists.Visible = true;
                chkPDTHFirstWorldBank.Visible = true;
                chkPDTHHeatStreet.Visible = true;
                chkPDTHPanicRoom.Visible = true;
                chkPDTHGreenBridge.Visible = true;
                chkPDTHDiamondHeist.Visible = true;
                chkPDTHSlaughterhouse.Visible = true;
                chkPDTHCounterfeit.Visible = true;
                chkPDTHUndercover.Visible = true;
                chkPDTHNoMercy.Visible = true;
            }
            if (rdoPD2.Checked)
            {
                lblMethods.Location = new Point(6, 3);
                lblContractors.Location = new Point(6, ((25 * numRowsMethod) + 18));
                lblIndivHeists.Location = new Point(6, ((25 * numRowsCon) + (lblContractors.Location.Y + 18)));
                //method conversion
                var methods = new List<string>();

                for (int i = 0; i < PD2n3MethodOrderInfo.GetLength(0); i++)
                {
                    string name = PD2n3MethodOrderInfo[i];
                    methods.Add(name);
                }
                //contractor conversion
                var contractors = new List<string>();

                for (int i = 0; i < PD2ContractorReleaseOrder.GetLength(0); i++)
                {
                    string name = PD2ContractorReleaseOrder[i];
                    contractors.Add(name);
                }
                //heist conversion
                var heists = new List<string>();

                for (int i = 0; i < PD2HeistReleaseOrder.GetLength(0); i++)
                {
                    string name = PD2HeistReleaseOrder[i];
                    heists.Add(name);
                }
                //method math
                int MstartX = lblMethods.Location.X;
                int MstartY = lblMethods.Location.Y + 18;
                int MspacingX = 118;
                int MspacingY = 25;
                int MnumCols = (int)Math.Ceiling((double)methods.Count / numRowsMethod);
                int Mindex = 0;
                for (int col = 0; col < MnumCols; col++)
                {
                    for (int row = 0; row < numRowsMethod; row++)
                    {
                        if (Mindex >= heists.Count)
                            break;

                        int x = MstartX + col * MspacingX;
                        int y = MstartY + row * MspacingY;

                        controlPositionsMethods.Add(new Point(x, y));
                        Mindex++;
                    }
                }
                //contractor math
                int CstartX = lblContractors.Location.X;
                int CstartY = lblContractors.Location.Y + 18;
                int CspacingX = 111;
                int CspacingY = 25;
                int CnumCols = (int)Math.Ceiling((double)contractors.Count / numRowsCon);
                int Cindex = 0;
                for (int col = 0; col < CnumCols; col++)
                {
                    for (int row = 0; row < numRowsCon; row++)
                    {
                        if (Cindex >= heists.Count)
                            break;

                        int x = CstartX + col * CspacingX;
                        int y = CstartY + row * CspacingY;

                        controlPositionsContractors.Add(new Point(x, y));
                        Cindex++;
                    }
                }
                //heist math
                int HstartX = lblIndivHeists.Location.X;
                int HstartY = lblIndivHeists.Location.Y + 18;
                int HspacingX = 146;
                int HspacingY = 25;
                int HnumCols = (int)Math.Ceiling((double)heists.Count / numRowsHeist);
                int Hindex = 0;
                for (int col = 0; col < HnumCols; col++)
                {
                    for (int row = 0; row < numRowsHeist; row++)
                    {
                        if (Hindex >= heists.Count)
                            break;

                        int x = HstartX + col * HspacingX;
                        int y = HstartY + row * HspacingY;

                        controlPositionsHeists.Add(new Point(x, y));
                        Hindex++;
                    }
                }
                chkPD2Loud.Location = controlPositionsMethods[0];
                chkPD2Hybrid.Location = controlPositionsMethods[1];
                chkPD2Stealth.Location = controlPositionsMethods[2];
                if (sortMethod == 0)
                {
                    chkPD2Vlad.Location = controlPositionsContractors[0];
                    chkPD2Bain.Location = controlPositionsContractors[1];
                    chkPD2Hector.Location = controlPositionsContractors[2];
                    chkPD2Event.Location = controlPositionsContractors[3];
                    chkPD2TheElephant.Location = controlPositionsContractors[4];
                    chkPD2TheDentist.Location = controlPositionsContractors[5];
                    chkPD2TheButcher.Location = controlPositionsContractors[6];
                    chkPD2Classic.Location = controlPositionsContractors[7];
                    chkPD2Locke.Location = controlPositionsContractors[8];
                    chkPD2Jimmy.Location = controlPositionsContractors[9];
                    chkPD2Hoxton.Location = controlPositionsContractors[10];
                    chkPD2TheContinental.Location = controlPositionsContractors[11];
                    chkPD2JiuFeng.Location = controlPositionsContractors[12];
                    chkPD2Shayu.Location = controlPositionsContractors[13];
                    chkPD2GemmaMCShay.Location = controlPositionsContractors[14];
                    chkPD2BlaineKeegan.Location = controlPositionsContractors[15];
                    chkPD2FourStores.Location = controlPositionsHeists[0];
                    chkPD2JewelryStore.Location = controlPositionsHeists[1];
                    chkPD2UkrainianJob.Location = controlPositionsHeists[2];
                    chkPD2Mallcrasher.Location = controlPositionsHeists[3];
                    chkPD2BankHeistCash.Location = controlPositionsHeists[4];
                    chkPD2BankHeistDeposit.Location = controlPositionsHeists[5];
                    chkPD2BankHeistGold.Location = controlPositionsHeists[6];
                    chkPD2BankHeistRandom.Location = controlPositionsHeists[7];
                    chkPD2Nightclub.Location = controlPositionsHeists[8];
                    chkPD2Watchdogs.Location = controlPositionsHeists[9];
                    chkPD2Firestarter.Location = controlPositionsHeists[10];
                    chkPD2BigOil.Location = controlPositionsHeists[11];
                    chkPD2FramingFrame.Location = controlPositionsHeists[12];
                    chkPD2Rats.Location = controlPositionsHeists[13];
                    chkPD2DiamondStore.Location = controlPositionsHeists[14];
                    chkPD2SafeHouseNightmare.Location = controlPositionsHeists[15];
                    chkPD2TransportCrossroads.Location = controlPositionsHeists[16];
                    chkPD2TransportDowntown.Location = controlPositionsHeists[17];
                    chkPD2TransportHarbor.Location = controlPositionsHeists[18];
                    chkPD2TransportPark.Location = controlPositionsHeists[19];
                    chkPD2TransportUnderpass.Location = controlPositionsHeists[20];
                    chkPD2TransportTrainHeist.Location = controlPositionsHeists[21];
                    chkPD2GOBank.Location = controlPositionsHeists[22];
                    chkPD2ElectionDay.Location = controlPositionsHeists[23];
                    chkPD2ShadowRaid.Location = controlPositionsHeists[24];
                    chkPD2TheBigBank.Location = controlPositionsHeists[25];
                    chkPD2HotlineMiami.Location = controlPositionsHeists[26];
                    chkPD2ArtGallery.Location = controlPositionsHeists[27];
                    chkPD2HoxtonBreakout.Location = controlPositionsHeists[28];
                    chkPD2WhiteXmas.Location = controlPositionsHeists[29];
                    chkPD2TheDiamond.Location = controlPositionsHeists[30];
                    chkPD2TheBombDockyard.Location = controlPositionsHeists[31];
                    chkPD2TheBombForest.Location = controlPositionsHeists[32];
                    chkPD2CookOff.Location = controlPositionsHeists[33];
                    chkPD2CarShop.Location = controlPositionsHeists[34];
                    chkPD2HoxtonRevenge.Location = controlPositionsHeists[35];
                    chkPD2Meltdown.Location = controlPositionsHeists[36];
                    chkPD2TheAlessoHeist.Location = controlPositionsHeists[37];
                    chkPD2GoldenGrinCasino.Location = controlPositionsHeists[38];
                    chkPD2Aftershock.Location = controlPositionsHeists[39];
                    chkPD2FirstWorldBank.Location = controlPositionsHeists[40];
                    chkPD2Slaughterhouse.Location = controlPositionsHeists[41];
                    chkPD2LabRats.Location = controlPositionsHeists[42];
                    chkPD2BeneathTheMountain.Location = controlPositionsHeists[43];
                    chkPD2BirthOfSky.Location = controlPositionsHeists[44];
                    chkPD2SantasWorkshop.Location = controlPositionsHeists[45];
                    chkPD2GoatSimulator.Location = controlPositionsHeists[46];
                    chkPD2Counterfeit.Location = controlPositionsHeists[47];
                    chkPD2Undercover.Location = controlPositionsHeists[48];
                    chkPD2MurkyStation.Location = controlPositionsHeists[49];
                    chkPD2BoilingPoint.Location = controlPositionsHeists[50];
                    chkPD2TheBikerHeist.Location = controlPositionsHeists[51];
                    chkPD2SafeHouseRaid.Location = controlPositionsHeists[52];
                    chkPD2PanicRoom.Location = controlPositionsHeists[53];
                    chkPD2PrisonNightmare.Location = controlPositionsHeists[54];
                    chkPD2StealingXmas.Location = controlPositionsHeists[55];
                    chkPD2ScarfaceMansion.Location = controlPositionsHeists[56];
                    chkPD2Brooklyn1010.Location = controlPositionsHeists[57];
                    chkPD2TheYachtHeist.Location = controlPositionsHeists[58];
                    chkPD2HeatStreet.Location = controlPositionsHeists[59];
                    chkPD2GreenBridge.Location = controlPositionsHeists[60];
                    chkPD2AlaskanDeal.Location = controlPositionsHeists[61];
                    chkPD2DiamondHeist.Location = controlPositionsHeists[62];
                    chkPD2CursedKillRoom.Location = controlPositionsHeists[63];
                    chkPD2ReservoirDogsHeist.Location = controlPositionsHeists[64];
                    chkPD2BrooklynBank.Location = controlPositionsHeists[65];
                    chkPD2BreakinFeds.Location = controlPositionsHeists[66];
                    chkPD2HenrysRock.Location = controlPositionsHeists[67];
                    chkPD2ShacklethorneAuction.Location = controlPositionsHeists[68];
                    chkPD2HellsIsland.Location = controlPositionsHeists[69];
                    chkPD2NoMercy.Location = controlPositionsHeists[70];
                    chkPD2TheWhiteHouse.Location = controlPositionsHeists[71];
                    chkPD2BorderCrossing.Location = controlPositionsHeists[72];
                    chkPD2BorderCrystals.Location = controlPositionsHeists[73];
                    chkPD2SanMartinBank.Location = controlPositionsHeists[74];
                    chkPD2BreakfastInTijuana.Location = controlPositionsHeists[75];
                    chkPD2BulucsMansion.Location = controlPositionsHeists[76];
                    chkPD2DragonHeist.Location = controlPositionsHeists[77];
                    chkPD2TheUkrainianPrisoner.Location = controlPositionsHeists[78];
                    chkPD2BlackCat.Location = controlPositionsHeists[79];
                    chkPD2MountainMaster.Location = controlPositionsHeists[80];
                    chkPD2MidlandRanch.Location = controlPositionsHeists[81];
                    chkPD2LostInTransit.Location = controlPositionsHeists[82];
                    chkPD2HostileTakeover.Location = controlPositionsHeists[83];
                    chkPD2CrudeAwakening.Location = controlPositionsHeists[84];
                }
                if (sortMethod == 1)
                {
                    chkPD2BlaineKeegan.Location = controlPositionsContractors[0];
                    chkPD2GemmaMCShay.Location = controlPositionsContractors[1];
                    chkPD2Shayu.Location = controlPositionsContractors[2];
                    chkPD2JiuFeng.Location = controlPositionsContractors[3];
                    chkPD2TheContinental.Location = controlPositionsContractors[4];
                    chkPD2Hoxton.Location = controlPositionsContractors[5];
                    chkPD2Jimmy.Location = controlPositionsContractors[6];
                    chkPD2Locke.Location = controlPositionsContractors[7];
                    chkPD2Classic.Location = controlPositionsContractors[8];
                    chkPD2TheButcher.Location = controlPositionsContractors[9];
                    chkPD2TheDentist.Location = controlPositionsContractors[10];
                    chkPD2TheElephant.Location = controlPositionsContractors[11];
                    chkPD2Event.Location = controlPositionsContractors[12];
                    chkPD2Hector.Location = controlPositionsContractors[13];
                    chkPD2Bain.Location = controlPositionsContractors[14];
                    chkPD2Vlad.Location = controlPositionsContractors[15];
                    chkPD2CrudeAwakening.Location = controlPositionsHeists[0];
                    chkPD2HostileTakeover.Location = controlPositionsHeists[1];
                    chkPD2LostInTransit.Location = controlPositionsHeists[2];
                    chkPD2MidlandRanch.Location = controlPositionsHeists[3];
                    chkPD2MountainMaster.Location = controlPositionsHeists[4];
                    chkPD2BlackCat.Location = controlPositionsHeists[5];
                    chkPD2TheUkrainianPrisoner.Location = controlPositionsHeists[6];
                    chkPD2DragonHeist.Location = controlPositionsHeists[7];
                    chkPD2BulucsMansion.Location = controlPositionsHeists[8];
                    chkPD2BreakfastInTijuana.Location = controlPositionsHeists[9];
                    chkPD2SanMartinBank.Location = controlPositionsHeists[10];
                    chkPD2BorderCrystals.Location = controlPositionsHeists[11];
                    chkPD2BorderCrossing.Location = controlPositionsHeists[12];
                    chkPD2TheWhiteHouse.Location = controlPositionsHeists[13];
                    chkPD2NoMercy.Location = controlPositionsHeists[14];
                    chkPD2HellsIsland.Location = controlPositionsHeists[15];
                    chkPD2ShacklethorneAuction.Location = controlPositionsHeists[16];
                    chkPD2HenrysRock.Location = controlPositionsHeists[17];
                    chkPD2BreakinFeds.Location = controlPositionsHeists[18];
                    chkPD2BrooklynBank.Location = controlPositionsHeists[19];
                    chkPD2ReservoirDogsHeist.Location = controlPositionsHeists[20];
                    chkPD2CursedKillRoom.Location = controlPositionsHeists[21];
                    chkPD2DiamondHeist.Location = controlPositionsHeists[22];
                    chkPD2AlaskanDeal.Location = controlPositionsHeists[23];
                    chkPD2GreenBridge.Location = controlPositionsHeists[24];
                    chkPD2HeatStreet.Location = controlPositionsHeists[25];
                    chkPD2TheYachtHeist.Location = controlPositionsHeists[26];
                    chkPD2Brooklyn1010.Location = controlPositionsHeists[27];
                    chkPD2ScarfaceMansion.Location = controlPositionsHeists[28];
                    chkPD2StealingXmas.Location = controlPositionsHeists[29];
                    chkPD2PrisonNightmare.Location = controlPositionsHeists[30];
                    chkPD2PanicRoom.Location = controlPositionsHeists[31];
                    chkPD2SafeHouseRaid.Location = controlPositionsHeists[32];
                    chkPD2TheBikerHeist.Location = controlPositionsHeists[33];
                    chkPD2BoilingPoint.Location = controlPositionsHeists[34];
                    chkPD2MurkyStation.Location = controlPositionsHeists[35];
                    chkPD2Undercover.Location = controlPositionsHeists[36];
                    chkPD2Counterfeit.Location = controlPositionsHeists[37];
                    chkPD2GoatSimulator.Location = controlPositionsHeists[38];
                    chkPD2SantasWorkshop.Location = controlPositionsHeists[39];
                    chkPD2BirthOfSky.Location = controlPositionsHeists[40];
                    chkPD2BeneathTheMountain.Location = controlPositionsHeists[41];
                    chkPD2LabRats.Location = controlPositionsHeists[42];
                    chkPD2Slaughterhouse.Location = controlPositionsHeists[43];
                    chkPD2FirstWorldBank.Location = controlPositionsHeists[44];
                    chkPD2Aftershock.Location = controlPositionsHeists[45];
                    chkPD2GoldenGrinCasino.Location = controlPositionsHeists[46];
                    chkPD2TheAlessoHeist.Location = controlPositionsHeists[47];
                    chkPD2Meltdown.Location = controlPositionsHeists[48];
                    chkPD2HoxtonRevenge.Location = controlPositionsHeists[49];
                    chkPD2CarShop.Location = controlPositionsHeists[50];
                    chkPD2CookOff.Location = controlPositionsHeists[51];
                    chkPD2TheBombForest.Location = controlPositionsHeists[52];
                    chkPD2TheBombDockyard.Location = controlPositionsHeists[53];
                    chkPD2TheDiamond.Location = controlPositionsHeists[54];
                    chkPD2WhiteXmas.Location = controlPositionsHeists[55];
                    chkPD2HoxtonBreakout.Location = controlPositionsHeists[56];
                    chkPD2ArtGallery.Location = controlPositionsHeists[57];
                    chkPD2HotlineMiami.Location = controlPositionsHeists[58];
                    chkPD2TheBigBank.Location = controlPositionsHeists[59];
                    chkPD2ShadowRaid.Location = controlPositionsHeists[60];
                    chkPD2ElectionDay.Location = controlPositionsHeists[61];
                    chkPD2GOBank.Location = controlPositionsHeists[62];
                    chkPD2TransportTrainHeist.Location = controlPositionsHeists[63];
                    chkPD2TransportUnderpass.Location = controlPositionsHeists[64];
                    chkPD2TransportPark.Location = controlPositionsHeists[65];
                    chkPD2TransportHarbor.Location = controlPositionsHeists[66];
                    chkPD2TransportDowntown.Location = controlPositionsHeists[67];
                    chkPD2TransportCrossroads.Location = controlPositionsHeists[68];
                    chkPD2SafeHouseNightmare.Location = controlPositionsHeists[69];
                    chkPD2DiamondStore.Location = controlPositionsHeists[70];
                    chkPD2Rats.Location = controlPositionsHeists[71];
                    chkPD2FramingFrame.Location = controlPositionsHeists[72];
                    chkPD2BigOil.Location = controlPositionsHeists[73];
                    chkPD2Firestarter.Location = controlPositionsHeists[74];
                    chkPD2Watchdogs.Location = controlPositionsHeists[75];
                    chkPD2Nightclub.Location = controlPositionsHeists[76];
                    chkPD2BankHeistRandom.Location = controlPositionsHeists[77];
                    chkPD2BankHeistGold.Location = controlPositionsHeists[78];
                    chkPD2BankHeistDeposit.Location = controlPositionsHeists[79];
                    chkPD2BankHeistCash.Location = controlPositionsHeists[80];
                    chkPD2Mallcrasher.Location = controlPositionsHeists[81];
                    chkPD2UkrainianJob.Location = controlPositionsHeists[82];
                    chkPD2JewelryStore.Location = controlPositionsHeists[83];
                    chkPD2FourStores.Location = controlPositionsHeists[84];
                }
                if (sortMethod == 2)
                {
                    chkPD2Bain.Location = controlPositionsContractors[0];
                    chkPD2BlaineKeegan.Location = controlPositionsContractors[1];
                    chkPD2Classic.Location = controlPositionsContractors[2];
                    chkPD2Event.Location = controlPositionsContractors[3];
                    chkPD2GemmaMCShay.Location = controlPositionsContractors[4];
                    chkPD2Hector.Location = controlPositionsContractors[5];
                    chkPD2Hoxton.Location = controlPositionsContractors[6];
                    chkPD2Jimmy.Location = controlPositionsContractors[7];
                    chkPD2JiuFeng.Location = controlPositionsContractors[8];
                    chkPD2Locke.Location = controlPositionsContractors[9];
                    chkPD2Shayu.Location = controlPositionsContractors[10];
                    chkPD2TheButcher.Location = controlPositionsContractors[11];
                    chkPD2TheContinental.Location = controlPositionsContractors[12];
                    chkPD2TheDentist.Location = controlPositionsContractors[13];
                    chkPD2TheElephant.Location = controlPositionsContractors[14];
                    chkPD2Vlad.Location = controlPositionsContractors[15];
                    chkPD2Aftershock.Location = controlPositionsHeists[0];
                    chkPD2AlaskanDeal.Location = controlPositionsHeists[1];
                    chkPD2ArtGallery.Location = controlPositionsHeists[2];
                    chkPD2BankHeistCash.Location = controlPositionsHeists[3];
                    chkPD2BankHeistDeposit.Location = controlPositionsHeists[4];
                    chkPD2BankHeistGold.Location = controlPositionsHeists[5];
                    chkPD2BankHeistRandom.Location = controlPositionsHeists[6];
                    chkPD2BeneathTheMountain.Location = controlPositionsHeists[7];
                    chkPD2BigOil.Location = controlPositionsHeists[8];
                    chkPD2BirthOfSky.Location = controlPositionsHeists[9];
                    chkPD2BlackCat.Location = controlPositionsHeists[10];
                    chkPD2BoilingPoint.Location = controlPositionsHeists[11];
                    chkPD2BorderCrossing.Location = controlPositionsHeists[12];
                    chkPD2BorderCrystals.Location = controlPositionsHeists[13];
                    chkPD2BreakfastInTijuana.Location = controlPositionsHeists[14];
                    chkPD2BreakinFeds.Location = controlPositionsHeists[15];
                    chkPD2Brooklyn1010.Location = controlPositionsHeists[16];
                    chkPD2BrooklynBank.Location = controlPositionsHeists[17];
                    chkPD2BulucsMansion.Location = controlPositionsHeists[18];
                    chkPD2CarShop.Location = controlPositionsHeists[19];
                    chkPD2CookOff.Location = controlPositionsHeists[20];
                    chkPD2Counterfeit.Location = controlPositionsHeists[21];
                    chkPD2CrudeAwakening.Location = controlPositionsHeists[22];
                    chkPD2CursedKillRoom.Location = controlPositionsHeists[23];
                    chkPD2DiamondHeist.Location = controlPositionsHeists[24];
                    chkPD2DiamondStore.Location = controlPositionsHeists[25];
                    chkPD2DragonHeist.Location = controlPositionsHeists[26];
                    chkPD2ElectionDay.Location = controlPositionsHeists[27];
                    chkPD2Firestarter.Location = controlPositionsHeists[28];
                    chkPD2FirstWorldBank.Location = controlPositionsHeists[29];
                    chkPD2FourStores.Location = controlPositionsHeists[30];
                    chkPD2FramingFrame.Location = controlPositionsHeists[31];
                    chkPD2GOBank.Location = controlPositionsHeists[32];
                    chkPD2GoatSimulator.Location = controlPositionsHeists[33];
                    chkPD2GoldenGrinCasino.Location = controlPositionsHeists[34];
                    chkPD2GreenBridge.Location = controlPositionsHeists[35];
                    chkPD2HeatStreet.Location = controlPositionsHeists[36];
                    chkPD2HellsIsland.Location = controlPositionsHeists[37];
                    chkPD2HenrysRock.Location = controlPositionsHeists[38];
                    chkPD2HostileTakeover.Location = controlPositionsHeists[39];
                    chkPD2HotlineMiami.Location = controlPositionsHeists[40];
                    chkPD2HoxtonBreakout.Location = controlPositionsHeists[41];
                    chkPD2HoxtonRevenge.Location = controlPositionsHeists[42];
                    chkPD2JewelryStore.Location = controlPositionsHeists[43];
                    chkPD2LabRats.Location = controlPositionsHeists[44];
                    chkPD2LostInTransit.Location = controlPositionsHeists[45];
                    chkPD2Mallcrasher.Location = controlPositionsHeists[46];
                    chkPD2Meltdown.Location = controlPositionsHeists[47];
                    chkPD2MidlandRanch.Location = controlPositionsHeists[48];
                    chkPD2MountainMaster.Location = controlPositionsHeists[49];
                    chkPD2MurkyStation.Location = controlPositionsHeists[50];
                    chkPD2Nightclub.Location = controlPositionsHeists[51];
                    chkPD2NoMercy.Location = controlPositionsHeists[52];
                    chkPD2PanicRoom.Location = controlPositionsHeists[53];
                    chkPD2PrisonNightmare.Location = controlPositionsHeists[54];
                    chkPD2Rats.Location = controlPositionsHeists[55];
                    chkPD2ReservoirDogsHeist.Location = controlPositionsHeists[56];
                    chkPD2SafeHouseNightmare.Location = controlPositionsHeists[57];
                    chkPD2SafeHouseRaid.Location = controlPositionsHeists[58];
                    chkPD2SanMartinBank.Location = controlPositionsHeists[59];
                    chkPD2SantasWorkshop.Location = controlPositionsHeists[60];
                    chkPD2ScarfaceMansion.Location = controlPositionsHeists[61];
                    chkPD2ShacklethorneAuction.Location = controlPositionsHeists[62];
                    chkPD2ShadowRaid.Location = controlPositionsHeists[63];
                    chkPD2Slaughterhouse.Location = controlPositionsHeists[64];
                    chkPD2StealingXmas.Location = controlPositionsHeists[65];
                    chkPD2TheAlessoHeist.Location = controlPositionsHeists[66];
                    chkPD2TheBigBank.Location = controlPositionsHeists[67];
                    chkPD2TheBikerHeist.Location = controlPositionsHeists[68];
                    chkPD2TheBombDockyard.Location = controlPositionsHeists[69];
                    chkPD2TheBombForest.Location = controlPositionsHeists[70];
                    chkPD2TheDiamond.Location = controlPositionsHeists[71];
                    chkPD2TheWhiteHouse.Location = controlPositionsHeists[72];
                    chkPD2TheYachtHeist.Location = controlPositionsHeists[73];
                    chkPD2TransportCrossroads.Location = controlPositionsHeists[74];
                    chkPD2TransportDowntown.Location = controlPositionsHeists[75];
                    chkPD2TransportHarbor.Location = controlPositionsHeists[76];
                    chkPD2TransportPark.Location = controlPositionsHeists[77];
                    chkPD2TransportTrainHeist.Location = controlPositionsHeists[78];
                    chkPD2TransportUnderpass.Location = controlPositionsHeists[79];
                    chkPD2UkrainianJob.Location = controlPositionsHeists[80];
                    chkPD2Undercover.Location = controlPositionsHeists[81];
                    chkPD2Watchdogs.Location = controlPositionsHeists[82];
                    chkPD2WhiteXmas.Location = controlPositionsHeists[83];
                    chkPD2TheUkrainianPrisoner.Location = controlPositionsHeists[84];
                }
                if (sortMethod == 3)
                {
                    chkPD2Vlad.Location = controlPositionsContractors[0];
                    chkPD2TheElephant.Location = controlPositionsContractors[1];
                    chkPD2TheDentist.Location = controlPositionsContractors[2];
                    chkPD2TheContinental.Location = controlPositionsContractors[3];
                    chkPD2TheButcher.Location = controlPositionsContractors[4];
                    chkPD2Shayu.Location = controlPositionsContractors[5];
                    chkPD2Locke.Location = controlPositionsContractors[6];
                    chkPD2JiuFeng.Location = controlPositionsContractors[7];
                    chkPD2Jimmy.Location = controlPositionsContractors[8];
                    chkPD2Hoxton.Location = controlPositionsContractors[9];
                    chkPD2Hector.Location = controlPositionsContractors[10];
                    chkPD2GemmaMCShay.Location = controlPositionsContractors[11];
                    chkPD2Event.Location = controlPositionsContractors[12];
                    chkPD2Classic.Location = controlPositionsContractors[13];
                    chkPD2BlaineKeegan.Location = controlPositionsContractors[14];
                    chkPD2Bain.Location = controlPositionsContractors[15];
                    chkPD2TheUkrainianPrisoner.Location = controlPositionsHeists[0];
                    chkPD2WhiteXmas.Location = controlPositionsHeists[1];
                    chkPD2Watchdogs.Location = controlPositionsHeists[2];
                    chkPD2Undercover.Location = controlPositionsHeists[3];
                    chkPD2UkrainianJob.Location = controlPositionsHeists[4];
                    chkPD2TransportUnderpass.Location = controlPositionsHeists[5];
                    chkPD2TransportTrainHeist.Location = controlPositionsHeists[6];
                    chkPD2TransportPark.Location = controlPositionsHeists[7];
                    chkPD2TransportHarbor.Location = controlPositionsHeists[8];
                    chkPD2TransportDowntown.Location = controlPositionsHeists[9];
                    chkPD2TransportCrossroads.Location = controlPositionsHeists[10];
                    chkPD2TheYachtHeist.Location = controlPositionsHeists[11];
                    chkPD2TheWhiteHouse.Location = controlPositionsHeists[12];
                    chkPD2TheDiamond.Location = controlPositionsHeists[13];
                    chkPD2TheBombForest.Location = controlPositionsHeists[14];
                    chkPD2TheBombDockyard.Location = controlPositionsHeists[15];
                    chkPD2TheBikerHeist.Location = controlPositionsHeists[16];
                    chkPD2TheBigBank.Location = controlPositionsHeists[17];
                    chkPD2TheAlessoHeist.Location = controlPositionsHeists[18];
                    chkPD2StealingXmas.Location = controlPositionsHeists[19];
                    chkPD2Slaughterhouse.Location = controlPositionsHeists[20];
                    chkPD2ShadowRaid.Location = controlPositionsHeists[21];
                    chkPD2ShacklethorneAuction.Location = controlPositionsHeists[22];
                    chkPD2ScarfaceMansion.Location = controlPositionsHeists[23];
                    chkPD2SantasWorkshop.Location = controlPositionsHeists[24];
                    chkPD2SanMartinBank.Location = controlPositionsHeists[25];
                    chkPD2SafeHouseRaid.Location = controlPositionsHeists[26];
                    chkPD2SafeHouseNightmare.Location = controlPositionsHeists[27];
                    chkPD2ReservoirDogsHeist.Location = controlPositionsHeists[28];
                    chkPD2Rats.Location = controlPositionsHeists[29];
                    chkPD2PrisonNightmare.Location = controlPositionsHeists[30];
                    chkPD2PanicRoom.Location = controlPositionsHeists[31];
                    chkPD2NoMercy.Location = controlPositionsHeists[32];
                    chkPD2Nightclub.Location = controlPositionsHeists[33];
                    chkPD2MurkyStation.Location = controlPositionsHeists[34];
                    chkPD2MountainMaster.Location = controlPositionsHeists[35];
                    chkPD2MidlandRanch.Location = controlPositionsHeists[36];
                    chkPD2Meltdown.Location = controlPositionsHeists[37];
                    chkPD2Mallcrasher.Location = controlPositionsHeists[38];
                    chkPD2LostInTransit.Location = controlPositionsHeists[39];
                    chkPD2LabRats.Location = controlPositionsHeists[40];
                    chkPD2JewelryStore.Location = controlPositionsHeists[41];
                    chkPD2HoxtonRevenge.Location = controlPositionsHeists[42];
                    chkPD2HoxtonBreakout.Location = controlPositionsHeists[43];
                    chkPD2HotlineMiami.Location = controlPositionsHeists[44];
                    chkPD2HostileTakeover.Location = controlPositionsHeists[45];
                    chkPD2HenrysRock.Location = controlPositionsHeists[46];
                    chkPD2HellsIsland.Location = controlPositionsHeists[47];
                    chkPD2HeatStreet.Location = controlPositionsHeists[48];
                    chkPD2GreenBridge.Location = controlPositionsHeists[49];
                    chkPD2GoldenGrinCasino.Location = controlPositionsHeists[50];
                    chkPD2GoatSimulator.Location = controlPositionsHeists[51];
                    chkPD2GOBank.Location = controlPositionsHeists[52];
                    chkPD2FramingFrame.Location = controlPositionsHeists[53];
                    chkPD2FourStores.Location = controlPositionsHeists[54];
                    chkPD2FirstWorldBank.Location = controlPositionsHeists[55];
                    chkPD2Firestarter.Location = controlPositionsHeists[56];
                    chkPD2ElectionDay.Location = controlPositionsHeists[57];
                    chkPD2DragonHeist.Location = controlPositionsHeists[58];
                    chkPD2DiamondStore.Location = controlPositionsHeists[59];
                    chkPD2DiamondHeist.Location = controlPositionsHeists[60];
                    chkPD2CursedKillRoom.Location = controlPositionsHeists[61];
                    chkPD2CrudeAwakening.Location = controlPositionsHeists[62];
                    chkPD2Counterfeit.Location = controlPositionsHeists[63];
                    chkPD2CookOff.Location = controlPositionsHeists[64];
                    chkPD2CarShop.Location = controlPositionsHeists[65];
                    chkPD2BulucsMansion.Location = controlPositionsHeists[66];
                    chkPD2BrooklynBank.Location = controlPositionsHeists[67];
                    chkPD2Brooklyn1010.Location = controlPositionsHeists[68];
                    chkPD2BreakinFeds.Location = controlPositionsHeists[69];
                    chkPD2BreakfastInTijuana.Location = controlPositionsHeists[70];
                    chkPD2BorderCrystals.Location = controlPositionsHeists[71];
                    chkPD2BorderCrossing.Location = controlPositionsHeists[72];
                    chkPD2BoilingPoint.Location = controlPositionsHeists[73];
                    chkPD2BlackCat.Location = controlPositionsHeists[74];
                    chkPD2BirthOfSky.Location = controlPositionsHeists[75];
                    chkPD2BigOil.Location = controlPositionsHeists[76];
                    chkPD2BeneathTheMountain.Location = controlPositionsHeists[77];
                    chkPD2BankHeistRandom.Location = controlPositionsHeists[78];
                    chkPD2BankHeistGold.Location = controlPositionsHeists[79];
                    chkPD2BankHeistDeposit.Location = controlPositionsHeists[80];
                    chkPD2BankHeistCash.Location = controlPositionsHeists[81];
                    chkPD2ArtGallery.Location = controlPositionsHeists[82];
                    chkPD2AlaskanDeal.Location = controlPositionsHeists[83];
                    chkPD2Aftershock.Location = controlPositionsHeists[84];
                }
                lblMethods.Visible = true;
                lblContractors.Visible = true;
                lblIndivHeists.Visible = true;
                chkPD2Loud.Visible = true;
                chkPD2Hybrid.Visible = true;
                chkPD2Stealth.Visible = true;
                chkPD2Vlad.Visible = true;
                chkPD2Bain.Visible = true;
                chkPD2Hector.Visible = true;
                chkPD2Event.Visible = true;
                chkPD2TheElephant.Visible = true;
                chkPD2TheDentist.Visible = true;
                chkPD2TheButcher.Visible = true;
                chkPD2Classic.Visible = true;
                chkPD2Locke.Visible = true;
                chkPD2Jimmy.Visible = true;
                chkPD2Hoxton.Visible = true;
                chkPD2TheContinental.Visible = true;
                chkPD2JiuFeng.Visible = true;
                chkPD2Shayu.Visible = true;
                chkPD2GemmaMCShay.Visible = true;
                chkPD2BlaineKeegan.Visible = true;
                chkPD2FourStores.Visible = true;
                chkPD2JewelryStore.Visible = true;
                chkPD2UkrainianJob.Visible = true;
                chkPD2Mallcrasher.Visible = true;
                chkPD2BankHeistCash.Visible = true;
                chkPD2BankHeistDeposit.Visible = true;
                chkPD2BankHeistGold.Visible = true;
                chkPD2BankHeistRandom.Visible = true;
                chkPD2Nightclub.Visible = true;
                chkPD2Watchdogs.Visible = true;
                chkPD2Firestarter.Visible = true;
                chkPD2BigOil.Visible = true;
                chkPD2FramingFrame.Visible = true;
                chkPD2Rats.Visible = true;
                chkPD2DiamondStore.Visible = true;
                chkPD2SafeHouseNightmare.Visible = true;
                chkPD2TransportCrossroads.Visible = true;
                chkPD2TransportDowntown.Visible = true;
                chkPD2TransportHarbor.Visible = true;
                chkPD2TransportPark.Visible = true;
                chkPD2TransportUnderpass.Visible = true;
                chkPD2TransportTrainHeist.Visible = true;
                chkPD2GOBank.Visible = true;
                chkPD2ElectionDay.Visible = true;
                chkPD2ShadowRaid.Visible = true;
                chkPD2TheBigBank.Visible = true;
                chkPD2HotlineMiami.Visible = true;
                chkPD2ArtGallery.Visible = true;
                chkPD2HoxtonBreakout.Visible = true;
                chkPD2WhiteXmas.Visible = true;
                chkPD2TheDiamond.Visible = true;
                chkPD2TheBombDockyard.Visible = true;
                chkPD2TheBombForest.Visible = true;
                chkPD2CookOff.Visible = true;
                chkPD2CarShop.Visible = true;
                chkPD2HoxtonRevenge.Visible = true;
                chkPD2Meltdown.Visible = true;
                chkPD2TheAlessoHeist.Visible = true;
                chkPD2GoldenGrinCasino.Visible = true;
                chkPD2Aftershock.Visible = true;
                chkPD2FirstWorldBank.Visible = true;
                chkPD2Slaughterhouse.Visible = true;
                chkPD2LabRats.Visible = true;
                chkPD2BeneathTheMountain.Visible = true;
                chkPD2BirthOfSky.Visible = true;
                chkPD2SantasWorkshop.Visible = true;
                chkPD2GoatSimulator.Visible = true;
                chkPD2Counterfeit.Visible = true;
                chkPD2Undercover.Visible = true;
                chkPD2MurkyStation.Visible = true;
                chkPD2BoilingPoint.Visible = true;
                chkPD2TheBikerHeist.Visible = true;
                chkPD2SafeHouseRaid.Visible = true;
                chkPD2PanicRoom.Visible = true;
                chkPD2PrisonNightmare.Visible = true;
                chkPD2StealingXmas.Visible = true;
                chkPD2ScarfaceMansion.Visible = true;
                chkPD2Brooklyn1010.Visible = true;
                chkPD2TheYachtHeist.Visible = true;
                chkPD2HeatStreet.Visible = true;
                chkPD2GreenBridge.Visible = true;
                chkPD2AlaskanDeal.Visible = true;
                chkPD2DiamondHeist.Visible = true;
                chkPD2CursedKillRoom.Visible = true;
                chkPD2ReservoirDogsHeist.Visible = true;
                chkPD2BrooklynBank.Visible = true;
                chkPD2BreakinFeds.Visible = true;
                chkPD2HenrysRock.Visible = true;
                chkPD2ShacklethorneAuction.Visible = true;
                chkPD2HellsIsland.Visible = true;
                chkPD2NoMercy.Visible = true;
                chkPD2TheWhiteHouse.Visible = true;
                chkPD2BorderCrossing.Visible = true;
                chkPD2BorderCrystals.Visible = true;
                chkPD2SanMartinBank.Visible = true;
                chkPD2BreakfastInTijuana.Visible = true;
                chkPD2BulucsMansion.Visible = true;
                chkPD2DragonHeist.Visible = true;
                chkPD2TheUkrainianPrisoner.Visible = true;
                chkPD2BlackCat.Visible = true;
                chkPD2MountainMaster.Visible = true;
                chkPD2MidlandRanch.Visible = true;
                chkPD2LostInTransit.Visible = true;
                chkPD2HostileTakeover.Visible = true;
                chkPD2CrudeAwakening.Visible = true;
            }
            if (rdoPD3.Checked)
            {
                lblMethods.Location = new Point(6, 3);
                lblContractors.Location = new Point(6, ((25 * numRowsMethod) + 18));
                lblIndivHeists.Location = new Point(6, ((25 * numRowsCon) + (lblContractors.Location.Y + 18)));
                //method conversion
                var methods = new List<string>();

                for (int i = 0; i < PD2n3MethodOrderInfo.GetLength(0); i++)
                {
                    string name = PD2n3MethodOrderInfo[i];
                    methods.Add(name);
                }
                //contractor conversion
                var contractors = new List<string>();

                for (int i = 0; i < PD3ContractorReleaseOrder.GetLength(0); i++)
                {
                    string name = PD3ContractorReleaseOrder[i];
                    contractors.Add(name);
                }
                //heist conversion
                var heists = new List<string>();

                for (int i = 0; i < PD3HeistReleaseOrder.GetLength(0); i++)
                {
                    string name = PD3HeistReleaseOrder[i];
                    heists.Add(name);
                }
                //method math
                int MstartX = lblMethods.Location.X;
                int MstartY = lblMethods.Location.Y + 18;
                int MspacingX = 118;
                int MspacingY = 25;
                int MnumCols = (int)Math.Ceiling((double)methods.Count / numRowsMethod);
                int Mindex = 0;
                for (int col = 0; col < MnumCols; col++)
                {
                    for (int row = 0; row < numRowsMethod; row++)
                    {
                        if (Mindex >= heists.Count)
                            break;

                        int x = MstartX + col * MspacingX;
                        int y = MstartY + row * MspacingY;

                        controlPositionsMethods.Add(new Point(x, y));
                        Mindex++;
                    }
                }
                //contractor math
                int CstartX = lblContractors.Location.X;
                int CstartY = lblContractors.Location.Y + 18;
                int CspacingX = 100;
                int CspacingY = 25;
                int CnumCols = (int)Math.Ceiling((double)contractors.Count / numRowsCon);
                int Cindex = 0;
                for (int col = 0; col < CnumCols; col++)
                {
                    for (int row = 0; row < numRowsCon; row++)
                    {
                        if (Cindex >= heists.Count)
                            break;

                        int x = CstartX + col * CspacingX;
                        int y = CstartY + row * CspacingY;

                        controlPositionsContractors.Add(new Point(x, y));
                        Cindex++;
                    }
                }
                //heist math
                int HstartX = lblIndivHeists.Location.X;
                int HstartY = lblIndivHeists.Location.Y + 18;
                int HspacingX = 152;
                int HspacingY = 25;
                int HnumCols = (int)Math.Ceiling((double)heists.Count / numRowsHeist);
                int Hindex = 0;
                for (int col = 0; col < HnumCols; col++)
                {
                    for (int row = 0; row < numRowsHeist; row++)
                    {
                        if (Hindex >= heists.Count)
                            break;

                        int x = HstartX + col * HspacingX;
                        int y = HstartY + row * HspacingY;

                        controlPositionsHeists.Add(new Point(x, y));
                        Hindex++;
                    }
                }
                //movement

                chkPD3Loud.Location = controlPositionsMethods[0];
                chkPD3Hybrid.Location = controlPositionsMethods[1];
                chkPD3Stealth.Location = controlPositionsMethods[2];
                if (sortMethod == 0)
                {
                    chkPD3Shade.Location = controlPositionsContractors[0];
                    chkPD3Shayu.Location = controlPositionsContractors[1];
                    chkPD3TheButcher.Location = controlPositionsContractors[2];
                    chkPD3Vlad.Location = controlPositionsContractors[3];
                    chkPD3Beckett.Location = controlPositionsContractors[4];
                    chkPD3Mac.Location = controlPositionsContractors[5];
                    chkPD3BlaineKeegan.Location = controlPositionsContractors[6];
                    chkPD3Locke.Location = controlPositionsContractors[7];
                    chkPD3NoRestForTheWicked.Location = controlPositionsHeists[0];
                    chkPD3RoadRage.Location = controlPositionsHeists[1];
                    chkPD3DirtyIce.Location = controlPositionsHeists[2];
                    chkPD3RockTheCradle.Location = controlPositionsHeists[3];
                    chkPD3UnderTheSurphaze.Location = controlPositionsHeists[4];
                    chkPD3GoldNSharke.Location = controlPositionsHeists[5];
                    chkPD399Boxes.Location = controlPositionsHeists[6];
                    chkPD3TouchTheSky.Location = controlPositionsHeists[7];
                    chkPD3TurbidStation.Location = controlPositionsHeists[8];
                    chkPD3CookOff.Location = controlPositionsHeists[9];
                    chkPD3SyntaxError.Location = controlPositionsHeists[10];
                    chkPD3BoysInBlue.Location = controlPositionsHeists[11];
                    chkPD3HoustonBreakout.Location = controlPositionsHeists[12];
                    chkPD3DiamondDistrict.Location = controlPositionsHeists[13];
                    chkPD3FearNGreed.Location = controlPositionsHeists[14];
                    chkPD3FirstWorldBank.Location = controlPositionsHeists[15];
                    chkPD3PartyPowder.Location = controlPositionsHeists[16];
                }
                if (sortMethod == 1)
                {
                    chkPD3Locke.Location = controlPositionsContractors[0];
                    chkPD3BlaineKeegan.Location = controlPositionsContractors[1];
                    chkPD3Mac.Location = controlPositionsContractors[2];
                    chkPD3Beckett.Location = controlPositionsContractors[3];
                    chkPD3Vlad.Location = controlPositionsContractors[4];
                    chkPD3TheButcher.Location = controlPositionsContractors[5];
                    chkPD3Shayu.Location = controlPositionsContractors[6];
                    chkPD3Shade.Location = controlPositionsContractors[7];
                    chkPD3PartyPowder.Location= controlPositionsHeists[0];
                    chkPD3FirstWorldBank.Location = controlPositionsHeists[1];
                    chkPD3FearNGreed.Location = controlPositionsHeists[2];
                    chkPD3DiamondDistrict.Location = controlPositionsHeists[3];
                    chkPD3HoustonBreakout.Location = controlPositionsHeists[4];
                    chkPD3BoysInBlue.Location = controlPositionsHeists[5];
                    chkPD3SyntaxError.Location = controlPositionsHeists[6];
                    chkPD3CookOff.Location = controlPositionsHeists[7];
                    chkPD3TurbidStation.Location = controlPositionsHeists[8];
                    chkPD3TouchTheSky.Location = controlPositionsHeists[9];
                    chkPD399Boxes.Location = controlPositionsHeists[10];
                    chkPD3GoldNSharke.Location = controlPositionsHeists[11];
                    chkPD3UnderTheSurphaze.Location = controlPositionsHeists[12];
                    chkPD3RockTheCradle.Location = controlPositionsHeists[13];
                    chkPD3DirtyIce.Location = controlPositionsHeists[14];
                    chkPD3RoadRage.Location = controlPositionsHeists[15];
                    chkPD3NoRestForTheWicked.Location = controlPositionsHeists[16];
                }
                if (sortMethod == 2)
                {
                    chkPD3Beckett.Location = controlPositionsContractors[0];
                    chkPD3BlaineKeegan.Location = controlPositionsContractors[1];
                    chkPD3Locke.Location = controlPositionsContractors[2];
                    chkPD3Mac.Location = controlPositionsContractors[3];
                    chkPD3Shade.Location = controlPositionsContractors[4];
                    chkPD3Shayu.Location = controlPositionsContractors[5];
                    chkPD3TheButcher.Location = controlPositionsContractors[6];
                    chkPD3Vlad.Location = controlPositionsContractors[7];
                    chkPD399Boxes.Location = controlPositionsHeists[0];
                    chkPD3BoysInBlue.Location = controlPositionsHeists[1];
                    chkPD3CookOff.Location = controlPositionsHeists[2];
                    chkPD3DiamondDistrict.Location = controlPositionsHeists[3];
                    chkPD3DirtyIce.Location = controlPositionsHeists[4];
                    chkPD3FearNGreed.Location = controlPositionsHeists[5];
                    chkPD3FirstWorldBank.Location = controlPositionsHeists[6];
                    chkPD3GoldNSharke.Location = controlPositionsHeists[7];
                    chkPD3HoustonBreakout.Location = controlPositionsHeists[8];
                    chkPD3NoRestForTheWicked.Location = controlPositionsHeists[9];
                    chkPD3PartyPowder.Location = controlPositionsHeists[10];
                    chkPD3RoadRage.Location = controlPositionsHeists[11];
                    chkPD3RockTheCradle.Location = controlPositionsHeists[12];
                    chkPD3SyntaxError.Location = controlPositionsHeists[13];
                    chkPD3TouchTheSky.Location = controlPositionsHeists[14];
                    chkPD3TurbidStation.Location = controlPositionsHeists[15];
                    chkPD3UnderTheSurphaze.Location = controlPositionsHeists[16];
                }
                if (sortMethod == 3)
                {
                    chkPD3Vlad.Location = controlPositionsContractors[0];
                    chkPD3TheButcher.Location = controlPositionsContractors[1];
                    chkPD3Shayu.Location = controlPositionsContractors[2];
                    chkPD3Shade.Location = controlPositionsContractors[3];
                    chkPD3Mac.Location = controlPositionsContractors[4];
                    chkPD3Locke.Location = controlPositionsContractors[5];
                    chkPD3BlaineKeegan.Location = controlPositionsContractors[6];
                    chkPD3Beckett.Location = controlPositionsContractors[7];
                    chkPD3UnderTheSurphaze.Location = controlPositionsHeists[0];
                    chkPD3TurbidStation.Location = controlPositionsHeists[1];
                    chkPD3TouchTheSky.Location = controlPositionsHeists[2];
                    chkPD3SyntaxError.Location = controlPositionsHeists[3];
                    chkPD3RockTheCradle.Location = controlPositionsHeists[4];
                    chkPD3RoadRage.Location = controlPositionsHeists[5];
                    chkPD3PartyPowder.Location = controlPositionsHeists[6];
                    chkPD3NoRestForTheWicked.Location = controlPositionsHeists[7];
                    chkPD3HoustonBreakout.Location = controlPositionsHeists[8];
                    chkPD3GoldNSharke.Location = controlPositionsHeists[9];
                    chkPD3FirstWorldBank.Location = controlPositionsHeists[10];
                    chkPD3FearNGreed.Location = controlPositionsHeists[11];
                    chkPD3DirtyIce.Location = controlPositionsHeists[12];
                    chkPD3DiamondDistrict.Location = controlPositionsHeists[13];
                    chkPD3CookOff.Location = controlPositionsHeists[14];
                    chkPD3BoysInBlue.Location = controlPositionsHeists[15];
                    chkPD399Boxes.Location = controlPositionsHeists[16];
                }
                //visible
                lblMethods.Visible = true;
                lblContractors.Visible = true;
                lblIndivHeists.Visible = true;
                chkPD3Loud.Visible = true;
                chkPD3Hybrid.Visible = true;
                chkPD3Stealth.Visible = true;
                chkPD3Vlad.Visible = true;
                chkPD3TheButcher.Visible = true;
                chkPD3Shayu.Visible = true;
                chkPD3Shade.Visible = true;
                chkPD3Mac.Visible = true;
                chkPD3Locke.Visible = true;
                chkPD3BlaineKeegan.Visible = true;
                chkPD3Beckett.Visible = true;
                chkPD3UnderTheSurphaze.Visible = true;
                chkPD3TurbidStation.Visible = true;
                chkPD3TouchTheSky.Visible = true;
                chkPD3SyntaxError.Visible = true;
                chkPD3RockTheCradle.Visible = true;
                chkPD3RoadRage.Visible = true;
                chkPD3PartyPowder.Visible = true;
                chkPD3NoRestForTheWicked.Visible = true;
                chkPD3HoustonBreakout.Visible = true;
                chkPD3GoldNSharke.Visible = true;
                chkPD3FirstWorldBank.Visible = true;
                chkPD3FearNGreed.Visible = true;
                chkPD3DirtyIce.Visible = true;
                chkPD3DiamondDistrict.Visible = true;
                chkPD3CookOff.Visible = true;
                chkPD3BoysInBlue.Visible = true;
                chkPD399Boxes.Visible = true;
            }
        }
        private void PD2Parity(object sender, EventArgs e)
        {
            PD2Parity();
        }
        private void PD2Parity()// keeps the contractors and methods in line with the heists
        {
            if (chkPD2Aftershock.Checked == true ||
                chkPD2AlaskanDeal.Checked == true ||
                chkPD2BeneathTheMountain.Checked == true ||
                chkPD2BirthOfSky.Checked == true ||
                chkPD2BoilingPoint.Checked == true ||
                chkPD2BorderCrystals.Checked == true ||
                chkPD2Brooklyn1010.Checked == true ||
                chkPD2BrooklynBank.Checked == true ||
                chkPD2CookOff.Checked == true ||
                chkPD2Counterfeit.Checked == true ||
                chkPD2CursedKillRoom.Checked == true ||
                chkPD2GoatSimulator.Checked == true ||
                chkPD2GreenBridge.Checked == true ||
                chkPD2HeatStreet.Checked == true ||
                chkPD2HellsIsland.Checked == true ||
                chkPD2HenrysRock.Checked == true ||
                chkPD2HotlineMiami.Checked == true ||
                chkPD2HoxtonBreakout.Checked == true ||
                chkPD2LabRats.Checked == true ||
                chkPD2Mallcrasher.Checked == true ||
                chkPD2Meltdown.Checked == true ||
                chkPD2NoMercy.Checked == true ||
                chkPD2PanicRoom.Checked == true ||
                chkPD2PrisonNightmare.Checked == true ||
                chkPD2Rats.Checked == true ||
                chkPD2ReservoirDogsHeist.Checked == true ||
                chkPD2SafeHouseNightmare.Checked == true ||
                chkPD2SafeHouseRaid.Checked == true ||
                chkPD2SantasWorkshop.Checked == true ||
                chkPD2Slaughterhouse.Checked == true ||
                chkPD2StealingXmas.Checked == true ||
                chkPD2TheBikerHeist.Checked == true ||
                chkPD2TheBombForest.Checked == true ||
                chkPD2TransportCrossroads.Checked == true ||
                chkPD2TransportDowntown.Checked == true ||
                chkPD2TransportHarbor.Checked == true ||
                chkPD2TransportPark.Checked == true ||
                chkPD2TransportUnderpass.Checked == true ||
                chkPD2Undercover.Checked == true ||
                chkPD2Watchdogs.Checked == true ||
                chkPD2WhiteXmas.Checked == true)
            {
                chkPD2Loud.Checked = true;
            }
            else
            {
                chkPD2Loud.Checked = false;
            }
            if (chkPD2ArtGallery.Checked == true ||
                chkPD2BankHeistCash.Checked == true ||
                chkPD2BankHeistDeposit.Checked == true ||
                chkPD2BankHeistGold.Checked == true ||
                chkPD2BankHeistRandom.Checked == true ||
                chkPD2BigOil.Checked == true ||
                chkPD2BlackCat.Checked == true ||
                chkPD2BorderCrossing.Checked == true ||
                chkPD2BreakfastInTijuana.Checked == true ||
                chkPD2BulucsMansion.Checked == true ||
                chkPD2CrudeAwakening.Checked == true ||
                chkPD2DiamondHeist.Checked == true ||
                chkPD2DiamondStore.Checked == true ||
                chkPD2DragonHeist.Checked == true ||
                chkPD2ElectionDay.Checked == true ||
                chkPD2Firestarter.Checked == true ||
                chkPD2FirstWorldBank.Checked == true ||
                chkPD2FourStores.Checked == true ||
                chkPD2FramingFrame.Checked == true ||
                chkPD2GOBank.Checked == true ||
                chkPD2GoldenGrinCasino.Checked == true ||
                chkPD2HostileTakeover.Checked == true ||
                chkPD2HoxtonRevenge.Checked == true ||
                chkPD2JewelryStore.Checked == true ||
                chkPD2LostInTransit.Checked == true ||
                chkPD2MidlandRanch.Checked == true ||
                chkPD2MountainMaster.Checked == true ||
                chkPD2Nightclub.Checked == true ||
                chkPD2SanMartinBank.Checked == true ||
                chkPD2ScarfaceMansion.Checked == true ||
                chkPD2ShacklethorneAuction.Checked == true ||
                chkPD2TheAlessoHeist.Checked == true ||
                chkPD2TheBigBank.Checked == true ||
                chkPD2TheBombDockyard.Checked == true ||
                chkPD2TheDiamond.Checked == true ||
                chkPD2TheUkrainianPrisoner.Checked == true ||
                chkPD2TheWhiteHouse.Checked == true ||
                chkPD2TransportTrainHeist.Checked == true ||
                chkPD2UkrainianJob.Checked == true)
            {
                chkPD2Hybrid.Checked = true;
            }
            else
            {
                chkPD2Hybrid.Checked = false;
            }
            if (chkPD2BreakinFeds.Checked == true ||
                chkPD2CarShop.Checked == true ||
                chkPD2MurkyStation.Checked == true ||
                chkPD2ShadowRaid.Checked == true ||
                chkPD2TheYachtHeist.Checked == true)
            {
                chkPD2Stealth.Checked = true;
            }
            else
            {
                chkPD2Stealth.Checked = false;
            }
            if (chkPD2ArtGallery.Checked == true ||
                chkPD2BankHeistCash.Checked == true ||
                chkPD2BankHeistDeposit.Checked == true ||
                chkPD2BankHeistGold.Checked == true ||
                chkPD2BankHeistRandom.Checked == true ||
                chkPD2CarShop.Checked == true ||
                chkPD2CookOff.Checked == true ||
                chkPD2DiamondStore.Checked == true ||
                chkPD2GOBank.Checked == true ||
                chkPD2JewelryStore.Checked == true ||
                chkPD2ReservoirDogsHeist.Checked == true ||
                chkPD2ShadowRaid.Checked == true ||
                chkPD2TheAlessoHeist.Checked == true ||
                chkPD2TransportCrossroads.Checked == true ||
                chkPD2TransportDowntown.Checked == true ||
                chkPD2TransportHarbor.Checked == true ||
                chkPD2TransportPark.Checked == true ||
                chkPD2TransportTrainHeist.Checked == true ||
                chkPD2TransportUnderpass.Checked == true)
            {
                chkPD2Bain.Checked = true;
            }
            else
            {
                chkPD2Bain.Checked = false;
            }
            if (chkPD2CrudeAwakening.Checked == true ||
                chkPD2HostileTakeover.Checked == true)
            {
                chkPD2BlaineKeegan.Checked = true;
            }
            else
            {
                chkPD2BlaineKeegan.Checked = false;
            }
            if (chkPD2Counterfeit.Checked == true ||
                chkPD2DiamondHeist.Checked == true ||
                chkPD2FirstWorldBank.Checked == true ||
                chkPD2GreenBridge.Checked == true ||
                chkPD2HeatStreet.Checked == true ||
                chkPD2NoMercy.Checked == true ||
                chkPD2PanicRoom.Checked == true ||
                chkPD2Slaughterhouse.Checked == true ||
                chkPD2Undercover.Checked == true)
            {
                chkPD2Classic.Checked = true;
            }
            else
            {
                chkPD2Classic.Checked = false;
            }
            if (chkPD2CursedKillRoom.Checked == true ||
                chkPD2LabRats.Checked == true ||
                chkPD2PrisonNightmare.Checked == true ||
                chkPD2SafeHouseNightmare.Checked == true)
            {
                chkPD2Event.Checked = true;
            }
            else
            {
                chkPD2Event.Checked = false;
            }
            if (chkPD2MidlandRanch.Checked == true ||
                chkPD2LostInTransit.Checked == true)
            {
                chkPD2GemmaMCShay.Checked = true;
            }
            else
            {
                chkPD2GemmaMCShay.Checked = false;
            }
            if (chkPD2Firestarter.Checked == true ||
                chkPD2Rats.Checked == true ||
                chkPD2Watchdogs.Checked == true)
            {
                chkPD2Hector.Checked = true;
            }
            else
            {
                chkPD2Hector.Checked = false;
            }
            if (chkPD2SafeHouseRaid.Checked == true)
            {
                chkPD2Hoxton.Checked = true;
            }
            else
            {
                chkPD2Hoxton.Checked = false;
            }
            if (chkPD2AlaskanDeal.Checked == true ||
                chkPD2BeneathTheMountain.Checked == true ||
                chkPD2BirthOfSky.Checked == true ||
                chkPD2BorderCrossing.Checked == true ||
                chkPD2BorderCrystals.Checked == true ||
                chkPD2BreakfastInTijuana.Checked == true ||
                chkPD2BreakinFeds.Checked == true ||
                chkPD2BrooklynBank.Checked == true ||
                chkPD2HellsIsland.Checked == true ||
                chkPD2HenrysRock.Checked == true ||
                chkPD2ShacklethorneAuction.Checked == true ||
                chkPD2TheWhiteHouse.Checked == true)
            {
                chkPD2Locke.Checked = true;
            }
            else
            {
                chkPD2Locke.Checked = false;
            }
            if (chkPD2BoilingPoint.Checked == true ||
                chkPD2MurkyStation.Checked == true)
            {
                chkPD2Jimmy.Checked = true;
            }
            else
            {
                chkPD2Jimmy.Checked = false;
            }
            if (chkPD2DragonHeist.Checked == true ||
                chkPD2TheUkrainianPrisoner.Checked == true)
            {
                chkPD2JiuFeng.Checked = true;
            }
            else
            {
                chkPD2JiuFeng.Checked = false;
            }
            if (chkPD2MountainMaster.Checked == true)
            {
                chkPD2Shayu.Checked = true;
            }
            else
            {
                chkPD2Shayu.Checked = false;
            }
            if (chkPD2Brooklyn1010.Checked == true ||
                chkPD2TheYachtHeist.Checked == true)
            {
                chkPD2TheContinental.Checked = true;
            }
            else
            {
                chkPD2TheContinental.Checked = false;
            }
            if (chkPD2ScarfaceMansion.Checked == true ||
                chkPD2TheBombDockyard.Checked == true ||
                chkPD2TheBombForest.Checked == true)
            {
                chkPD2TheButcher.Checked = true;
            }
            else
            {
                chkPD2TheButcher.Checked = false;
            }
            if (chkPD2GoldenGrinCasino.Checked == true ||
                chkPD2HotlineMiami.Checked == true ||
                chkPD2HoxtonRevenge.Checked == true ||
                chkPD2HoxtonRevenge.Checked == true ||
                chkPD2TheBigBank.Checked == true ||
                chkPD2TheDiamond.Checked == true)
            {
                chkPD2TheDentist.Checked = true;
            }
            else
            {
                chkPD2TheDentist.Checked = false;
            }
            if (chkPD2BigOil.Checked == true ||
                chkPD2ElectionDay.Checked == true ||
                chkPD2FramingFrame.Checked == true ||
                chkPD2TheBikerHeist.Checked == true)
            {
                chkPD2TheElephant.Checked = true;
            }
            else
            {
                chkPD2TheElephant.Checked = false;
            }
            if (chkPD2Aftershock.Checked == true ||
                chkPD2BlackCat.Checked == true ||
                chkPD2BulucsMansion.Checked == true ||
                chkPD2FourStores.Checked == true ||
                chkPD2GoatSimulator.Checked == true ||
                chkPD2Mallcrasher.Checked == true ||
                chkPD2Meltdown.Checked == true ||
                chkPD2Nightclub.Checked == true ||
                chkPD2SanMartinBank.Checked == true ||
                chkPD2SantasWorkshop.Checked == true ||
                chkPD2StealingXmas.Checked == true ||
                chkPD2UkrainianJob.Checked == true ||
                chkPD2WhiteXmas.Checked == true)
            {
                chkPD2Vlad.Checked = true;
            }
            else
            {
                chkPD2Vlad.Checked = false;
            }
        }
        private void chkPD2Loud_Click(object sender, EventArgs e)
        {
            if (chkPD2Loud.Checked == true)
            {
                chkPD2Aftershock.Checked = true;
                chkPD2AlaskanDeal.Checked = true;
                chkPD2BeneathTheMountain.Checked = true;
                chkPD2BirthOfSky.Checked = true;
                chkPD2BoilingPoint.Checked = true;
                chkPD2BorderCrystals.Checked = true;
                chkPD2Brooklyn1010.Checked = true;
                chkPD2BrooklynBank.Checked = true;
                chkPD2CookOff.Checked = true;
                chkPD2Counterfeit.Checked = true;
                chkPD2CursedKillRoom.Checked = true;
                chkPD2GoatSimulator.Checked = true;
                chkPD2GreenBridge.Checked = true;
                chkPD2HeatStreet.Checked = true;
                chkPD2HellsIsland.Checked = true;
                chkPD2HenrysRock.Checked = true;
                chkPD2HotlineMiami.Checked = true;
                chkPD2HoxtonBreakout.Checked = true;
                chkPD2LabRats.Checked = true;
                chkPD2Mallcrasher.Checked = true;
                chkPD2Meltdown.Checked = true;
                chkPD2NoMercy.Checked = true;
                chkPD2PanicRoom.Checked = true;
                chkPD2PrisonNightmare.Checked = true;
                chkPD2Rats.Checked = true;
                chkPD2ReservoirDogsHeist.Checked = true;
                chkPD2SafeHouseNightmare.Checked = true;
                chkPD2SafeHouseRaid.Checked = true;
                chkPD2SantasWorkshop.Checked = true;
                chkPD2Slaughterhouse.Checked = true;
                chkPD2StealingXmas.Checked = true;
                chkPD2TheBikerHeist.Checked = true;
                chkPD2TheBombForest.Checked = true;
                chkPD2TransportCrossroads.Checked = true;
                chkPD2TransportDowntown.Checked = true;
                chkPD2TransportHarbor.Checked = true;
                chkPD2TransportPark.Checked = true;
                chkPD2TransportUnderpass.Checked = true;
                chkPD2Undercover.Checked = true;
                chkPD2Watchdogs.Checked = true;
                chkPD2WhiteXmas.Checked = true;
            }
            else
            {
                chkPD2Aftershock.Checked = false;
                chkPD2AlaskanDeal.Checked = false;
                chkPD2BeneathTheMountain.Checked = false;
                chkPD2BirthOfSky.Checked = false;
                chkPD2BoilingPoint.Checked = false;
                chkPD2BorderCrystals.Checked = false;
                chkPD2Brooklyn1010.Checked = false;
                chkPD2BrooklynBank.Checked = false;
                chkPD2CookOff.Checked = false;
                chkPD2Counterfeit.Checked = false;
                chkPD2CursedKillRoom.Checked = false;
                chkPD2GoatSimulator.Checked = false;
                chkPD2GreenBridge.Checked = false;
                chkPD2HeatStreet.Checked = false;
                chkPD2HellsIsland.Checked = false;
                chkPD2HenrysRock.Checked = false;
                chkPD2HotlineMiami.Checked = false;
                chkPD2HoxtonBreakout.Checked = false;
                chkPD2LabRats.Checked = false;
                chkPD2Mallcrasher.Checked = false;
                chkPD2Meltdown.Checked = false;
                chkPD2NoMercy.Checked = false;
                chkPD2PanicRoom.Checked = false;
                chkPD2PrisonNightmare.Checked = false;
                chkPD2Rats.Checked = false;
                chkPD2ReservoirDogsHeist.Checked = false;
                chkPD2SafeHouseNightmare.Checked = false;
                chkPD2SafeHouseRaid.Checked = false;
                chkPD2SantasWorkshop.Checked = false;
                chkPD2Slaughterhouse.Checked = false;
                chkPD2StealingXmas.Checked = false;
                chkPD2TheBikerHeist.Checked = false;
                chkPD2TheBombForest.Checked = false;
                chkPD2TransportCrossroads.Checked = false;
                chkPD2TransportDowntown.Checked = false;
                chkPD2TransportHarbor.Checked = false;
                chkPD2TransportPark.Checked = false;
                chkPD2TransportUnderpass.Checked = false;
                chkPD2Undercover.Checked = false;
                chkPD2Watchdogs.Checked = false;
                chkPD2WhiteXmas.Checked = false;
            }
            PD2Parity();
        }

        private void chkPD2Hybrid_Click(object sender, EventArgs e)
        {
            if (chkPD2Hybrid.Checked == true)
            {
                chkPD2ArtGallery.Checked = true;
                chkPD2BankHeistCash.Checked = true;
                chkPD2BankHeistDeposit.Checked = true;
                chkPD2BankHeistGold.Checked = true;
                chkPD2BankHeistRandom.Checked = true;
                chkPD2BigOil.Checked = true;
                chkPD2BlackCat.Checked = true;
                chkPD2BorderCrossing.Checked = true;
                chkPD2BreakfastInTijuana.Checked = true;
                chkPD2BulucsMansion.Checked = true;
                chkPD2CrudeAwakening.Checked = true;
                chkPD2DiamondHeist.Checked = true;
                chkPD2DiamondStore.Checked = true;
                chkPD2DragonHeist.Checked = true;
                chkPD2ElectionDay.Checked = true;
                chkPD2Firestarter.Checked = true;
                chkPD2FirstWorldBank.Checked = true;
                chkPD2FourStores.Checked = true;
                chkPD2FramingFrame.Checked = true;
                chkPD2GOBank.Checked = true;
                chkPD2GoldenGrinCasino.Checked = true;
                chkPD2HostileTakeover.Checked = true;
                chkPD2HoxtonRevenge.Checked = true;
                chkPD2JewelryStore.Checked = true;
                chkPD2LostInTransit.Checked = true;
                chkPD2MidlandRanch.Checked = true;
                chkPD2MountainMaster.Checked = true;
                chkPD2Nightclub.Checked = true;
                chkPD2SanMartinBank.Checked = true;
                chkPD2ScarfaceMansion.Checked = true;
                chkPD2ShacklethorneAuction.Checked = true;
                chkPD2TheAlessoHeist.Checked = true;
                chkPD2TheBigBank.Checked = true;
                chkPD2TheBombDockyard.Checked = true;
                chkPD2TheDiamond.Checked = true;
                chkPD2TheUkrainianPrisoner.Checked = true;
                chkPD2TheWhiteHouse.Checked = true;
                chkPD2TransportTrainHeist.Checked = true;
                chkPD2UkrainianJob.Checked = true;
            }
            else
            {
                chkPD2ArtGallery.Checked = false;
                chkPD2BankHeistCash.Checked = false;
                chkPD2BankHeistDeposit.Checked = false;
                chkPD2BankHeistGold.Checked = false;
                chkPD2BankHeistRandom.Checked = false;
                chkPD2BigOil.Checked = false;
                chkPD2BlackCat.Checked = false;
                chkPD2BorderCrossing.Checked = false;
                chkPD2BreakfastInTijuana.Checked = false;
                chkPD2BulucsMansion.Checked = false;
                chkPD2CrudeAwakening.Checked = false;
                chkPD2DiamondHeist.Checked = false;
                chkPD2DiamondStore.Checked = false;
                chkPD2DragonHeist.Checked = false;
                chkPD2ElectionDay.Checked = false;
                chkPD2Firestarter.Checked = false;
                chkPD2FirstWorldBank.Checked = false;
                chkPD2FourStores.Checked = false;
                chkPD2FramingFrame.Checked = false;
                chkPD2GOBank.Checked = false;
                chkPD2GoldenGrinCasino.Checked = false;
                chkPD2HostileTakeover.Checked = false;
                chkPD2HoxtonRevenge.Checked = false;
                chkPD2JewelryStore.Checked = false;
                chkPD2LostInTransit.Checked = false;
                chkPD2MidlandRanch.Checked = false;
                chkPD2MountainMaster.Checked = false;
                chkPD2Nightclub.Checked = false;
                chkPD2SanMartinBank.Checked = false;
                chkPD2ScarfaceMansion.Checked = false;
                chkPD2ShacklethorneAuction.Checked = false;
                chkPD2TheAlessoHeist.Checked = false;
                chkPD2TheBigBank.Checked = false;
                chkPD2TheBombDockyard.Checked = false;
                chkPD2TheDiamond.Checked = false;
                chkPD2TheUkrainianPrisoner.Checked = false;
                chkPD2TheWhiteHouse.Checked = false;
                chkPD2TransportTrainHeist.Checked = false;
                chkPD2UkrainianJob.Checked = false;
            }
            PD2Parity();
        }

        private void chkPD2Stealth_Click(object sender, EventArgs e)
        {
            if (chkPD2Stealth.Checked == true)
            {
                chkPD2BreakinFeds.Checked = true;
                chkPD2CarShop.Checked = true;
                chkPD2MurkyStation.Checked = true;
                chkPD2ShadowRaid.Checked = true;
                chkPD2TheYachtHeist.Checked = true;
            }
            else
            {
                chkPD2BreakinFeds.Checked = false;
                chkPD2CarShop.Checked = false;
                chkPD2MurkyStation.Checked = false;
                chkPD2ShadowRaid.Checked = false;
                chkPD2TheYachtHeist.Checked = false;
            }
            PD2Parity();
        }

        private void chkPD2Vlad_Click(object sender, EventArgs e)
        {
            if (chkPD2Vlad.Checked == true)
            {
                chkPD2Aftershock.Checked = true;
                chkPD2BlackCat.Checked = true;
                chkPD2BulucsMansion.Checked = true;
                chkPD2FourStores.Checked = true;
                chkPD2GoatSimulator.Checked = true;
                chkPD2Mallcrasher.Checked = true;
                chkPD2Meltdown.Checked = true;
                chkPD2Nightclub.Checked = true;
                chkPD2SanMartinBank.Checked = true;
                chkPD2SantasWorkshop.Checked = true;
                chkPD2StealingXmas.Checked = true;
                chkPD2UkrainianJob.Checked = true;
                chkPD2WhiteXmas.Checked = true;
            }
            else
            {
                chkPD2Aftershock.Checked = false;
                chkPD2BlackCat.Checked = false;
                chkPD2BulucsMansion.Checked = false;
                chkPD2FourStores.Checked = false;
                chkPD2GoatSimulator.Checked = false;
                chkPD2Mallcrasher.Checked = false;
                chkPD2Meltdown.Checked = false;
                chkPD2Nightclub.Checked = false;
                chkPD2SanMartinBank.Checked = false;
                chkPD2SantasWorkshop.Checked = false;
                chkPD2StealingXmas.Checked = false;
                chkPD2UkrainianJob.Checked = false;
                chkPD2WhiteXmas.Checked = false;
            }
            PD2Parity();
        }

        private void chkPD2Bain_Click(object sender, EventArgs e)
        {
            if (chkPD2Bain.Checked == true)
            {
                chkPD2ArtGallery.Checked = true;
                chkPD2BankHeistCash.Checked = true;
                chkPD2BankHeistDeposit.Checked = true;
                chkPD2BankHeistGold.Checked = true;
                chkPD2BankHeistRandom.Checked = true;
                chkPD2CarShop.Checked = true;
                chkPD2CookOff.Checked = true;
                chkPD2DiamondStore.Checked = true;
                chkPD2GOBank.Checked = true;
                chkPD2JewelryStore.Checked = true;
                chkPD2ReservoirDogsHeist.Checked = true;
                chkPD2ShadowRaid.Checked = true;
                chkPD2TheAlessoHeist.Checked = true;
                chkPD2TransportCrossroads.Checked = true;
                chkPD2TransportDowntown.Checked = true;
                chkPD2TransportHarbor.Checked = true;
                chkPD2TransportPark.Checked = true;
                chkPD2TransportTrainHeist.Checked = true;
                chkPD2TransportUnderpass.Checked = true;
            }
            else
            {
                chkPD2ArtGallery.Checked = false;
                chkPD2BankHeistCash.Checked = false;
                chkPD2BankHeistDeposit.Checked = false;
                chkPD2BankHeistGold.Checked = false;
                chkPD2BankHeistRandom.Checked = false;
                chkPD2CarShop.Checked = false;
                chkPD2CookOff.Checked = false;
                chkPD2DiamondStore.Checked = false;
                chkPD2GOBank.Checked = false;
                chkPD2JewelryStore.Checked = false;
                chkPD2ReservoirDogsHeist.Checked = false;
                chkPD2ShadowRaid.Checked = false;
                chkPD2TheAlessoHeist.Checked = false;
                chkPD2TransportCrossroads.Checked = false;
                chkPD2TransportDowntown.Checked = false;
                chkPD2TransportHarbor.Checked = false;
                chkPD2TransportPark.Checked = false;
                chkPD2TransportTrainHeist.Checked = false;
                chkPD2TransportUnderpass.Checked = false;
            }
            PD2Parity();
        }

        private void chkPD2Hector_Click(object sender, EventArgs e)
        {
            if (chkPD2Hector.Checked == true)
            {
                chkPD2Firestarter.Checked = true;
                chkPD2Rats.Checked = true;
                chkPD2Watchdogs.Checked = true;
            }
            else
            {
                chkPD2Firestarter.Checked = false;
                chkPD2Rats.Checked = false;
                chkPD2Watchdogs.Checked = false;
            }
            PD2Parity();
        }

        private void chkPD2Event_Click(object sender, EventArgs e)
        {
            if (chkPD2Event.Checked == true)
            {
                chkPD2CursedKillRoom.Checked = true;
                chkPD2LabRats.Checked = true;
                chkPD2PrisonNightmare.Checked = true;
                chkPD2SafeHouseNightmare.Checked = true;
            }
            else
            {
                chkPD2CursedKillRoom.Checked = false;
                chkPD2LabRats.Checked = false;
                chkPD2PrisonNightmare.Checked = false;
                chkPD2SafeHouseNightmare.Checked = false;
            }
            PD2Parity();
        }

        private void chkPD2TheElephant_Click(object sender, EventArgs e)
        {
            if (chkPD2TheElephant.Checked == true)
            {
                chkPD2BigOil.Checked = true;
                chkPD2ElectionDay.Checked = true;
                chkPD2FramingFrame.Checked = true;
                chkPD2TheBikerHeist.Checked = true;
            }
            else
            {
                chkPD2BigOil.Checked = false;
                chkPD2ElectionDay.Checked = false;
                chkPD2FramingFrame.Checked = false;
                chkPD2TheBikerHeist.Checked = false;
            }
            PD2Parity();
        }

        private void chkPD2TheDentist_Click(object sender, EventArgs e)
        {
            if (chkPD2TheDentist.Checked == true)
            {
                chkPD2GoldenGrinCasino.Checked = true;
                chkPD2HotlineMiami.Checked = true;
                chkPD2HoxtonRevenge.Checked = true;
                chkPD2HoxtonRevenge.Checked = true;
                chkPD2TheBigBank.Checked = true;
                chkPD2TheDiamond.Checked = true;
            }
            else
            {
                chkPD2GoldenGrinCasino.Checked = false;
                chkPD2HotlineMiami.Checked = false;
                chkPD2HoxtonRevenge.Checked = false;
                chkPD2HoxtonRevenge.Checked = false;
                chkPD2TheBigBank.Checked = false;
                chkPD2TheDiamond.Checked = false;
            }
            PD2Parity();
        }

        private void chkPD2TheButcher_Click(object sender, EventArgs e)
        {
            if (chkPD2TheButcher.Checked == true)
            {
                chkPD2ScarfaceMansion.Checked = true;
                chkPD2TheBombDockyard.Checked = true;
                chkPD2TheBombForest.Checked = true;
            }
            else
            {
                chkPD2ScarfaceMansion.Checked = false;
                chkPD2TheBombDockyard.Checked = false;
                chkPD2TheBombForest.Checked = false;
            }
            PD2Parity();
        }

        private void chkPD2Classic_Click(object sender, EventArgs e)
        {
            if (chkPD2Classic.Checked == true)
            {
                chkPD2Counterfeit.Checked = true;
                chkPD2DiamondHeist.Checked = true;
                chkPD2FirstWorldBank.Checked = true;
                chkPD2GreenBridge.Checked = true;
                chkPD2HeatStreet.Checked = true;
                chkPD2NoMercy.Checked = true;
                chkPD2PanicRoom.Checked = true;
                chkPD2Slaughterhouse.Checked = true;
                chkPD2Undercover.Checked = true;
            }
            else
            {
                chkPD2Counterfeit.Checked = false;
                chkPD2DiamondHeist.Checked = false;
                chkPD2FirstWorldBank.Checked = false;
                chkPD2GreenBridge.Checked = false;
                chkPD2HeatStreet.Checked = false;
                chkPD2NoMercy.Checked = false;
                chkPD2PanicRoom.Checked = false;
                chkPD2Slaughterhouse.Checked = false;
                chkPD2Undercover.Checked = false;
            }
            PD2Parity();
        }

        private void chkPD2Locke_Click(object sender, EventArgs e)
        {
            if (chkPD2Locke.Checked == true)
            {
                chkPD2AlaskanDeal.Checked = true;
                chkPD2BeneathTheMountain.Checked = true;
                chkPD2BirthOfSky.Checked = true;
                chkPD2BorderCrossing.Checked = true;
                chkPD2BorderCrystals.Checked = true;
                chkPD2BreakfastInTijuana.Checked = true;
                chkPD2BreakinFeds.Checked = true;
                chkPD2BrooklynBank.Checked = true;
                chkPD2HellsIsland.Checked = true;
                chkPD2HenrysRock.Checked = true;
                chkPD2ShacklethorneAuction.Checked = true;
                chkPD2TheWhiteHouse.Checked = true;
            }
            else
            {
                chkPD2AlaskanDeal.Checked = false;
                chkPD2BeneathTheMountain.Checked = false;
                chkPD2BirthOfSky.Checked = false;
                chkPD2BorderCrossing.Checked = false;
                chkPD2BorderCrystals.Checked = false;
                chkPD2BreakfastInTijuana.Checked = false;
                chkPD2BreakinFeds.Checked = false;
                chkPD2BrooklynBank.Checked = false;
                chkPD2HellsIsland.Checked = false;
                chkPD2HenrysRock.Checked = false;
                chkPD2ShacklethorneAuction.Checked = false;
                chkPD2TheWhiteHouse.Checked = false;
            }
            PD2Parity();
        }

        private void chkPD2Jimmy_Click(object sender, EventArgs e)
        {
            if (chkPD2Jimmy.Checked)
            {
                chkPD2BoilingPoint.Checked = true;
                chkPD2MurkyStation.Checked = true;
            }
            else
            {
                chkPD2BoilingPoint.Checked = false;
                chkPD2MurkyStation.Checked = false;
            }
            PD2Parity();
        }

        private void chkPD2Hoxton_Click(object sender, EventArgs e)
        {
            if (chkPD2Hoxton.Checked == true)
            {
                chkPD2SafeHouseRaid.Checked = true;
            }
            else
            {
                chkPD2SafeHouseRaid.Checked = false;
            }
            PD2Parity();
        }

        private void chkPD2TheContinental_Click(object sender, EventArgs e)
        {
            if (chkPD2TheContinental.Checked == true)
            {
                chkPD2Brooklyn1010.Checked = true;
                chkPD2TheYachtHeist.Checked = true;
            }
            else
            {
                chkPD2Brooklyn1010.Checked = false;
                chkPD2TheYachtHeist.Checked = false;
            }
            PD2Parity();
        }

        private void chkPD2JiuFeng_Click(object sender, EventArgs e)
        {
            if (chkPD2JiuFeng.Checked == true)
            {
                chkPD2DragonHeist.Checked = true;
                chkPD2TheUkrainianPrisoner.Checked = true;
            }
            else
            {
                chkPD2DragonHeist.Checked = false;
                chkPD2TheUkrainianPrisoner.Checked = false;
            }
            PD2Parity();
        }

        private void chkPD2Shayu_Click(object sender, EventArgs e)
        {
            if (chkPD2Shayu.Checked == true)
            {
                chkPD2MountainMaster.Checked = true;
            }
            else
            {
                chkPD2MountainMaster.Checked = false;
            }
            PD2Parity();
        }

        private void chkPD2GemmaMCShay_Click(object sender, EventArgs e)
        {
            if (chkPD2GemmaMCShay.Checked == true)
            {
                chkPD2MidlandRanch.Checked = true;
                chkPD2LostInTransit.Checked = true;
            }
            else
            {
                chkPD2MidlandRanch.Checked = false;
                chkPD2LostInTransit.Checked = false;
            }
            PD2Parity();
        }

        private void chkPD2BlaineKeegan_Click(object sender, EventArgs e)
        {
            if (chkPD2BlaineKeegan.Checked == true)
            {
                chkPD2HostileTakeover.Checked = true;
                chkPD2CrudeAwakening.Checked = true;
            }
            else
            {
                chkPD2HostileTakeover.Checked = false;
                chkPD2CrudeAwakening.Checked = false;
            }
            PD2Parity();
        }

        private void PD3Parity(object sender, EventArgs e)
        {
            PD3Parity();
        }
        private void PD3Parity()// keeps the contractors and methods in line with the heists
        {
            if (chkPD3RoadRage.Checked == true ||
                chkPD3CookOff.Checked == true)
            {
                chkPD3Loud.Checked = true;
            }
            else
            {
                chkPD3Loud.Checked = false;
            }
            if (chkPD3NoRestForTheWicked.Checked == true ||
                chkPD3DirtyIce.Checked == true ||
                chkPD3RockTheCradle.Checked == true ||
                chkPD3UnderTheSurphaze.Checked == true ||
                chkPD3GoldNSharke.Checked == true ||
                chkPD399Boxes.Checked == true ||
                chkPD3TouchTheSky.Checked == true ||
                chkPD3SyntaxError.Checked == true ||
                chkPD3BoysInBlue.Checked == true ||
                chkPD3HoustonBreakout.Checked == true ||
                chkPD3DiamondDistrict.Checked == true ||
                chkPD3FearNGreed.Checked == true ||
                chkPD3FirstWorldBank.Checked == true ||
                chkPD3PartyPowder.Checked == true)
            {
                chkPD3Hybrid.Checked = true;
            }
            else
            {
                chkPD3Hybrid.Checked = false;
            }
            if (chkPD3TurbidStation.Checked == true)
            {
                chkPD3Stealth.Checked = true;
            }
            else
            {
                chkPD3Stealth.Checked = false;
            }
            if (chkPD3NoRestForTheWicked.Checked == true ||
                chkPD3GoldNSharke.Checked == true ||
                chkPD3HoustonBreakout.Checked == true ||
                chkPD3FearNGreed.Checked == true)
            {
                chkPD3Shade.Checked = true;
            }
            else
            {
                chkPD3Shade.Checked = false;
            }
            if (chkPD3RoadRage.Checked == true ||
                chkPD3PartyPowder.Checked == true)
            {
                chkPD3Shayu.Checked = true;
            }
            else
            {
                chkPD3Shayu.Checked = false;
            }
            if (chkPD3DirtyIce.Checked == true ||
                chkPD3SyntaxError.Checked == true)
            {
                chkPD3TheButcher.Checked = true;
            }
            else
            {
                chkPD3TheButcher.Checked = false;
            }
            if (chkPD3RockTheCradle.Checked == true ||
                chkPD3BoysInBlue.Checked == true)
            {
                chkPD3Vlad.Checked = true;
            }
            else
            {
                chkPD3Vlad.Checked = false;
            }
            if (chkPD3UnderTheSurphaze.Checked == true ||
                chkPD3DiamondDistrict.Checked == true)
            {
                chkPD3Beckett.Checked = true;
            }
            else
            {
                chkPD3Beckett.Checked = false;
            }
            if (chkPD399Boxes.Checked == true)
            {
                chkPD3Mac.Checked = true;
            }
            else
            {
                chkPD3Mac.Checked = false;
            }
            if (chkPD3TouchTheSky.Checked == true)
            {
                chkPD3BlaineKeegan.Checked = true;
            }
            else
            {
                chkPD3BlaineKeegan.Checked = false;
            }
            if (chkPD3TurbidStation.Checked == true ||
                chkPD3CookOff.Checked == true ||
                chkPD3FirstWorldBank.Checked == true)
            {
                chkPD3Locke.Checked = true;
            }
            else
            {
                chkPD3Locke.Checked = false;
            }
        }

        private void chkLoud_Click(object sender, EventArgs e)
        {
            if (chkPD3Loud.Checked == true)
            {
                chkPD3RoadRage.Checked = true;
                chkPD3CookOff.Checked = true;
            }
            else
            {
                chkPD3RoadRage.Checked = false;
                chkPD3CookOff.Checked = false;
            }
            PD3Parity();
        }
        private void chkHybrid_Click(object sender, EventArgs e)
        {
            if (chkPD3Hybrid.Checked == true)
            {
                chkPD3NoRestForTheWicked.Checked = true;
                chkPD3DirtyIce.Checked = true;
                chkPD3RockTheCradle.Checked = true;
                chkPD3UnderTheSurphaze.Checked = true;
                chkPD3GoldNSharke.Checked = true;
                chkPD399Boxes.Checked = true;
                chkPD3TouchTheSky.Checked = true;
                chkPD3SyntaxError.Checked = true;
                chkPD3BoysInBlue.Checked = true;
                chkPD3HoustonBreakout.Checked = true;
                chkPD3DiamondDistrict.Checked = true;
                chkPD3FearNGreed.Checked = true;
                chkPD3FirstWorldBank.Checked = true;
                chkPD3PartyPowder.Checked = true;
            }
            else
            {
                chkPD3NoRestForTheWicked.Checked = false;
                chkPD3DirtyIce.Checked = false;
                chkPD3RockTheCradle.Checked = false;
                chkPD3UnderTheSurphaze.Checked = false;
                chkPD3GoldNSharke.Checked = false;
                chkPD399Boxes.Checked = false;
                chkPD3TouchTheSky.Checked = false;
                chkPD3SyntaxError.Checked = false;
                chkPD3BoysInBlue.Checked = false;
                chkPD3HoustonBreakout.Checked = false;
                chkPD3DiamondDistrict.Checked = false;
                chkPD3FearNGreed.Checked = false;
                chkPD3FirstWorldBank.Checked = false;
                chkPD3PartyPowder.Checked = false;
            }
            PD3Parity();
        }

        private void chkStealth_Click(object sender, EventArgs e)
        {
            if (chkPD3Stealth.Checked == true)
            {
                chkPD3TurbidStation.Checked = true;
            }
            else
            {
                chkPD3TurbidStation.Checked = false;
            }
            PD3Parity();
        }

        private void chkPD3Shade_Click(object sender, EventArgs e)
        {
            if (chkPD3Shade.Checked == true)
            {
                chkPD3NoRestForTheWicked.Checked = true;
                chkPD3GoldNSharke.Checked = true;
                chkPD3HoustonBreakout.Checked = true;
                chkPD3FearNGreed.Checked = true;
            }
            else
            {
                chkPD3NoRestForTheWicked.Checked = false;
                chkPD3GoldNSharke.Checked = false;
                chkPD3HoustonBreakout.Checked = false;
                chkPD3FearNGreed.Checked = false;
            }
            PD3Parity();
        }

        private void chkPD3Shayu_Click(object sender, EventArgs e)
        {
            if (chkPD3Shayu.Checked == true)
            {
                chkPD3RoadRage.Checked = true;
                chkPD3PartyPowder.Checked = true;
            }
            else
            {
                chkPD3RoadRage.Checked = false;
                chkPD3PartyPowder.Checked= false;
            }
            PD3Parity();
        }

        private void chkPD3TheButcher_Click(object sender, EventArgs e)
        {
            if (chkPD3TheButcher.Checked == true)
            {
                chkPD3DirtyIce.Checked = true;
                chkPD3SyntaxError.Checked = true;
            }
            else
            {
                chkPD3DirtyIce.Checked = false;
                chkPD3SyntaxError.Checked = false;
            }
            PD3Parity();
        }

        private void chkPD3Vlad_Click(object sender, EventArgs e)
        {
            if (chkPD3Vlad.Checked == true)
            {
                chkPD3RockTheCradle.Checked = true;
                chkPD3BoysInBlue.Checked = true;
            }
            else
            {
                chkPD3RockTheCradle.Checked = false;
                chkPD3BoysInBlue.Checked = false;
            }
            PD3Parity();
        }

        private void chkPD3Beckett_Click(object sender, EventArgs e)
        {
            if (chkPD3Beckett.Checked == true)
            {
                chkPD3UnderTheSurphaze.Checked = true;
                chkPD3DiamondDistrict.Checked = true;
            }
            else
            {
                chkPD3UnderTheSurphaze.Checked = false;
                chkPD3DiamondDistrict.Checked = false;
            }
            PD3Parity();
        }

        private void chkPD3Mac_Click(object sender, EventArgs e)
        {
            if (chkPD3Mac.Checked == true)
            {
                chkPD399Boxes.Checked = true;
            }
            else
            {
                chkPD399Boxes.Checked = false;
            }
            PD3Parity();
        }

        private void chkPD3BlaineKeegan_Click(object sender, EventArgs e)
        {
            if (chkPD3BlaineKeegan.Checked == true)
            {
                chkPD3TouchTheSky.Checked = true;
            }
            else
            {
                chkPD3TouchTheSky.Checked = false;
            }
            PD3Parity();
        }

        private void chkPD3Locke_Click(object sender, EventArgs e)
        {
            if (chkPD3Locke.Checked == true)
            {
                chkPD3TurbidStation.Checked = true;
                chkPD3CookOff.Checked = true;
                chkPD3FirstWorldBank.Checked = true;
            }
            else
            {
                chkPD3TurbidStation.Checked = false;
                chkPD3CookOff.Checked = false;
                chkPD3FirstWorldBank.Checked = false;
            }
            PD3Parity();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"The only thing that is accounted for when rolling for a heist is what check boxes are checked in the Individual Heists section, the Contractors and Methods are not used directly by the roller.\n\n" +
                            $"You can set how many rows are in each section individually. The defaults are 1, 4, and 8 from top to bottom, this is a remnant from when this project was being made in Scratch.\n\n" +
                            $"If you'd wish to have each section be perfect squares/rectangles then I have a list of factors you can use:\nMethods: (1,3)\nPayday 2's contractors: (1,16), (2,8), (4,4)\nPayday 2's heists: (1,85), (5,17)\nPayday 3's contractors: (1,8), (2,4)\nPayday 3's heists: (1,17)\n\n" +
                            $"Like all my projects this will be updated based on how much I'm into the thing it's based on.", "Documentation");
        }

        private void btnSaveCSV_Click(object sender, EventArgs e)
        {
            string homeDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string expectedFolder = "PDRHS Prefrences Files";
            string expectedFolderPath = Path.Combine(homeDirectory, expectedFolder);
            if (!Directory.Exists(expectedFolderPath))
            {
                Directory.CreateDirectory(expectedFolderPath);
            }
            string saveData = ""; //i'll pry make it not hard coded eventually but this'll do for now
            saveData += $"{numRowsMethod}\n";
            saveData += $"{numRowsCon}\n";
            saveData += $"{numRowsHeist}\n";
            saveData += $"{sortMethod}\n";
            saveData += $"{theme}\n";
            saveData += $"{chkPDTHCounterfeit.Checked}\n";
            saveData += $"{chkPDTHDiamondHeist.Checked}\n";
            saveData += $"{chkPDTHFirstWorldBank.Checked}\n";
            saveData += $"{chkPDTHGreenBridge.Checked}\n";
            saveData += $"{chkPDTHHeatStreet.Checked}\n";
            saveData += $"{chkPDTHNoMercy.Checked}\n";
            saveData += $"{chkPDTHPanicRoom.Checked}\n";
            saveData += $"{chkPDTHSlaughterhouse.Checked}\n";
            saveData += $"{chkPDTHUndercover.Checked}\n";
            saveData += $"{chkPD2Aftershock.Checked}\n";
            saveData += $"{chkPD2AlaskanDeal.Checked}\n";
            saveData += $"{chkPD2ArtGallery.Checked}\n";
            saveData += $"{chkPD2Bain.Checked}\n";
            saveData += $"{chkPD2BankHeistCash.Checked}\n";
            saveData += $"{chkPD2BankHeistDeposit.Checked}\n";
            saveData += $"{chkPD2BankHeistGold.Checked}\n";
            saveData += $"{chkPD2BankHeistRandom.Checked}\n";
            saveData += $"{chkPD2BeneathTheMountain.Checked}\n";
            saveData += $"{chkPD2BigOil.Checked}\n";
            saveData += $"{chkPD2BirthOfSky.Checked}\n";
            saveData += $"{chkPD2BlackCat.Checked}\n";
            saveData += $"{chkPD2BlaineKeegan.Checked}\n";
            saveData += $"{chkPD2BoilingPoint.Checked}\n";
            saveData += $"{chkPD2BorderCrossing.Checked}\n";
            saveData += $"{chkPD2BorderCrystals.Checked}\n";
            saveData += $"{chkPD2BreakfastInTijuana.Checked}\n";
            saveData += $"{chkPD2BreakinFeds.Checked}\n";
            saveData += $"{chkPD2Brooklyn1010.Checked}\n";
            saveData += $"{chkPD2BrooklynBank.Checked}\n";
            saveData += $"{chkPD2BulucsMansion.Checked}\n";
            saveData += $"{chkPD2CarShop.Checked}\n";
            saveData += $"{chkPD2Classic.Checked}\n";
            saveData += $"{chkPD2CookOff.Checked}\n";
            saveData += $"{chkPD2Counterfeit.Checked}\n";
            saveData += $"{chkPD2CrudeAwakening.Checked}\n";
            saveData += $"{chkPD2CursedKillRoom.Checked}\n";
            saveData += $"{chkPD2DiamondHeist.Checked}\n";
            saveData += $"{chkPD2DiamondStore.Checked}\n";
            saveData += $"{chkPD2DragonHeist.Checked}\n";
            saveData += $"{chkPD2ElectionDay.Checked}\n";
            saveData += $"{chkPD2Event.Checked}\n";
            saveData += $"{chkPD2Firestarter.Checked}\n";
            saveData += $"{chkPD2FirstWorldBank.Checked}\n";
            saveData += $"{chkPD2FourStores.Checked}\n";
            saveData += $"{chkPD2FramingFrame.Checked}\n";
            saveData += $"{chkPD2GemmaMCShay.Checked}\n";
            saveData += $"{chkPD2GoatSimulator.Checked}\n";
            saveData += $"{chkPD2GOBank.Checked}\n";
            saveData += $"{chkPD2GoldenGrinCasino.Checked}\n";
            saveData += $"{chkPD2GreenBridge.Checked}\n";
            saveData += $"{chkPD2HeatStreet.Checked}\n";
            saveData += $"{chkPD2Hector.Checked}\n";
            saveData += $"{chkPD2HellsIsland.Checked}\n";
            saveData += $"{chkPD2HenrysRock.Checked}\n";
            saveData += $"{chkPD2HostileTakeover.Checked}\n";
            saveData += $"{chkPD2HotlineMiami.Checked}\n";
            saveData += $"{chkPD2Hoxton.Checked}\n";
            saveData += $"{chkPD2HoxtonBreakout.Checked}\n";
            saveData += $"{chkPD2HoxtonRevenge.Checked}\n";
            saveData += $"{chkPD2Hybrid.Checked}\n";
            saveData += $"{chkPD2JewelryStore.Checked}\n";
            saveData += $"{chkPD2Jimmy.Checked}\n";
            saveData += $"{chkPD2JiuFeng.Checked}\n";
            saveData += $"{chkPD2LabRats.Checked}\n";
            saveData += $"{chkPD2Locke.Checked}\n";
            saveData += $"{chkPD2LostInTransit.Checked}\n";
            saveData += $"{chkPD2Loud.Checked}\n";
            saveData += $"{chkPD2Mallcrasher.Checked}\n";
            saveData += $"{chkPD2Meltdown.Checked}\n";
            saveData += $"{chkPD2MidlandRanch.Checked}\n";
            saveData += $"{chkPD2MountainMaster.Checked}\n";
            saveData += $"{chkPD2MurkyStation.Checked}\n";
            saveData += $"{chkPD2Nightclub.Checked}\n";
            saveData += $"{chkPD2NoMercy.Checked}\n";
            saveData += $"{chkPD2PanicRoom.Checked}\n";
            saveData += $"{chkPD2PrisonNightmare.Checked}\n";
            saveData += $"{chkPD2Rats.Checked}\n";
            saveData += $"{chkPD2ReservoirDogsHeist.Checked}\n";
            saveData += $"{chkPD2SafeHouseNightmare.Checked}\n";
            saveData += $"{chkPD2SafeHouseRaid.Checked}\n";
            saveData += $"{chkPD2SanMartinBank.Checked}\n";
            saveData += $"{chkPD2SantasWorkshop.Checked}\n";
            saveData += $"{chkPD2ScarfaceMansion.Checked}\n";
            saveData += $"{chkPD2ShacklethorneAuction.Checked}\n";
            saveData += $"{chkPD2ShadowRaid.Checked}\n";
            saveData += $"{chkPD2Shayu.Checked}\n";
            saveData += $"{chkPD2Slaughterhouse.Checked}\n";
            saveData += $"{chkPD2StealingXmas.Checked}\n";
            saveData += $"{chkPD2Stealth.Checked}\n";
            saveData += $"{chkPD2TheAlessoHeist.Checked}\n";
            saveData += $"{chkPD2TheBigBank.Checked}\n";
            saveData += $"{chkPD2TheBikerHeist.Checked}\n";
            saveData += $"{chkPD2TheBombDockyard.Checked}\n";
            saveData += $"{chkPD2TheBombForest.Checked}\n";
            saveData += $"{chkPD2TheButcher.Checked}\n";
            saveData += $"{chkPD2TheContinental.Checked}\n";
            saveData += $"{chkPD2TheDentist.Checked}\n";
            saveData += $"{chkPD2TheDiamond.Checked}\n";
            saveData += $"{chkPD2TheElephant.Checked}\n";
            saveData += $"{chkPD2TheUkrainianPrisoner.Checked}\n";
            saveData += $"{chkPD2TheWhiteHouse.Checked}\n";
            saveData += $"{chkPD2TheYachtHeist.Checked}\n";
            saveData += $"{chkPD2TransportCrossroads.Checked}\n";
            saveData += $"{chkPD2TransportDowntown.Checked}\n";
            saveData += $"{chkPD2TransportHarbor.Checked}\n";
            saveData += $"{chkPD2TransportPark.Checked}\n";
            saveData += $"{chkPD2TransportTrainHeist.Checked}\n";
            saveData += $"{chkPD2TransportUnderpass.Checked}\n";
            saveData += $"{chkPD2UkrainianJob.Checked}\n";
            saveData += $"{chkPD2Undercover.Checked}\n";
            saveData += $"{chkPD2Vlad.Checked}\n";
            saveData += $"{chkPD2Watchdogs.Checked}\n";
            saveData += $"{chkPD2WhiteXmas.Checked}\n";
            saveData += $"{chkPD399Boxes.Checked}\n";
            saveData += $"{chkPD3Beckett.Checked}\n";
            saveData += $"{chkPD3BlaineKeegan.Checked}\n";
            saveData += $"{chkPD3BoysInBlue.Checked}\n";
            saveData += $"{chkPD3CookOff.Checked}\n";
            saveData += $"{chkPD3DiamondDistrict.Checked}\n";
            saveData += $"{chkPD3DirtyIce.Checked}\n";
            saveData += $"{chkPD3FearNGreed.Checked}\n";
            saveData += $"{chkPD3FirstWorldBank.Checked}\n";
            saveData += $"{chkPD3GoldNSharke.Checked}\n";
            saveData += $"{chkPD3HoustonBreakout.Checked}\n";
            saveData += $"{chkPD3Hybrid.Checked}\n";
            saveData += $"{chkPD3Locke.Checked}\n";
            saveData += $"{chkPD3Loud.Checked}\n";
            saveData += $"{chkPD3Mac.Checked}\n";
            saveData += $"{chkPD3NoRestForTheWicked.Checked}\n";
            saveData += $"{chkPD3RoadRage.Checked}\n";
            saveData += $"{chkPD3RockTheCradle.Checked}\n";
            saveData += $"{chkPD3Shade.Checked}\n";
            saveData += $"{chkPD3Shayu.Checked}\n";
            saveData += $"{chkPD3Stealth.Checked}\n";
            saveData += $"{chkPD3SyntaxError.Checked}\n";
            saveData += $"{chkPD3TheButcher.Checked}\n";
            saveData += $"{chkPD3TouchTheSky.Checked}\n";
            saveData += $"{chkPD3TurbidStation.Checked}\n";
            saveData += $"{chkPD3UnderTheSurphaze.Checked}\n";
            saveData += $"{chkPD3Vlad.Checked}";
            saveData += $"{chkPD3PartyPowder.Checked}";
            string fileName = "";
            using (FileNameSaver inputDialog = new FileNameSaver("Enter a name for the text file:"))
            {
                if (inputDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = inputDialog.InputText.Trim();

                    if (!string.IsNullOrWhiteSpace(fileName))
                    {
                        string fullPath = Path.Combine(expectedFolderPath, fileName + ".txt");
                        File.WriteAllText(fullPath,saveData);
                        MessageBox.Show($"File saved", "Success");
                    }
                    else
                    {
                        MessageBox.Show("Filename cannot be empty.");
                    }
                }
            }
        }
        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            string homeDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string expectedFolder = "PDRHS Prefrences Files";
            string expectedFolderPath = Path.Combine(homeDirectory, expectedFolder);
            string[] content = { };
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "select a file",
                Filter = "Text Document (*.txt)|*.txt",
                InitialDirectory = expectedFolderPath
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;
                content = File.ReadAllLines(selectedFilePath);
            }
            try
            {
                numRowsMethod = int.Parse(content[0]);
                numRowsCon = int.Parse(content[1]);
                numRowsHeist = int.Parse(content[2]);
                sortMethod = int.Parse(content[3]);
                theme = int.Parse(content[4]);
                chkPDTHCounterfeit.Checked = bool.Parse(content[5]);
                chkPDTHDiamondHeist.Checked = bool.Parse(content[6]);
                chkPDTHFirstWorldBank.Checked = bool.Parse(content[7]);
                chkPDTHGreenBridge.Checked = bool.Parse(content[8]);
                chkPDTHHeatStreet.Checked = bool.Parse(content[9]);
                chkPDTHNoMercy.Checked = bool.Parse(content[10]);
                chkPDTHPanicRoom.Checked = bool.Parse(content[11]);
                chkPDTHSlaughterhouse.Checked = bool.Parse(content[12]);
                chkPDTHUndercover.Checked = bool.Parse(content[13]);
                chkPD2Aftershock.Checked = bool.Parse(content[14]);
                chkPD2AlaskanDeal.Checked = bool.Parse(content[15]);
                chkPD2ArtGallery.Checked = bool.Parse(content[16]);
                chkPD2Bain.Checked = bool.Parse(content[17]);
                chkPD2BankHeistCash.Checked = bool.Parse(content[18]);
                chkPD2BankHeistDeposit.Checked = bool.Parse(content[19]);
                chkPD2BankHeistGold.Checked = bool.Parse(content[20]);
                chkPD2BankHeistRandom.Checked = bool.Parse(content[21]);
                chkPD2BeneathTheMountain.Checked = bool.Parse(content[22]);
                chkPD2BigOil.Checked = bool.Parse(content[23]);
                chkPD2BirthOfSky.Checked = bool.Parse(content[24]);
                chkPD2BlackCat.Checked = bool.Parse(content[25]);
                chkPD2BlaineKeegan.Checked = bool.Parse(content[26]);
                chkPD2BoilingPoint.Checked = bool.Parse(content[27]);
                chkPD2BorderCrossing.Checked = bool.Parse(content[28]);
                chkPD2BorderCrystals.Checked = bool.Parse(content[29]);
                chkPD2BreakfastInTijuana.Checked = bool.Parse(content[30]);
                chkPD2BreakinFeds.Checked = bool.Parse(content[31]);
                chkPD2Brooklyn1010.Checked = bool.Parse(content[32]);
                chkPD2BrooklynBank.Checked = bool.Parse(content[33]);
                chkPD2BulucsMansion.Checked = bool.Parse(content[34]);
                chkPD2CarShop.Checked = bool.Parse(content[35]);
                chkPD2Classic.Checked = bool.Parse(content[36]);
                chkPD2CookOff.Checked = bool.Parse(content[37]);
                chkPD2Counterfeit.Checked = bool.Parse(content[38]);
                chkPD2CrudeAwakening.Checked = bool.Parse(content[39]);
                chkPD2CursedKillRoom.Checked = bool.Parse(content[40]);
                chkPD2DiamondHeist.Checked = bool.Parse(content[41]);
                chkPD2DiamondStore.Checked = bool.Parse(content[42]);
                chkPD2DragonHeist.Checked = bool.Parse(content[43]);
                chkPD2ElectionDay.Checked = bool.Parse(content[44]);
                chkPD2Event.Checked = bool.Parse(content[45]);
                chkPD2Firestarter.Checked = bool.Parse(content[46]);
                chkPD2FirstWorldBank.Checked = bool.Parse(content[47]);
                chkPD2FourStores.Checked = bool.Parse(content[48]);
                chkPD2FramingFrame.Checked = bool.Parse(content[49]);
                chkPD2GemmaMCShay.Checked = bool.Parse(content[50]);
                chkPD2GoatSimulator.Checked = bool.Parse(content[51]);
                chkPD2GOBank.Checked = bool.Parse(content[52]);
                chkPD2GoldenGrinCasino.Checked = bool.Parse(content[53]);
                chkPD2GreenBridge.Checked = bool.Parse(content[54]);
                chkPD2HeatStreet.Checked = bool.Parse(content[55]);
                chkPD2Hector.Checked = bool.Parse(content[56]);
                chkPD2HellsIsland.Checked = bool.Parse(content[57]);
                chkPD2HenrysRock.Checked = bool.Parse(content[58]);
                chkPD2HostileTakeover.Checked = bool.Parse(content[59]);
                chkPD2HotlineMiami.Checked = bool.Parse(content[60]);
                chkPD2Hoxton.Checked = bool.Parse(content[61]);
                chkPD2HoxtonBreakout.Checked = bool.Parse(content[62]);
                chkPD2HoxtonRevenge.Checked = bool.Parse(content[63]);
                chkPD2Hybrid.Checked = bool.Parse(content[64]);
                chkPD2JewelryStore.Checked = bool.Parse(content[65]);
                chkPD2Jimmy.Checked = bool.Parse(content[66]);
                chkPD2JiuFeng.Checked = bool.Parse(content[67]);
                chkPD2LabRats.Checked = bool.Parse(content[68]);
                chkPD2Locke.Checked = bool.Parse(content[69]);
                chkPD2LostInTransit.Checked = bool.Parse(content[70]);
                chkPD2Loud.Checked = bool.Parse(content[71]);
                chkPD2Mallcrasher.Checked = bool.Parse(content[72]);
                chkPD2Meltdown.Checked = bool.Parse(content[73]);
                chkPD2MidlandRanch.Checked = bool.Parse(content[74]);
                chkPD2MountainMaster.Checked = bool.Parse(content[75]);
                chkPD2MurkyStation.Checked = bool.Parse(content[76]);
                chkPD2Nightclub.Checked = bool.Parse(content[77]);
                chkPD2NoMercy.Checked = bool.Parse(content[78]);
                chkPD2PanicRoom.Checked = bool.Parse(content[79]);
                chkPD2PrisonNightmare.Checked = bool.Parse(content[80]);
                chkPD2Rats.Checked = bool.Parse(content[81]);
                chkPD2ReservoirDogsHeist.Checked = bool.Parse(content[82]);
                chkPD2SafeHouseNightmare.Checked = bool.Parse(content[83]);
                chkPD2SafeHouseRaid.Checked = bool.Parse(content[84]);
                chkPD2SanMartinBank.Checked = bool.Parse(content[85]);
                chkPD2SantasWorkshop.Checked = bool.Parse(content[86]);
                chkPD2ScarfaceMansion.Checked = bool.Parse(content[87]);
                chkPD2ShacklethorneAuction.Checked = bool.Parse(content[88]);
                chkPD2ShadowRaid.Checked = bool.Parse(content[89]);
                chkPD2Shayu.Checked = bool.Parse(content[90]);
                chkPD2Slaughterhouse.Checked = bool.Parse(content[91]);
                chkPD2StealingXmas.Checked = bool.Parse(content[92]);
                chkPD2Stealth.Checked = bool.Parse(content[93]);
                chkPD2TheAlessoHeist.Checked = bool.Parse(content[94]);
                chkPD2TheBigBank.Checked = bool.Parse(content[95]);
                chkPD2TheBikerHeist.Checked = bool.Parse(content[96]);
                chkPD2TheBombDockyard.Checked = bool.Parse(content[97]);
                chkPD2TheBombForest.Checked = bool.Parse(content[98]);
                chkPD2TheButcher.Checked = bool.Parse(content[99]);
                chkPD2TheContinental.Checked = bool.Parse(content[100]);
                chkPD2TheDentist.Checked = bool.Parse(content[101]);
                chkPD2TheDiamond.Checked = bool.Parse(content[102]);
                chkPD2TheElephant.Checked = bool.Parse(content[103]);
                chkPD2TheUkrainianPrisoner.Checked = bool.Parse(content[104]);
                chkPD2TheWhiteHouse.Checked = bool.Parse(content[105]);
                chkPD2TheYachtHeist.Checked = bool.Parse(content[106]);
                chkPD2TransportCrossroads.Checked = bool.Parse(content[107]);
                chkPD2TransportDowntown.Checked = bool.Parse(content[108]);
                chkPD2TransportHarbor.Checked = bool.Parse(content[109]);
                chkPD2TransportPark.Checked = bool.Parse(content[110]);
                chkPD2TransportTrainHeist.Checked = bool.Parse(content[111]);
                chkPD2TransportUnderpass.Checked = bool.Parse(content[112]);
                chkPD2UkrainianJob.Checked = bool.Parse(content[113]);
                chkPD2Undercover.Checked = bool.Parse(content[114]);
                chkPD2Vlad.Checked = bool.Parse(content[115]);
                chkPD2Watchdogs.Checked = bool.Parse(content[116]);
                chkPD2WhiteXmas.Checked = bool.Parse(content[117]);
                chkPD399Boxes.Checked = bool.Parse(content[118]);
                chkPD3Beckett.Checked = bool.Parse(content[119]);
                chkPD3BlaineKeegan.Checked = bool.Parse(content[120]);
                chkPD3BoysInBlue.Checked = bool.Parse(content[121]);
                chkPD3CookOff.Checked = bool.Parse(content[122]);
                chkPD3DiamondDistrict.Checked = bool.Parse(content[123]);
                chkPD3DirtyIce.Checked = bool.Parse(content[124]);
                chkPD3FearNGreed.Checked = bool.Parse(content[125]);
                chkPD3FirstWorldBank.Checked = bool.Parse(content[126]);
                chkPD3GoldNSharke.Checked = bool.Parse(content[127]);
                chkPD3HoustonBreakout.Checked = bool.Parse(content[128]);
                chkPD3Hybrid.Checked = bool.Parse(content[129]);
                chkPD3Locke.Checked = bool.Parse(content[130]);
                chkPD3Loud.Checked = bool.Parse(content[131]);
                chkPD3Mac.Checked = bool.Parse(content[132]);
                chkPD3NoRestForTheWicked.Checked = bool.Parse(content[133]);
                chkPD3RoadRage.Checked = bool.Parse(content[134]);
                chkPD3RockTheCradle.Checked = bool.Parse(content[135]);
                chkPD3Shade.Checked = bool.Parse(content[136]);
                chkPD3Shayu.Checked = bool.Parse(content[137]);
                chkPD3Stealth.Checked = bool.Parse(content[138]);
                chkPD3SyntaxError.Checked = bool.Parse(content[139]);
                chkPD3TheButcher.Checked = bool.Parse(content[140]);
                chkPD3TouchTheSky.Checked = bool.Parse(content[141]);
                chkPD3TurbidStation.Checked = bool.Parse(content[142]);
                chkPD3UnderTheSurphaze.Checked = bool.Parse(content[143]);
                chkPD3Vlad.Checked = bool.Parse(content[144]);
                chkPD3PartyPowder.Checked = bool.Parse(content[145]);
                Cancel();
                Theme();
                MessageBox.Show($"File loaded successfully", "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "Invalid File");
            }
        }
    }
}
